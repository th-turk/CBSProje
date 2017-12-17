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
    public partial class WorldTrends : UserControl
    {
        private static WorldTrends _instance;
        public static WorldTrends Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WorldTrends();
                return _instance;
            }
        }
        public WorldTrends()
        {
            InitializeComponent();
            GetTrends("Dünya");
        }

        public void GetTrends(string loc)
        {
            labelDistance = 0;
            Twitter twitter = new Twitter();
            List<string> trendler = new List<string>();

            Label title = new Label();
            panel1.Controls.Add(title);
            title.AutoSize = true;
            title.Text = loc +" Trendleri";
            title.Location = new Point(30, 0);
            title.ForeColor = Color.Black;
            labelDistance += 40;

            twitter.getTrends(loc, trendler);
            
            for (int i = 0; i < trendler.Count; i++)
            {
                HashTagler(trendler[i], i);
            }
        }

        int labelDistance = 0;

        //Hashtagler için Label oluşturma
        public Label HashTagler(string tagname, int i)
        {
            Random randonGen = new Random();
            Color[] randomColor = {Color.Red,Color.Pink,Color.Orange,
                                    Color.Turquoise,Color.Yellow,Color.Green,
                                        Color.Blue,Color.Gray,Color.DarkBlue,Color.Brown};
            
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
