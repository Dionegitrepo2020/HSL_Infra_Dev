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
        int max;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowMessage();
            }
        }

        private void ShowMessage()
        {
            DateTime ExpDate = Convert.ToDateTime(ConfigurationManager.AppSettings["ExpDate"].ToString());
            DateTime CurDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan t = ExpDate - CurDate;
            double days = t.TotalDays;
            if (days > 0)
            {

            }
            else
            { ErrMsg.Visible = true; }
            int webmax = Convert.ToInt32(ConfigurationManager.AppSettings["max"]);
            webmax += 1;

        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Pages/Dashboard.aspx");
        }
    }
}