<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskSearch.aspx.cs" Inherits="DairyManager.TaskSearch" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
         <div class="page-header">
<h1>Task Search</h1>
             </div>
        
        <div>
            <dx:ASPxGridView ID="gvTaskSearch" runat="server">
                <Settings ShowFilterRow="True" />
            </dx:ASPxGridView>
        </div>
          <div class="clearfix form-actions">
            <dx:ASPxButton ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Task.aspx"></dx:ASPxButton>
        </div>

    </div>
</asp:Content>
