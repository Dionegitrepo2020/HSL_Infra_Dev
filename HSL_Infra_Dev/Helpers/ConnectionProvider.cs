using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HSL_Infra_Dev.Helpers
{
    public class ConnectionProvider
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["InfraConnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConnection);
                conn.Open();
                return conn;
            }
            catch (SqlException e)
            {
                return null;
            }

        }

        public static SqlConnection GetServerConnection()
        {
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConnection);
                conn.Open();
                return conn;
            }
            catch (SqlException e)
            {
                return null;
            }

        }
    }
}