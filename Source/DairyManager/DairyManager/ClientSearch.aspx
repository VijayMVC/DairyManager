<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientSearch.aspx.cs" Inherits="DairyManager.ClientSearch" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div class="page-header">
        <h1>Client Search</h1>
            </div>
        <div>
            <dx:ASPxGridView ID="gvClientSearch" runat="server" AutoGenerateColumns="False" KeyFieldName="ClientId" OnRowDeleting="gvClientSearch_RowDeleting">
                <Columns>
                    <%--<dx:GridViewDataTextColumn VisibleIndex="1" Caption="Name">
                        <DataItemTemplate>
                            <a id="clickElement" target="_blank" href="/Client.aspx?ClientId=<%# Container.KeyValue%>"><%#  Eval("Name").ToString()%> </a>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>--%>


                     <dx:GridViewDataHyperLinkColumn Caption="Name" FieldName="ClientId" VisibleIndex="1">
                        <PropertiesHyperLinkEdit NavigateUrlFormatString="/Client.aspx?ClientId={0}" TextField="Name">
                        </PropertiesHyperLinkEdit>
                        <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />
                    </dx:GridViewDataHyperLinkColumn>

                    <dx:GridViewDataTextColumn Caption="DOB" FieldName="DOB" VisibleIndex="2">
                        <PropertiesTextEdit DisplayFormatString="dd-MMM-yy">
                        </PropertiesTextEdit>
                        <Settings FilterMode="DisplayText" />
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="3" Caption="Address Line 1" 
                        FieldName="AddressLine1">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="4" Caption="Address Line 2" 
                        FieldName="AddressLine2">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="5" Caption="Address Line 3" 
                        FieldName="AddressLine3">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="6" Caption="Telephone" 
                        FieldName="Telephone">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="7" Caption="Fax" FieldName="Fax">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="8" Caption="Email" FieldName="Email">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="9" Caption="Contact Person" 
                        FieldName="ContactPerson">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0">
                        <DeleteButton Visible="True">
                            <Image Url="~/Images/delete.png">
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
        <div class="clearfix form-actions">
            <dx:ASPxButton ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Client.aspx"></dx:ASPxButton>
        </div>

    </div>
</asp:Content>


