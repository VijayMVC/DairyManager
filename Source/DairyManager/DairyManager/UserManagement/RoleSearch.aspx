<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoleSearch.aspx.cs" Inherits="DairyManager.UserManagement.RoleSearch" %>

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
            <h1>Search Roles</h1>
        </div>
        <div class="form-group">

            <dx:ASPxGridView ID="gvRoles" runat="server" Width="100%" AutoGenerateColumns="False"
                KeyFieldName="RoleId" OnRowDeleting="gvRoles_RowDeleting">
                <Columns>
                    <dx:GridViewDataTextColumn Caption="Role Name" FieldName="RoleName"
                        Visible="False" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
               <%--     <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Role Name" FieldName="RoleId">
                        <DataItemTemplate>
                            <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" NavigateUrl="/Roles.aspx?RoleId='<%# Eval("RoleId") %>'" Text='<%# Eval("RoleName") %>' />
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>--%>
                    <dx:GridViewDataTextColumn Caption="Role Description" FieldName="RoleDescription"
                        VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewCommandColumn VisibleIndex="0" ButtonType="Image" Caption="Actions" Width="60px">
                        <DeleteButton Visible="True">
                            <Image ToolTip="Delete" Url="~/Images/delete.png">
                            </Image>
                        </DeleteButton>
                        <ClearFilterButton Visible="True">
                        </ClearFilterButton>
                    </dx:GridViewCommandColumn>
                </Columns>
                <SettingsBehavior ConfirmDelete="True" />
                <Settings ShowFilterRow="True" />
            </dx:ASPxGridView>
        </div>



    </div>
</asp:Content>



