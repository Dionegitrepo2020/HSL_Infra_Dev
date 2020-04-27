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
    public class ItemImpl : IItem
    {
        public List<Items> GetItems()
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Item", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "GetAllItems";

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    List<Items> itemsList = new List<Items>();
                    itemsList = (from DataRow dr in dt.Rows
                                     select new Items()
                                     {
                                         Item_Id = Convert.ToInt32(dr["ITEM_ID"]),
                                         Item_Description = dr["ITEM_DESC"].ToString(),
                                         Uom_Id = Convert.ToInt32(dr["UOM_ID"]),
                                         //Is_Active = Convert.ToBoolean(dr["ISACTIVE"]),
                                         Created_Date = Convert.ToDateTime(dr["CREATED_DATE"]),
                                         Updated_Date = Convert.ToDateTime(dr["MODIFIED_DATE"])
                                     }).ToList();
                    return itemsList;
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

        public Items GetItem(int ItemId)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Item", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "GetItemById";
                    cmdDistrict.Parameters.Add("@ITEM_ID", SqlDbType.Char).Value = ItemId;

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Items item = new Items();
                    foreach (DataRow row in dt.Rows)
                    {
                        item.Item_Id = Convert.ToInt32(row["ITEM_ID"]);
                        item.Item_Description = row["ITEM_DESC"].ToString();
                        item.Uom_Id = Convert.ToInt32(row["UOM_ID"]);
                        //location.Is_Active = Convert.ToBoolean(row["ISACTIVE"]);
                    }
                    return item;
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

        //public string CreateLocation(Location location)
        //{
        //    using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
        //    {
        //        try
        //        {
        //            SqlCommand cmdDistrict = new SqlCommand("SP_Location", connGetDistrict);
        //            cmdDistrict.CommandType = CommandType.StoredProcedure;
        //            cmdDistrict.CommandTimeout = 250;
        //            cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "CreateLocation";
        //            cmdDistrict.Parameters.Add("@LOCATION_DESC", SqlDbType.Char).Value = location.Location_Description;
        //            cmdDistrict.Parameters.Add("@DEPARTMENT_ID", SqlDbType.Int).Value = location.Department_id;
        //            cmdDistrict.Parameters.Add("@ISACTIVE", SqlDbType.Char).Value = location.Is_Active ? "1" : "0";

        //            SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            string result = dt.Rows[0]["Result"].ToString();

        //            return result;
        //        }
        //        catch (Exception ex)
        //        {
        //            return null;
        //        }
        //        finally
        //        {
        //            if (connGetDistrict.State == ConnectionState.Open)
        //                connGetDistrict.Close();
        //        }
        //    }
        //}

        //public int DeleteLocation(int location_id)
        //{
        //    using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
        //    {
        //        try
        //        {
        //            SqlCommand cmdDistrict = new SqlCommand("SP_Location", connGetDistrict);
        //            cmdDistrict.CommandType = CommandType.StoredProcedure;
        //            cmdDistrict.CommandTimeout = 250;
        //            cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "DeleteLocation";
        //            cmdDistrict.Parameters.Add("@LOCATION_ID", SqlDbType.Char).Value = location_id;
        //            int result = cmdDistrict.ExecuteNonQuery();
        //            return result;
        //        }
        //        catch (Exception ex)
        //        {
        //            return 0;
        //        }
        //        finally
        //        {
        //            if (connGetDistrict.State == ConnectionState.Open)
        //                connGetDistrict.Close();
        //        }
        //    }
        //}

        //public string UpdateLocation(Location location)
        //{
        //    using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
        //    {
        //        try
        //        {
        //            SqlCommand cmdDistrict = new SqlCommand("SP_Location", connGetDistrict);
        //            cmdDistrict.CommandType = CommandType.StoredProcedure;
        //            cmdDistrict.CommandTimeout = 250;
        //            cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "UpdateLocation";
        //            cmdDistrict.Parameters.Add("@LOCATION_ID", SqlDbType.Int).Value = location.Id;
        //            cmdDistrict.Parameters.Add("@DEPARTMENT_ID", SqlDbType.Int).Value = location.Department_id;
        //            cmdDistrict.Parameters.Add("@LOCATION_DESC", SqlDbType.Char).Value = location.Location_Description;
        //            cmdDistrict.Parameters.Add("@ISACTIVE", SqlDbType.Char).Value = location.Is_Active ? "1" : "0";

        //            SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            string result = dt.Rows[0]["Result"].ToString();

        //            return result;
        //        }
        //        catch (Exception ex)
        //        {
        //            return null;
        //        }
        //        finally
        //        {
        //            if (connGetDistrict.State == ConnectionState.Open)
        //                connGetDistrict.Close();
        //        }
        //    }
        //}
    }
}