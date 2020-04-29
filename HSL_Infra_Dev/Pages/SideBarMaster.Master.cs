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
            count.InnerHtml = Session["Count"].ToString();
            VisibilityAll(false);
            LoadNavItems();
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

                if (module.Product.Equals("Sale") && module.Status.Equals("New"))
                {
                    saleAlert.Visible = true;
                    saleAlert.InnerHtml = "Action Needed";
                }else if(module.Product.Equals("Sale") && module.Status.Equals("Expired"))
                {
                    saleAlert.Visible = true;
                    saleAlert.InnerHtml = "Expired";
                }

                if (module.Product.Equals("Purchase") && module.Status.Equals("New"))
                {
                    PurchaseAlert.Visible = true;
                    PurchaseAlert.InnerHtml = "Action Needed";
                }
                else if (module.Product.Equals("Purchase") && module.Status.Equals("Expired"))
                {
                    PurchaseAlert.Visible = true;
                    PurchaseAlert.InnerHtml = "Expired";
                }

                if (module.Product.Equals("Inventory") && module.Status.Equals("New"))
                {
                    InventoryAlert.Visible = true;
                    InventoryAlert.InnerHtml = "Action Needed";
                }
                else if (module.Product.Equals("Inventory") && module.Status.Equals("Expired"))
                {
                    InventoryAlert.Visible = true;
                    InventoryAlert.InnerHtml = "Expired";
                }

                if (MaterialRequest.Visible == false && MaterialIssue.Visible == false)
                {
                    InventoryAlert.Visible = true;
                    InventoryAlert.InnerHtml = "Not Licensed";
                }
                if (P_Order.Visible == false && P_Receipt.Visible == false && P_Request.Visible == false)
                {
                    PurchaseAlert.Visible = true;
                    PurchaseAlert.InnerHtml = "Not Licensed";
                }
                if (S_Qoutation.Visible == false&&S_Order.Visible==false&&S_Delivery.Visible==false)
                {
                    saleAlert.Visible = true;
                    saleAlert.InnerHtml = "Not Licensed";
                }
            }
        }

        public void EnableInventory(bool RequestVisible, bool IssueVisible)
        {
            MaterialRequest.Visible = RequestVisible;
            MaterialIssue.Visible = IssueVisible;
        }

        public void EnablePurchase(bool P_RequestVisible, bool P_OrderVisible, bool P_ReceiptVisible)
        {
            P_Request.Visible = P_RequestVisible;
            P_Order.Visible = P_OrderVisible;
            P_Receipt.Visible = P_ReceiptVisible;
        }

        public void EnableSales(bool S_QoutationVisible, bool S_OrderVisible, bool S_DeliveryVisible)
        {
            S_Qoutation.Visible = S_QoutationVisible;
            S_Order.Visible = S_OrderVisible;
            S_Delivery.Visible = S_DeliveryVisible;
        }
    }
}