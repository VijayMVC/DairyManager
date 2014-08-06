﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskSearch.aspx.cs" Inherits="DairyManager.TaskSearch" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Task Search</h1>
        <div>

            <dx:ASPxGridView ID="gvTaskSearch" runat="server">
                <Settings ShowFilterRow="True" />
            </dx:ASPxGridView>
        </div>
        <div>

            <dx:ASPxButton ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Task.aspx"></dx:ASPxButton>
        </div>
    
    </div>
    </form>
</body>
</html>