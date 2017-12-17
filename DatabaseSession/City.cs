using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSession
{
    public class City
    {
        public int id { get; set; }
        public string cityName { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public double northeast_lat { get; set; }
        public double northeast_lng { get; set; }
        public double southwest_lat { get; set; }
        public double southwest_lng { get; set; }

        public string FullInfo
        {
            get
            {
                return $"{cityName} ({lat},{lon})";
            }
        }
    }
}
