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
    public class DepartmentImpl:IDepartment
    {
        public List<Department> GetDepartment()
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Department", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "GetAllDepartments";

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    List<Department> departmentList = new List<Department>();
                    departmentList = (from DataRow dr in dt.Rows
                                   select new Department()
                                   {
                                       Id = Convert.ToInt32(dr["DEPARTMENT_ID"]),
                                       Department_Description = dr["DEPARTMENT_DESC"].ToString(),
                                       Is_Active = Convert.ToBoolean(dr["ISACTIVE"]),
                                       Created_Date = Convert.ToDateTime(dr["CREATED_DATE"]),
                                       Updated_Date = Convert.ToDateTime(dr["MODIFIED_DATE"])
                                   }).ToList();
                    return departmentList;
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

        public Department GetDepartment(int DepartmentId)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Department", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "GetDepartmentById";
                    cmdDistrict.Parameters.Add("@DEPARTMENT_ID", SqlDbType.Char).Value = DepartmentId;

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Department department = new Department();
                    foreach(DataRow row in dt.Rows)
                    {
                        department.Id = Convert.ToInt32(row["DEPARTMENT_ID"]);
                        department.Department_Description = row["DEPARTMENT_DESC"].ToString();
                        department.Is_Active = Convert.ToBoolean(row["ISACTIVE"]);
                    }
                    return department;
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

        public string CreateDepartment(Department departments)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Department", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "CreateDepartment";
                    cmdDistrict.Parameters.Add("@DEPARTMENT_DESC", SqlDbType.Char).Value = departments.Department_Description;
                    cmdDistrict.Parameters.Add("@ISACTIVE", SqlDbType.Char).Value = departments.Is_Active?"1":"0";

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    string result = dt.Rows[0]["Result"].ToString();
                    
                    return result;
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

        public int DeleteDepartment(int department_id)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Department", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "DeleteDepartment";
                    cmdDistrict.Parameters.Add("@DEPARTMENT_ID", SqlDbType.Char).Value = department_id;
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

        public string UpdateDepartment(Department departments)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Department", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "UpdateDepartment";
                    cmdDistrict.Parameters.Add("@DEPARTMENT_ID", SqlDbType.Char).Value = departments.Id;
                    cmdDistrict.Parameters.Add("@DEPARTMENT_DESC", SqlDbType.Char).Value = departments.Department_Description;
                    cmdDistrict.Parameters.Add("@ISACTIVE", SqlDbType.Char).Value = departments.Is_Active ? "1" : "0";

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    string result = dt.Rows[0]["Result"].ToString();

                    return result;
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