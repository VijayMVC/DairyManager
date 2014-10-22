<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DairyManager.Dashboard" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>



<%@ Register Assembly="DevExpress.XtraScheduler.v12.2.Core, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraScheduler" TagPrefix="cc1" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  <div class="page-header">
            <h1>Dashboard</h1>
        </div>
    <div>
        <dxwschs:ASPxScheduler ID="Scheduler" runat="server" ActiveViewType="Month" GroupType="Resource" OnBeforeExecuteCallbackCommand="ASPxScheduler1_BeforeExecuteCallbackCommand" OnPopupMenuShowing="ASPxScheduler1_PopupMenuShowing" ClientIDMode="AutoID" Start="2014-09-08">
            <Views>
                <DayView>
                    <TimeRulers>
                        <cc1:TimeRuler ShowCurrentTime="False"></cc1:TimeRuler>
                    </TimeRulers>
                </DayView>

                <WorkWeekView>
                    <TimeRulers>
                        <cc1:TimeRuler></cc1:TimeRuler>
                    </TimeRulers>
                </WorkWeekView>
                <WeekView NavigationButtonVisibility="Never">
                </WeekView>
                <MonthView>
                    <Templates>
                        <DateCellBodyTemplate>
                           
                        </DateCellBodyTemplate>
                    </Templates>
                </MonthView>
            </Views>
            <OptionsCustomization AllowAppointmentConflicts="Forbidden" AllowAppointmentCopy="None" AllowAppointmentCreate="None" AllowAppointmentDelete="None" AllowAppointmentDrag="None" AllowAppointmentDragBetweenResources="None" AllowAppointmentEdit="NonRecurring" AllowAppointmentMultiSelect="False" AllowAppointmentResize="None" AllowDisplayAppointmentDependencyForm="Never" AllowInplaceEditor="None" />
            <OptionsForms AppointmentFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/AppointmentForm.ascx" AppointmentFormVisibility="None" AppointmentInplaceEditorFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/InplaceEditor.ascx" GotoDateFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/GotoDateForm.ascx" RecurrentAppointmentDeleteFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/RecurrentAppointmentDeleteForm.ascx" RecurrentAppointmentDeleteFormVisibility="None" RecurrentAppointmentEditFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/RecurrentAppointmentEditForm.ascx" RecurrentAppointmentEditFormVisibility="None" RemindersFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/ReminderForm.ascx" />
            <OptionsToolTips AppointmentDragToolTipUrl="~/DevExpress/ASPxSchedulerForms/AppointmentDragToolTip.ascx" AppointmentToolTipUrl="~/DevExpress/ASPxSchedulerForms/AppointmentToolTip.ascx" SelectionToolTipUrl="~/DevExpress/ASPxSchedulerForms/SelectionToolTip.ascx" ShowAppointmentDragToolTip="False" />
            <ResourceNavigator Visibility="Never" />
        </dxwschs:ASPxScheduler>
    </div>
    <script type="text/javascript">
        // <![CDATA[
        function DefaultAppointmentMenuHandler(scheduler, s, args) {
            if (args.item.GetItemCount() <= 0)
            {
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
