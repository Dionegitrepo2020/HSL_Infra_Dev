<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/SideBarMaster.Master" AutoEventWireup="true" CodeBehind="MaterialRequest.aspx.cs" Inherits="HSL_Infra_Dev.Pages.InventoryModule.MaterialRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>HIMATSINGKA</title>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">
        <script src="../../Scripts/jquery-3.0.0.min.js"></script>
        <script src="../../Scripts/jquery-ui.js"></script>
        <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.css" />
        <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css" />
        <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js"></script>
        <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap4.min.js"></script>
    </head>
    <body class="bg-light">
        <form runat="server">
            <div class="container-fluid shadow bg-white mb-2">
                <div class="row">
                    <h5 class="col align-items-centert m-1">MATERIAL REQUISITION</h5>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Requisition No :</label>
                            <input type="text" class="form-control ml-1" placeholder="Requisition No" aria-label="Recipient's username" aria-describedby="basic-addon2">
                            <div class="input-group-append">
                                <i runat="server" class="input-group-text fa fa-search" id="btnSearch"></i>
                                <i runat="server" class="input-group-text fa fa-file" id="I3"></i>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Date :</label>
                            <input type="text" class="form-control ml-1" placeholder="Date" aria-label="Recipient's username" aria-describedby="basic-addon2">
                            <div class="input-group-append">
                                <i runat="server" class="input-group-text fa fa-calendar" id="I1"></i>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Time :</label>
                            <input type="text" class="form-control ml-1" placeholder="Time" aria-label="Recipient's username" aria-describedby="basic-addon2">
                            <div class="input-group-append">
                                <i runat="server" class="input-group-text fa fa-clock-o" id="I2"></i>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Requester Name :</label>
                            <input type="text" class="form-control ml-1" placeholder="Requester Name" aria-label="Recipient's username" aria-describedby="basic-addon2">
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Department :</label>
                            <asp:DropDownList runat="server" ID="DropDownList1" CssClass="custom-select rounded-0 ml-1">
                                <asp:ListItem Text="----Select Deprtment----" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="input-group mb-3">
                            <input type="text" class="form-control ml-1" aria-label="Recipient's username" aria-describedby="basic-addon2">
                        </div>
                    </div>

                    <div class="col-sm-12">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Description :</label>
                            <input type="text" class="form-control ml-1" placeholder="Description" aria-label="Recipient's username" aria-describedby="basic-addon2">
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Comments :</label>
                            <input type="text" class="form-control ml-1" placeholder="Comments" aria-label="Recipient's username" aria-describedby="basic-addon2">
                        </div>
                    </div>
                </div>
            </div>

            <%--ADD ITEMS TO GRIDVIEW--%>
            <div class="container-fluid shadow bg-white mt-2">
                <div class="row">
                    <h5 class="col align-items-centert m-1">ADD ITEMS</h5>
                </div>
                <div class="row">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-sm-2">
                                <div class="form-group">
                                    <label for="txtpono" class="col-form-label">Item ID</label>
                                    <div class="input-group mb-3">
                                        <input type="text" class="form-control ml-1" placeholder="Item ID" aria-label="Recipient's username" aria-describedby="basic-addon2">
                                        <div class="input-group-append">
                                            <i class="input-group-text fa fa-search" data-toggle="modal" data-target="#exampleModal"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-2">
                                <div class="form-group">
                                    <label for="txtpono" class="col-form-label">Description</label>
                                    <asp:TextBox ID="txtItemDesc" class="form-control rounded-0" runat="server" />
                                </div>
                            </div>

                            <div class="col-sm-2">
                                <div class="form-group">
                                    <label for="txtpono" class="col-form-label">UOM</label>
                                    <asp:DropDownList runat="server" ID="ddluom" CssClass="form-control dropdown">
                                        <asp:ListItem Text="----Select Uom----" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-sm-2">
                                <div class="form-group">
                                    <label for="txtpono" class="col-form-label">Location</label>
                                    <asp:DropDownList runat="server" ID="ddlLocations" CssClass="form-control dropdown">
                                        <asp:ListItem Text="----Select Locations----" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-sm-1">
                                <div class="form-group">
                                    <label for="txtpono" class="col-form-label">Quantity</label>
                                    <asp:TextBox ID="txtQuantity" class="form-control rounded-0" runat="server" />
                                </div>
                            </div>

                            <div class="col-sm-2">
                                <div class="form-group">
                                    <label for="txtpono" class="col-form-label">Comment</label>
                                    <asp:TextBox ID="txtComment" class="form-control rounded-0" runat="server" />
                                </div>
                            </div>

                            <div class="col-sm-1">
                                <div class="form-group">
                                    <label for="txtpono" class="col-form-label invisible">Comment</label>
                                    <asp:Button ID="btnAdd" class="btn btn-success" runat="server" Text="Add" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <asp:GridView ID="grdvCrudOperation" runat="server" HorizontalAlign="Center" OnRowDataBound="grdvCrudOperation_RowDataBound"
                                AutoGenerateColumns="false" CssClass="table table-bordered table-sm table-striped table-hover">
                                <Columns>
                                    <asp:BoundField DataField="ITEM_ID" HeaderText="ITEM ID" />
                                    <asp:BoundField DataField="ITEM_DESC" HeaderText="ITEM DESCRIPTION" />
                                    <asp:BoundField DataField="LOCATION_ID" HeaderText="LOCATION" />
                                    <asp:BoundField DataField="TOTALQTY" HeaderText="QUANTITY" />
                                    <%--<asp:BoundField DataField="CREATED_DATE" HeaderText="CREATED DATE" />
                                <asp:BoundField DataField="MODIFIED_DATE" HeaderText="MODIFIED DATE" />--%>
                                    <asp:TemplateField HeaderText="ACTION" ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <i class="fa fa-lg fa-edit" id="edtRow" data-toggle="modal" data-target="#exampleModal" style="color: dodgerblue"></i>
                                            <a class="fa fa-lg fa-trash" runat="server" style="color: red"></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>THERE ARE NO ITEMS CREATED YET</EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

            <%-- Modal --%>
            <div class="modal" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Create Item</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="container-fluid">
                                <asp:GridView ID="grdvCrudOperation1" runat="server" HorizontalAlign="Center" OnRowDataBound="grdvCrudOperation_RowDataBound"
                                    AutoGenerateColumns="false" CssClass="table table-bordered table-sm table-striped table-hover">
                                    <Columns>
                                        <asp:BoundField DataField="ITEM_ID" HeaderText="ITEM ID" />
                                        <asp:BoundField DataField="ITEM_DESC" HeaderText="ITEM DESCRIPTION" />
                                        <asp:BoundField DataField="LOCATION_ID" HeaderText="LOCATION" />
                                        <asp:BoundField DataField="TOTALQTY" HeaderText="QUANTITY" />
                                        <%--<asp:BoundField DataField="CREATED_DATE" HeaderText="CREATED DATE" />
                                <asp:BoundField DataField="MODIFIED_DATE" HeaderText="MODIFIED DATE" />--%>
                                        <asp:TemplateField HeaderText="ACTION" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <i class="fa fa-lg fa-edit" id="edtRow" style="color: dodgerblue"></i>
                                                <a class="fa fa-lg fa-trash" runat="server" style="color: red"></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>THERE ARE NO ITEMS CREATED YET</EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </body>
    </html>
</asp:Content>
