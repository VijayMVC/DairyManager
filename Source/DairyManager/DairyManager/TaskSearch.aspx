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
            <dx:ASPxGridView ID="gvTaskSearch" runat="server" AutoGenerateColumns="False" KeyFieldName="TaskId" OnRowDeleting="gvTaskSearch_RowDeleting">
                <Columns>
                    <%--<dx:GridViewDataTextColumn VisibleIndex="0" Caption="Task Date" Width="100px">                        
                        
                        <DataItemTemplate>
                            <a id="clickElement" target="_self" href="/Task.aspx?TaskId=<%#  Container.KeyValue %>"><%# Convert.ToDateTime(Eval("TaskDate")).ToString("dd-MMMM-yy") %> </a>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>--%>

                    <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0">
                        <DeleteButton Visible="True">
                            <Image Url="~/Images/delete.png">
                            </Image>
                        </DeleteButton>
                    </dx:GridViewCommandColumn>

                    <dx:GridViewDataHyperLinkColumn Caption="Task Date" FieldName="TaskId" VisibleIndex="1">
                        <PropertiesHyperLinkEdit NavigateUrlFormatString="/Task.aspx?TaskId={0}" TextField="TaskDate" TextFormatString="dd-MMM-yy HH:mm">
                        </PropertiesHyperLinkEdit>
                        <Settings FilterMode="DisplayText" />
                    </dx:GridViewDataHyperLinkColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="3" Caption="Task Creator" FieldName="TaskCreator">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="4" Caption="Fee Earner" FieldName="FeeEarner" >
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn FieldName="Code" ShowInCustomizationForm="True" Caption="UFN" VisibleIndex="2"></dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Task Type" FieldName="TaskDescription">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn FieldName="TaskDescription1" ShowInCustomizationForm="True" Caption="Task Description" VisibleIndex="5"></dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="6" Caption="Remaining Hours" FieldName="TotalRemainingHours">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="7" Caption="Start Time" FieldName="StartTime">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="8" Caption="End Time" FieldName="EndTime">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="9" Caption="Total Hours" FieldName="TotalHours">
                    </dx:GridViewDataTextColumn>



                </Columns>
                <SettingsBehavior ConfirmDelete="True" />
                <Settings ShowFilterRow="True" />
            </dx:ASPxGridView>
        </div>
        <div class="clearfix form-actions">
            <dx:ASPxButton ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Task.aspx"></dx:ASPxButton>
        </div>

    </div>
</asp:Content>
