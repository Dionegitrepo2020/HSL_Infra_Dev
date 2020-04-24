using HSL_Infra_Dev.Interfaces;
using HSL_Infra_Dev.Models;
using HSL_Infra_Dev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

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
            txt_CompName.Text = company.CompanyName;
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

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Company company = new Company();
            company.Id = Convert.ToInt32(txt_CompId.Text);
            company.CompanyName = Request.Form[txt_CompName.UniqueID];
            company.CompanyAddress = Request.Form[txt_Address.UniqueID];
            company.CompanyCountry = Request.Form[txt_Country.UniqueID];
            company.CompanyCity = Request.Form[txt_City.UniqueID];
            company.CompanyZip = Request.Form[txt_Zip.UniqueID];

            company.CompanyEmail = Request.Form[txt_Email.UniqueID];
            company.CompanyTelephone = Request.Form[txt_Telephone.UniqueID];

            company.CompanyUserid = Request.Form[txt_userid.UniqueID];
            company.CompanyPassword = Request.Form[txt_password.UniqueID];

            List<CompanyLicense> licenseList=new List<CompanyLicense>();
            if (txt_InventoryKey.Text != "")
            {
                CompanyLicense companyLicense = new CompanyLicense();
                companyLicense.LicenseKey = Request.Form[txt_InventoryKey.UniqueID];
                licenseList.Add(companyLicense);
            }
            if (txt_PurchaseKey.Text != "")
            {
                CompanyLicense companyLicense = new CompanyLicense();
                companyLicense.LicenseKey = Request.Form[txt_PurchaseKey.UniqueID];
                licenseList.Add(companyLicense);
            }
            if (txt_SaleKey.Text != "")
            {
                CompanyLicense companyLicense = new CompanyLicense();
                companyLicense.LicenseKey = Request.Form[txt_SaleKey.UniqueID];
                licenseList.Add(companyLicense);
            }
            company.CompanyLicense = licenseList;
            string result= companyService.UpdateCompany(company);
            MessageBox.Show(result);
            MessageBox.Show("You need to login again to apply changes");
            Response.Redirect("~/LoginRegistrationForm.aspx");
        }
    }
}