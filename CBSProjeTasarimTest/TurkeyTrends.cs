using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseSession;

namespace CBSProjeTasarimTest
{
    public partial class TurkeyTrends : UserControl
    {
        public TurkeyTrends()
        {
            InitializeComponent();
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
            for (int i = 0; i < 1; i++)
            {
                string trendUrl = twitter.GenerateHashtagString(trends[i]);
                List<Tweet> tweetler = twitter.GetTweetsByHashtag(trendUrl, trends[i]);
                twitter.FindUserLocation(tweetler);

                Label tag = new Label();
                panel1.Controls.Add(tag);
                tag.Top = labelDistance;
                tag.Left = 15;
                tag.AutoSize = true;
                tag.Text = trends[i];
                tag.Font = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold);
                tag.ForeColor = Color.Green;
                tag.Visible = true;
                labelDistance += 30;

                tag.Click += new EventHandler(tag_Click);
                tag.MouseHover += new EventHandler(tag_MouseHover);
            }
        }

        int labelDistance = 40;

        public void GetTrends(List<ResultsObj> allHashtags)
        {
            labelDistance = 0;            
            Label title = new Label();
            panel1.Controls.Add(title);
            title.AutoSize = true;
            title.Text = "Bütün Hashtagler";
            title.Location = new Point(30, 0);
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
            MessageBox.Show(hashtag);
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
