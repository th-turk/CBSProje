using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSession
{
    public class TweetDB
    {
        public string id { get; set; }
        public string hastag { get; set; }
        public string user { get; set; }
        public string location { get; set; }
        public string date { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        
    }
}
