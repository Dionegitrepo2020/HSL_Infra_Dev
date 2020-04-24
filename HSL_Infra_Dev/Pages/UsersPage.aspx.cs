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
    public partial class UsersPage : System.Web.UI.Page
    {
        DataTable dataTable = new DataTable();
        IUsers users = new UsersImpl();
        ListtoDataTableConverter converter = new ListtoDataTableConverter();
        protected void Page_Load(object sender, EventArgs e)
        {
            dataTable.Columns.Add("USER_ID");
            dataTable.Columns.Add("USER_NAME");
            //dataTable.Columns.Add("USER_PASSWORD");
            dataTable.Columns.Add("DEPARTMENT_ID");
            dataTable.Columns.Add("ROLE_ID");
            dataTable.Columns.Add("ISACTIVE");
            dataTable.Columns.Add("CREATED_DATE");
            dataTable.Columns.Add("MODIFIED_DATE");
            LoadGridTable();
        }

        private void LoadGridTable()
        {
            List<Users> user = users.GetUsers();
            dataTable = converter.ToDataTable(user, dataTable);
            grdvCrudOperation.DataSource = dataTable;
            grdvCrudOperation.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Users user = new Users();
            //user.USER_NAME = txt_UserName.Text;
            //user.USER_PASSWORD = txt_UserPass.Text;
            //user.Department_id = Convert.ToInt32(txt_DeptId.Text);
            //user.Role_id = Convert.ToInt32(txt_Role.Text);
            //user.Is_Active = chkActive.Checked ? true : false;
            //string result = users.CreateUser(user);
            //dataTable.Rows.Clear();
            //LoadGridTable();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            //var DeletButton = (Control)sender;
            //GridViewRow row = (GridViewRow)DeletButton.NamingContainer;
            //int Dept_ID = Convert.ToInt32(row.Cells[0].Text);
            //int DeleteResult = department.DeleteDepartment(Dept_ID);
            //if (DeleteResult > 0)
            //{
            //    dataTable.Rows.Clear();
            //    LoadGridTable();
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success",
            //            "alert('Department : " + Dept_ID + " was deleted');", true);
            //}
            //else
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
            //            "alert('Something went wrong');", true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
            //            "confirm('Do you want to delete?');", true);
            //Department departments = new Department();
            //departments.Id = Convert.ToInt32(txt_DeptId.Text);
            //departments.Department_Description = txt_DeptDesc.Text;
            //departments.Is_Active = chkActive.Checked ? true : false;
            //string result = department.UpdateDepartment(departments);
            //if (result.Equals("Updated"))
            //{
            //    dataTable.Rows.Clear();
            //    LoadGridTable();
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success",
            //            "alert('Department : " + txt_DeptId.Text + " was updated');", true);
            //}
            //else
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
            //            "alert('Something went wrong');", true);
        }
    }
}