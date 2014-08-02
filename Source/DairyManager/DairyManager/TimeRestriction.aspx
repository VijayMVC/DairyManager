<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeRestriction.aspx.cs" Inherits="DairyManager.TimeRestriction" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
            <h1>Time Restriction</h1>
            <div>
                <div>
                    <span>Maximum time recording per day</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxTextBox ID="txtMaximumTime" runat="server" Width="170px"></dx:ASPxTextBox>
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
                    <dx:ASPxButton ID="btnSave" runat="server" Text="Save"></dx:ASPxButton>
                </div>
                <div>
                    <dx:ASPxButton ID="btnCancel" runat="server" Text="Cancel"></dx:ASPxButton>
                </div>


            </div>

        </div>
</asp:Content>


