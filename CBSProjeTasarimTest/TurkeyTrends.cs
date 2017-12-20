using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DatabaseSession;

namespace CBSProjeTasarimTest
{
    public partial class TurkeyTrends : UserControl
    {
        int labelDistance = 40;

        public TurkeyTrends()
        {
            InitializeComponent();
        }
        
        //Live Tweets Scrape Start 
        public void GetTrends(string loc)
        {
            labelDistance = 0;
            Twitter twitter = new Twitter();
            List<string> trends = new List<string>();
            
            twitter.getTrends(loc, trends);

            Label title = new Label();
            panel1.Controls.Add(title);
            title.AutoSize = true;
            title.Text = loc + " Trends";
            title.Location = new Point(40, 0);
            title.ForeColor = Color.Black;
            labelDistance += 40;

            //
            // trends.ToArray().Length for i<1
            //
            for (int i = 0; i < trends.ToArray().Length; i++)
            {
                string trendUrl = twitter.GenerateHashtagString(trends[i]);
                List<Tweet> tweetler = twitter.GetTweetsByHashtag(trendUrl, trends[i]);
                twitter.FindUserLocation(tweetler);
                
            }
            DataAccess db = new DataAccess();
            List<ResultsObj> ro = db.GetTweetsInlast10MinHashtags();
            for (int i = 0; i < ro.ToArray().Length; i++)
            {
                Label tag = new Label();
                panel1.Controls.Add(tag);
                tag.Top = labelDistance;
                tag.Left = 15;
                tag.AutoSize = true;
                tag.Text = ro[i].ToString();
                tag.Font = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold);
                tag.ForeColor = Color.Green;
                tag.Visible = true;
                labelDistance += 30;
                tag.Click += new EventHandler(tag_Click);
                tag.MouseHover += new EventHandler(tag_MouseHover);
            }
            
        }
        
        //List Database Queries At Start
        public void GetTrends(List<ResultsObj> allHashtags)
        {
            labelDistance = 0;            
            Label title = new Label();
            panel1.Controls.Add(title);
            title.AutoSize = true;
            title.Text = "All Hashtags";
            title.Location = new Point(40, 0);
            title.ForeColor = Color.Black;
            labelDistance += 40;

            //
            // trends.ToArray().Length for i<1
            //
            for (int i = 0; i < allHashtags.ToArray().Length; i++)
            {
                Label tag = new Label();
                panel1.Controls.Add(tag);
                tag.Top = labelDistance;
                tag.Left = 15;
                tag.AutoSize = true;
                tag.Text= allHashtags[i].ToString();
                tag.Font = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold);
                tag.ForeColor = Color.DarkBlue;
                tag.Visible = true;
                labelDistance += 30;


                tag.Click += new EventHandler(tag_Click); 
                tag.MouseHover += new EventHandler(tag_MouseHover);
            }
        }
      
        protected void tag_Click(object sender, EventArgs e)
        {
            Label temp = sender as Label;
            string hashtag = temp.Text;
            int index = hashtag.IndexOf('(');
            int index2 = hashtag.IndexOf(')');

            int sayi = Convert.ToInt32(hashtag.Substring(index + 1, (index2 - index - 1)));
            hashtag = hashtag.Substring(0, index).Trim();
            DataAccess db = new DataAccess();
            List<TweetDB> tw = new List<TweetDB>();
            DbResults dbR = null;
            tw = db.GetTweetsByHastag(hashtag);
            if (tw.ToArray().Length == 0)
            {
                MessageBox.Show("Please Select Another Hashtag");
            }
            else
            {
                Maps.DeleteTweetTable();
                Maps.createLiveTweetsTable();
                List<ResultsObj> rdb = new List<ResultsObj>();
                ResultsObj rb = new ResultsObj { sayi = sayi, hastag = hashtag };
                rdb.Add(rb);
                dbR = new DbResults(rdb);
                Maps.PutTweetsOnMap(tw);
            }
            
        }

        protected void tag_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
