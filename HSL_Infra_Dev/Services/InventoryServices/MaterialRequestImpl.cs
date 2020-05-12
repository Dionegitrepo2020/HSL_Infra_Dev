using HSL_Infra_Dev.Helpers;
using HSL_Infra_Dev.Interfaces;
using HSL_Infra_Dev.Models.InventoryModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HSL_Infra_Dev.Services.InventoryServices
{
    public class MaterialRequestImpl : IRequest
    {
        public int CreateRequest(MaterialRequest materialRequest)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                int Result=0;
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Request", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "CreateRequestHdr";
                    cmdDistrict.Parameters.Add("@DATE", SqlDbType.Date).Value = materialRequest.Date;
                    cmdDistrict.Parameters.Add("@TIME", SqlDbType.NVarChar).Value = materialRequest.Time;
                    cmdDistrict.Parameters.Add("@REQUESTER_NAME", SqlDbType.NVarChar).Value = materialRequest.Requester_Name;
                    cmdDistrict.Parameters.Add("@DEPARTMENT_ID", SqlDbType.Int).Value = materialRequest.Department_Id;
                    cmdDistrict.Parameters.Add("@DESCRIPTION", SqlDbType.NVarChar).Value = materialRequest.Description;
                    cmdDistrict.Parameters.Add("@COMMENTS", SqlDbType.NVarChar).Value = materialRequest.Comment;
                    cmdDistrict.Parameters.Add("@OutID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmdDistrict.ExecuteNonQuery();
                    int ID = Convert.ToInt32(cmdDistrict.Parameters["@OutID"].Value);
                    string ReqNumber = "MRI" + ID;
                    cmdDistrict.Parameters.Clear();
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "UpdateReqNo";
                    cmdDistrict.Parameters.Add("@REQUEST_NO", SqlDbType.NVarChar).Value = ReqNumber;
                    cmdDistrict.Parameters.Add("@REQUEST_HDR_ID", SqlDbType.Int).Value = ID;
                    cmdDistrict.Parameters.Add("@OutID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    Result = cmdDistrict.ExecuteNonQuery();
                    if (Result > 0)
                    {
                        foreach (var Items in materialRequest.RequestItemsList)
                        {
                            cmdDistrict.Parameters.Clear();
                            cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "CreateRequestDtl";
                            cmdDistrict.Parameters.Add("@REQUEST_HDR_ID", SqlDbType.Int).Value = ID;
                            cmdDistrict.Parameters.Add("@ITEM_ID", SqlDbType.Int).Value = Items.Item_Id;
                            cmdDistrict.Parameters.Add("@UOM_ID", SqlDbType.Int).Value = Items.Uom_Id;
                            cmdDistrict.Parameters.Add("@TO_LOCATION", SqlDbType.Int).Value = Items.To_Location;
                            cmdDistrict.Parameters.Add("@REQUEST_QUANTITY", SqlDbType.Decimal).Value = Items.Request_Quantity;
                            cmdDistrict.Parameters.Add("@COMMENTS", SqlDbType.NVarChar).Value = Items.Comment;
                            cmdDistrict.Parameters.Add("@OutID", SqlDbType.Int).Direction = ParameterDirection.Output;
                            Result = cmdDistrict.ExecuteNonQuery();
                        }
                    }
                    return Result;
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

        public int CreateIssue(MaterialRequest materialRequest)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                int Result = 0;
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Request", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "CreateIssueHdr";
                    cmdDistrict.Parameters.Add("@REQUEST_ID", SqlDbType.Int).Value = materialRequest.Request_Id;
                    cmdDistrict.Parameters.Add("@DATE", SqlDbType.Date).Value = materialRequest.Date;
                    cmdDistrict.Parameters.Add("@TIME", SqlDbType.NVarChar).Value = materialRequest.Time;
                    cmdDistrict.Parameters.Add("@REQUESTER_NAME", SqlDbType.NVarChar).Value = materialRequest.Requester_Name;
                    cmdDistrict.Parameters.Add("@DEPARTMENT_ID", SqlDbType.Int).Value = materialRequest.Department_Id;
                    cmdDistrict.Parameters.Add("@DESCRIPTION", SqlDbType.NVarChar).Value = materialRequest.Description;
                    cmdDistrict.Parameters.Add("@COMMENTS", SqlDbType.NVarChar).Value = materialRequest.Comment;
                    cmdDistrict.Parameters.Add("@OutID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmdDistrict.ExecuteNonQuery();
                    int ID = Convert.ToInt32(cmdDistrict.Parameters["@OutID"].Value);
                    string IssueNumber = "MII" + ID;
                    cmdDistrict.Parameters.Clear();
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "UpdateIssNo";
                    cmdDistrict.Parameters.Add("@REQUEST_NO", SqlDbType.NVarChar).Value = IssueNumber;
                    cmdDistrict.Parameters.Add("@REQUEST_HDR_ID", SqlDbType.Int).Value = ID;
                    cmdDistrict.Parameters.Add("@OutID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    Result = cmdDistrict.ExecuteNonQuery();
                    if (Result > 0)
                    {
                        foreach (var Items in materialRequest.RequestItemsList)
                        {
                            cmdDistrict.Parameters.Clear();
                            cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "CreateIssueDtl";
                            cmdDistrict.Parameters.Add("@REQUEST_HDR_ID", SqlDbType.Int).Value = ID;
                            cmdDistrict.Parameters.Add("@REQUEST_ID", SqlDbType.Int).Value = Items.Request_Id;
                            cmdDistrict.Parameters.Add("@ITEM_ID", SqlDbType.Int).Value = Items.Item_Id;
                            cmdDistrict.Parameters.Add("@UOM_ID", SqlDbType.Int).Value = Items.Uom_Id;
                            cmdDistrict.Parameters.Add("@TO_LOCATION", SqlDbType.Int).Value = Items.To_Location;
                            cmdDistrict.Parameters.Add("@REQUEST_QUANTITY", SqlDbType.Decimal).Value = Items.Request_Quantity;
                            cmdDistrict.Parameters.Add("@ISSUED_QUANTITY", SqlDbType.Decimal).Value = Items.Issued_Quantity;
                            cmdDistrict.Parameters.Add("@COMMENTS", SqlDbType.NVarChar).Value = Items.Comment;
                            cmdDistrict.Parameters.Add("@OutID", SqlDbType.Int).Direction = ParameterDirection.Output;
                            Result = cmdDistrict.ExecuteNonQuery();
                        }
                    }
                    return Result;
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

        public DataTable GetAllRequestHeader()
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Request", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "GetAllReqHdr";
                    cmdDistrict.Parameters.Add("@OutID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
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
        public DataTable GetAllRequestDetailById(int RequestId)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Request", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "GetReqDtlById";
                    cmdDistrict.Parameters.Add("@REQUEST_HDR_ID", SqlDbType.Int).Value = RequestId;
                    cmdDistrict.Parameters.Add("@OutID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
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

        public DataTable GetAllIssueDetailById(int RequestId)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_Request", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "GetIssDtlById";
                    cmdDistrict.Parameters.Add("@REQUEST_HDR_ID", SqlDbType.Int).Value = RequestId;
                    cmdDistrict.Parameters.Add("@OutID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
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