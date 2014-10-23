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
    
    <link rel="stylesheet" href="/assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="/assets/css/ace.min.css" />
    <link href="Styles/Site.css" rel="stylesheet" />
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
                    <dx:FilterControlTextColumn ColumnType="String" DisplayName="UFN" PropertyName="UFN">
                    </dx:FilterControlTextColumn>
                </Columns>
                <ClientSideEvents Applied="function(s, e) {
	 grid.ApplyFilter(e.filterExpression);
}" />
            </dx:ASPxFilterControl>
        </div>
        <div class="clearfix form-actions">
            <dx:ASPxButton ID="btnApply" runat="server" Text="Apply" AutoPostBack="False" UseSubmitBehavior="False">
                <ClientSideEvents Click="function(s, e) {
	filter.Apply();
}" />
            </dx:ASPxButton>
        </div>

        <div>
            <div> <span>Group By</span></div>
            <div  class="clearfix form-actions">
                <dx:ASPxRadioButtonList ID="rbGroupBy" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="True" 
                    onselectedindexchanged="rbGroupBy_SelectedIndexChanged" SelectedIndex="0">
                    <Items>
                        <dx:ListEditItem Text="UFN" Value="UFN" Selected="True" />
                        <dx:ListEditItem Text="Task Type" Value="Task Type" />
                        <dx:ListEditItem Text="Client" Value="Client" />
                        <dx:ListEditItem Text="Task Creator" Value="Task Creator" />
                        <dx:ListEditItem Text="Fee Earner" Value="Fee Earner" />
                        <dx:ListEditItem Text="None" Value="None" />
                    </Items>
                    <Border BorderStyle="None" />
                </dx:ASPxRadioButtonList>
            </div>
        
        </div>
        <div>
            <dx:ASPxGridView ID="gvReports" runat="server" Width="100%" EnableViewState="False"
                ClientInstanceName="grid" AutoGenerateColumns="False">
                <TotalSummary>
                    <dx:ASPxSummaryItem DisplayFormat="Total {0}" FieldName="TotalHours" 
                        SummaryType="Sum" />
                </TotalSummary>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="UFN" FieldName="UFN" Name="colUFN" 
                        VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Task Date" FieldName="TaskDate" 
                        Name="colTaskDate" VisibleIndex="1">
                        <PropertiesTextEdit DisplayFormatString="dd-MMM-yy">
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Task Type" FieldName="TaskType" 
                        Name="colTaskType" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Client" FieldName="Client" Name="colClient" 
                        VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="TaskCreator" FieldName="TaskCreator" 
                        Name="colTaskCreator" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="FeeEarner" FieldName="FeeEarner" 
                        Name="colFeeEarner" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="TaskDescription" 
                        FieldName="TaskDescription" Name="colTaskDescription" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Start Time" FieldName="StartTime" 
                        Name="colStartTime" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="End Time" FieldName="EndTime" 
                        Name="colEndTime" VisibleIndex="8">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Hours" FieldName="TotalHours" 
                        Name="colTotalHours" VisibleIndex="9">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Settings HorizontalScrollBarMode="Auto" ShowFilterRow="True" ShowFooter="True" ShowGroupFooter="VisibleIfExpanded"
                    ShowGroupPanel="True" />
            </dx:ASPxGridView>
        </div>
        <div>
            <dx:ASPxGridViewExporter ID="gvExporter" runat="server" GridViewID="gvReports" BottomMargin="20"
                LeftMargin="20" RightMargin="20" TopMargin="20">
            </dx:ASPxGridViewExporter>
        </div>
        <div class="clearfix form-actions">
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
