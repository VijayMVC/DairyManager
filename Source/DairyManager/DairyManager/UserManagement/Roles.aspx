﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="DairyManager.UserManagement.Roles" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="wrapper-inner">
        <h2 class="w875">
            Add Roles</h2>
        <table class="role-tbl">
            <tr>
                <td>
                    <table class="role-search-tbl">
                        <tr>
                            <td height="21">
                                Role Name<span class="reqfield">*</span>
                                <asp:HiddenField ID="hdnRoleId" runat="server" />
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtRoleName" runat="server" Width="170px" MaxLength="50">
                                    <ValidationSettings Display="Dynamic" ValidationGroup="vgSave" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Required" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="21">
                                Role Description<span class="reqfield">*</span>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtRoleDescription" runat="server" Width="170px" MaxLength="50">
                                    <ValidationSettings Display="Dynamic" ValidationGroup="vgSave" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Required" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <h2 class="w875">
                        Rights List</h2>
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
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vgSave"
                        HorizontalAlign="Center" ImageSpacing="15px" VerticalAlign="Middle" UseSubmitBehavior="False">
                        <Image Url="~/Images/Save.png">
                        </Image>
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
