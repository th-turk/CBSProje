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

namespace CBSProjeTasarimTest
{
    
    public partial class Form1 : Form
    {
        public static MapInfoApplication mi;
        public Form1()
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

            //mi.Do("Set Map  Layer 2 Display Graphic");
            //mi.Do("Set Map  Layer 1 Display off");
            mi.Do("Set Map  Zoom Entire Layer 2");
            
        }

        private void turkiye_Click(object sender, EventArgs e)
        {
            
            sidePanel.Height = turkiye.Height;
            turkiye.BackColor = selected;
            stat.BackColor = unselected;
            dunya.BackColor = unselected;
            sidePanel.Top = turkiye.Top;

            containerMap.Visible = true;
            sideBarReset();

            //mi.Do("Set Map  Layer 2 Display off");
            //mi.Do("Set Map  Layer 1 Display Graphic");
            mi.Do("Set Map  Zoom Entire Layer 1");
           

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
                iconsSlider.Width += 22;
                if (iconsSlider.Width >= 110)
                {
                    timer.Stop();
                    sliderHided = false;
                    this.Refresh();
                }
            }
            else
            {
                iconsSlider.Width -= 22;
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
            mi.Do("run menu command 1707");
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

        
    }
}
