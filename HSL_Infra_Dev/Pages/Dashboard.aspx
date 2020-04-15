<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="HSL_Infra_Dev.Pages.Dashboard" %>

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
        <script src="../Scripts/jquery-3.0.0.min.js"></script>
        <script src="../Scripts/jquery-ui.js"></script>
    </head>
    <body>
        <form runat="server">
            <div class="container-fluid">
                <div class="row">
                    <div class="col">
                        <div class="row ml-1 mb-1 mt-1 bg-warning rounded-right pl-1 border">
                            <div>
                                <h4>Dashboard</h4>
                                <p>Some text..</p>
                            </div>
                        </div>
                        <div class="row ml-1">
                            <div class="col-sm-2 bg-danger rounded mr-1 border">
                                <div class="well">
                                    <h4>Data1</h4>
                                    <p>x Million</p>
                                </div>
                            </div>
                            <div class="col-sm-2 bg-success rounded mr-1 border">
                                <div class="well">
                                    <h4>Data2</h4>
                                    <p>xxx Million</p>
                                </div>
                            </div>
                            <div class="col-sm-2 bg-primary rounded mr-1 border">
                                <div class="well">
                                    <h4>Data3</h4>
                                    <p>xx Million</p>
                                </div>
                            </div>
                            <div class="col-sm-2 bg-info rounded mr-1 border">
                                <div class="well">
                                    <h4>Data4</h4>
                                    <p>xx%</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </body>
    </html>
</asp:Content>
