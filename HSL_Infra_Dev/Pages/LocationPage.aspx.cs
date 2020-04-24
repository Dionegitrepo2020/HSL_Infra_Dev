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
    public partial class LocationPage : System.Web.UI.Page
    {
        DataTable dataTable = new DataTable();
        ILocation location = new LocationImpl();
        IDepartment departmentService = new DepartmentImpl();
        ListtoDataTableConverter converter = new ListtoDataTableConverter();
        protected void Page_Load(object sender, EventArgs e)
        {
            dataTable.Columns.Add("LOCATION_ID");
            dataTable.Columns.Add("LOCATION_DESC");
            dataTable.Columns.Add("DEPARTMENT_ID");
            dataTable.Columns.Add("ISACTIVE");
            dataTable.Columns.Add("CREATED_DATE");
            dataTable.Columns.Add("MODIFIED_DATE");
            LoadGridTable();
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            List<Department> departments = new List<Department>();
            departments = departmentService.GetDepartment();
            foreach(var dept in departments)
            {
                ddlDepts.Items.Add(new ListItem(dept.Department_Description,dept.Id.ToString()));
            }
        }

        private void LoadGridTable()
        {
            List<Location> locations = location.GetLocation();
            dataTable = converter.ToDataTable(locations, dataTable);
            grdvCrudOperation.DataSource = dataTable;
            grdvCrudOperation.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Location locations = new Location();
            locations.Location_Description = txt_loationdesc.Text;
            locations.Department_id = Convert.ToInt32(ddlDepts.SelectedItem.Value);
            locations.Is_Active = chkActive.Checked ? true : false;
            string result = location.CreateLocation(locations);
            dataTable.Rows.Clear();
            LoadGridTable();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            var DeletButton = (Control)sender;
            GridViewRow row = (GridViewRow)DeletButton.NamingContainer;
            int Loc_ID = Convert.ToInt32(row.Cells[0].Text);
            int DeleteResult = location.DeleteLocation(Loc_ID);
            if (DeleteResult > 0)
            {
                dataTable.Rows.Clear();
                LoadGridTable();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success",
                        "alert('Location : " + Loc_ID + " was deleted');", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
                        "alert('Something went wrong');", true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
                        "confirm('Do you want to delete?');", true);
            Location locations = new Location();
            locations.Id = Convert.ToInt32(txt_Locationid.Text);
            locations.Location_Description= txt_loationdesc.Text;
            locations.Department_id = Convert.ToInt32(ddlDepts.SelectedItem.Value);
            locations.Is_Active = chkActive.Checked ? true : false;
            string result = location.UpdateLocation(locations);
            if (result.Equals("Updated"))
            {
                dataTable.Rows.Clear();
                LoadGridTable();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success",
                        "alert('Location : " + txt_Locationid.Text + " was updated');", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
                        "alert('Something went wrong');", true);
        }

        protected void grdvCrudOperation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                    TableCell deptCell = e.Row.Cells[2];
                    Department department = departmentService.GetDepartment(Convert.ToInt32(deptCell.Text));
                    deptCell.Text = department.Department_Description;
                //TableCell statusCell = e.Row.Cells[2];
                //if (statusCell.Text == "A")
                //{
                //    statusCell.Text = "Absent";
                //}
                //if (statusCell.Text == "P")
                //{
                //    statusCell.Text = "Present";
                //}
            }
        }
    }
}