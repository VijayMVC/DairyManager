﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskSearch.aspx.cs" Inherits="DairyManager.TaskSearch" MasterPageFile="~/Site.master" %>

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
            <dx:ASPxGridView ID="gvTaskSearch" runat="server" AutoGenerateColumns="False" KeyFieldName="TaskId">
                <Columns>
                    <%--<dx:GridViewDataTextColumn VisibleIndex="0" Caption="Task Date" Width="100px">                        
                        
                        <DataItemTemplate>
                            <a id="clickElement" target="_self" href="/Task.aspx?TaskId=<%#  Container.KeyValue %>"><%# Convert.ToDateTime(Eval("TaskDate")).ToString("dd-MMMM-yy") %> </a>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>--%>

                     <dx:GridViewDataHyperLinkColumn Caption="Task Date" FieldName="TaskId" VisibleIndex="0">
                        <PropertiesHyperLinkEdit NavigateUrlFormatString="/Task.aspx?TaskId={0}" TextField="TaskDate" TextFormatString="dd-MMM-yy">
                        </PropertiesHyperLinkEdit>
                         <Settings FilterMode="DisplayText" />
                    </dx:GridViewDataHyperLinkColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Task Creator" FieldName="TaskCreator">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="3" Caption="Fee Earner" FieldName="FeeEarner">
                    </dx:GridViewDataTextColumn>

<dx:GridViewDataTextColumn FieldName="Case" ShowInCustomizationForm="True" Caption="Case Type" VisibleIndex="1"></dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Task Type" FieldName="TaskDescription">
                    </dx:GridViewDataTextColumn>

<dx:GridViewDataTextColumn FieldName="TaskDescription1" ShowInCustomizationForm="True" Caption="Task Description" VisibleIndex="4"></dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="5" Caption="Remaining Hours" FieldName="TotalRemainingHours">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="6" Caption="Start Time" FieldName="StartTime">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="7" Caption="End Time" FieldName="EndTime">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="8" Caption="Total Hours" FieldName="TotalHours">
                    </dx:GridViewDataTextColumn>

                   

                </Columns>
                <Settings ShowFilterRow="True" />
            </dx:ASPxGridView>
        </div>
        <div class="clearfix form-actions">
            <dx:ASPxButton ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Task.aspx"></dx:ASPxButton>
        </div>

    </div>
</asp:Content>
