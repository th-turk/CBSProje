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
            trendleriAl("Türkiye");
        }


        public void trendleriAl(string loc)
        {
            labelAralik = 0;
            Twitter twitter = new Twitter();
            List<string> trendler = new List<string>();
            
            twitter.getTrends(loc, trendler);

            Label baslik = new Label();
            panel1.Controls.Add(baslik);
            baslik.AutoSize = true;
            baslik.Text = loc + " Trendleri";
            baslik.Location = new Point(30, 0);
            //baslik.Font = new Font("Myanmar Text", 12, FontStyle.Bold);
            baslik.ForeColor = Color.Black;
            labelAralik += 40;

            for (int i = 0; i < trendler.Count; i++)
            {
                HashTagler(trendler[i], i);
            }

            
        }

        int labelAralik = 40;
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
            tag.Top = labelAralik;
            tag.Left = 15;
            tag.AutoSize = true;
            tag.Name = randomColor[i].Name;
            tag.Text = tagname;
            tag.Font = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold);
            tag.ForeColor = randomColor[i];
            tag.Visible = true;
            labelAralik += 30;
            return tag;
        }
    }
}
