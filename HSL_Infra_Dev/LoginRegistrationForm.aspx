<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginRegistrationForm.aspx.cs" Inherits="HSL_Infra_Dev.LoginRegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <script type="text/javascript" src="Scripts/jquery-3.0.0.min.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <style>
        #load {
            width: 100%;
            height: 100%;
            position: fixed;
            z-index: 9999;
            background-color: transparent;
            background: url("Assets/Preload.gif") no-repeat center center rgba(255,255,255,255)
        }
    </style>
    <script>
        document.onreadystatechange = function () {
            var state = document.readyState
            if (state == 'interactive') {
                document.getElementById('contents').style.visibility = "hidden";
            } else if (state == 'complete') {
                setTimeout(function () {
                    document.getElementById('interacive');
                    document.getElementById('load').style.visibility = "hidden";
                    document.getElementById('contents').style.visibility = "visible";
                }, 2000)
            }
        }
    </script>
</head>
<body>
    <div id="load"></div>

    <form id="form1" runat="server" class="container h-100 justify-content-center align-items-center mt-5">
        <div id="contents" class="row h-100 justify-content-center align-items-center mt-5">
            <div class="col-6 mt-5">
                <div runat="server" id="ErrMsg" class="alert alert-danger" role="alert" visible="false">
                    EXPIRED!!!
                </div>
                <div class="card mt-5">
                    <div class="card-header">
                        <label class="h3">Login</label>
                    </div>
                    <div class="card-body">
                        <div class="tab-content mt-3">
                            <%--Login Content--%>
                            <div class="tab-pane active" id="one" role="tabpanel" aria-labelledby="one-tab">
                                <div class="form-group">
                                    <label for="uname1">Username</label>
                                    <asp:TextBox runat="server" ID="txt_UserName" CssClass="form-control" required="true" />
                                    <div class="invalid-feedback">Please enter your username or email</div>
                                </div>
                                <div class="form-group">
                                    <label>Password</label>
                                    <asp:TextBox runat="server" ID="txt_Password" CssClass="form-control" TextMode="Password" required="true" />
                                    <div class="invalid-feedback">Please enter a password</div>
                                </div>
                                <button runat="server" onserverclick="btnLogin_ServerClick" type="submit" class="btn btn-success btn-lg float-right" id="btnLogin">Login</button>

                            </div>
                            <%--Registration Content--%>
                            <div class="tab-pane" id="two" role="tabpanel" aria-labelledby="two-tab">
                                <p class="card-text">First settled around 1000 BCE and then founded as the Etruscan Felsina about 500 BCE, it was occupied by the Boii in the 4th century BCE and became a Roman colony and municipium with the name of Bononia in 196 BCE. </p>
                                <a href="#" class="card-link text-danger">Read more</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
