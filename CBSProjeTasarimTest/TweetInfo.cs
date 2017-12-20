using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBSProjeTasarimTest
{
    public partial class TweetInfo : Form
    {
       
        public TweetInfo()
        {
            InitializeComponent();
        }

        public void fill_form()
        {
            label7.Text = Maps.mi.Eval("CANLI_TWEET.id");
            label8.Text = Maps.mi.Eval("CANLI_TWEET.hastag");
            label9.Text = Maps.mi.Eval("CANLI_TWEET.user");
            label10.Text = Maps.mi.Eval("CANLI_TWEET.konum");
            label11.Text = Maps.mi.Eval("CANLI_TWEET.tarih");

           
            WindowState = FormWindowState.Normal;
            TopMost = false;
            this.ShowDialog();
            this.BringToFront();
        }

    }
}
