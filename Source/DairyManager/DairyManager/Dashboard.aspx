<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DairyManager.Dashboard" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>



<%@ Register Assembly="DevExpress.XtraScheduler.v12.2.Core, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraScheduler" TagPrefix="cc1" %>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  <div class="page-header">
            <h1>Dashboard</h1>
        </div>
    <div>
        <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" ActiveViewType="Month" GroupType="Date" OnBeforeExecuteCallbackCommand="ASPxScheduler1_BeforeExecuteCallbackCommand" OnPopupMenuShowing="ASPxScheduler1_PopupMenuShowing">
            <Views>
                <DayView>
                    <TimeRulers>
                        <cc1:TimeRuler></cc1:TimeRuler>
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
                            sample text
                        </DateCellBodyTemplate>
                    </Templates>
                </MonthView>
            </Views>
            <OptionsCustomization AllowAppointmentConflicts="Forbidden" AllowAppointmentCopy="None" AllowAppointmentCreate="None" AllowAppointmentDelete="None" AllowAppointmentDrag="None" AllowAppointmentDragBetweenResources="None" AllowAppointmentEdit="NonRecurring" AllowAppointmentMultiSelect="False" AllowAppointmentResize="None" AllowDisplayAppointmentDependencyForm="Never" />
        </dxwschs:ASPxScheduler>
    </div>
    <script type="text/javascript">
        // <![CDATA[
        function DefaultAppointmentMenuHandler(scheduler, s, args) {
            if (args.item.GetItemCount() <= 0)
                alert(args.item.name);
            scheduler.RaiseCallback("USRAPTMENU|" + args.item.name);
        }
        // ]]> 
    </script>
</asp:Content>
