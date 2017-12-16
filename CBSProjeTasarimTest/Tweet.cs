using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CBSProjeTasarimTest
{
    public class Tweet
    {
        public string id;
        public string hastag;
        public string user = null;
        public string konum = null;
        public string tarih = null;
        
        
        public Tweet(string id, string hastag)
        {
            this.id = id;
            this.hastag = hastag;
        }
        
        public Point KonumOlustur(Point[] noktalar)
        {
            return new Point();
        }

        public string KonumParset(string fullKonum)
        {

            return "";
        }

        private void RunScript(double a, double b, double Ax, double Ay, double Bx, double By, double Cx, double Cy, double Az, double Bz, double Cz, ref object Point)
        {
            
        }
    }
}
