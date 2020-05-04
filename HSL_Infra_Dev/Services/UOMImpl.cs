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
    public class UOMImpl:IUOM
    {
        public List<UOM> GetUOMs()
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_UOM", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "GetAllUOMs";

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    List<UOM> uomList = new List<UOM>();
                    uomList = (from DataRow dr in dt.Rows
                                      select new UOM()
                                      {
                                          Id = Convert.ToInt32(dr["UOM_ID"]),
                                          uom_key = dr["UOM_NAME"].ToString(),
                                          uom_desc = dr["UOM_DESC"].ToString(),
                                          unit_factor=Convert.ToInt32(dr["UNIT_FACTOR"]),
                                          min_conversion=Convert.ToInt32(dr["MIN_CONVERTION"]),
                                          is_active=Convert.ToBoolean(dr["ISACTIVE"]),
                                          created_date = Convert.ToDateTime(dr["CREATED_DATE"]),
                                          updated_date = Convert.ToDateTime(dr["MODIFIED_DATE"])
                                      }).ToList();
                    return uomList;
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

        public UOM GetUOM(int Uom_Id)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_UOM", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "GetUomById";
                    cmdDistrict.Parameters.Add("@UOM_ID", SqlDbType.Char).Value = Uom_Id;

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    UOM uom = new UOM();
                    foreach (DataRow row in dt.Rows)
                    {
                        uom.Id = Convert.ToInt32(row["UOM_ID"]);
                        uom.uom_key = row["UOM_NAME"].ToString();
                        uom.uom_desc = row["UOM_DESC"].ToString();
                        uom.unit_factor = Convert.ToInt32(row["UNIT_FACTOR"]);
                        uom.min_conversion = Convert.ToInt32(row["MIN_CONVERTION"]);
                        uom.is_active = Convert.ToBoolean(row["ISACTIVE"]);
                    }
                    return uom;
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

        public string CreateUom(UOM uom)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_UOM", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "CreateUom";
                    cmdDistrict.Parameters.Add("@UOM_NAME", SqlDbType.Char).Value = uom.uom_key;
                    cmdDistrict.Parameters.Add("@UOM_DESC", SqlDbType.Char).Value = uom.uom_desc;
                    cmdDistrict.Parameters.Add("@UNIT_FACTOR", SqlDbType.Char).Value = uom.unit_factor;
                    cmdDistrict.Parameters.Add("@MIN_CONVERTION", SqlDbType.Char).Value = uom.min_conversion;
                    cmdDistrict.Parameters.Add("@ISACTIVE", SqlDbType.Char).Value = uom.is_active ? "1" : "0";

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

        public int DeleteUom(int Uom_Id)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_UOM", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "DeleteUom";
                    cmdDistrict.Parameters.Add("@UOM_ID", SqlDbType.Char).Value = Uom_Id;
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

        public string UpdateUom(UOM uom)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_UOM", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "UpdateUom";
                    cmdDistrict.Parameters.Add("@UOM_ID", SqlDbType.Char).Value = uom.Id;
                    cmdDistrict.Parameters.Add("@UOM_NAME", SqlDbType.Char).Value = uom.uom_key;
                    cmdDistrict.Parameters.Add("@UOM_DESC", SqlDbType.Char).Value = uom.uom_desc;
                    cmdDistrict.Parameters.Add("@UNIT_FACTOR", SqlDbType.Char).Value = uom.unit_factor;
                    cmdDistrict.Parameters.Add("@MIN_CONVERTION", SqlDbType.Char).Value = uom.min_conversion;
                    cmdDistrict.Parameters.Add("@ISACTIVE", SqlDbType.Char).Value = uom.is_active ? "1" : "0";

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