<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaseType.aspx.cs" Inherits="DairyManager.CaseType" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div class="page-header">
            <h1>Case Types</h1>
            </div>
        <asp:HiddenField ID="hdnCaseTypeId" runat="server" />
        <div class="form-group">
            <div>
                <span>Case Type Description</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtCaseTypeDescription" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </div>

        </div>

        <div class="form-group">
            <div>
                <span>Case Code</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtCaseCode" runat="server" Width="170px" MaxLength="20">
                    <ValidationSettings CausesValidation="True" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </div>

        </div>
        <div class="clearfix form-actions">
            <div>
                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vgSave"></dx:ASPxButton>
            </div>
            <div>
                <dx:ASPxButton ID="btnSearch" runat="server" Text="Search" PostBackUrl="~/CaseTypeSearch.aspx" CausesValidation="False"></dx:ASPxButton>
            </div>

          
        </div>
    </div>
</asp:Content>


