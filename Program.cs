using System;
using StarWars.Models;

namespace StarWars
{
    /// <summary>
    /// Main class of the project
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main entry point of the program
        /// </summary>
        /// <param name="args">Command line args</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Star Wars SWAPI (The Star Wars API) \n\tC# .Net Console application\n\nThis application will print all the available Star Wars star ships collection information based on your inputs.\n");

            StarshipHelper starshipHelper = new StarshipHelper();
            starshipHelper.Api_StarshipColler();
        }
    }
}
