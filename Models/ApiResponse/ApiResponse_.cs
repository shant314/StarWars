using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Models.ApiResponse
{
    public class ApiResponse_
    {
        public string People { get; set; }
        public string Planets { get; set; }
        public string Films { get; set; }
        public string Species { get; set; }
        public string Vehicles { get; set; }
        public string Starships { get; set; }
    }
}

/* model Desciption

    * People string -- the hypermedia URL of People resource.
    * Planets string -- the hypermedia URL of Planets resource.
    * Films string -- the hypermedia URL of Films resource.
    * Species string -- the hypermedia URL of Species resource.
    * Vehicles string -- the hypermedia URL of Vehicles resource.
    * Starships string -- the hypermedia URL of Starships resource.

 */
