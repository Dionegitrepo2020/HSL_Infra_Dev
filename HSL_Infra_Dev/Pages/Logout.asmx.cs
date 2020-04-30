using HSL_Infra_Dev.Interfaces;
using HSL_Infra_Dev.Models;
using HSL_Infra_Dev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace HSL_Infra_Dev.Pages
{
    /// <summary>
    /// Summary description for Logout
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Logout : System.Web.Services.WebService
    {
        ILogin loginService = new LoginService();

        [WebMethod(EnableSession = true)]
        public string LogoutMethod()
        {
            // take a log.txt and write on there with time
            LoginLog login = new LoginLog();
            login.UserId = Convert.ToInt32(Session["UserID"]);
            login.CompanyId = Convert.ToInt32(Session["CompanyID"]);
            bool logout = loginService.RemoveFromCount(login);
            return "";
        }
    }
}
