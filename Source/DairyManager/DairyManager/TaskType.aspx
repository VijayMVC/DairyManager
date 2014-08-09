<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskType.aspx.cs" Inherits="DairyManager.TaskType" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ MasterType VirtualPath="~/Site.Master"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        
<div class="page-header">
            <h1>Task Types</h1>
    </div>
            <asp:HiddenField ID="hdnTaskTypeId" runat="server" />
            <div class="form-group">
                <div>
                    <span>Task Description</span>
                    <span>*</span>
                </div>
                <div class="input-group">
                    <dx:ASPxTextBox ID="txtTaskDescription" runat="server" Width="170px" MaxLength="50">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                            <RequiredField ErrorText="Required" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </div>
            </div>

            <div class="form-group">
                <div>
                    <span>Task Code</span>
                    <span>*</span>
                </div>
                <div class="input-group">
                    <dx:ASPxTextBox ID="txtTaskCode" runat="server" Width="170px" MaxLength="20">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
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
                    <dx:ASPxButton ID="btnSearch" runat="server" Text="Search" PostBackUrl="~/TaskTypeSearch.aspx" CausesValidation="False"></dx:ASPxButton>
                </div>


            </div>
            <div>

            </div>

        </div>
</asp:Content>


