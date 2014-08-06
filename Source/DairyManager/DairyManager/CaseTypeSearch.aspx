<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaseTypeSearch.aspx.cs" Inherits="DairyManager.CaseTypeSearch" MasterPageFile="~/Site.master"  %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
            <h1>Case Type Search</h1>
            <div>
                <dx:ASPxGridView ID="gvCaseTypeSearch" runat="server" AutoGenerateColumns="False" KeyFieldName="CaseTypeId">
                    <Columns>
                        <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Case Code">
                            <DataItemTemplate>
                                <a id="clickElement" target="_blank" href="/Case.aspx?CaseTypeId=<%# Container.KeyValue%>"><%#  Eval("CaseCode").ToString()%> </a>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Case Description" FieldName="CaseDescription" ShowInCustomizationForm="True">
                        </dx:GridViewDataTextColumn>

                    </Columns>
                    <Settings ShowFilterRow="True" />
                </dx:ASPxGridView>
            </div>
            <div>
                <dx:ASPxButton ID="btnBack" runat="server" Text="Back" PostBackUrl="~/CaseType.aspx"></dx:ASPxButton>
            </div>

        </div>
</asp:Content>

    



