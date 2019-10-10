using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Models.ApiResponse
{
    public class ApiResponse_Starships
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public ApiResponse_Starship[] Results { get; set; }
    }
}

/* model Desciption

    * Count int -- The count of all star ships the API can provide".
    * Next string -- The URL structure to request next page".
    * Previous string -- The URL structure to request previous page".
    * Results string -- The Array of collected star ships".

 */
