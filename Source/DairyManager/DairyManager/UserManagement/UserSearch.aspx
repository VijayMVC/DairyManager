﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserSearch.aspx.cs" Inherits="DairyManager.UserManagement.UserSearch" %>

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
            <h1>Search Users</h1>
        </div>

        <div class="form-group">
           <dx:ASPxGridView ID="gvUsers" runat="server" Width="100%" AutoGenerateColumns="False"
                        KeyFieldName="UserId" OnRowDeleting="gvUsers_RowDeleting">
                        <Columns>
                            <dx:GridViewDataTextColumn VisibleIndex="1" Caption="User Name" FieldName="UserId"
                                Width="100px">
                                <DataItemTemplate>
                                    <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" NavigateUrl='<%# Diary.Common.Constant.CreateURLQueryString("~/UserManagement/Users.aspx?UserId=",Eval("UserId"))%>'
                                        Text='<%# Eval("UserName") %>' />
                                </DataItemTemplate>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="User Name" FieldName="UserName"
                                VisibleIndex="2" Visible="False">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="FirstName" ShowInCustomizationForm="True" Width="100px"
                                Caption="First Name" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn VisibleIndex="4" Caption="Last Name" FieldName="LastName"
                                Width="100px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Email Address" FieldName="EmailAddress" VisibleIndex="5"
                                Width="100px">
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
                        <Settings ShowFilterRow="True"></Settings>
                    </dx:ASPxGridView>
        </div>

   </div>
</asp:Content>

