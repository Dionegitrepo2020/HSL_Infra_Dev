﻿using HSL_Infra_Dev.Helpers;
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
        public string CheckAdminLogin(string UserId, string Password)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetServerConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_License", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "CheckLogin";
                    cmdDistrict.Parameters.Add("@COMPANY_USER_ID", SqlDbType.Char).Value = UserId;
                    cmdDistrict.Parameters.Add("@COMPANY_PASSWORD", SqlDbType.Char).Value = Password;

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Columns.Contains("Result"))
                        return "UNAUTHORIZED";
                    else
                        return dt.Rows[0]["COMPANY_ID"].ToString();
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
                finally
                {
                    if (connGetDistrict.State == ConnectionState.Open)
                        connGetDistrict.Close();
                }
            }
        }

        public string CheckUserLogin(string UserId, string Password)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Users", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "CheckLogin";
                    cmdDistrict.Parameters.Add("@USER_NAME", SqlDbType.Char).Value = UserId;
                    cmdDistrict.Parameters.Add("@USER_PASSWORD", SqlDbType.Char).Value = Password;

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Columns.Contains("Result"))
                        return "UNAUTHORIZED";
                    else
                        return dt.Rows[0]["USER_ID"].ToString();
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
                finally
                {
                    if (connGetDistrict.State == ConnectionState.Open)
                        connGetDistrict.Close();
                }
            }
        }
        public Users GetUsers(int UserId)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Users", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "GetUserById";
                    cmdDistrict.Parameters.Add("@USER_ID", SqlDbType.Char).Value = UserId;

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Users users = new Users();
                    users.User_Id = Convert.ToInt32(dt.Rows[0]["USER_ID"]);
                    users.Company_Id= Convert.ToInt32(dt.Rows[0]["COMPANY_ID"]);
                    users.User_Name = dt.Rows[0]["USER_NAME"].ToString();
                    users.User_Password = dt.Rows[0]["USER_PASSWORD"].ToString();
                    users.Name = dt.Rows[0]["NAME"].ToString();
                    users.Department_Id = Convert.ToInt32(dt.Rows[0]["DEPARTMENT_ID"]);
                    users.Role_Id = Convert.ToInt32(dt.Rows[0]["ROLE_ID"]);
                    users.Is_Active = Convert.ToBoolean(dt.Rows[0]["ISACTIVE"]);
                    return users;
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

        public List<Users> GetUsers()
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Users", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "GetAllUser";

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    List<Users> usersList = new List<Users>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Users users = new Users();
                        users.User_Id = Convert.ToInt32(dr["USER_ID"]);
                        users.Company_Id = Convert.ToInt32(dr["COMPANY_ID"]);
                        users.User_Name = dr["USER_NAME"].ToString();
                        users.User_Password = dr["USER_PASSWORD"].ToString();
                        users.Name = dr["NAME"].ToString();
                        users.Department_Id = Convert.ToInt32(dr["DEPARTMENT_ID"]);
                        users.Role_Id = Convert.ToInt32(dr["ROLE_ID"]);
                        users.Is_Active = Convert.ToBoolean(dr["ISACTIVE"]);
                        usersList.Add(users);
                    }
                    return usersList;
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

        public int CreateUsers(Users users)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Users", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "CreateUsers";
                    cmdDistrict.Parameters.Add("@COMPANY_ID", SqlDbType.Int).Value = users.Company_Id;
                    cmdDistrict.Parameters.Add("@USER_NAME", SqlDbType.NVarChar).Value = users.User_Name;
                    cmdDistrict.Parameters.Add("@USER_PASSWORD", SqlDbType.NVarChar).Value = users.User_Password;
                    cmdDistrict.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = users.Name;
                    cmdDistrict.Parameters.Add("@DEPARTMENT_ID", SqlDbType.Int).Value = users.Department_Id;
                    cmdDistrict.Parameters.Add("@ROLE_ID", SqlDbType.Int).Value = users.Role_Id;
                    cmdDistrict.Parameters.Add("@ISACTIVE", SqlDbType.Char).Value = users.Is_Active ? "1" : "0";

                    int result = cmdDistrict.ExecuteNonQuery();

                    return result;
                }
                catch (Exception ex)
                {
                    return 0;
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