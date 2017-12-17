using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Windows.Forms;
using System.Net;
using DatabaseSession;

namespace CBSProjeTasarimTest
{
    public  class Twitter 
    {
        public String html;
        public Uri url;
        
        // return a list if  trends which is popular  in current moment 
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

        // genetaring  a search or hashtag Url to access tweets which include 
        public string GenerateHashtagString(string speHashtag)
        {
            String baseHashtag = "";
            String hashtag = speHashtag;
            String urlTag;

            //hashtag ise hashtag anahtarı ile değilse  arama  ile popular  başlıkları aratır
            if (!hashtag.Contains("#"))
            {
                baseHashtag = "https://twitter.com/search?f=tweets&vertical=default&q=";
                hashtag.Replace("?", String.Empty);
                String enSonTweet = "&src=typd";
                urlTag = baseHashtag + hashtag + enSonTweet;
                //https://twitter.com/search?f=tweets&vertical=default&q=G%C3%B6khan%20G%C3%B6n%C3%BCl&src=typd
            }
            else
            {
                baseHashtag = "https://twitter.com/hashtag/";
                hashtag = hashtag.Substring(hashtag.IndexOf("#") + 1);
                hashtag.Replace("?", String.Empty);
                String enSonTweet = "?f=tweets&";
                String sonKisim = "vertical=default&src=tren";

                urlTag = baseHashtag + hashtag + enSonTweet + sonKisim;
            }

            Console.WriteLine(urlTag);
            return urlTag;
        }

        //returning a list of tweets which posted with spesific hashtag
        public List<Tweet> GetTweetsByHashtag(String Url, string hashtag)
        {
            //Pattern of twettes  which include hashtag 
            string xPathTag = "//span[b]";
            List<Tweet> tweets = new List<Tweet>();
            try
            {
                url = new Uri(Url);
            }
            catch (UriFormatException)
            {
                if (MessageBox.Show("Hatali Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    MessageBox.Show("Hatali Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw;
            }
            catch (ArgumentNullException)
            {
                if (MessageBox.Show("Hatali Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    MessageBox.Show("Hatali Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Hatali Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw;
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            HtmlNodeCollection users = null;
            try
            {
                users = doc.DocumentNode.SelectNodes(xPathTag);
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
                foreach (var user in users)
                {
                    string nickname = user.InnerText.Replace("\n", String.Empty);
                    if (nickname != null && nickname != "" && nickname != String.Empty && nickname != "\n")
                    {
                        nickname = nickname.Substring(nickname.IndexOf("@") + 1);
                        string dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        Tweet tweet = new Tweet(generateID(), hashtag);
                        tweet.user = nickname;
                        tweet.date = dateTime;
                        tweets.Add(tweet);
                    }
                }
            }
            catch (NullReferenceException)
            {
                if (MessageBox.Show("Hatali XPath", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    MessageBox.Show("Hatali XPath", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw;
            }

            return tweets;
        }

        //generate a new uniq id to each tweets
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }

        //checking for is a posted tweet have location . 
        public void FindUserLocation(List<Tweet> tweets)
        {
            String urlAdress = "https://twitter.com/";

            for (int i = 0; i < tweets.ToArray().Length; i++)
            {
                string tempUrlAdress = urlAdress + tweets[i].user.ToString();
                 tweets[i]= ScrapeAdress(tempUrlAdress, tweets[i]);
            }
            List<TweetDB> tweetDB = new List<TweetDB>();
            //Display all tweets which have location
            foreach (var tweet in tweets)
            {
                if (tweet.location != null)
                {
                    TweetDB tw = new TweetDB();
                    tw.id = tweet.id;
                    tw.hastag = tweet.hastag;
                    tw.tweeted_user = tweet.user;
                    tw.tweeted_date = tweet.date;
                    tw.tweeted_location = tweet.location;
                    tw.lat = tweet.lat;
                    tw.lon = tweet.lon;

                    tweetDB.Add(tw);


                    Console.WriteLine("Tweet ID-> " + tweet.id);
                    Console.WriteLine("Tweet User-> " + tweet.user);
                    Console.WriteLine("Tweet HashTag-> " + tweet.hastag);
                    Console.WriteLine("Tweet Tarih-> " + tweet.date);
                    Console.WriteLine("Tweet location-> " + tweet.location);
                    Console.WriteLine("Tweet lat-> " + tweet.lat);
                    Console.WriteLine("Tweet lon-> " + tweet.lon);
                    Console.WriteLine("\n************\n");


                }
            }
            DataAccess db = new DataAccess();
            db.InsertTweets(tweetDB);

        }

        //scrape the user page and  set tweet's location is its exist
        public Tweet ScrapeAdress(String Url, Tweet tweet)
        {
            String xPathAdres = "//*[@id='page-container']/div[2]/div/div/div[1]/div/div/div/div[1]/div[1]/span[2]";
            try
            {
                url = new Uri(Url);
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

            HtmlNode adress;
            try
            {
                adress = doc.DocumentNode.SelectSingleNode(xPathAdres);
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
                if (adress != null)
                {
                    string adres = adress.InnerText.Replace("\n", String.Empty);
                    adres = adres.Replace(" ", String.Empty);
                    if (adres != null && adres != "" && adres != String.Empty && adres != "\n")
                    {
                        tweet.LocationParse(adres);
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
            return tweet;
        }
    }
}
