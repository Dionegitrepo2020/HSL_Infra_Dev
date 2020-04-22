using HSL_Infra_Dev.Interfaces;
using HSL_Infra_Dev.Models;
using HSL_Infra_Dev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HSL_Infra_Dev.Pages
{
    public partial class CompanyMaster : System.Web.UI.Page
    {
        ICompany companyService = new CompanyImpl();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txt_CompId_TextChanged(object sender, EventArgs e)
        {
            int CompanyId = Convert.ToInt32(txt_CompId.Text);
            Company company= companyService.GetCompany(CompanyId);
            txt_Address.Text = company.CompanyAddress;
            txt_Country.Text = company.CompanyCountry;
            txt_City.Text = company.CompanyCity;
            txt_Zip.Text = company.CompanyZip;

            txt_Email.Text = company.CompanyEmail;
            txt_Telephone.Text = company.CompanyTelephone;

            txt_userid.Text = company.CompanyUserid;
            txt_password.Text = company.CompanyPassword;

            foreach(var licenses in company.CompanyLicense)
            {
                var Product = licenses.Product;
                if (Product.Equals("Inventory"))
                    txt_InventoryKey.Text = licenses.LicenseKey;
                else if (Product.Equals("Purchase"))
                    txt_PurchaseKey.Text = licenses.LicenseKey;
                else
                    txt_SaleKey.Text = licenses.LicenseKey;
            }
        }
    }
}