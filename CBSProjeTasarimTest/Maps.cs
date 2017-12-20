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
using DatabaseSession;
using System.Diagnostics;

namespace CBSProjeTasarimTest
{
    public partial class Maps : Form
    {
        public static string path = Path.GetDirectoryName(
                         Path.GetDirectoryName(
                             Directory.GetCurrentDirectory()));
        public static MapInfoApplication mi;
        Callback callb;
        public TweetInfo f2 = new TweetInfo();

        public static int counter = 0;

        public static int layerSayisi = 2;
        
        DataAccess db = new DataAccess();

        public Maps()
        {
            InitializeComponent();
            callb = new Callback(this);
            simgeDurKuc.Visible = false;
            FormBorderStyle = FormBorderStyle.None;
            sliderHided=true;
            iconsSlider.Width = 0;

            DeleteTweetTable();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sidePanel.Height = turkey.Height;
            turkey.BackColor = selected;
            sidePanel.Top = turkey.Top;

            searchPanel.Visible = true;

            fullSize.BackgroundImage = CBSProjeTasarimTest.Properties.Resources.switch_to_full_screen_button__1_;

            //to load all Depended tables
            try
            {
                mi = new MapInfo.MapInfoApplication();
                int p = map.Handle.ToInt32();
                mi.Do("set next document parent " + p.ToString() + "style 1");
                mi.Do("set application window " + p.ToString());
                mi.Do("run application \"" + path + "\\Resources\\Databases\\haritalar2.WOR" + "\"");

                mi.Do("Set Map  Zoom Entire Layer " + (layerSayisi - 1));
                mi.Do("Set Map  Layer " + (layerSayisi) + " Editable On");
                mi.Do("Set Map  Layer " + (layerSayisi) + " Editable On");


                mi.SetCallback(callb);

                mi.Do("create buttonpad \"a\" as toolbutton calling OLE \"info\" id 2001");


                tableProsses();
                //Display all Hashtags
                getAllHashtags();
                
            }
            catch (Exception)
            {
                string message = "Are You Sure to Close App?";
                string caption = "Application Shut Down";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    CloseMapInfo();
                    Form.ActiveForm.Close();
                }
                else
                {
                    Form1_Load(sender, e);
                }
            }
            
        }

        
        private void close_Click(object sender, EventArgs e)
        {

            CloseMapInfo();
            this.Close();
            Application.Exit();

        }

