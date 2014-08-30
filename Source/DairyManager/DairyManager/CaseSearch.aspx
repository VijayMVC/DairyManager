<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaseSearch.aspx.cs" Inherits="DairyManager.CaseSearch" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div class="page-header">
            <h1>Search Case</h1>
        </div>
        <div>
            <dx:ASPxGridView ID="gvCaseSearch" runat="server" AutoGenerateColumns="False" KeyFieldName="CaseId" OnRowDeleting="gvCaseSearch_RowDeleting">
                <Columns>
                    <%-- <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Case Code">
                        <DataItemTemplate>
                            <a id="clickElement" target="_self" href="/Case.aspx?CaseId=<%# Container.KeyValue%>"><%#  Eval("Code").ToString()%> </a>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>--%>

                    <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0">
                        <DeleteButton Visible="True">
                            <Image Url="~/Images/delete.png">
                            </Image>
                        </DeleteButton>
                    </dx:GridViewCommandColumn>

                    <dx:GridViewDataHyperLinkColumn Caption="UFN" FieldName="CaseId" VisibleIndex="1">
                        <PropertiesHyperLinkEdit NavigateUrlFormatString="/Case.aspx?CaseId={0}" TextField="Code">
                        </PropertiesHyperLinkEdit>
                        <Settings FilterMode="DisplayText" />
                    </dx:GridViewDataHyperLinkColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Case" FieldName="Case" ShowInCustomizationForm="True" Visible="false">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="3" Caption="Offence" FieldName="Offence" ShowInCustomizationForm="True">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="4" Caption="Court" FieldName="Court" ShowInCustomizationForm="True">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="5" Caption="Client" FieldName="Name" ShowInCustomizationForm="True">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="6" Caption="Case Type" FieldName="CaseCode" ShowInCustomizationForm="True">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="7" Caption="Email" FieldName="Email" ShowInCustomizationForm="True" Visible="false">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="8" Caption="Contact" FieldName="Contact" ShowInCustomizationForm="True" Visible="false">
                    </dx:GridViewDataTextColumn>

                </Columns>
                <SettingsBehavior ConfirmDelete="True" />
                <Settings ShowFilterRow="True" />
            </dx:ASPxGridView>

        </div>
        <div class="clearfix form-actions">
            <dx:ASPxButton ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Case.aspx"></dx:ASPxButton>
        </div>

    </div>
</asp:Content>











