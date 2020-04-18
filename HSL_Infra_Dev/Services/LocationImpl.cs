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
    public class LocationImpl : ILocation
    {
        public List<Location> GetLocation()
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Location", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "GetAllLocations";

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    List<Location> locationtList = new List<Location>();
                    locationtList = (from DataRow dr in dt.Rows
                                      select new Location()
                                      {
                                          Id = Convert.ToInt32(dr["LOCATION_ID"]),
                                          Location_Description = dr["LOCATION_DESC"].ToString(),
                                          Department_id = Convert.ToInt32(dr["DEPARTMENT_ID"]),
                                          Is_Active = Convert.ToBoolean(dr["ISACTIVE"]),
                                          Created_Date = Convert.ToDateTime(dr["CREATED_DATE"]),
                                          Updated_Date = Convert.ToDateTime(dr["MODIFIED_DATE"])
                                      }).ToList();
                    return locationtList;
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

        public Location GetLocation(int LocationId)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Location", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "GetLocationById";
                    cmdDistrict.Parameters.Add("@LOCATION_ID", SqlDbType.Char).Value = LocationId;

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Location location = new Location();
                    foreach (DataRow row in dt.Rows)
                    {
                        location.Id = Convert.ToInt32(row["ID"]);
                        location.Location_Description = row["LOCATION_DESC"].ToString();
                        location.Department_id = Convert.ToInt32(row["DEPARTMENT_ID"]);
                        location.Is_Active = Convert.ToBoolean(row["ISACTIVE"]);
                    }
                    return location;
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

        public string CreateLocation(Location location)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Location", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "CreateLocation";
                    cmdDistrict.Parameters.Add("@LOCATION_DESC", SqlDbType.Char).Value = location.Location_Description;
                    cmdDistrict.Parameters.Add("@DEPARTMENT_ID", SqlDbType.Int).Value = location.Department_id;
                    cmdDistrict.Parameters.Add("@ISACTIVE", SqlDbType.Char).Value = location.Is_Active ? "1" : "0";

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

        public int DeleteLocation(int location_id)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Location", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "DeleteLocation";
                    cmdDistrict.Parameters.Add("@LOCATION_ID", SqlDbType.Char).Value = location_id;
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

        public string UpdateLocation(Location location)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Location", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "UpdateLocation";
                    cmdDistrict.Parameters.Add("@LOCATION_ID", SqlDbType.Int).Value = location.Id;
                    cmdDistrict.Parameters.Add("@DEPARTMENT_ID", SqlDbType.Int).Value = location.Department_id;
                    cmdDistrict.Parameters.Add("@LOCATION_DESC", SqlDbType.Char).Value = location.Location_Description;
                    cmdDistrict.Parameters.Add("@ISACTIVE", SqlDbType.Char).Value = location.Is_Active ? "1" : "0";

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