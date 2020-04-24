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
    public class UsersImpl : IUsers
    {
        public List<Users> GetUsers()
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Users", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "GetAllUsers";

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    List<Users> userList = new List<Users>();
                    userList = (from DataRow dr in dt.Rows
                                      select new Users()
                                      {
                                          USER_ID = Convert.ToInt32(dr["USER_ID"]),
                                          USER_NAME = dr["USER_NAME"].ToString(),
                                          Department_id = Convert.ToInt32(dr["DEPARTMENT_ID"]),
                                          Role_id = Convert.ToInt32(dr["ROLE_ID"]),
                                          Is_Active = Convert.ToBoolean(dr["ISACTIVE"]),
                                          Created_Date = Convert.ToDateTime(dr["CREATED_DATE"]),
                                          Updated_Date = Convert.ToDateTime(dr["MODIFIED_DATE"])
                                      }).ToList();
                    return userList;
                }
                catch (Exception ex)
                {
                    return null;
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