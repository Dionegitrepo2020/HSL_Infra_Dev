<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/SideBarMaster.Master" AutoEventWireup="true" CodeBehind="MaterialRequest.aspx.cs" Inherits="HSL_Infra_Dev.Pages.MaterialRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <!DOCTYPE html>
    <html>
    <head>
        <title>HIMATSINGKA</title>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">
        <script src="../Scripts/jquery-3.0.0.min.js"></script>
        <script src="../Scripts/jquery-ui.js"></script>
        <script src="../Scripts/jquery-ui-timepicker-addon.min.js"></script>
        <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.css" />
        <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css" />
        <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js"></script>
        <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap4.min.js"></script>
    </head>
    <body>
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
                            <asp:TextBox class="form-control ml-1" placeholder="Date" runat="server" ID="txtDate" />
                            <div class="input-group-append">
                                <i class="input-group-text fa fa-calendar"></i>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Time :</label>
                            <asp:TextBox class="form-control ml-1" placeholder="Date" runat="server" ID="txtTime" />
                            <div class="input-group-append">
                                <i class="input-group-text fa fa-clock-o"></i>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Requester Name :</label>
                            <asp:TextBox class="form-control ml-1" runat="server" ID="txtRequesterName" />
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Department :</label>
                            <asp:DropDownList runat="server" ID="ddlDepartment" CssClass="custom-select rounded-0 ml-1">
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
                            <asp:TextBox class="form-control ml-1" placeholder="Description" runat="server" ID="txtDescription" />
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Comments :</label>
                            <asp:TextBox class="form-control ml-1" placeholder="Comments" runat="server" ID="txtReqComment" />
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
                                        <asp:TextBox runat="server" class="form-control ml-1" placeholder="Item ID" ID="txtItemID" />
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
                                    <asp:Button ID="btnAdd" class="btn btn-success" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="container-fluid" style="height:200px;overflow:scroll;">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-sm table-striped table-hover"
                            OnRowDeleting="GridView1_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="Item_ID" HeaderText="ITEM ID" />
                                <asp:BoundField DataField="Item_Description" HeaderText="ITEM DESC" />
                                <asp:BoundField DataField="UOM" HeaderText="UOM" />
                                <asp:BoundField DataField="Location" HeaderText="LOCATION" />
                                <asp:BoundField DataField="Quantity" HeaderText="QUANTITY" />
                                <asp:BoundField DataField="Comment" HeaderText="COMMENTS" />
                                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ControlStyle-CssClass="btn-link" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="row container-fluid">
                    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-outline-success" Text="Submit" OnClick="btnSubmit_Click" />
                </div>
            </div>

            <%-- Modal --%>
            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Select Item</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="container-fluid">
                                <asp:GridView ID="grdvCrudOperation" runat="server" HorizontalAlign="Center" OnRowDataBound="grdvCrudOperation_RowDataBound"
                                    AutoGenerateColumns="false" CssClass="table table-bordered table-sm table-striped table-hover">
                                    <Columns>
                                        <asp:BoundField DataField="ITEM_ID" HeaderText="ITEM ID" />
                                        <asp:BoundField DataField="ITEM_DESC" HeaderText="ITEM DESCRIPTION" />
                                        <asp:BoundField DataField="LOCATION_ID" HeaderText="LOCATION" />
                                        <asp:BoundField DataField="TOTALQTY" HeaderText="QUANTITY" />
                                        <asp:TemplateField HeaderText="ACTION" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <a id="linkBtn" class="text-primary" data-dismiss="modal">Select</a>
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
        <script type="text/javascript">
            $(function () {
                $('[id*=grdvCrudOperation]').prepend($("<thead></thead>").append($('[id*=grdvCrudOperation]').find("tr:first"))).DataTable({
                    "responsive": true,
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
        <script type="text/javascript">
            $(function () {
                $("[id*=grdvCrudOperation]").find("[id*=linkBtn]").click(function () {
                    //Reference the GridView Row.
                    var row = $(this).closest("tr");

                    //Determine the Row Index.
                    $("[id*=txtItemID]").val(row.find("td").eq(0).html());

                    //Read values from Cells.
                    $("[id*=txtItemDesc]").val(row.find("td").eq(1).html());
                    message += "\nCustomer Id: " + row.find("td").eq(0).html();
                    message += "\nName: " + row.find("td").eq(1).html();

                    //Display the data using JavaScript Alert Message Box.
                    return false;
                });
            });
        </script>
        <script>
            $(document).ready(function () {
                //var dt = new Date();
                $('#<%=txtDate.ClientID%>').datepicker({
                    dateFormat: "yy-mm-dd"
                });
                $('#<%=txtTime.ClientID%>').timepicker({
                    timeFormat: "hh:mm:ss"
                });
            });
        </script>
    </body>
    </html>
</asp:Content>