        //Close all MapInfo exe after close  the App
        public void CloseMapInfo()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                if (p.ProcessName.StartsWith("MapInfo"))
                {
                    p.Kill();
                }
            }
        }


        //
        //App Size Settings
        //
        //Set Full Size Of screen
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
        //exit from full screen
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


        //
        //New UI Change Position Settings
        //
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



        //MapInfo Tool Button Panel Open And Close 
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
        
        //
        //MapInfo Tools Window Settings
        //
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
            mi.Do("run menu command id 2001");
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
        //ToolTip show
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
        //ToolTip hide
        private void button6_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Transparent;
            toolTip1.RemoveAll();
        }
   

        Color unselected = Color.FromArgb(113, 208, 240);
        Color selected = Color.FromArgb(189, 199, 216);
        //To Get All Tweets In database 
        private void turkey_Click(object sender, EventArgs e)
        {
            sidePanel.Height = turkey.Height;
            turkey.BackColor = selected;
            turkeyLive.BackColor = unselected;
            stat.BackColor = unselected;
            sidePanel.Top = turkey.Top;

            searchPanel.Visible = true;
            map.Visible = true;
            tags.Visible = true;
            sideBarReset();

            getAllHashtags();
            tableProsses();
        }
        //To Get Live Tweets In Current Time 
        private void turkeyLive_Click(object sender, EventArgs e)
        {
            string message = "This Event Will Take Around 10 Minute \n Are You Sure to Continue?";
            string caption = "Turkey Live";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                sidePanel.Height = turkeyLive.Height;
                turkeyLive.BackColor = selected;
                stat.BackColor = unselected;
                turkey.BackColor = unselected;
                sidePanel.Top = turkeyLive.Top;

                searchPanel.Visible = false;
                map.Visible = true;
                tags.Visible = true;
                sideBarReset();

                // set Map settings
                mi.Do("Set Map  Zoom Entire Layer " + (layerSayisi - 1));
                mi.Do("Set Map  Layer " + (layerSayisi) + " Editable On");
                mi.Do("Set Map  Layer " + (layerSayisi) + " Editable On");

                TurkeyTrends turkeyTrends = new TurkeyTrends();
                turkeyTrends.GetTrends("Turkey");
                if (!tags.Contains(turkeyTrends))
                {
                    tags.Controls.Add(turkeyTrends);
                    turkeyTrends.Dock = DockStyle.Fill;
                    turkeyTrends.BringToFront();
                }
                else turkeyTrends.BringToFront();

                tableProsses();

                List<TweetDB> twDB;
                twDB = db.GetTweetsInlast10Min();

                PutTweetsOnMap(twDB);
            }

        }
        //Statistic Window 
        private void stat_Click(object sender, EventArgs e)
        {
            sidePanel.Height = stat.Height;
            stat.BackColor = selected;
            turkeyLive.BackColor = unselected;
            turkey.BackColor = unselected;
            sidePanel.Top = stat.Top;

            searchPanel.Visible = false;
            map.Visible = false;
            tags.Visible = false;
            panel2.Visible = false;

            containerMap.Controls.Add(new Statistic());

        }
        
        // search button to find all tweets by chiritizied
        private void searchButton_Click(object sender, EventArgs e)
        {
            DeleteTweetTable();
            createLiveTweetsTable();

            string hashtag = null;
            string timePeriod=null;
            int sayi=0;
            if (hashtagSearch.SelectedItem != null && hashtagSearch.SelectedIndex != 0)
            {
                hashtag = hashtagSearch.SelectedItem.ToString();
                int index = hashtag.IndexOf('(');
                int index2 = hashtag.IndexOf(')');
                
                sayi = Convert.ToInt32(hashtag.Substring(index + 1, (index2 - index - 1)));
                hashtag = hashtag.Substring(0, index).Trim();
            }
            if (searchTimePer.SelectedItem != null && searchTimePer.SelectedIndex != 0)
                timePeriod = searchTimePer.SelectedItem.ToString();
            
            List<TweetDB> tw = new List<TweetDB>();
            DbResults dbR=null;
            if (hashtag == null && timePeriod == null)
            {
                MessageBox.Show("Please Select a Hashtag or Time Period");
                ClearContent();
            }
            else if (hashtag == null && timePeriod != null)
            {
                tw = db.GetTweetsByTime(timePeriod);
                if (tw.ToArray().Length==0)
                {
                    MessageBox.Show("Please Select Dedicated Time Period");
                }
                else
                {
                    dbR = new DbResults(db.GetTrendTagsByTime(timePeriod));
                    PutTweetsOnMap(tw);
                }

                ClearContent();
            }
            else if (hashtag != null && timePeriod == null)
            {
                tw = db.GetTweetsByHastag(hashtag);
                if (tw.ToArray().Length == 0)
                {
                    MessageBox.Show("Please Select Another Hashtag");
                }
                else
                {
                    List<ResultsObj> rdb = new List<ResultsObj>();
                    ResultsObj rb = new ResultsObj {sayi = sayi, hastag = hashtag };
                    rdb.Add(rb);
                    dbR = new DbResults(rdb);
                    PutTweetsOnMap(tw);
                }

                ClearContent();
            }
            else if (hashtag != null && timePeriod != null)
            {
                tw = db.GetTweetsByHastagTime(hashtag,timePeriod);
                if (tw.ToArray().Length==0)
                {
                    MessageBox.Show("Please Select a Hashtag or Time Period");
                }
                else
                {
                    List<ResultsObj> rdb = new List<ResultsObj>();
                    ResultsObj rb = new ResultsObj { sayi = sayi, hastag = hashtag };
                    rdb.Add(rb);
                    dbR = new DbResults(rdb);
                    PutTweetsOnMap(tw);
                }

                ClearContent();
            }

            if (!tags.Contains(dbR) && dbR != null)
            {
                tags.Controls.Add(dbR);
                dbR.Dock = DockStyle.Fill;
                dbR.BringToFront();
            }
        }
        
        
        // Return All Hashtags from database
        public void getAllHashtags()
        {
            TurkeyTrends turkeyTrends = new TurkeyTrends();
            if (!tags.Contains(turkeyTrends))
            {
                tags.Controls.Add(turkeyTrends);
                turkeyTrends.Dock = DockStyle.Fill;
                turkeyTrends.BringToFront();
            }
            else
            {
                tags.Controls.Remove(turkeyTrends);
                tags.Controls.Add(turkeyTrends);
                turkeyTrends.Dock = DockStyle.Fill;
                turkeyTrends.BringToFront();
            }

            List<ResultsObj> twDB;
            twDB = db.GetAllHashtags();
            hashtagSearch.DataSource = twDB;
            hashtagSearch.Text = "Select A Hashtag";
            turkeyTrends.GetTrends(twDB);
        }

        // Delete Live Tweets Table and  Create again
        public void tableProsses()
        {
            if (layerSayisi == 3)
            {
                DeleteTweetTable();
                createLiveTweetsTable();
            }
            else
            {
                createLiveTweetsTable();
            }
        }

        //canlı tweet gösterme tablosu 
        public static void createLiveTweetsTable()
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
            }
        }

        //canlı tweet tablosu silme
        public static void DeleteTweetTable()
        {
            if (layerSayisi == 3)
            {
                mi.Do("close table CANLI_TWEET");
                layerSayisi--;
            }
            if (File.Exists(path + "\\Resources\\CANLI_TWEET.TAB"))
            {
                File.Delete(path + "\\Resources\\CANLI_TWEET.TAB");
                if (File.Exists(path + "\\Resources\\CANLI_TWEET.DAT"))
                    File.Delete(path + "\\Resources\\CANLI_TWEET.DAT");
                if (File.Exists(path + "\\Resources\\CANLI_TWEET.MAP"))
                    File.Delete(path + "\\Resources\\CANLI_TWEET.MAP");
                if (File.Exists(path + "\\Resources\\CANLI_TWEET.ID"))
                    File.Delete(path + "\\Resources\\CANLI_TWEET.ID");
            }
        }

        // get all tweets adn  display them on a map
        public static void PutTweetsOnMap(List<TweetDB> tweetDB)
        {
            createLiveTweetsTable();
            if (counter == 0)
            {
                Maps.mi.Do("dim p as object");
            }
            Maps.counter++;
            foreach (var tweet in tweetDB)
            {
                Maps.mi.Do("Create point  into variable p (" + tweet.lon + "," + tweet.lat + ") Symbol MakeCustomSymbol (\"PING-64.BMP\",0,12,0)");
                Maps.mi.Do("insert into CANLI_TWEET(obj,id,hastag,user,konum,tarih) values (p,\"" + tweet.id + "\",\"" + tweet.hastag + "\",\"" + tweet.tweeted_user + "\",\"" + tweet.tweeted_location + "\",\"" + tweet.tweeted_date + "\")");

            }
            Maps.mi.Do("Commit Table CANLI_TWEET");

        }

        public void ClearContent()
        {
            hashtagSearch.SelectedItem = null;
            searchTimePer.SelectedItem = null;
            hashtagSearch.Text = "Select A Hashtag";
            searchTimePer.Text = "Select A Time Period";
        }
       
    }
    
}
