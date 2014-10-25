<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DairyManager.Dashboard" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>

<%@ Register Src="~/DashboardTemplates/DairyVerticalAppointmentTemplate.ascx" TagName="DairyVerticalAppointment" TagPrefix="dva" %>
<%@ Register Src="~/DashboardTemplates/DairyHorizontalAppointmentTemplate.ascx" TagName="DairyHorizontalAppointment" TagPrefix="dva" %>
<%@ Register Src="~/DashboardTemplates/DairyHorizontalSameDayAppointmentTemplate.ascx" TagName="DairyHorizontalSameDayAppointment" TagPrefix="dva" %>

<%@ Register Assembly="DevExpress.XtraScheduler.v12.2.Core, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraScheduler" TagPrefix="cc1" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="page-header">
        <h1>Dashboard</h1>
    </div>
    <div>
        <dxwschs:ASPxScheduler ID="Scheduler" runat="server" ActiveViewType="Month" OnBeforeExecuteCallbackCommand="ASPxScheduler1_BeforeExecuteCallbackCommand" OnPopupMenuShowing="ASPxScheduler1_PopupMenuShowing" ClientIDMode="AutoID" Start="2014-09-08">
            <Views>
                <DayView>
                    <Templates>
                        <VerticalAppointmentTemplate>
                            <dva:DairyVerticalAppointment runat="server" />
                        </VerticalAppointmentTemplate>
                    </Templates>
                    <TimeRulers>
                        <cc1:TimeRuler></cc1:TimeRuler>
                    </TimeRulers>
                </DayView>

                <WorkWeekView>
                    <Templates>
                        <VerticalAppointmentTemplate>
                            <dva:DairyVerticalAppointment ID="DairyVerticalAppointment1" runat="server" />
                        </VerticalAppointmentTemplate>
                    </Templates>
                    <TimeRulers>
                        <cc1:TimeRuler></cc1:TimeRuler>
                    </TimeRulers>
                </WorkWeekView>
                <WeekView NavigationButtonVisibility="Never">
                   <Templates>
                        <HorizontalSameDayAppointmentTemplate>
                            <dva:DairyHorizontalSameDayAppointment ID="DairyHorizontalSameDayAppointment1" runat="server" />
                        </HorizontalSameDayAppointmentTemplate>
                    </Templates>
                    <AppointmentDisplayOptions EndTimeVisibility="Always" StartTimeVisibility="Always" TimeDisplayType="Text" AppointmentHeight="40" ShowRecurrence="False" ShowReminder="False" />
                </WeekView>
                <MonthView>
                    <AppointmentDisplayOptions StartTimeVisibility="Always" AppointmentHeight="100" EndTimeVisibility="Always" />
                    <Templates>
                        <HorizontalSameDayAppointmentTemplate>
                            <dva:DairyHorizontalSameDayAppointment runat="server" />
                        </HorizontalSameDayAppointmentTemplate>
                    </Templates>
                </MonthView>
                <TimelineView Enabled="False">
                    <TimelineViewStyles>
                        <TimelineCellBody Wrap="False">
                        </TimelineCellBody>
                    </TimelineViewStyles>
                    <AppointmentDisplayOptions AppointmentAutoHeight="True" EndTimeVisibility="Always" StartTimeVisibility="Always" StatusDisplayType="Time" TimeDisplayType="Clock" />
                    <CellAutoHeightOptions Mode="FitToContent" />
                </TimelineView>
            </Views>
            <OptionsCustomization AllowAppointmentCopy="None" AllowAppointmentCreate="None" AllowAppointmentDelete="None" AllowAppointmentDrag="None" AllowAppointmentDragBetweenResources="None" AllowAppointmentEdit="None" AllowAppointmentMultiSelect="False" AllowAppointmentResize="None" AllowDisplayAppointmentDependencyForm="Never" AllowInplaceEditor="None" />
            <OptionsForms AppointmentFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/AppointmentForm.ascx" AppointmentFormVisibility="None" AppointmentInplaceEditorFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/InplaceEditor.ascx" GotoDateFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/GotoDateForm.ascx" RecurrentAppointmentDeleteFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/RecurrentAppointmentDeleteForm.ascx" RecurrentAppointmentDeleteFormVisibility="None" RecurrentAppointmentEditFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/RecurrentAppointmentEditForm.ascx" RecurrentAppointmentEditFormVisibility="None" RemindersFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/ReminderForm.ascx" />
            <OptionsToolTips AppointmentDragToolTipUrl="~/DevExpress/ASPxSchedulerForms/AppointmentDragToolTip.ascx" AppointmentToolTipUrl="~/DevExpress/ASPxSchedulerForms/AppointmentToolTip.ascx" SelectionToolTipUrl="~/DevExpress/ASPxSchedulerForms/SelectionToolTip.ascx" ShowAppointmentDragToolTip="False" AppointmentToolTipCornerType="Rounded" SelectionToolTipCornerType="Rounded" />
            <ResourceNavigator Visibility="Always" EnableFirstLast="False" EnableIncreaseDecrease="False" />
        </dxwschs:ASPxScheduler>
    </div>
    <script type="text/javascript">
        // <![CDATA[
        function DefaultAppointmentMenuHandler(scheduler, s, args) {
            if (args.item.GetItemCount() <= 0) {
                scheduler.RaiseCallback("USRAPTMENU|" + args.item.name);
                sleep(1500);
                document.location.href = '/Task.aspx';
            }

        }

        function sleep(milliseconds) {
            var start = new Date().getTime();
            for (var i = 0; i < 1e7; i++) {
                if ((new Date().getTime() - start) > milliseconds) {
                    break;
                }
            }
        }
        // ]]> 
    </script>
</asp:Content>
