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
    public partial class SideBarMaster : System.Web.UI.MasterPage
    {
        ICompany companyService = new CompanyImpl();
        IUsers usersService = new UsersImpl();
        ILogin loginService = new LoginService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Department.HRef = "#";
                UOM.HRef = "#";
                Location.HRef = "#";
                MaterialIssue.HRef = "#";
                MaterialRequest.HRef = "#";
            }
            if(Session["IsNewUser"]==null) CheckSessions();
            else if (!Session["IsNewUser"].Equals("yes")) CheckSessions();
            VisibilityAll(false);
            LoadNavItems();
            LoadUserData();
            LoadLicenseExpDate();
            LoadMasters();
        }

        private void LoadMasters()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                Masters.Visible = true;
            }
            else
            {
                Masters.Visible = false;
            }
        }

        private void LoadLicenseExpDate()
        {
            Company company = companyService.GetCompany(Convert.ToInt32(Session["CompanyID"]));
            foreach(var license in company.CompanyLicense)
            {
                DateTime CurrentDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                DateTime ExpiryDate = Convert.ToDateTime(license.ExpiryDate);
                TimeSpan difference = ExpiryDate - CurrentDate;
                if (Convert.ToInt32(license.NotificationDays) >= difference.TotalDays)
                {
                    WarnContent.Visible = true;
                    WarnContentText.InnerHtml += "\n"+license.Product + " Expires in " + difference.TotalDays + " days | ";
                }
            }
        }

        private void LoadUserData()
        {
            Company company = companyService.GetCompany(Convert.ToInt32(Session["CompanyID"]));
            Users users = usersService.GetUsers(Convert.ToInt32(Session["UserID"]));
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                User_Name.InnerHtml = company.CompanyName;
                SidebarBrand.InnerHtml = company.CompanyName;
            }
            else
            {
                Company companyData = companyService.GetCompany(Convert.ToInt32(users.Company_Id));
                User_Name.InnerHtml = users.Name;
                SidebarBrand.InnerHtml = companyData.CompanyName;
            }
        }

        private void VisibilityAll(bool Visibilty)
        {
            MaterialRequest.Visible = Visibilty;
            MaterialIssue.Visible = Visibilty;

            P_Request.Visible = Visibilty;
            P_Order.Visible = Visibilty;
            P_Receipt.Visible = Visibilty;

            S_Qoutation.Visible = Visibilty;
            S_Order.Visible = Visibilty;
            S_Delivery.Visible = Visibilty;
        }

        private void LoadNavItems()
        {
            Company company = companyService.GetCompany(Convert.ToInt32(Session["CompanyID"]));
            List<CompanyLicense> companyLicensesList = company.CompanyLicense;
            foreach (var module in companyLicensesList)
            {
                if (module.Product.Equals("Inventory")&&module.Status.Equals("Activated"))
                {
                    EnableInventory(true, true);
                }
                if (module.Product.Equals("Purchase") && module.Status.Equals("Activated"))
                {
                    EnablePurchase(true, true, true);
                }
                if (module.Product.Equals("Sale") && module.Status.Equals("Activated"))
                {
                    EnableSales(true, true, true);
                }

                switch (module.Product)
                {
                    case "Inventory":
                        if (module.Product.Equals("Inventory") && module.Status.Equals("New"))
                        {
                            InventoryAlert.InnerHtml = "Action Needed";
                        }
                        else if (module.Product.Equals("Inventory") && module.Status.Equals("Expired"))
                        {
                            InventoryAlert.InnerHtml = "Expired";
                        }
                        break;
                    case "Purchase":
                        if (module.Product.Equals("Purchase") && module.Status.Equals("New"))
                        {
                            PurchaseAlert.InnerHtml = "Action Needed";
                        }
                        else if (module.Product.Equals("Purchase") && module.Status.Equals("Expired"))
                        {
                            PurchaseAlert.InnerHtml = "Expired";
                        }
                        break;
                    case "Sale":
                        if (module.Product.Equals("Sale") && module.Status.Equals("New"))
                        {
                            saleAlert.InnerHtml = "Action Needed";
                        }
                        else if (module.Product.Equals("Sale") && module.Status.Equals("Expired"))
                        {
                            saleAlert.InnerHtml = "Expired";
                        }
                        break;
                }
            }
        }

        public void EnableInventory(bool RequestVisible, bool IssueVisible)
        {
            MaterialRequest.Visible = RequestVisible;
            MaterialIssue.Visible = IssueVisible;
            InventoryAlert.Visible = false;
        }

        public void EnablePurchase(bool P_RequestVisible, bool P_OrderVisible, bool P_ReceiptVisible)
        {
            P_Request.Visible = P_RequestVisible;
            P_Order.Visible = P_OrderVisible;
            P_Receipt.Visible = P_ReceiptVisible;
            PurchaseAlert.Visible = false;
        }

        public void EnableSales(bool S_QoutationVisible, bool S_OrderVisible, bool S_DeliveryVisible)
        {
            S_Qoutation.Visible = S_QoutationVisible;
            S_Order.Visible = S_OrderVisible;
            S_Delivery.Visible = S_DeliveryVisible;
            saleAlert.Visible = false;
        }

        protected void btnLogout_ServerClick(object sender, EventArgs e)
        {
            LoginLog login = new LoginLog();
            login.UserId =Convert.ToInt32(Session["UserID"]);
            login.CompanyId = Convert.ToInt32(Session["CompanyID"]);
            bool logout = loginService.RemoveFromCount(login);
            //if (logout)
            //{
                Session["UserID"] = null;
                Session["CompanyID"] = null;
                CheckSessions();
            //}
        }

        private void CheckSessions()
        {
            if (Session["UserID"]==null&& Session["CompanyID"]==null)
                Response.Redirect("~/LoginRegistrationForm.aspx");
        }
    }
}