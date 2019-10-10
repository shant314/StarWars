using Common;
using StarWars.Models;
using StarWars.Models.ApiResponse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace StarWars
{
    /// <summary>
    /// API Gate access class.
    /// </summary>
    public class ApiHelper
    {

        #region Methods

        /// <summary>
        /// Main method to request data from API
        /// </summary>
        /// <typeparam name="T">Type of class to map the API JSON string with return result</typeparam>
        /// <param name="requestMethod">string to be combined with the API request URL for a resource</param>
        /// <returns>model mapped with passed T param Class type</returns>
        public T GetResponseFromSwapi<T>(string requestMethod = "")
        {
            try
            {
                Console.WriteLine("Processing API Request, please wait.");

                string requestUrl = Constant.SwapiMainUrl;
                requestUrl += requestMethod;

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUrl);

                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "GET";

                var webResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var stream = webResponse.GetResponseStream();

                if (stream == null)
                {
                    throw new NullReferenceException("response.GetResponseStream() is null");
                }
                using (var streamReader = new StreamReader(stream))
                {
                    string resultjson = streamReader.ReadToEnd();
                    var resp = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(resultjson);

                    return resp;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Request all star ships from the SWAPI
        /// </summary>
        /// <returns>model contains list of star ships</returns>
        public StarshipListModel GetStarshipList()
        {
            try
            {
                int countPage = 1;
                int countTotal = 0;

                StarshipListModel starshipListModel = new StarshipListModel();
                starshipListModel.StarshipList = new List<Starship>();

                do
                {
                    string requestMethod = Constant.StarshipGetAllTheResources;
                    if (countPage > 1)
                    {
                        requestMethod = Constant.StarshipGetAllTheResourcesPage;
                        requestMethod += countPage;
                    }
                    countPage++;

                    var apiResponse_StarshipsList = GetResponseFromSwapi<ApiResponse_Starships>(requestMethod);
                    if (apiResponse_StarshipsList == null)
                    {
                        throw new Exception("SWAPI is not reachable !\n");
                    }
                    else if (apiResponse_StarshipsList.Count == 0)
                    {
                        throw new Exception("SWAPI did not provide me with data !\n");
                    }

                    foreach (var item in apiResponse_StarshipsList.Results)
                    {
                        starshipListModel.StarshipList.Add(
                            new Starship
                            {
                                Name = item.Name,
                                Model = item.Model,
                                StarshipClass = item.Starship_Class,
                                Manufacturer = item.Manufacturer,
                                CostInCredits = item.Cost_In_Credits,
                                Crew = item.Crew,
                                Passengers = item.Passengers,
                                MaxAtmospheringSpeed = item.Max_Atmosphering_Speed,
                                HyperdriveRating = item.Hyperdrive_Rating,
                                Mglt = item.Mglt,
                                CargoCapacity = item.Cargo_Capacity,
                                Consumables = item.Consumables,
                                FilmList = item.Films,
                                PilotList = item.Pilots,
                                DateCreate = item.Created,
                                DateEdit = item.Edited,
                            });
                    }

                    if (countTotal > 0)
                        countTotal = countTotal - apiResponse_StarshipsList.Results.Count();
                    else
                        countTotal = apiResponse_StarshipsList.Count - apiResponse_StarshipsList.Results.Count();
                }
                while (countTotal > 0);

                return starshipListModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Methods

    }
}
