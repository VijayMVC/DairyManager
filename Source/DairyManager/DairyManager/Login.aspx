<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DairyManager.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- bootstrap & fontawesome -->
    <link rel="stylesheet" href="~/assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="~/assets/css/font-awesome.min.css" />

    <!-- page specific plugin styles -->

    <!-- text fonts -->
    <link rel="stylesheet" href="~/assets/css/ace-fonts.css" />

    <!-- ace styles -->
    <link rel="stylesheet" href="~/assets/css/ace.min.css" />

    <!--[if lte IE 9]>
			<link rel="stylesheet" href="assets/css/ace-part2.min.css" />
		<![endif]-->
    <link rel="stylesheet" href="~/assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="~/assets/css/ace-rtl.min.css" />

    <!--[if lte IE 9]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->

    <!-- inline styles related to this page -->

    <!-- ace settings handler -->
    <script src="./assets/js/ace-extra.min.js"></script>

    <!-- HTML5shiv and Respond.js for IE8 to support HTML5 elements and media queries -->

    <!--[if lte IE 8]>
		<script src="assets/js/html5shiv.min.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->

    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body class="no-skin">
    <form id="form1" runat="server">
    <div>
     <div class="login-container">
        <div class="center">
            <h1>
                <i class="ace-icon fa fa-leaf green"></i>
                <span class="red">Log </span>
                <span class="grey" id="id-text2">In</span>
            </h1>
            <h5 class="blue" id="id-company-text">
                <p>
                    Please enter your username and password.        
                </p>
            </h5>
        </div>

        <div class="space-6"></div>

        <div class="position-relative">
            <div id="login-box" class="login-box visible widget-box no-border">
                <div class="widget-body">
                    <div class="widget-main">
                        <h4 class="header blue lighter bigger">
                            <i class="ace-icon fa fa-coffee green"></i>
                            Account Information
                        </h4>

                        <div class="space-6"></div>
<%--<asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">--%>
                            <%--<LayoutTemplate>--%>
                                <span class="failureNotification">
                                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                                </span>
                                <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                                    ValidationGroup="LoginUserValidationGroup" />
                                <div class="accountInfo">
                                    <fieldset class="login">
                                        <%--<legend>Account Information</legend>--%>
                                        <%--<fieldset>--%>
                                            <label class="block clearfix">
                                                <span class="block input-icon input-icon-right">
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtUserName">Username:</asp:Label>
                                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="textEntry form-control" placeholder="Username"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUserName"
                                                        CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                                                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                                    <%--<i class="ace-icon fa fa-user"></i>--%>
                                                </span>
                                            </label>

                                            <label class="block clearfix">
                                                <span class="block input-icon input-icon-right">
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="txtPassword">Password:</asp:Label>
                                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="passwordEntry form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                                                        CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                                                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>

                                                    <i class="ace-icon fa fa-lock"></i>
                                                </span>
                                            </label>

                                            <div class="space"></div>

                                            <div class="clearfix">
                                                <label class="inline">
                                                    <asp:CheckBox ID="RememberMe" runat="server" CssClass="inline ace" Visible="false" />
                                                    <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline lbl" Visible="false">Keep me logged in</asp:Label>
                                                </label>


                                            </div>

                                            <div class="space-4"></div>
                                        <%--</fieldset>--%>

                                    </fieldset>
                                    <p class="submitButton">
                                        <asp:Button ID="LoginButton" runat="server" class="width-35 pull-right btn btn-sm btn-primary" Text="Log In" ValidationGroup="LoginUserValidationGroup" OnClick="LoginButton_Click" />
                                    </p>
                                </div>
                            <%--</LayoutTemplate>--%>
                        <%--</asp:Login>--%>


                        <div class="space-6"></div>


                    </div>
                    <!-- /.widget-main -->


                </div>
                <!-- /.widget-body -->
            </div>
            <!-- /.login-box -->

        </div>

        <!-- /.position-relative -->

    </div>
    </div>
    </form>
</body>
</html>
