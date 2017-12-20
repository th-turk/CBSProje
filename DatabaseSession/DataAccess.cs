using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
namespace DatabaseSession
{
    public class DataAccess
    {
        //get all Cities from database
        public List<City> GetCities()
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DB")))
            {
                 return conn.Query<City>($"Select * from city").ToList();
            } 
        }

        //get all Cities from database
        public List<string> GetCityName(int id)
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DB")))
            {
                return conn.Query<string>($"Select cityName from city where id={id}").ToList();
            }
        }
        //get all Districts from database
        public List<District> GetDistricts()
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DB")))
            {
                return conn.Query<District>($"Select * from district").ToList();
            }
        }

        //insert Tweets 
        public void InsertTweets(List<TweetDB> tweetDB)
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DB")))
            {
                foreach (var tweet in tweetDB)
                {
                    conn.Query($"INSERT INTO TWEET VALUES ('"+tweet.id+"'," +
                        "'"+tweet.hastag.Replace("\"", " ").Replace("'", " ") + "'," +
                        "'"+tweet.tweeted_user.Replace("\"", " ").Replace("'", " ") + "'," +
                        "'"+tweet.tweeted_location.Replace("\"", " ").Replace("'", " ") + "'," +
                        "Convert(datetime,'"+tweet.tweeted_date.Replace("\"", " ").Replace("'", " ") + "',103)," +
                        "'"+tweet.lat+"','"+tweet.lon+"')");
                }
            }
        }

        //Get Tweets 
        public List<TweetDB> GetAllTweets()
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DB")))
            {
                return conn.Query<TweetDB>($"select top(500) * from tweet ").ToList();
            }
        }

        //Get All Hashtags
        public List<ResultsObj> GetAllHashtags()
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DB")))
            {
                return conn.Query<ResultsObj>($"select COUNT(*) as sayi, tw.hastag from tweet tw group by hastag order by sayi desc;").ToList();
            }
        }

        //Get Tweets with last 10 minutes
        public List<TweetDB> GetTweetsInlast10Min()
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DB")))
            {
                return conn.Query<TweetDB>($"select * from tweet where tweeted_date > DateADD(mi, -12, GETDATE()); ").ToList();
            }
        }

        //Get Hashtags with last 10 minutes
        public List<ResultsObj> GetTweetsInlast10MinHashtags()
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DB")))
            {
                return conn.Query<ResultsObj>($"SELECT  COUNT(*) AS sayi, tw.hastag from tweet tw where tweeted_date > DateADD(mi, -12, GETDATE()) GROUP BY tw.hastag ORDER BY  sayi DESC;  ").ToList();
            }
        }

        //Get Tweets By given hashtag and time
        public List<TweetDB> GetTweetsByHastagTime(string hashtag,string time)
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DB")))
            {
                hashtag = hashtag.Trim();
                string[] parser = time.Split(' ');
                if(parser.Length == 3)
                {
                    if (parser[2] == "min")
                        return conn.Query<TweetDB>($"select * from tweet where tweeted_date > DateADD(mi, -" + parser[1] + ", GETDATE()) and hastag ='"+hashtag+"'; ").ToList();
                    else if (parser[2] == "hour")
                        return conn.Query<TweetDB>($"select * from tweet where tweeted_date > DateADD(hour, -" + parser[1] + ", GETDATE()) and hastag ='" + hashtag + "'; ").ToList();
                    else if (parser[2] == "day")
                        return conn.Query<TweetDB>($"select * from tweet where tweeted_date > DateADD(day, -" + parser[1] + ", GETDATE()) and hastag ='" + hashtag + "'; ").ToList();
                    else if (parser[2] == "week")
                        return conn.Query<TweetDB>($"select * from tweet where tweeted_date > DateADD(week, -" + parser[1] + ", GETDATE()) and hastag ='" + hashtag + "'; ").ToList();
                    else if (parser[2] == "mounth")
                        return conn.Query<TweetDB>($"select * from tweet where tweeted_date > DateADD(mounth, -" + parser[1] + ", GETDATE()) and hastag ='" + hashtag + "'; ").ToList();
                    else
                        return null;
                }
                else
                    return null;
                
            }
        }

        //Get Tweets By given hashtag 
        public List<TweetDB> GetTweetsByHastag(string hashtag)
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DB")))
            {
                hashtag = hashtag.Trim();
                return conn.Query<TweetDB>($"select * from tweet where hastag ='"+ hashtag + "'; ").ToList();
            }
        }
        //Get Tweets By given time
        public List<TweetDB> GetTweetsByTime(string time)
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DB")))
            {
                string[] parser = time.Split(' ');
                if (parser[2] == "min")
                    return conn.Query<TweetDB>($"select * from tweet where tweeted_date > DateADD(mi, -" + parser[1] + ", GETDATE()); ").ToList();
                else if (parser[2] == "hour")
                    return conn.Query<TweetDB>($"select * from tweet where tweeted_date > DateADD(hour, -" + parser[1] + ", GETDATE()); ").ToList();
                else if (parser[2] == "day")
                    return conn.Query<TweetDB>($"select * from tweet where tweeted_date > DateADD(day, -" + parser[1] + ", GETDATE()); ").ToList();
                else if (parser[2] == "week")
                    return conn.Query<TweetDB>($"select * from tweet where tweeted_date > DateADD(week, -" + parser[1] + ", GETDATE()); ").ToList();
                else if (parser[2] == "month")
                    return conn.Query<TweetDB>($"select * from tweet where tweeted_date > DateADD(month, -" + parser[1] + ", GETDATE()); ").ToList();
                else
                    return null;
            }
        }

        //Get top trends in current time 
        public List<ResultsObj> GetTrendTagsByTime(string time)
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DB")))
            {
                string[] parser = time.Split(' ');
                if (parser[2] == "min")
                    return conn.Query<ResultsObj>($"SELECT  COUNT(*) AS sayi, tw.hastag from tweet tw where tweeted_date > DateADD(mi, -" + parser[1] + ", GETDATE()) GROUP BY tw.hastag ORDER BY  sayi DESC; ").ToList();
                else if (parser[2] == "hour")
                    return conn.Query<ResultsObj>($"SELECT  COUNT(*) AS sayi, tw.hastag from tweet tw  where tweeted_date > DateADD(hour, -" + parser[1] + ", GETDATE()) GROUP BY tw.hastag ORDER BY  sayi DESC; ").ToList();
                else if (parser[2] == "day")
                    return conn.Query<ResultsObj>($"SELECT  COUNT(*) AS sayi, tw.hastag from tweet tw  where tweeted_date > DateADD(day, -" + parser[1] + ", GETDATE()) GROUP BY tw.hastag ORDER BY  sayi DESC; ").ToList();
                else if (parser[2] == "week")
                    return conn.Query<ResultsObj>($"SELECT  COUNT(*) AS sayi, tw.hastag from tweet tw  where tweeted_date > DateADD(week, -" + parser[1] + ", GETDATE()) GROUP BY tw.hastag ORDER BY  sayi DESC; ").ToList();
                else if (parser[2] == "month")
                    return conn.Query<ResultsObj>($"SELECT  COUNT(*) AS sayi, tw.hastag from tweet tw  where tweeted_date > DateADD(month, -" + parser[1] + ", GETDATE()) GROUP BY tw.hastag ORDER BY  sayi DESC; ").ToList();
                else
                    return null;
            }
        }

        //Get top trends in current time 
        public List<ResultsObj2> GetChart1Value(string hashtag)
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DB")))
            {
                hashtag = hashtag.Trim();
                return conn.Query<ResultsObj2>($"select Top 8 COUNT(*) AS sayi, tw.tweeted_location FROM tweet tw where hastag ='" + hashtag + "' GROUP by tw.tweeted_location ORDER BY  sayi DESC; ").ToList();
            }
        }


    }
}
