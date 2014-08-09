<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeRestriction.aspx.cs" Inherits="DairyManager.TimeRestriction" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <h1>Time Restriction</h1>
        <asp:HiddenField ID="hdnTimeRestrictionId" runat="server" />
        <div>
            <div>
                <span>Maximum time recording per day</span>
                <span>*</span>
            </div>
            <div>
                <dx:ASPxSpinEdit ID="seMaximumTime" runat="server" Height="21px" Number="0">
                </dx:ASPxSpinEdit>
            </div>
        </div>
        <div>
            <div>
                <span>Warning after time exceed</span>
                <span>*</span>
            </div>
            <div>
                <dx:ASPxTextBox ID="txtTimeExceed" runat="server" Width="170px"></dx:ASPxTextBox>
            </div>
        </div>
        <div>
            <div>
                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></dx:ASPxButton>
            </div>
        </div>
    </div>
</asp:Content>


