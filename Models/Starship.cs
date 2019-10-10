using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class Starship
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string StarshipClass { get; set; }
        public string Manufacturer { get; set; }
        public string CostInCredits { get; set; }
        public string Length { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }
        public string MaxAtmospheringSpeed { get; set; }
        public string HyperdriveRating { get; set; }
        public string Mglt { get; set; }
        public string CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public string[] FilmList { get; set; }
        public string[] PilotList { get; set; }
        public string Url { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateEdit { get; set; }
        //public DateTime DateDestruct { get; set; }
    }
}
/* model Desciption

    * Name string -- The name of this starship. The common name, such as "Death Star".
    * Model string -- The model or official name of this starship. Such as "T-65 X-wing" or "DS-1 Orbital Battle Station".
    * StarshipClass string -- The class of this starship, such as "Starfighter" or "Deep Space Mobile Battlestation"
    * Manufacturer string -- The manufacturer of this starship. Comma separated if more than one.
    * CostInCredits string -- The cost of this starship new, in galactic credits.
    * Length string -- The length of this starship in meters.
    * Crew string -- The number of personnel needed to run or pilot this starship.
    * Passengers string -- The number of non-essential people this starship can transport.
    * MaxAtmospheringSpeed string -- The maximum speed of this starship in the atmosphere. "N/A" if this starship is incapable of atmospheric flight.
    * HyperdriveRating string -- The class of this starships hyperdrive.
    * Mglt string -- The Maximum number of Megalights this starship can travel in a standard hour. A "Megalight" is a standard unit of distance and has never been defined before within the Star Wars universe. This figure is only really useful for measuring the difference in speed of starships. We can assume it is similar to AU, the distance between our Sun (Sol) and Earth.
    * CargoCapacity string -- The maximum number of kilograms that this starship can transport.
    * Consumables *string The maximum length of time that this starship can provide consumables for its entire crew without having to resupply.
    * FilmList array -- An array of Film URL Resources that this starship has appeared in.
    * PilotList array -- An array of People URL Resources that this starship has been piloted by.
    * url string -- the hypermedia URL of this resource.
    * DateCreate string -- the ISO 8601 date format of the time that this resource was created.
    * DateEdit string -- the ISO 8601 date format of the time that this resource was edited.

 */
