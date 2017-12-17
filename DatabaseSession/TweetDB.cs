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
        public string tweeted_user { get; set; }
        public string tweeted_location { get; set; }
        public string tweeted_date { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        
    }
}
