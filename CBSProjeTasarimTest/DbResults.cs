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
                HashTagler(trendler[i].hastag, i);
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
