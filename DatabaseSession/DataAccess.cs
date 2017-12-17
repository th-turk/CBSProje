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
        public List<City> GetCities()
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DB")))
            {
                 return conn.Query<City>($"Select * from city").ToList();
            } 
        }

        public List<District> GetDistrict()
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DB")))
            {
                return conn.Query<District>($"Select * from district").ToList();
            }
        }
    }
}
