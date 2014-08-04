<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Case.aspx.cs" Inherits="DairyManager.Case" MasterPageFile="~/Site.master" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <h2>Code</h2>
        <div>
            <div>
                <span>Code</span>
                <span>*</span>
            </div>
            <div>
                <dx:ASPxComboBox ID="cmbCode" runat="server" ValueType="System.String"></dx:ASPxComboBox>
            </div>
        </div>
        <div>
            <div>
                <span>Case</span>
                <span>*</span>
            </div>
            <div>
                <dx:ASPxTextBox ID="txtCase" runat="server" Width="170px"></dx:ASPxTextBox>
            </div>
        </div>
        <div>
            <div>
                <span>Client</span>
                <span>*</span>
            </div>
            <div>
                <dx:ASPxComboBox ID="cmbClient" runat="server" ValueType="System.String"></dx:ASPxComboBox>
            </div>
        </div>
        <div>
            <div>
                <span>Case Type</span>
                <span>*</span>
            </div>
            <div>
                <dx:ASPxComboBox ID="cmbCaseType" runat="server" ValueType="System.String"></dx:ASPxComboBox>
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
                <span>Contact</span>
                <span>*</span>
            </div>
            <div>
                <dx:ASPxTextBox ID="txtContact" runat="server" Width="170px"></dx:ASPxTextBox>
            </div>
        </div>
        <div>
            <div>
                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></dx:ASPxButton>
                <asp:HiddenField ID="hdnCaseId" runat="server" />
            </div>
            <div>
                <dx:ASPxButton ID="btnCancel" runat="server" Text="Cancel"></dx:ASPxButton>
            </div>


        </div>
        <div>
            <dx:ASPxGridView ID="gvHistoryData" runat="server"></dx:ASPxGridView>

        </div>
    </div>
</asp:Content>
