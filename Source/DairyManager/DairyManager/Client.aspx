<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="DairyManager.Client" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="page-header">
            <h1>Client</h1>
                </div>
            <asp:HiddenField ID="hdnClientId" runat="server" />
            <div>
                <div>
                    <span>Name</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxTextBox ID="txtName" runat="server" Width="170px"></dx:ASPxTextBox>
                </div>
            </div>

            <div>
                <div>
                    <span>Address Line 1</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxTextBox ID="txtAddressLine1" runat="server" Width="170px"></dx:ASPxTextBox>

                </div>
            </div>

            <div>
                <div>
                    <span>Address Line 2</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxTextBox ID="txtAddressLine2" runat="server" Width="170px"></dx:ASPxTextBox>

                </div>
            </div>

            <div>
                <div>
                    <span>Address Line 3</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxTextBox ID="txtAddressLine3" runat="server" Width="170px"></dx:ASPxTextBox>

                </div>
            </div>


            <div>
                <div>
                    <span>Telephone</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxTextBox ID="txtTelephone" runat="server" Width="170px"></dx:ASPxTextBox>

                </div>
            </div>


            <div>
                <div>
                    <span>Fax</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxTextBox ID="txtFax" runat="server" Width="170px"></dx:ASPxTextBox>

                </div>
            </div>


            <div>
                <div>
                    <span>Email</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxTextBox ID="txtEmail" runat="server" Width="170px"></dx:ASPxTextBox>

                </div>
            </div>

            <div>
                <div>
                    <span>Contact Person</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxTextBox ID="txtContactPerson" runat="server" Width="170px"></dx:ASPxTextBox>

                </div>
            </div>

                    <div>
            <div>
                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></dx:ASPxButton>
                
            </div>
            <div>
                <dx:ASPxButton ID="btnSearch" runat="server" Text="Search" PostBackUrl="~/ClientSearh.aspx"></dx:ASPxButton>
            </div>


        </div>   
        </div>
    </form>
</body>
</html>
