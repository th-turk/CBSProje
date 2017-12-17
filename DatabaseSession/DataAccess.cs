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
                        "'"+tweet.hastag+"','"+tweet.tweeted_user+"','"+tweet.tweeted_location+"'," +
                        "Convert(datetime,'"+tweet.tweeted_date+"',103),'"+tweet.lat+"','"+tweet.lon+"')");
                }
            }
        }
    }
}
