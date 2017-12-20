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
    public partial class DbResults : UserControl
    {
        
        public DbResults(List<ResultsObj> trendler)
        {
            InitializeComponent();
            GetTrends(trendler);
        }
        
        public void GetTrends(List<ResultsObj> trendler)
        {
            labelDistance = 0;
            Label title = new Label();
            panel1.Controls.Add(title);
            title.AutoSize = true;
            title.Text = "Hashtags";
            title.Location = new Point(30, 0);
            title.ForeColor = Color.Black;
            labelDistance += 40;
            
            
            for (int i = 0; i < trendler.Count; i++)
            {
                Label tag = new Label();
                panel1.Controls.Add(tag);
                tag.Top = labelDistance;
                tag.Left = 15;
                tag.AutoSize = true;
                tag.Text = trendler[i].ToString();
                tag.Font = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold);
                tag.ForeColor = Color.Red;
                tag.Visible = true;
                labelDistance += 30;

                tag.Click += new EventHandler(tag_Click);
            }
        }

        int labelDistance = 0;

        protected void tag_Click(object sender, EventArgs e)
        {
            Label temp = sender as Label;
            string hashtag = temp.Text;
            int index = hashtag.IndexOf('(');
            int index2 = hashtag.IndexOf(')');
            
            int sayi =Convert.ToInt32(hashtag.Substring(index+1, (index2 - index-1)));
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
    }
}
