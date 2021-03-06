﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Offence.aspx.cs" Inherits="DairyManager.Offence" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div class="page-header">
            <h1>Offence</h1>
        </div>
        <asp:HiddenField ID="hdnOffenceTypeId" runat="server" />
        <div class="form-group">
            <div>
                <span>Offence</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtOffence" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
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
                <dx:ASPxButton ID="btnClear" runat="server" Text="Clear" CausesValidation="False" OnClick="btnClear_Click">
                    <ClientSideEvents Click="function(s, e) {
	e.processOnServer = confirm('Do you wish to clear the form?');
}" />
                </dx:ASPxButton>

            </div>
            <div>
                <dx:ASPxButton ID="btnSearch" runat="server" Text="Search" PostBackUrl="~/OffenceSearch.aspx" CausesValidation="False"></dx:ASPxButton>
            </div>


        </div>
    </div>
</asp:Content>


