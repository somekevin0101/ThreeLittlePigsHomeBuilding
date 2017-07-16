using ThreeLittlePigs.Web.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ThreeLittlePigs.Web.DAL
{
    public class HouseSQLDAL: IHouseDAL
    {
        private string connectionString;
        private const string SQL_GetAllParks = "Select * from house;";
        private const string SQL_GetHouse = "SELECT * FROM house WHERE houseCode = @houseCode;";

        public HouseSQLDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<House> GetAllHouses()
        {
            List<House> allParks = new List<House>();

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    allParks = conn.Query<House>(SQL_GetAllParks).ToList();
                }

                return allParks;
            }

            catch(SqlException ex)
            {
                throw;
            }
        }

        public House GetHouse(string houseCode)
        {
            House p = new House();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                p = conn.QueryFirstOrDefault<House>(SQL_GetHouse, new { @houseCode = houseCode });
            }
            return p;
        }

    }
}