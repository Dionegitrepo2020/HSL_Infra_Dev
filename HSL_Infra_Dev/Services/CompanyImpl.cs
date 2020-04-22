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
    public class CompanyImpl : ICompany
    {
        public Company GetCompany(int ComanyId)
        {
            using (SqlConnection connGetDistrict = ConnectionProvider.GetServerConnection())
            {
                try
                {
                    SqlCommand cmdDistrict = new SqlCommand("SP_License", connGetDistrict);
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.NVarChar).Value = "GetCompanyById";
                    cmdDistrict.Parameters.Add("@COMPANY_ID", SqlDbType.Char).Value = ComanyId;

                    SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Company company = new Company();
                    foreach (DataRow row in dt.Rows)
                    {
                        company.Id = Convert.ToInt32(row["COMPANY_ID"]);
                        company.CompanyName = row["COMPANY_NAME"].ToString();
                        company.CompanyAddress = row["COMPANY_ADDRESS"].ToString();
                        company.CompanyCountry = row["COMPANY_COUNTRY"].ToString();
                        company.CompanyCity = row["COMPANY_CITY"].ToString();
                        company.CompanyZip = row["COMPANY_ZIP"].ToString();
                        company.CompanyEmail = row["COMPANY_EMAIL"].ToString();
                        company.CompanyUserid = row["COMPANY_USER_ID"].ToString();
                        company.CompanyPassword = row["COMPANY_PASSWORD"].ToString();
                        company.CompanyTelephone = row["COMPANY_TELEPHONE"].ToString();
                        company.UserCount = row["COMPANY_TELEPHONE"].ToString();
                    }
                    cmdDistrict.Dispose();
                    cmdDistrict.Parameters.Clear();
                    cmdDistrict.CommandType = CommandType.StoredProcedure;
                    cmdDistrict.CommandTimeout = 250;
                    cmdDistrict.Parameters.Add("@flag", SqlDbType.NVarChar).Value = "GetLicensesById";
                    cmdDistrict.Parameters.Add("@COMPANY_ID", SqlDbType.Char).Value = ComanyId;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmdDistrict);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    List<CompanyLicense> companyLicenses = new List<CompanyLicense>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        CompanyLicense companyLicense = new CompanyLicense();
                        companyLicense.LicenseId = Convert.ToInt32(row["LICENSE_ID"]);
                        companyLicense.CompanyId = Convert.ToInt32(row["COMPANY_ID"]);
                        companyLicense.LicenseKey = row["LICENSE_KEY"].ToString();
                        companyLicense.Product = row["PRODUCT"].ToString();
                        companyLicense.Status = row["STATUS"].ToString();
                        companyLicense.RegistrationDate = Convert.ToDateTime(row["REGISTRATION_DATE"]);
                        companyLicense.ExpiryDate = Convert.ToDateTime(row["EXPIRY_DATE"]);
                        companyLicense.NotificationDays = Convert.ToInt32(row["NOTIFICATION_DAY"]);
                        companyLicenses.Add(companyLicense);
                    }
                    company.CompanyLicense = companyLicenses;

                    return company;
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