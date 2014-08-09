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
            <dx:ASPxGridView ID="gvCaseSearch" runat="server" AutoGenerateColumns="False" KeyFieldName="CaseId">
                <Columns>
                    <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Case Code">
                        <DataItemTemplate>
                            <a id="clickElement" target="_blank" href="/Case.aspx?CaseId=<%# Container.KeyValue%>"><%#  Eval("Code").ToString()%> </a>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Case" FieldName="Case" ShowInCustomizationForm="True">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="3" Caption="Name" FieldName="Name" ShowInCustomizationForm="True">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="4" Caption="CaseCode" FieldName="CaseCode" ShowInCustomizationForm="True">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="5" Caption="Email" FieldName="Email" ShowInCustomizationForm="True">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="6" Caption="Contact" FieldName="Contact" ShowInCustomizationForm="True">
                    </dx:GridViewDataTextColumn>

                </Columns>
                <Settings ShowFilterRow="True" />
            </dx:ASPxGridView>

        </div>
        <div class="clearfix form-actions">
            <dx:ASPxButton ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Case.aspx"></dx:ASPxButton>
        </div>

    </div>
</asp:Content>











