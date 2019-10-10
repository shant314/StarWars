using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Models.ApiResponse
{
    public class ApiResponse_Starship
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Starship_Class { get; set; }
        public string Manufacturer { get; set; }
        public string Cost_In_Credits { get; set; }
        public string Length { get; set; }
        public string Crew { get; set; }
        public string Passengers{ get; set; }
        public string Max_Atmosphering_Speed { get; set; }
        public string Hyperdrive_Rating { get; set; }
        public string Mglt { get; set; }
        public string Cargo_Capacity { get; set; }
        public string Consumables { get; set; }
        public string[] Films { get; set; }
        public string[] Pilots { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        //public DateTime Destruct { get; set; }

    }
}

/* model Desciption

    * Name string -- The name of this starship. The common name, such as "Death Star".
    * Model string -- The model or official name of this starship. Such as "T-65 X-wing" or "DS-1 Orbital Battle Station".
    * Starship_Class string -- The class of this starship, such as "Starfighter" or "Deep Space Mobile Battlestation"
    * Manufacturer string -- The manufacturer of this starship. Comma separated if more than one.
    * Cost_In_Credits string -- The cost of this starship new, in galactic credits.
    * length string -- The length of this starship in meters.
    * Crew string -- The number of personnel needed to run or pilot this starship.
    * Passengers string -- The number of non-essential people this starship can transport.
    * Max_Atmosphering_Speed string -- The maximum speed of this starship in the atmosphere. "N/A" if this starship is incapable of atmospheric flight.
    * Hyperdrive_Rating string -- The class of this starships hyperdrive.
    * Mglt string -- The Maximum number of Megalights this starship can travel in a standard hour. A "Megalight" is a standard unit of distance and has never been defined before within the Star Wars universe. This figure is only really useful for measuring the difference in speed of starships. We can assume it is similar to AU, the distance between our Sun (Sol) and Earth.
    * Cargo_Capacity string -- The maximum number of kilograms that this starship can transport.
    * Consumables *string The maximum length of time that this starship can provide consumables for its entire crew without having to resupply.
    * Films array -- An array of Film URL Resources that this starship has appeared in.
    * Pilots array -- An array of People URL Resources that this starship has been piloted by.
    * Url string -- the hypermedia URL of this resource.
    * Created string -- the ISO 8601 date format of the time that this resource was created.
    * Edited string -- the ISO 8601 date format of the time that this resource was edited.

 */
