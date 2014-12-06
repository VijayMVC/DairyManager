﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskTypeSearch.aspx.cs" Inherits="DairyManager.TaskTypeSearch" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div class="page-header">
            <h1>Task Type Search</h1>
        </div>
        <div>
            <dx:ASPxGridView ID="gvTaskTypeSearch" runat="server" AutoGenerateColumns="False" KeyFieldName="TaskTypeId" OnRowDeleting="gvTaskTypeSearch_RowDeleting">
                <Columns>
                    <%--<dx:GridViewDataTextColumn VisibleIndex="1" Caption="Task Code">
                        <DataItemTemplate>
                            <a id="clickElement" target="_self" href="/TaskType.aspx?TaskTypeId=<%# Container.KeyValue%>"><%#  Eval("TaskCode").ToString()%> </a>

                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>--%>

                      <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0">
                          <DeleteButton Visible="True">
                              <Image Url="~/Images/delete.png">
                              </Image>
                          </DeleteButton>
                    </dx:GridViewCommandColumn>

                      <dx:GridViewDataHyperLinkColumn Caption="Task Code" FieldName="TaskTypeId" VisibleIndex="1">
                        <PropertiesHyperLinkEdit NavigateUrlFormatString="/TaskType.aspx?TaskTypeId={0}" TextField="TaskCode" >
                        </PropertiesHyperLinkEdit>
                          <Settings FilterMode="DisplayText" />
                    </dx:GridViewDataHyperLinkColumn>


                    <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Task Description" FieldName="TaskDescription" ShowInCustomizationForm="True">
                        <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" />
                    </dx:GridViewDataTextColumn>

                </Columns>
                <SettingsBehavior ConfirmDelete="True" />
                <Settings ShowFilterRow="True" />
            </dx:ASPxGridView>
        </div>

        <div class="clearfix form-actions">
            <dx:ASPxButton ID="btnBack" runat="server" Text="Back" PostBackUrl="~/TaskType.aspx"></dx:ASPxButton>
        </div>


    </div>
</asp:Content>

