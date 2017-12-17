using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBSProjeTasarimTest
{
    public partial class TurkeyTrends : UserControl
    {

        private static TurkeyTrends _instance;
        public static TurkeyTrends Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TurkeyTrends();
                return _instance;
            }
        }
        public TurkeyTrends()
        {
            InitializeComponent();
            //GetTrends("Türkiye");
        }
        
        public void GetTrends(string loc)
        {
            labelDistance = 0;
            Twitter twitter = new Twitter();
            List<string> trends = new List<string>();
            
            twitter.getTrends(loc, trends);

            Label title = new Label();
            panel1.Controls.Add(title);
            title.AutoSize = true;
            title.Text = loc + " Trendleri";
            title.Location = new Point(30, 0);
            title.ForeColor = Color.Black;
            labelDistance += 40;

            //
            // trends.ToArray().Length for i<1
            //
            for (int i = 0; i < trends.ToArray().Length; i++)
            {
                HashTagler(trends[i], i);

                string trendUrl = twitter.GenerateHashtagString(trends[i]);
                List<Tweet> tweetler = twitter.GetTweetsByHashtag(trendUrl, trends[i]);
                twitter.FindUserLocation(tweetler);
            }
                
           
            
        }

        int labelDistance = 40;
        //Hashtagler için Label oluşturma
        public Label HashTagler(string tagname, int i)
        {
            Random randonGen = new Random();
            Color[] randomColor = {Color.Red,Color.Pink,Color.Orange,
                                    Color.Turquoise,Color.Yellow,Color.Green,
                                        Color.Blue,Color.Gray,Color.DarkBlue,Color.Brown};
            //Color.FromArgb(randonGen.Next(255), randonGen.Next(255),
            //randonGen.Next(255));

            Label tag = new Label();
            panel1.Controls.Add(tag);
            tag.Top = labelDistance;
            tag.Left = 15;
            tag.AutoSize = true;
            tag.Name = randomColor[i].Name;
            tag.Text = tagname;
            tag.Font = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold);
            tag.ForeColor = randomColor[i];
            tag.Visible = true;
            labelDistance += 30;
            return tag;
        }
    }
}
