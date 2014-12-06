<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaseTypeSearch.aspx.cs" Inherits="DairyManager.CaseTypeSearch" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div class="page-header">
            <h1>Case Type Search</h1>
        </div>
        <div>
            <dx:ASPxGridView ID="gvCaseTypeSearch" runat="server" AutoGenerateColumns="False" KeyFieldName="CaseTypeId" OnRowDeleting="gvCaseTypeSearch_RowDeleting">
                <Columns>
                    <%--  <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Case Code">
                            <DataItemTemplate>
                                <a id="clickElement" target="_self" href="/CaseType.aspx?CaseTypeId=<%# Container.KeyValue%>"><%#  Eval("CaseCode").ToString()%> </a>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>--%>


                    <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0">
                        <DeleteButton Visible="True">
                            <Image Url="~/Images/delete.png">
                            </Image>
                        </DeleteButton>
                    </dx:GridViewCommandColumn>


                    <dx:GridViewDataHyperLinkColumn Caption="Case Code" FieldName="CaseTypeId" VisibleIndex="1">
                        <PropertiesHyperLinkEdit NavigateUrlFormatString="/CaseType.aspx?CaseTypeId={0}" TextField="CaseCode">
                        </PropertiesHyperLinkEdit>
                        <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />
                    </dx:GridViewDataHyperLinkColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Case Description" FieldName="CaseDescription" ShowInCustomizationForm="True">
                        <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" />
                    </dx:GridViewDataTextColumn>

                </Columns>
                <SettingsBehavior ConfirmDelete="True" />
                <Settings ShowFilterRow="True" />
            </dx:ASPxGridView>
        </div>
        <div class="clearfix form-actions">
            <dx:ASPxButton ID="btnBack" runat="server" Text="Back" PostBackUrl="~/CaseType.aspx"></dx:ASPxButton>
        </div>

    </div>
</asp:Content>





