<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/SideBarMaster.Master" AutoEventWireup="true" CodeBehind="CompanyMaster.aspx.cs" Inherits="HSL_Infra_Dev.Pages.CompanyMaster" %>

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
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
        <link rel="stylesheet" type="text/css" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
        <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
        <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.0.3/css/font-awesome.css" />
        <link rel="stylesheet" type="text/css" href="../Styles/feildset.css" />
    </head>
    <body class="bg-light">
        <!-- MultiStep Form -->
        <div class="container-fluid" id="grad1">
            <div class="row justify-content-center mt-0">
                <div class="col-11 col-sm-9 col-md-7 col-lg-6 text-center p-0 mt-3 mb-2">
                    <div class="card px-0 pt-4 pb-0 mt-3 mb-3">
                        <h2><strong>Sign Up Your Company Account</strong></h2>
                        <div class="row">
                            <div class="col-md-12 mx-0">
                                <form runat="server" id="msform">
                                    <!-- progressbar -->
                                    <ul id="progressbar">
                                        <li class="active" id="account"><strong>Company Details</strong></li>
                                        <li id="personal"><strong>Address</strong></li>
                                        <li id="payment"><strong>Credentials</strong></li>
                                        <li id="license"><strong>License</strong></li>
                                        <li id="confirm"><strong>Finish</strong></li>
                                    </ul>
                                    <!-- fieldsets -->
                                    <fieldset>
                                        <div class="form-card">
                                            <h2 class="fs-title">Company Details <span><i id="fdset1edit" class="fa fa-pencil" style="color:darkturquoise"></i></span></h2>
                                            <asp:TextBox runat="server" ID="txt_CompId" OnTextChanged="txt_CompId_TextChanged" AutoPostBack="true" placeholder="Company Id" />
                                            <asp:TextBox runat="server" ID="txt_CompName" placeholder="Company Name" ReadOnly="true" />
                                            <asp:TextBox runat="server" ID="txt_Address" placeholder="Address" ReadOnly="true" />
                                            <asp:TextBox runat="server" ID="txt_Country" placeholder="Country" ReadOnly="true" />
                                            <asp:TextBox runat="server" ID="txt_City" placeholder="City" ReadOnly="true" />
                                            <asp:TextBox runat="server" ID="txt_Zip" placeholder="Zip" ReadOnly="true" />
                                        </div>
                                        <input type="button" name="next" class="next action-button" value="Next Step" />
                                    </fieldset>
                                    <fieldset>
                                        <div class="form-card">
                                            <h2 class="fs-title">Address Information <span><i id="fdset2edit" class="fa fa-pencil" style="color:darkturquoise"></i></span></h2>
                                            <asp:TextBox runat="server" ID="txt_Email" placeholder="Email" ReadOnly="true" />
                                            <asp:TextBox runat="server" ID="txt_Telephone" placeholder="Telephone" ReadOnly="true" />
                                        </div>
                                        <input type="button" name="previous" class="previous action-button-previous" value="Previous" />
                                        <input type="button" name="next" class="next action-button" value="Next Step" />
                                    </fieldset>
                                    <fieldset>
                                        <div class="form-card">
                                            <h2 class="fs-title">Address Information <span><i id="fdset3edit" class="fa fa-pencil" style="color:darkturquoise"></i></span></h2>
                                            <asp:TextBox runat="server" ID="txt_userid" placeholder="User Id" ReadOnly="true" />
                                            <asp:TextBox runat="server" ID="txt_password" placeholder="Password" ReadOnly="true" />
                                            <%--<asp:TextBox runat="server" ID="txt_confpassword" placeholder="Confirm Password" ReadOnly="true" />--%>
                                        </div>
                                        <input type="button" name="previous" class="previous action-button-previous" value="Previous" />
                                        <input type="button" name="make_payment" class="next action-button" value="Next Step" />
                                    </fieldset>
                                    <fieldset>
                                        <div class="form-card">
                                            <h2 class="fs-title">Product Key <span><i id="fdset4edit" class="fa fa-pencil" style="color:darkturquoise"></i></span></h2>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>Inventory Module</td>
                                                    <td><asp:TextBox runat="server" ID="txt_InventoryKey" placeholder="Product License" ReadOnly="true" /></td>
                                                </tr>
                                                <tr>
                                                    <td>Purchase Module</td>
                                                    <td><asp:TextBox runat="server" ID="txt_PurchaseKey" placeholder="Product License" ReadOnly="true" /></td>
                                                </tr>
                                                <tr>
                                                    <td>Sale Module</td>
                                                    <td><asp:TextBox runat="server" ID="txt_SaleKey" placeholder="Product License" ReadOnly="true" /></td>
                                                </tr>
                                            </table>
                                        </div>
                                        <input type="button" name="previous" class="previous action-button-previous" value="Previous" />
                                        <input type="button" runat="server" name="make_payment" class="next action-button submit" value="Confirm" />
                                    </fieldset>
                                    <fieldset>
                                        <div class="form-card">
                                            <h2 class="fs-title text-center">Success !</h2>
                                            <br>
                                            <br>
                                            <div class="row justify-content-center">
                                                <div class="col-3">
                                                    <img src="https://img.icons8.com/color/96/000000/ok--v2.png" class="fit-image">
                                                </div>
                                            </div>
                                            <br>
                                            <br>
                                            <div class="row justify-content-center">
                                                <div class="col-7 text-center">
                                                    <asp:Button runat="server" Text="Submit" CssClass="btn btn-success" OnClick="Unnamed_ServerClick" />
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script type="text/javascript">
            $(document).ready(function () {

                var current_fs, next_fs, previous_fs; //fieldsets
                var opacity;

                $(".next").click(function () {

                    current_fs = $(this).parent();
                    next_fs = $(this).parent().next();

                    //Add Class Active
                    $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

                    //show the next fieldset
                    next_fs.show();
                    //hide the current fieldset with style
                    current_fs.animate({ opacity: 0 }, {
                        step: function (now) {
                            // for making fielset appear animation
                            opacity = 1 - now;

                            current_fs.css({
                                'display': 'none',
                                'position': 'relative'
                            });
                            next_fs.css({ 'opacity': opacity });
                        },
                        duration: 600
                    });
                });

                $(".previous").click(function () {

                    current_fs = $(this).parent();
                    previous_fs = $(this).parent().prev();

                    //Remove class active
                    $("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");

                    //show the previous fieldset
                    previous_fs.show();

                    //hide the current fieldset with style
                    current_fs.animate({ opacity: 0 }, {
                        step: function (now) {
                            // for making fielset appear animation
                            opacity = 1 - now;

                            current_fs.css({
                                'display': 'none',
                                'position': 'relative'
                            });
                            previous_fs.css({ 'opacity': opacity });
                        },
                        duration: 600
                    });
                });

                $('.radio-group .radio').click(function () {
                    $(this).parent().find('.radio').removeClass('selected');
                    $(this).addClass('selected');
                });

                $(".submit").click(function () {
                    return false;
                })
                // Enabling fieldset 1 for edit
                $("#fdset1edit").click(function () {
                    $(this).hide();
                    $("[id*=txt_CompName]").attr('readonly', false);
                    $("[id*=txt_Address]").attr('readonly', false);
                    $("[id*=txt_Country]").attr('readonly', false);
                    $("[id*=txt_City]").attr('readonly', false);
                    $("[id*=txt_Zip]").attr('readonly', false);
                })
                // Enabling fieldset 2 for edit
                $("#fdset2edit").click(function () {
                    $(this).hide();
                    $("[id*=txt_Email]").attr('readonly', false);
                    $("[id*=txt_Telephone]").attr('readonly', false);
                })
                // Enabling fieldset 3 for edit
                $("#fdset3edit").click(function () {
                    $(this).hide();
                    $("[id*=txt_userid]").attr('readonly', false);
                    $("[id*=txt_password]").attr('readonly', false);
                    $("[id*=txt_confpassword]").attr('readonly', false);
                })
                // Enabling fieldset 4 for edit
                $("#fdset4edit").click(function () {
                    $(this).hide();
                    $("[id*=txt_InventoryKey]").attr('readonly', false);
                    $("[id*=txt_PurchaseKey]").attr('readonly', false);
                    $("[id*=txt_SaleKey]").attr('readonly', false);
                })

            });
        </script>
    </body>
    </html>
</asp:Content>
