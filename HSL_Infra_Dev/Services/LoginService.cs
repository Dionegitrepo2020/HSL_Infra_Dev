using HSL_Infra_Dev.Helpers;
using HSL_Infra_Dev.Interfaces;
using HSL_Infra_Dev.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HSL_Infra_Dev.Services
{
    public class LoginService:ILogin
    {
        public bool AddToCount(LoginLog loginLog)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetServerConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Active_Users", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "Insert";
                    cmdDistrict.Parameters.Add("@USER_ID", SqlDbType.Char).Value = loginLog.UserId;
                    cmdDistrict.Parameters.Add("@COMPANY_ID", SqlDbType.Char).Value = loginLog.CompanyId;

                    int insrted= cmdDistrict.ExecuteNonQuery();
                    if (insrted > 0)
                        return true;
                    else
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    if (connGetDistrict.State == ConnectionState.Open)
                        connGetDistrict.Close();
                }
            }
        }

        public bool RemoveFromCount(LoginLog loginLog)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetServerConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Active_Users", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "DeleteActiveusers";
                    cmdDistrict.Parameters.Add("@USER_ID", SqlDbType.Char).Value = loginLog.UserId;
                    cmdDistrict.Parameters.Add("@COMPANY_ID", SqlDbType.Char).Value = loginLog.CompanyId;

                    int deleted = cmdDistrict.ExecuteNonQuery();
                    if (deleted > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    if (connGetDistrict.State == ConnectionState.Open)
                        connGetDistrict.Close();
                }
            }
        }

    }
}