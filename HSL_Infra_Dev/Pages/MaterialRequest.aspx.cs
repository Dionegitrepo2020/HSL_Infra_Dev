using HSL_Infra_Dev.Interfaces;
using HSL_Infra_Dev.Models;
using HSL_Infra_Dev.Models.InventoryModels;
using HSL_Infra_Dev.Services;
using HSL_Infra_Dev.Services.InventoryServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HSL_Infra_Dev.Pages
{
    public partial class MaterialRequest : System.Web.UI.Page
    {
        DataTable dataTable = new DataTable();
        DataTable Requestdt = new DataTable();
        IItem item = new ItemImpl();
        IUOM uomsService = new UOMImpl();
        ILocation locationService = new LocationImpl();
        IDepartment departmentService = new DepartmentImpl();
        IStock stockService = new StockImpl();
        IUsers usersService = new UsersImpl();
        IRequest requestService = new MaterialRequestImpl();
        ICompany companyService = new CompanyImpl();
        protected void Page_Load(object sender, EventArgs e)
        {
            dataTable.Columns.Add("ITEM_ID");
            dataTable.Columns.Add("ITEM_DESC");
            dataTable.Columns.Add("LOCATION_ID");
            dataTable.Columns.Add("TOTALQTY");
            LoadGridTable();
            LoadUserData();
            LoadUoms();
            Loadlocations();
            if (ViewState["RequestData"] == null)
            {
                Requestdt.Columns.Add("Item_ID");
                Requestdt.Columns.Add("Item_Description");
                Requestdt.Columns.Add("UOM");
                Requestdt.Columns.Add("Location");
                Requestdt.Columns.Add("Quantity");
                Requestdt.Columns.Add("Comment");
                ViewState["RequestData"] = Requestdt;
            }
        }

        private void LoadUserData()
        {
            ddlDepartment.Items.Clear();

            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                Company company = companyService.GetCompany(Convert.ToInt32(Session["CompanyID"]));
                List<Department> departments = departmentService.GetDepartment();
                foreach (var department in departments)
                    ddlDepartment.Items.Add(new ListItem(department.Department_Description, department.Id.ToString()));
                txtRequesterName.Text = company.CompanyName;
            }
            else
            {
                Users usersModel = usersService.GetUsers(Convert.ToInt32(Session["UserID"]));
                Department department = departmentService.GetDepartment(usersModel.Department_Id);
                ddlDepartment.Items.Add(new ListItem(department.Department_Description, department.Id.ToString()));
                txtRequesterName.Text = usersModel.Name;
            }
        }

        private void Loadlocations()
        {
            ddlLocations.Items.Clear();
            List<Location> locations = new List<Location>();
            locations = locationService.GetLocation();
            foreach (var location in locations)
            {
                ddlLocations.Items.Add(new ListItem(location.Location_Description, location.Id.ToString()));
            }
        }

        private void LoadUoms()
        {
            ddluom.Items.Clear();
            List<UOM> uoms = new List<UOM>();
            uoms = uomsService.GetUOMs();
            foreach (var uom in uoms)
            {
                ddluom.Items.Add(new ListItem(uom.uom_desc, uom.Id.ToString()));
            }
        }

        private void LoadGridTable()
        {
            dataTable = item.GetItemsDataTable();
            grdvCrudOperation.DataSource = dataTable;
            grdvCrudOperation.DataBind();
        }

        protected void grdvCrudOperation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell locCell = e.Row.Cells[2];
                Location location = locationService.GetLocation(Convert.ToInt32(locCell.Text));
                locCell.Text = location.Location_Description;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (validateMaterial())
            {
                Requestdt = (DataTable)ViewState["RequestData"];
                Requestdt.Rows.Add(txtItemID.Text, txtItemDesc.Text, ddluom.SelectedItem.Value, ddlLocations.SelectedItem.Value, txtQuantity.Text, txtComment.Text);
                GridView1.DataSource = Requestdt;
                GridView1.DataBind();
                clearMaterialDetail();
            }
            else ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
                        "alert('Please fill all the feilds');", true);
        }

        private void clearMaterialDetail()
        {
            txtItemID.Text = "";
            txtItemDesc.Text = "";
            ddluom.SelectedIndex = -1;
            ddlLocations.SelectedIndex = -1;
            txtQuantity.Text = "";
            txtComment.Text = "";
        }

        private bool validateMaterial()
        {
            if (txtItemID.Text != "" && txtItemDesc.Text != "" && txtQuantity.Text != "") return true;
            else return false;
        }

        protected void deleterow_ServerClick(object sender, EventArgs e)
        {
            var DeletButton = (Control)sender;
            GridViewRow row = (GridViewRow)DeletButton.NamingContainer;
            GridView1.DeleteRow(row.RowIndex);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            Requestdt = (DataTable)ViewState["RequestData"];
            Requestdt.Rows[index].Delete();
            GridView1.DataSource = Requestdt;
            GridView1.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Models.InventoryModels.MaterialRequest materialRequest = new Models.InventoryModels.MaterialRequest();
            materialRequest.Date = Convert.ToDateTime(txtDate.Text);
            materialRequest.Time = Convert.ToDateTime(txtTime.Text);
            materialRequest.Requester_Name = txtRequesterName.Text;
            materialRequest.Department_Id = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
            materialRequest.Description = txtDescription.Text;
            materialRequest.Comment = txtReqComment.Text;
            List<RequestItems> reqItemsList = new List<RequestItems>();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                RequestItems Items = new RequestItems();
                Items.Item_Id = Convert.ToInt32(GridView1.Rows[i].Cells[0].Text);
                Items.To_Location = Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);
                Items.Uom_Id = Convert.ToInt32(GridView1.Rows[i].Cells[2].Text);
                Items.Request_Quantity = Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text);
                Items.Comment = GridView1.Rows[i].Cells[5].Text;
                reqItemsList.Add(Items);
            }
            materialRequest.RequestItemsList = reqItemsList;
            int Result = requestService.CreateRequest(materialRequest);
            if (Result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
                        "alert('Request Created');", true);
                ResetPage();
            }
            else ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
                       "alert('Something went wrong');", true);

        }

        private void ResetPage()
        {
            txtDate.Text = "";
            txtTime.Text = "";
            txtDescription.Text = "";
            txtReqComment.Text = "";
            ViewState["RequestData"] = null;
            Requestdt = (DataTable)ViewState["RequestData"];
            GridView1.DataSource = Requestdt;
            GridView1.DataBind();
        }
    }
}