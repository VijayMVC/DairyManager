<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaseType.aspx.cs" Inherits="DairyManager.CaseType" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Case Types</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Case Types</h2>

            <div>
                <div>
                    <span>New Case Type</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxTextBox ID="txtNewCaseType" runat="server" Width="170px"></dx:ASPxTextBox>
                </div>

            </div>

            <div>
                <div>
                    <span>Case Code</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxTextBox ID="txtCaseCode" runat="server" Width="170px"></dx:ASPxTextBox>
                </div>

            </div>
            <div>
                <div>
                    <dx:ASPxButton ID="btnSave" runat="server" Text="Save"></dx:ASPxButton>
                </div>
                <div>
                    <dx:ASPxButton ID="btnCancel" runat="server" Text="Cancel"></dx:ASPxButton>
                </div>

                <div>
                    <dx:ASPxGridView ID="gvHistoryData" runat="server"></dx:ASPxGridView>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
