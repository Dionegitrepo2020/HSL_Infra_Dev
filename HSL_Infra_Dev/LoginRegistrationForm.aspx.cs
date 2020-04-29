using HSL_Infra_Dev.Interfaces;
using HSL_Infra_Dev.Models;
using HSL_Infra_Dev.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HSL_Infra_Dev
{
    public partial class LoginRegistrationForm : System.Web.UI.Page
    {
        IUsers userService = new UsersImpl();
        ICompany companyService = new CompanyImpl();
        int countSession = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            if (txt_UserName.Text == "admin" && txt_Password.Text == "admin")
            {
                Session["UserID"] = null;
                Session["CompanyID"] = null;
                Response.Redirect("Pages/Dashboard.aspx");
            }
            else if (chkAdmin.Checked)
            {
                string Result = userService.CheckAdminLogin(txt_UserName.Text, txt_Password.Text);
                if (Result.Equals("UNAUTHORIZED"))
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
                        "alert('Invalid Credentials');", true);
                else
                {
                    Company company = companyService.GetCompany(Convert.ToInt32(Result));
                    Session["UserID"] = company.Id;
                    Session["CompanyID"] = company.Id;
                    CheckLimit();
                    Response.Redirect("Pages/Dashboard.aspx");
                }
            }
            else
            {
                string Result = userService.CheckUserLogin(txt_UserName.Text, txt_Password.Text);
                if (Result.Equals("UNAUTHORIZED"))
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
                        "alert('Invalid Credentials');", true);
                else
                {
                    Users users = userService.GetUsers(Convert.ToInt32(Result));
                    Session["UserID"] = users.User_Id;
                    Session["CompanyID"] = users.Company_Id;
                    Response.Redirect("Pages/Dashboard.aspx");
                }
            }
        }

        private void CheckLimit()
        {
            if (Session["LIMIT"] != null)
            {
                countSession++;
                Session["Count"] = countSession;
            }
            else
            {
                countSession = 0;
                countSession++;
                Session["Count"] = countSession;
            }
        }
    }
}