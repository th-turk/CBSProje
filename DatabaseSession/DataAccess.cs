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
                        "'"+tweet.hastag.Replace("\"", "&#39;").Replace("'", "&#39;") + "'," +
                        "'"+tweet.tweeted_user.Replace("\"", "&#39;").Replace("'", "&#39;") + "'," +
                        "'"+tweet.tweeted_location.Replace("\"", "&#39;").Replace("'", "&#39;") + "'," +
                        "Convert(datetime,'"+tweet.tweeted_date.Replace("\"", "&#39;").Replace("'", "&#39;") + "',103)," +
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

        //Get Tweets with last 10 minutes
        public List<TweetDB> GetTweetsInlast10Min()
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DB")))
            {
                return conn.Query<TweetDB>($"select * from tweet where tweeted_date > DateADD(mi, -12, GETDATE()); ").ToList();
            }
        }
    }
}
