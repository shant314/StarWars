using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StarWars
{
    /// <summary>
    /// API Gate access class.
    /// </summary>
    public class StarshipHelper
    {
        #region Parameters

        private ApiHelper _apiHelper { get; set; }

        #endregion Parameters


        #region Constructors

        /// <summary>
        /// Main constructor
        /// </summary>
        public StarshipHelper()
        {
            _apiHelper = new ApiHelper();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Request all available star ships from the Api
        /// </summary>
        public void Api_StarshipColler()
        {
            try
            {

                StarshipListModel starshipListModel = _apiHelper.GetStarshipList();
                StarshipListModel starshipListModelFail = null;

                Console.WriteLine("\nAvailable star ships count:" + starshipListModel.StarshipList.Count + "\n");

                var valid = false;
                double distance = 0;

                while (!valid)
                {
                    Console.WriteLine("Enter the requested input distance in mega lights (MGLT), or enter 0 as input to print the default distances for each star ship can reach with one supply");

                    var val = Console.ReadLine();
                    valid = !string.IsNullOrWhiteSpace(val) && val.All(c => c >= '0' && c <= '9');

                    if (valid)
                        double.TryParse(val, out distance);
                }

                Console.WriteLine("\n");

                foreach (var starship in starshipListModel.StarshipList)
                {
                    int countMglt = 0;
                    var validApiData = int.TryParse(starship.Mglt, out countMglt);

                    if (validApiData)
                    {
                        var countResupply = StarshipResupplyCalculater(starship, distance);
                        if (distance == 0)
                        {
                            Console.WriteLine("Name: " + starship.Name + ",\t Distance : " + countResupply + " MGLT");
                        }
                        else
                        {
                            Console.WriteLine("Name: " + starship.Name + ",\t Resupply : " + countResupply);
                        }
                    }
                    else
                    {
                        if (starshipListModelFail == null)
                        {
                            starshipListModelFail = new StarshipListModel();
                            starshipListModelFail.StarshipList = new System.Collections.Generic.List<Starship>();
                        }

                        starshipListModelFail.StarshipList.Add(starship);
                    }
                }
                if (starshipListModelFail != null)
                {
                    var countStarshipFail = starshipListModelFail.StarshipList.Count;

                    Console.WriteLine("\nFailed to calculate " + countStarshipFail + (countStarshipFail > 1 ? " star ship:" : " star ships:"));

                    for (int i = 0; i < countStarshipFail; i++)
                    {
                        Console.WriteLine("Name: " + starshipListModelFail.StarshipList[i].Name);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine("\n\nDo you want to try again?\nPres Enter to retry or Escape to exit application.\n");
            ConsoleKeyInfo consoleKeyInfo;
            consoleKeyInfo = Console.ReadKey();
            if (consoleKeyInfo.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            Api_StarshipColler();
        }

        /// <summary>
        /// calculate total amount of stops required to make the distance between the planets
        /// </summary>
        /// <param name="starship">requested star ship to process calculation</param>
        /// <param name="distance">Value zero or valid distance number in MGLT</param>
        /// <returns>if distance is greater than zero returns resupply count of the requested star ship, else returns the star ship total distance can travel with default supply</returns>
        public double StarshipResupplyCalculater(Starship starship, double distance)
        {

            int speed = 0;// MGLT/h
            double time = 0; //hour

            int.TryParse(starship.Mglt, out speed);

            var consumablesString = Regex.Match(starship.Consumables, @"\d+").Value;

            int lastIndex = starship.Consumables.LastIndexOf(consumablesString);
            string dateRangeName = starship.Consumables.Substring(lastIndex + 1, starship.Consumables.Length - 1);

            double tempSpeed = 0;
            double.TryParse(consumablesString, out tempSpeed);

            switch (dateRangeName)
            {
                case " day":
                case " days":
                    {
                        time = 24 * tempSpeed;
                    }
                    break;
                case " week":
                case " weeks":
                    {
                        time = (24 * 7) * tempSpeed; //1 week = 7 days/week = (7 days/week) × (24 hours/day) = 168 hours/week
                    }
                    break;
                case " month":
                case " months":
                    {
                        time = (365.25 * 24 / 12) * tempSpeed; //365.25 days X 24 hours / 12 months = 730.5 hours

                    }
                    break;
                case " year":
                case " years":
                    {
                        time = 365 * 24 * tempSpeed; //1 common year = 365 days = (365 days) × (24 hours/day) = 8760 hours
                    }
                    break;
            }

            //distance (MGLT)= speed (MGLT/h) * time (h)

            if (distance == 0)
            {
                distance = speed * time;
                return distance;
            }

            double sTime = distance / speed;
            double resupplyCout = sTime / time;

            return Math.Round(resupplyCout, MidpointRounding.ToEven);
        }

        #endregion Methods

    }
}
