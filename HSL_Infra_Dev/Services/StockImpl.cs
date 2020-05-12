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
    public class StockImpl:IStock
    {
        public int CreateStock(Stock stockModel)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Stock", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "CreateStock";
                    cmdDistrict.Parameters.Add("@LOCATION_ID", SqlDbType.Int).Value = stockModel.Location_Id;
                    cmdDistrict.Parameters.Add("@ITEM_ID", SqlDbType.Int).Value = stockModel.Item_Id;
                    cmdDistrict.Parameters.Add("@UOM_ID", SqlDbType.Int).Value = stockModel.Base_Uom_Id;
                    cmdDistrict.Parameters.Add("@QUANTITY", SqlDbType.Decimal).Value = stockModel.Stock_Quantity;

                    int result=cmdDistrict.ExecuteNonQuery();

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
        public Stock getStockByLocation(int Item_id,int Loc_id)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Stock", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "StockByLocation";
                    cmdDistrict.Parameters.Add("@ITEM_ID", SqlDbType.Int).Value = Item_id;
                    cmdDistrict.Parameters.Add("@LOCATION_ID", SqlDbType.Int).Value = Loc_id;
                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Stock stock = new Stock();
                    foreach (DataRow row in dt.Rows)
                    {
                        stock.Stock_Id = Convert.ToInt32(row["STOCK_ID"]);
                        stock.Location_Id = Convert.ToInt32(row["LOCATION_ID"]);
                        stock.Item_Id = Convert.ToInt32(row["ITEM_ID"]);
                        stock.Base_Uom_Id = Convert.ToInt32(row["UOM_ID"]);
                        stock.Stock_Quantity= Convert.ToDecimal(row["QUANTITY"]);
                    }
                    return stock;
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