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
    }
}