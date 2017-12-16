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
        public Point point ;
        public string[] konumlar;
        
        
        public Tweet(string id, string hastag)
        {
            this.id = id;
            this.hastag = hastag;
        }
        
        public Point KonumOlustur(Point[] noktalar)
        {
            return new Point();
        }

        public string[] KonumParset(string konumString)
        {
            char[] patters = { '/', ',', '\n',';',' '};

            konumlar = konumString.Split(patters);
            return konumlar;
        }
    }
}
