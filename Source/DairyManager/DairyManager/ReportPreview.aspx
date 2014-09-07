<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportPreview.aspx.cs"
    Inherits="DairyManager.ReportPreview" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Styles/Site.css" rel="stylesheet" />
    <link rel="stylesheet" href="/assets/css/bootstrap.min.css" />
    <title>Report Preview</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <dx:ASPxFilterControl ID="ASPxFilterControl1" runat="server" ClientInstanceName="filter">
                <Columns>
                    <dx:FilterControlDateColumn ColumnType="DateTime" DisplayName="Task Date" PropertyName="TaskDate">
                    </dx:FilterControlDateColumn>
                </Columns>
                <ClientSideEvents Applied="function(s, e) {
	 grid.ApplyFilter(e.filterExpression);
}" />
            </dx:ASPxFilterControl>
        </div>
        <div>
            <dx:ASPxButton ID="btnApply" runat="server" Text="Apply" AutoPostBack="False" UseSubmitBehavior="False">
                <ClientSideEvents Click="function(s, e) {
	filter.Apply();
}" />
            </dx:ASPxButton>
        </div>
        <div>
            <dx:ASPxGridView ID="gvReports" runat="server" Width="100%" EnableViewState="False"
                ClientInstanceName="grid">
                <Settings HorizontalScrollBarMode="Auto" ShowFilterRow="True" ShowFooter="True" ShowGroupFooter="VisibleIfExpanded"
                    ShowGroupPanel="True" />
            </dx:ASPxGridView>
        </div>
        <div>
            <dx:ASPxGridViewExporter ID="gvExporter" runat="server" GridViewID="gvReports" BottomMargin="20"
                LeftMargin="20" RightMargin="20" TopMargin="20">
            </dx:ASPxGridViewExporter>
        </div>
        <div>
            <dx:ASPxComboBox ID="cbmExporter" runat="server" OnButtonClick="cbmExporter_ButtonClick"
                Width="200px" SelectedIndex="0" Visible="False">
                <Items>
                    <dx:ListEditItem Text="PDF" Value="PDF" Selected="True" />
                    <dx:ListEditItem Text="RTF" Value="RTF" />
                    <dx:ListEditItem Text="Excel" Value="Excel" />
                    <dx:ListEditItem Text="CSV" Value="CSV" />
                </Items>
                <DropDownButton Position="Left">
                </DropDownButton>
                <Buttons>
                    <dx:EditButton Text="Export Report" Width="100px">
                    </dx:EditButton>
                </Buttons>
            </dx:ASPxComboBox>
        </div>
    </div>
    </form>
</body>
</html>
