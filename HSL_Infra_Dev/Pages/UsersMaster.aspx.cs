using HSL_Infra_Dev.Helpers;
using HSL_Infra_Dev.Interfaces;
using HSL_Infra_Dev.Models;
using HSL_Infra_Dev.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HSL_Infra_Dev.Pages
{
    public partial class UsersMaster : System.Web.UI.Page
    {
        DataTable dataTable = new DataTable();
        ICompany companyService = new CompanyImpl();
        IDepartment departmentService = new DepartmentImpl();
        IUsers usersService = new UsersImpl();
        ListtoDataTableConverter converter = new ListtoDataTableConverter();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCompany.Attributes.Add("ReadOnly","true");

            //Adding  columns to datatable
            dataTable.Columns.Add("USER_ID");
            dataTable.Columns.Add("COMPANY_ID");
            dataTable.Columns.Add("USER_NAME");
            dataTable.Columns.Add("USER_PASSWORD");
            dataTable.Columns.Add("NAME");
            dataTable.Columns.Add("DEPARTMENT_ID");
            dataTable.Columns.Add("ROLE_ID");
            dataTable.Columns.Add("ISACTIVE");
            dataTable.Columns.Add("CREATED_DATE");
            dataTable.Columns.Add("MODIFIED_DATE");
            LoadGridTable();

            if (!Page.IsPostBack)
            {
                Company company = companyService.GetCompany(Convert.ToInt32(Session["CompanyID"]));
                txtCompany.Text = company.CompanyName;
                LoadDepartment();
            }
        }

        private void LoadGridTable()
        {
            List<Users> users = usersService.GetUsers();
            dataTable = converter.ToDataTable(users, dataTable);
            grdvCrudOperation.DataSource = dataTable;
            grdvCrudOperation.DataBind();
        }

        private void LoadDepartment()
        {
            List<Department> departments = new List<Department>();
            departments = departmentService.GetDepartment();
            foreach (var dept in departments)
            {
                ddlDepts.Items.Add(new ListItem(dept.Department_Description, dept.Id.ToString()));
            }
        }

        protected void SaveUser_Button_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Company_Id = Convert.ToInt32(Session["CompanyID"]);
            users.Name = txtFullName.Text;
            users.User_Name = txtUserName.Text;
            users.User_Password = txtPassword.Text;
            users.Department_Id= Convert.ToInt32(ddlDepts.SelectedItem.Value);
            //Hardcoded value passing
            users.Role_Id = 2;
            users.Is_Active = true;
            int Createresult = usersService.CreateUsers(users);
            LoadGridTable();
            if (Createresult>0)
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success",
                        "alert('User Created');", true);
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success",
                        "alert('Something went wrong');", true);
        }

        protected void grdvCrudOperation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell compId = e.Row.Cells[1];
                Company company = companyService.GetCompany(Convert.ToInt32(compId.Text));
                compId.Text = company.CompanyName;

                TableCell deptCell = e.Row.Cells[5];
                Department department = departmentService.GetDepartment(Convert.ToInt32(deptCell.Text));
                deptCell.Text = department.Department_Description;
            }
        }
    }
}