<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="DairyManager.UserManagement.Roles" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div class="page-header">
            <h1>Add Roles</h1>
            <asp:HiddenField ID="hdnRoleId" runat="server" />
        </div>

        <div class="form-group">
            <div>
                <span>Role Name</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtRoleName" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings Display="Dynamic" ValidationGroup="vgSave" ErrorDisplayMode="ImageWithTooltip">
                        <RequiredField IsRequired="True" ErrorText="Required" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </div>
        </div>

        <div class="form-group">
            <div>
                <span>Role Description</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtRoleDescription" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings Display="Dynamic" ValidationGroup="vgSave" ErrorDisplayMode="ImageWithTooltip">
                        <RequiredField IsRequired="True" ErrorText="Required" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </div>
        </div>

        <div class="form-group">
            <dx:ASPxGridView ID="gvRights" runat="server" Width="100%" AutoGenerateColumns="False"
                KeyFieldName="RightId">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Width="100px">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="Module" FieldName="ModuleName" VisibleIndex="1"
                        Width="150px">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Right Name" FieldName="RightName" VisibleIndex="2"
                        Width="200px">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Description" FieldName="RightDescription" VisibleIndex="3"
                        Width="400px">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="RightId" FieldName="RightId" VisibleIndex="6"
                        Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="RoleId" FieldName="RoleId" VisibleIndex="7"
                        Visible="False">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior AllowDragDrop="False" />
            </dx:ASPxGridView>

        </div>
        <div class="clearfix form-actions">
            <div>
                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vgSave"></dx:ASPxButton>
            </div>
        </div>

    </div>


</asp:Content>



