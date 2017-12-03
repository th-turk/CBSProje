﻿using System;
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
            FormBorderStyle = FormBorderStyle.None;
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
            mi.Do("run application \"" + "d:/ole1.WOR" + "\"");
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

        }

        private void turkiye_Click(object sender, EventArgs e)
        {
            sidePanel.Height = turkiye.Height;
            turkiye.BackColor = selected;
            stat.BackColor = unselected;
            dunya.BackColor = unselected;
            sidePanel.Top = turkiye.Top;
        }

        private void stat_Click(object sender, EventArgs e)
        {
            sidePanel.Height = stat.Height;
            stat.BackColor = selected;
            turkiye.BackColor = unselected;
            dunya.BackColor = unselected;
            sidePanel.Top = stat.Top;
        }

        private void simgeDurKuc_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Visible = false;
                       
        }
    }
}
