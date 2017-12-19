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
    public partial class Statistic : UserControl
    {
        DataAccess db = new DataAccess();
        public Statistic()
        {
            InitializeComponent();
            foreach (var series in this.chart1.Series)
            {
                series.Points.Clear();
            }
            hashtagStat.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hashtag = hashtagStat.Text.Trim();
            List<ResultsObj2> ro = db.GetChart1Value(hashtag);
            foreach (var series in this.chart1.Series)
            {
                series.Points.Clear();
            }

            foreach (var result in ro)
            {
                this.chart1.Series["Number"].BorderWidth = 20;
                this.chart1.Series["Number"].Points.AddXY(result.tweeted_location,result.sayi);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string timePeriod = null;
            if (comboBox1.SelectedItem != null)
                timePeriod = comboBox1.SelectedItem.ToString();
            List<ResultsObj> ro=null;
            if (timePeriod != null)
                ro = db.GetTrendTagsByTime(timePeriod);
            foreach (var series in this.chart2.Series)
            {
                series.Points.Clear();
            }

            foreach (var result in ro)
            {
                chart2.ChartAreas[0].AxisX.Interval = 1;
                this.chart2.Series["hashtag"].BorderWidth = 20;
                this.chart2.Series["hashtag"].Points.AddXY(result.hastag, result.sayi);
            }
        }


        private void hashtagStat_MouseClick(object sender, MouseEventArgs e)
        {
            hashtagStat.Text = "";
        }
    }
}
