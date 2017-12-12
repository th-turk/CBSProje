using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Windows.Forms;
using System.Net;

namespace CBSProjeTasarimTest
{
    public  class Twitter 
    {
        public String html;
        public Uri url;

        public void getTrends(String Url, List<string> CikanSonuc)
        {
            string urlTrends="";
            string XPath = "";
            try
            {
                if(Url =="Türkiye") urlTrends = "https://trends24.in/turkey/";
                else urlTrends = "https://trends24.in";
                
                XPath = "//*[@id='trend-list']/div[1]/ol/li";
                url = new Uri(urlTrends);
            }
            catch (UriFormatException)
            {
                if (MessageBox.Show("Hatali Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
                throw;
            }
            catch (ArgumentNullException)
            {
                if (MessageBox.Show("Hatali Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
                throw;
            }

            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Proxy = null;
            try
            {
                html = client.DownloadString(url);
            }
            catch (WebException)
            {
                if (MessageBox.Show("Hatali Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
                throw;
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            HtmlNodeCollection trends;
            try
            {
                trends = doc.DocumentNode.SelectNodes(XPath);
            }
            catch (NullReferenceException)
            {

                MessageBox.Show("Hatali XPath", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
            catch (Exception e)
            {
                MessageBox.Show("Hatali XPath", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            try
            {
                if (trends != null)
                {
                    foreach (var trend in trends)
                    {
                       
                        string hashtag = trend.InnerText;
                        if (hashtag != null && hashtag != "" && hashtag != String.Empty && hashtag != "\n")
                        {
                            hashtag = hashtag.Replace("#39;", "'");
                            CikanSonuc.Add(hashtag);
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Path Boş", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {

                    }
                }
            }
            catch (NullReferenceException)
            {
                if (MessageBox.Show("Hatali XPath adres yok", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
                throw;
            }
        }
        
    }
}
