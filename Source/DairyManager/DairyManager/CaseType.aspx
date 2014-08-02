<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaseType.aspx.cs" Inherits="DairyManager.CaseType" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <h2>Case Types</h2>
        <asp:HiddenField ID="hdnCaseTypeId" runat="server" />
        <div>
            <div>
                <span>Case Type Description</span>
                <span>*</span>
            </div>
            <div>
                <dx:ASPxTextBox ID="txtCaseTypeDescription" runat="server" Width="170px"></dx:ASPxTextBox>
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
                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></dx:ASPxButton>
            </div>
            <div>
                <dx:ASPxButton ID="btnCancel" runat="server" Text="Cancel"></dx:ASPxButton>
            </div>

            <div>
                <dx:ASPxGridView ID="gvHistoryData" runat="server"></dx:ASPxGridView>

            </div>
        </div>
    </div>
</asp:Content>


