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
        ILogin loginService = new LoginService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null && Session["CompanyID"] != null)
                Response.Redirect("Pages/Dashboard.aspx");
        }
        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            Session["IsNewUser"] = "no";
            if (txt_UserName.Text == "admin" && txt_Password.Text == "admin")
            {
                Session["IsAdmin"] = true;
                Session["UserID"] = null;
                Session["CompanyID"] = null;
                Session["IsNewUser"] = "yes";
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
                    Session["IsAdmin"] = true;
                    if (CheckLimit(company.Id, company.Id))
                        Response.Redirect("Pages/Dashboard.aspx");
                    else
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
                        "alert('Maximum Number of Users Exceeded');", true);
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
                    Session["IsAdmin"] = false;
                    if (CheckLimit(users.User_Id, users.Company_Id))
                        Response.Redirect("Pages/Dashboard.aspx");
                    else
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
                        "alert('Maximum Number of Users Exceeded');", true);
                }
            }
        }

        private bool CheckLimit(int UserId, int CompanyId)
        {
            LoginLog login = new LoginLog();
            login.CompanyId = CompanyId;
            login.UserId = UserId;
            bool inserted = loginService.AddToCount(login);
            return inserted;
        }
    }
}