﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourtSearch.aspx.cs" Inherits="DairyManager.CourtSearch" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div class="page-header">
            <h1>Court Search</h1>
        </div>
        <div>
            <dx:ASPxGridView ID="gvCaseTypeSearch" runat="server" AutoGenerateColumns="False" KeyFieldName="CourtId" OnRowDeleting="gvCaseTypeSearch_RowDeleting">
                <Columns>
   

                    <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0">
                        <DeleteButton Visible="True">
                            <Image Url="~/Images/delete.png">
                            </Image>
                        </DeleteButton>
                    </dx:GridViewCommandColumn>


                    <dx:GridViewDataHyperLinkColumn Caption="Court" FieldName="CourtId" VisibleIndex="1">
                        <PropertiesHyperLinkEdit NavigateUrlFormatString="/Court.aspx?CourtId={0}" TextField="Court">
                        </PropertiesHyperLinkEdit>
                        <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />
                    </dx:GridViewDataHyperLinkColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Court Type" 
                        FieldName="CourtType">
                        <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" />
                    </dx:GridViewDataTextColumn>

                      <dx:GridViewDataTextColumn VisibleIndex="3" Caption="Police Station" 
                        FieldName="PoliceStation" Visible="False">
                    </dx:GridViewDataTextColumn>


                </Columns>
                <SettingsBehavior ConfirmDelete="True" />
                <Settings ShowFilterRow="True" />
            </dx:ASPxGridView>
        </div>
        <div class="clearfix form-actions">
            <dx:ASPxButton ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Court.aspx"></dx:ASPxButton>
        </div>

    </div>
</asp:Content>





