using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatabaseSession
{
    public class District
    {
        public int id { get; set; }
        public int city_id { get; set; }
        public string districtName { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public double northeast_lat { get; set; }
        public double northeast_lng { get; set; }
        public double southwest_lat { get; set; }
        public double southwest_lng { get; set; }

        DataAccess db = new DataAccess();
        public string CityName
        {
            get
            {
                return $"{db.GetCityName(city_id)}";
            }
        }
    }
}
