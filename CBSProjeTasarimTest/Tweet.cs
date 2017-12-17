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
        public double lon
        public string[] locations;
        
        
        public Tweet(string id, string hastag)
        {
            this.id = id;
            this.hastag = hastag;
        }
        
        public Point KonumOlustur(Point[] noktalar)
        {

            return new Point();
        }

        public void LocationParse(string locationStr)
        {
            char[] patters = { '/', ',', '\n',';',' '};
            locations = locationStr.Split(patters);

            foreach (var loc in locations)
            {
                MatchLocation
            }
        }

        public double[] GenerateLocationNearly(double x0, double y0, int radius)
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

        public void MatchLocation(string loc)
        {
            DataAccess db = new DataAccess();

            List<City> cities = db.GetCitys();

            foreach (var city in cities)
            {
                Console.WriteLine("City name :" + city.cityName.ToLower());
                Console.WriteLine("City lat :" + city.lat);
                Console.WriteLine("City lon :" + city.lon);
            }
        }
        
    }
}
