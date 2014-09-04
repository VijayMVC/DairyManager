<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task.aspx.cs" Inherits="DairyManager.Task"
    MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div class="page-header">
            <h1>
                Task</h1>
        </div>
        <asp:HiddenField ID="hdnTaskId" runat="server" />
        <div class="form-group">
            <div>
                <span>Date</span> <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxDateEdit ID="dtDate" runat="server" EditFormat="DateTime" EditFormatString="dd-MMM-yy HH:mm"
                    UseMaskBehavior="True">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxDateEdit>
            </div>
        </div>
        <div class="form-group">
            <div>
                <span>Task Creator</span> <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxComboBox ID="cmbTaskCreator" runat="server" ValueType="System.String" IncrementalFilteringMode="Contains">
                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </div>
        </div>
        <div class="form-group">
            <div>
                <span>Fee Earner</span> <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxComboBox ID="cmbFeeEarner" runat="server" ValueType="System.String" IncrementalFilteringMode="Contains">
                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </div>
        </div>
        <div class="form-group">
            <div>
                <span>Case</span> <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxComboBox ID="cmbCase" runat="server" IncrementalFilteringMode="Contains"
                    TextFormatString="{0}" AutoPostBack="True" OnSelectedIndexChanged="cmbCase_SelectedIndexChanged">
                    <Columns>
                        <dx:ListBoxColumn Caption="UFN" FieldName="Code" />
                        <dx:ListBoxColumn Caption="Clients" FieldName="Name" />
                    </Columns>
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </div>
        </div>
        
        <div class="form-group">
            <dx:ASPxGridView ID="gvHistory" runat="server" AutoGenerateColumns="False" Visible="False">
                <TotalSummary>
                    <dx:ASPxSummaryItem DisplayFormat="Total {0:N2}" FieldName="TotalHours" ShowInColumn="Total Hours"
                        SummaryType="Sum" />
                </TotalSummary>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="Case" FieldName="Code" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Task Description" FieldName="TaskDescription"
                        VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Start Time" FieldName="StartTime" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="End Time" FieldName="EndTime" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Total Hours" FieldName="TotalHours" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Settings ShowFooter="True" />
            </dx:ASPxGridView>
        </div>
        <div class="form-group">
            <div>
                <span>Total number of hours remaining</span> <span></span>
            </div>
            <div class="input-group">
                <dx:ASPxLabel ID="lblRemainingHours" runat="server" Text="0">
                </dx:ASPxLabel>
            </div>
        </div>
        <div class="form-group">
            <div>
                <span>Maximum Recording</span> <span></span>
            </div>
            <div class="input-group">
                <dx:ASPxLabel ID="lblMaximumRecording" runat="server" Text="0">
                </dx:ASPxLabel>
            </div>
        </div>

        <div class="form-group">
            <div>
                <span>Task Type</span> <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxComboBox ID="cmbTaskType" runat="server" ValueType="System.String" IncrementalFilteringMode="Contains">
                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </div>
        </div>
        <div class="form-group">
            <div>
                <span>Task Description</span> <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtTaskDescription" runat="server" Width="170px" MaxLength="100">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </div>
        </div>
        <div class="form-group">
            <div>
                <span>Task start time</span> <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxTimeEdit ID="teStartTime" runat="server" EditFormatString="HH:mm" ClientInstanceName="startTime" EditFormat="Custom">
                    <ClientSideEvents Validation="function(s, e) {
	



}" />
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave" EnableCustomValidation="True" ErrorText="Invalid">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTimeEdit>
            </div>
        </div>
        <div class="form-group">
            <div>
                <span>Task end time</span> <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxTimeEdit ID="teEndTime" runat="server" EditFormat="Custom" EditFormatString="HH:mm" ClientInstanceName="endTime">
                    <ClientSideEvents Validation="function(s, e) {
	var startTimeText= startTime.GetText();
    var endTimeText = endTime.GetText();     
	

	if (endTimeText  &gt;  startTimeText)
	{
		    e.isValid = true;
	}
	else
	{
    		e.isValid = false;
	}
	
	

}" />
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave" EnableCustomValidation="True" ErrorText="Invalid">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTimeEdit>
            </div>
        </div>
        <div class="form-group">
            <div>
                <span>Total number of hours</span> <span></span>
            </div>
            <div class="input-group">
                <dx:ASPxSpinEdit ID="seTotalHours" runat="server" Height="21px" Number="0">
                    <ClientSideEvents Validation="function(s, e) {
	if(e.value &lt;=0 ) {e.isValid=false;}
}" />
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" 
                        ValidationGroup="vgSave" EnableCustomValidation="True" ErrorText="Invalid">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxSpinEdit>
            </div>
        </div>
        <div class="clearfix form-actions">
            <div>
                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vgSave">
                </dx:ASPxButton>
            </div>
            <div>
                <dx:ASPxButton ID="btnClear" runat="server" Text="Clear" CausesValidation="False"
                    OnClick="btnClear_Click">
                </dx:ASPxButton>
            </div>
            <div>
                <dx:ASPxButton ID="btnSearch" runat="server" Text="Search" PostBackUrl="~/TaskSearch.aspx">
                </dx:ASPxButton>
            </div>
        </div>
    </div>
</asp:Content>
