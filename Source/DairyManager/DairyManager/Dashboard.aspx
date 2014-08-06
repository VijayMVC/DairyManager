<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DairyManager.Dashboard" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>



<%@ Register assembly="DevExpress.XtraScheduler.v12.2.Core, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraScheduler" tagprefix="cc1" %>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>Dashboard</h1>
    <div>
        <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server"></dxwschs:ASPxScheduler>
    </div>
</asp:Content>
