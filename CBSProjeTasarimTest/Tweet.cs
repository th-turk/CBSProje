using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DatabaseSession;

namespace CBSProjeTasarimTest
{
    public class Tweet
    {
        public string id;
        public string hastag;
        public string user = null;
        public string location = null;
        public string date = null;
        public double lat;
        public double lon;
        public string[] locations;
        
        public Tweet(string id, string hastag)
        {
            this.id = id;
            this.hastag = hastag;
        }
        
        //parse location by dedicated characters 
        public void LocationParse(string locationStr)
        {
            char[] patters = { '/', ',', '\n',';',' ','\\','.'};
            locations = locationStr.Split(patters);

            foreach (var loc in locations)
            {
                MatchLocation(loc);
            }
        }
        
        //find if locations include any of real location in database
        public void MatchLocation(string loc)
        {
            DataAccess db = new DataAccess();

            List<City> cities = db.GetCities();
            List<District> districts = db.GetDistricts();

            // if location not setted then  look for city 
            if(location == null)
            {
                foreach (var city in cities)
                {
                    LocationSimilarity(loc, city);
                    if (location != null)
                        break;
                }
            }

            if (location == null)
            {
                foreach (var district in districts)
                {
                    LocationSimilarity(loc, district);
                    if (location != null)
                        break;
                }
            }

        }

        // calculate ratio of founded string with matched city location
        public void LocationSimilarity(string foundedLocation, City c)
        {
            foundedLocation = foundedLocation.ToLower();
            string realLocation = c.cityName.ToLower();
            

            if (realLocation.Length == foundedLocation.Length)
            {
                double rate = 0;
                for (int i = 0; i < realLocation.Length; i++)
                {
                    if (realLocation[i] == foundedLocation[i])
                        rate++;
                    else rate--;
                }

                rate = rate / realLocation.Length*100;
               
                if (rate > 19)
                {
                    location = c.cityName;
                    double[] locKord = GenerateLocationNearly(c.lat, c.lon);
                    lat = locKord[0];
                    lon = locKord[1];
                }
            }
                
        }

        // calculate ratio of founded string with matched District location
        public void LocationSimilarity(string foundedLocation, District d)
        {
            foundedLocation = foundedLocation.ToLower();
            string realLocation = d.districtName.ToLower();
           


            if (realLocation.Length == foundedLocation.Length)
            {
                double rate = 0;
                for (int i = 0; i < realLocation.Length; i++)
                {
                    if (realLocation[i] == foundedLocation[i])
                        rate++;
                    else rate--;
                }

                rate = rate / realLocation.Length*100;

                if (rate > 19)
                {
                    location = d.districtName + "(" + d.city_id + ")";
                    double[] locKord = GenerateLocationNearly(d.lat, d.lon, 10000);
                    lat = locKord[0];
                    lon = locKord[1];
                }
            }
            
        }

        //generate a location which is in 40000 meters radious an circle with given lat and  lon
        public double[] GenerateLocationNearly(double x0, double y0, int radius = 40000)
        {
            Random random = new Random();

            // Convert radius from meters to degrees
            double radiusInDegrees = radius / 111000f;

            double u = random.NextDouble();
            double v = random.NextDouble();
            double w = radiusInDegrees * Math.Sqrt(u);
            double t = 2 * Math.PI * v;
            double x = w * Math.Cos(t);
            double y = w * Math.Sin(t);

            // Adjust the x-coordinate for the shrinking of the east-west distances
            double y0Radians = (Math.PI / 180) * y0;
            double new_x = x / Math.Cos(y0Radians);

            double foundLongitude = Math.Round((new_x + x0), 5);
            double foundLatitude = Math.Round((y + y0), 5);

            //MessageBox.Show("Longitude: " + foundLongitude + "  Latitude: " + foundLatitude);
            double[] loc = { foundLongitude, foundLatitude };
            return loc;
        }

    }
}
