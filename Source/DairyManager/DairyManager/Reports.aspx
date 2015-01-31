﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Reports.aspx.cs" Inherits="DairyManager.Reports" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="page-header">
            <h1>
                Reports</h1>
        </div>
        <div class="form-group">
            <div>
                <span>Report Type</span> <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxComboBox ID="cmbReportTyppe" runat="server" ValueType="System.String" IncrementalFilteringMode="Contains">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgGenerate">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </div>
        </div>
        <div class="form-group">
            <div>
                <span>From Date</span> <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxDateEdit ID="deFromDate" runat="server" ClientInstanceName="fromdate" 
                    DisplayFormatString="dd-MMM-yy" EditFormat="Custom" 
                    EditFormatString="dd-MMM-yy">
                    <CalendarProperties ShowClearButton="False">
                    </CalendarProperties>
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" 
                        ValidationGroup="vgGenerate">
                        <RequiredField ErrorText="Require" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxDateEdit>
            </div>
        </div>

        <div class="form-group">
            <div>
                <span>To Date</span> <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxDateEdit ID="deToDate" runat="server" ClientInstanceName="todate" 
                    DisplayFormatString="dd-MMM-yy" EditFormat="Custom" 
                    EditFormatString="dd-MMM-yy">
                    <CalendarProperties ShowClearButton="False">
                    </CalendarProperties>
                    <ClientSideEvents Validation="function(s, e) {

	if (fromdate.GetValue() != '')
{

	var todatetext = new Date(todate.GetValue());
    var fromdatetext = new Date(fromdate.GetValue());     	
	


	if(fromdatetext  &lt;= todatetext )
	{
		    e.isValid = true;
	}
	else
	{
    		e.isValid = false;
	}
}
}" />
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" 
                        ValidationGroup="vgGenerate">
                        <RequiredField ErrorText="Require" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxDateEdit>
            </div>
        </div>

        <div class="clearfix form-actions">
            <div>
                <dx:ASPxButton ID="btnGenerate" runat="server" Text="Generate" ValidationGroup="vgGenerate"
                    OnClick="btnGenerate_Click">
                </dx:ASPxButton>
            </div>
        </div>
        <div>
            <iframe id="iframePage" runat="server" width="100%" height="1000px" style="border: none">
            </iframe>
        </div>
    </div>
</asp:Content>
