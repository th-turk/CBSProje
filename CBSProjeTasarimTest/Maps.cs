using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapInfo;
using System.Runtime.InteropServices;
using System.IO;

namespace CBSProjeTasarimTest
{
    public partial class Maps : Form
    {
        string path = Path.GetDirectoryName(
                         Path.GetDirectoryName(
                             Directory.GetCurrentDirectory()));
        public static MapInfoApplication mi;
        public static int counter = 0;

        public int layerSayisi = 2;
        public Maps()
        {
            InitializeComponent();
            simgeDurKuc.Visible = false;
            FormBorderStyle = FormBorderStyle.None;
            sliderHided=true;
            iconsSlider.Width = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sidePanel.Height = dunya.Height;
            dunya.BackColor = selected;
            sidePanel.Top = dunya.Top;
            

            fullSize.BackgroundImage = CBSProjeTasarimTest.Properties.Resources.switch_to_full_screen_button__1_;

            mi = new MapInfo.MapInfoApplication();
            int p = map.Handle.ToInt32();
            mi.Do("set next document parent " + p.ToString() + "style 1");
            mi.Do("set application window " + p.ToString());
            mi.Do("run application \"" + "d:/haritalar2.WOR" + "\"");


            if (!tags.Contains(WorldTrends.Instance))
            {
                tags.Controls.Add(WorldTrends.Instance);
                WorldTrends.Instance.Dock = DockStyle.Fill;
                WorldTrends.Instance.BringToFront();
            }
            else WorldTrends.Instance.BringToFront();
            
        }



        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

       
        private void fullSize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                TopMost = true;
                fullSize.BackgroundImage = null;
                fullSize.BackgroundImage = CBSProjeTasarimTest.Properties.Resources.full_screen_exit;
            }
            else if(WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                TopMost = false;
                fullSize.BackgroundImage = null;
                fullSize.BackgroundImage = CBSProjeTasarimTest.Properties.Resources.switch_to_full_screen_button__1_;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }

        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (mi != null)
            {
                // The form has been resized. 
                if (mi.Eval("WindowID(0)") != "")
                {
                    // Update the map to match the current size of the panel. 
                    MoveWindow((System.IntPtr)long.Parse(mi.Eval("WindowInfo(FrontWindow(),12)")), 0, 0, this.map.Width, this.map.Height, false);
                }

            }

            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(500);
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon.Visible = false;
            }
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void topBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void topBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void topBar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        Color unselected = Color.FromArgb(113, 208, 240);
        Color selected = Color.FromArgb(189, 199, 216);
        private void dunya_Click(object sender, EventArgs e)
        {
            sidePanel.Height = dunya.Height;
            dunya.BackColor = selected;
            turkiye.BackColor = unselected;
            stat.BackColor = unselected;
            sidePanel.Top = dunya.Top;

            containerMap.Visible = true;
            sideBarReset();

            
            mi.Do("Set Map  Zoom Entire Layer "+(layerSayisi ));
            mi.Do("Set Map  Layer "+ (layerSayisi - 1) + " Editable On");
            mi.Do("Set Map  Layer "+ (layerSayisi - 1) + " Editable On");

           
            if (!tags.Contains(WorldTrends.Instance))
            {
                tags.Controls.Add(WorldTrends.Instance);
                WorldTrends.Instance.Dock = DockStyle.Fill;
                WorldTrends.Instance.BringToFront();
            }
            else WorldTrends.Instance.BringToFront();
            
        }

        private void turkiye_Click(object sender, EventArgs e)
        {

            if (!tags.Contains(TurkeyTrends.Instance))
            {
                tags.Controls.Add(TurkeyTrends.Instance);
                TurkeyTrends.Instance.Dock = DockStyle.Fill;
                TurkeyTrends.Instance.BringToFront();
            }
            else TurkeyTrends.Instance.BringToFront();

            sidePanel.Height = turkiye.Height;
            turkiye.BackColor = selected;
            stat.BackColor = unselected;
            dunya.BackColor = unselected;
            sidePanel.Top = turkiye.Top;

            containerMap.Visible = true;
            sideBarReset();
            
            mi.Do("Set Map  Zoom Entire Layer "+(layerSayisi-1));
            mi.Do("Set Map  Layer "+ (layerSayisi ) + " Editable On");
            mi.Do("Set Map  Layer "+ (layerSayisi ) + " Editable On");
            
        }

        private void stat_Click(object sender, EventArgs e)
        {
            sidePanel.Height = stat.Height;
            stat.BackColor = selected;
            turkiye.BackColor = unselected;
            dunya.BackColor = unselected;
            sidePanel.Top = stat.Top;

            containerMap.Visible = false;
            panel2.Visible = false;
            
        }
        private void sideBarReset()
        {
            panel2.Visible = true;
            sliderButton.Text = "<<";
            iconsSlider.Width = 0;
            sliderHided = true;
        }

        private void simgeDurKuc_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        public int sliderSize;
        public bool sliderHided;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (sliderHided)
            {
                iconsSlider.Width += 27;
                if (iconsSlider.Width >= 108)
                {
                    timer.Stop();
                    sliderHided = false;
                    this.Refresh();
                }
            }
            else
            {
                iconsSlider.Width -= 27;
                if (iconsSlider.Width <= 0)
                {
                    timer.Stop();
                    sliderHided = true;
                    this.Refresh();
                }
            }
           
        }

        private void sliderButton_Click(object sender, EventArgs e)
        {
            if (sliderHided) sliderButton.Text = ">>";
            else sliderButton.Text = "<<";
            timer.Start();
        }

        //zoom-in
        private void button6_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command  1705");
        }

        //zoom-out
        private void button9_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command  1706");
        }

        //grabber
        private void button4_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command  1702");
        }

        //info
        private void button7_Click(object sender, EventArgs e)
        {
            mi.RunMenuCommand(1707);
            //mi.Do("run menu command 1707");
        }

        //cancel all selects
        private void button5_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command  304");
        }

        //select
        private void button8_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command  1701");
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(154, 164, 171);
            string tooltipText="";
            switch (((Button)sender).Name)
            {
                case "button6":
                    tooltipText = "Zoom++";
                    break;
                case "button9":
                    tooltipText = "Zoom--";
                    break;
                case "button5":
                    tooltipText = "Seçili Alanları Kaldır";
                    break;
                case "button4":
                    tooltipText = "Harita Tut-Sürükle";
                    break;
                case "button8":
                    tooltipText = "Alan Seç";
                    break;
                case "button7":
                    tooltipText = "Bilgi";
                    break;
            }

            toolTip1.Show(tooltipText, ((Button)sender), ((Button)sender).Width - 1, ((Button)sender).Height - 1,5000);

        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Transparent;
            toolTip1.RemoveAll();
        }
        
        //canlı tweet gösterme tablosu 
        private void tabloOlustur()
        {
            if (layerSayisi == 2) layerSayisi++;
            try
            {
                if (!File.Exists(path + "\\Resources\\CANLI_TWEET.TAB"))
                {
                    mi.Do("create table CANLI_TWEET(x Float,y Float ,id Char(100), hastag Char(100), user Char(100), konum Char(100), tarih Char(100)) file \"" + path + "\\Resources\\CANLI_TWEET\"  type native");
                    mi.Do("open table \"" + path + "\\Resources\\CANLI_TWEET.TAB\"");
                    mi.Do("create Map for  CANLI_TWEET");
                    mi.Do("add map layer  CANLI_TWEET");
                }
                else
                {

                    if (Int32.Parse(mi.Eval("numtables()")) < 1)
                    {
                        MessageBox.Show("İller Tablosu Yok");
                    }
                    else
                    {
                        for (int i = 0; i < Int32.Parse(mi.Eval("numtables()")); i++)
                        {
                            Console.WriteLine(path);
                            if (!mi.Eval("tableinfo(" + i + ",1)").Equals("CANLI_TWEET"))
                            {
                                Console.WriteLine(path + "///1");
                                mi.Do("open table \"" + path + "\\Resources\\CANLI_TWEET.TAB\"");
                                if (!mi.Eval("layerinfo(frontWindow(),1,1)").Equals("CANLI_TWEET"))
                                {
                                    Console.WriteLine(path + "///2");
                                    mi.Do("add map layer  CANLI_TWEET");
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                this.Close();
            }
        }

        
        public void HaritayaTweetKoy(double x,double y,string kus)
        {
            if (counter == 0)
            {
                tabloOlustur();
                Maps.mi.Do("dim p as object");
                
            }
            Maps.counter++;
            Tweet tweet = new Tweet("1"+counter,"türkiye"); 
            tweet.location = "kus";
            tweet.user = "tahaturk";
            tweet.date = "11/22/2017";
            Maps.mi.Do("Create point  into variable p (" + x + "," + y + ") Symbol MakeCustomSymbol (\"TRUC-64.BMP\",0,12,0)");
            Maps.mi.Do("insert into CANLI_TWEET(obj,id,hastag,user,konum,tarih) values (p,\"" + tweet.id + "\",\"" + tweet.hastag + "\",\"" + tweet.user + "\",\"" + tweet.location + "\",\"" + tweet.date + "\")");
            Maps.mi.Do("Commit Table CANLI_TWEET");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] loc= { 41.27694, 39.90861 };
            HaritayaTweetKoy(loc[0], loc[1],"blue");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tweet t = new Tweet("a","a");

            t.MatchLocation();
        }
    }
    
}
