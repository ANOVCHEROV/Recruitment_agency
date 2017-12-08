using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace RecuirementAgency.Models.Dao_Summ
{
    public class DAO
    {
        public static SqlConnection getConnection()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;
                Initial Catalog=RecAgency;
                Integrated Security=True;
                Pooling=False";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
        public static void closeConnection(SqlConnection con)
        {
            con.Close();
        }
    }
}