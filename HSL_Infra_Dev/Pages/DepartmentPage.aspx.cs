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
    public partial class DepartmentPage : System.Web.UI.Page
    {
        DataTable dataTable = new DataTable();
        IDepartment department = new DepartmentImpl();
        ListtoDataTableConverter converter = new ListtoDataTableConverter();
        protected void Page_Load(object sender, EventArgs e)
        {
            //dataTable = new DataTable();
            dataTable.Columns.Add("DEPARTMENT_ID");
            dataTable.Columns.Add("DEPARTMENT_DESC");
            dataTable.Columns.Add("ISACTIVE");
            dataTable.Columns.Add("CREATED_DATE");
            dataTable.Columns.Add("MODIFIED_DATE");
            LoadGridTable();
        }

        private void LoadGridTable()
        {
            List<Department> departments = department.GetDepartment();
            dataTable = converter.ToDataTable(departments,dataTable);
            grdvCrudOperation.DataSource = dataTable;
            grdvCrudOperation.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Department departments = new Department();
            departments.Department_Description = txt_DeptDesc.Text;
            departments.Is_Active = chkActive.Checked ? true : false;
            string result = department.CreateDepartment(departments);
            dataTable.Rows.Clear();
            LoadGridTable();
        }
    }
}