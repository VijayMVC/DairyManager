using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxMenu;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Internal;
using DevExpress.XtraScheduler;
using Diary.Common;

namespace DairyManager
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master.LoggedUser == null)
            {
                Session[Constant.SESSION_LOGGEDUSER] = null;
                Response.Redirect(Constant.URL_LOGIN, false);
                return;
            }

            MapSchedulerFields();
        }

        private void MapSchedulerFields()
        {
            DataSet dsTimeLineData = GetTimelineData();

            dsTimeLineData.Tables[0].PrimaryKey = new DataColumn[] { dsTimeLineData.Tables[0].Columns["TaskId"] };
            dsTimeLineData.Tables[1].PrimaryKey = new DataColumn[] { dsTimeLineData.Tables[1].Columns["UserId"] };

            DataRelation tableRelation = new DataRelation("ReservationRoomRel", dsTimeLineData.Tables[1].Columns["UserId"], dsTimeLineData.Tables[0].Columns["FeeEarner"]);
            dsTimeLineData.Relations.Add(tableRelation);

            Scheduler.ResourceDataSource = dsTimeLineData.Tables[1];
            Scheduler.Storage.Resources.Mappings.ResourceId = "UserId";
            Scheduler.Storage.Resources.Mappings.Caption = "Name";

            //Scheduler.Storage.

            Scheduler.Views.WorkWeekView.Enabled = false;
            Scheduler.AppointmentDataSource = dsTimeLineData.Tables[0];
            Scheduler.Storage.Appointments.Mappings.AppointmentId = "TaskId";
            Scheduler.Storage.Appointments.Mappings.Start = "StartTime";
            Scheduler.Storage.Appointments.Mappings.End = "EndTime";
            //Scheduler.Storage.Appointments.Mappings.Label = "CaseDescription";
            Scheduler.Storage.Appointments.Mappings.Label = "CaseDescription";
            Scheduler.Storage.Appointments.Mappings.Subject = "Label";
            Scheduler.Storage.Appointments.Mappings.ResourceId = "FeeEarner";
            //Scheduler.Storage.Appointments.Mappings.Description = "Label";
            Scheduler.Storage.Appointments.Mappings.Description = "Label";


            Scheduler.DataBind();
        }

        protected DataSet GetTimelineData()
        {

            DataSet dsTasks = new Diary.BLL.Task().SelectDashboardData(DateTime.Now.AddMonths(-3), DateTime.Now.AddMonths(3));
            return dsTasks;
        }

        protected void ASPxScheduler1_BeforeExecuteCallbackCommand(object sender, SchedulerCallbackCommandEventArgs e)
        {
            if (e.CommandId == "MNUVIEW")
                e.Command = new DairyCustomMenuViewCallbackCommand(Scheduler);
            else if (e.CommandId == "USRAPTMENU")
                e.Command = new DashboardCustomMenuAppointmentCallbackCommand(Scheduler);
        }

        protected void ASPxScheduler1_PopupMenuShowing(object sender, DevExpress.Web.ASPxScheduler.PopupMenuShowingEventArgs e)
        {
            ASPxSchedulerPopupMenu menu = e.Menu;
            DevExpress.Web.ASPxMenu.MenuItemCollection menuItems = menu.Items;
            if (menu.Id.Equals(SchedulerMenuItemId.DefaultMenu))
            {
                ClearUnusedDefaultMenuItems(menu);
                menu.ClientSideEvents.ItemClick = String.Format("function(s, e) {{ DefaultAppointmentMenuHandler({0}, s, e); }}", Scheduler.ClientID);

                menu.Items.Clear();
                DevExpress.Web.ASPxMenu.MenuItem addTask = new DevExpress.Web.ASPxMenu.MenuItem("Add new task", "AddTaskId");
                addTask.BeginGroup = true;
                menuItems.Add(addTask);
            }
            else if (menu.Id.Equals(SchedulerMenuItemId.AppointmentMenu))
            {
                //menu.ClientSideEvents.ItemClick = String.Format("function(s, e) {{ DefaultAppointmentMenuHandler({0}, s, e); }}", ASPxScheduler1.ClientID);
                menu.Items.Clear();
                //AddScheduleNewEventSubMenu(menu, "Change Event");
                //MenuItem addTask = new MenuItem("AddTask", "AddTaskId");
                //addTask.BeginGroup = true;
                //menuItems.Add(addTask);
            }
        }

        protected void ClearUnusedDefaultMenuItems(ASPxSchedulerPopupMenu menu)
        {
            RemoveMenuItem(menu, "NewAppointment");
            RemoveMenuItem(menu, "NewAllDayEvent");
            RemoveMenuItem(menu, "NewRecurringAppointment");
            RemoveMenuItem(menu, "NewRecurringEvent");
            RemoveMenuItem(menu, "GotoToday");
            //RemoveMenuItem(menu, "GotoDate");
        }

        //protected void AddScheduleNewEventSubMenu(ASPxSchedulerPopupMenu menu, string caption)
        //{
        //    MenuItem newWithTemplateItem = new MenuItem(caption, "TemplateEvents");
        //    newWithTemplateItem.BeginGroup = true;
        //    menu.Items.Insert(0, newWithTemplateItem);
        //    AddTemplatesSubMenuItems(newWithTemplateItem);
        //}

        private static void AddTemplatesSubMenuItems(DevExpress.Web.ASPxMenu.MenuItem parentMenuItem)
        {
            parentMenuItem.Items.Add(new DevExpress.Web.ASPxMenu.MenuItem("SubMenu1Id", "SubMenu1Id"));
            parentMenuItem.Items.Add(new DevExpress.Web.ASPxMenu.MenuItem("SubMenu2Id", "SubMenu2Id"));
            parentMenuItem.Items.Add(new DevExpress.Web.ASPxMenu.MenuItem("SubMenu3Id", "SubMenu3Id"));
            parentMenuItem.Items.Add(new DevExpress.Web.ASPxMenu.MenuItem("SubMenu4Id", "SubMenu4Id"));
            parentMenuItem.Items.Add(new DevExpress.Web.ASPxMenu.MenuItem("SubMenu5Id", "SubMenu5Id"));
        }

        protected void RemoveMenuItem(ASPxSchedulerPopupMenu menu, string menuItemName)
        {
            DevExpress.Web.ASPxMenu.MenuItem item = menu.Items.FindByName(menuItemName);
            if (item != null)
                menu.Items.Remove(item);
        }

    }

}

#region CustomMenuViewCallbackCommand

public class DairyCustomMenuViewCallbackCommand : MenuViewCallbackCommand
{
    string myMenuItemId;

    public DairyCustomMenuViewCallbackCommand(ASPxScheduler control)
        : base(control)
    {
    }

    public string MyMenuItemId 
    { 
        get 
        { 
            return myMenuItemId; 
        } 
    }

    protected override void ParseParameters(string parameters)
    {
        this.myMenuItemId = parameters;
        base.ParseParameters(parameters);
    }

    protected override void ExecuteCore()
    {
        ExecuteUserMenuCommand(MyMenuItemId);
        base.ExecuteCore();
    }

    protected internal virtual void ExecuteUserMenuCommand(string menuItemId)
    {
        if (menuItemId == "SubMenu1Id")
            CreateAppointment("Check engine oil", AppointmentStatusType.Busy, 4);
        else if (menuItemId == "SubMenu2Id")
            CreateAppointment("Wash the car", AppointmentStatusType.OutOfOffice, 1);
        else if (menuItemId == "SubMenu3Id")
            CreateAppointment("Wax the car", AppointmentStatusType.Tentative, 1);
        else if (menuItemId == "SubMenu4Id")
            CreateAppointment("Check transmission fluid", AppointmentStatusType.Busy, 6);
        else if (menuItemId == "SubMenu5Id")
            CreateAppointment("Inspect by mechanic", AppointmentStatusType.Busy, 7);
    }

    protected void CreateAppointment(string subject, AppointmentStatusType statusType, int labelId)
    {
        Appointment apt = Control.Storage.CreateAppointment(AppointmentType.Normal);
        apt.Subject = subject;
        apt.Start = Control.SelectedInterval.Start;
        apt.End = Control.SelectedInterval.End;
        apt.ResourceId = Control.SelectedResource.Id;
        apt.StatusId = (int)statusType;
        apt.LabelId = labelId;
        Control.Storage.Appointments.Add(apt);
    }
}

#endregion


#region CustomMenuAppointmentCallbackCommand

public class DashboardCustomMenuAppointmentCallbackCommand : SchedulerCallbackCommand
{
    string menuItemId = String.Empty;

    public DashboardCustomMenuAppointmentCallbackCommand(ASPxScheduler control)
        : base(control)
    {
    }

    public override string Id
    {
        get
        {
            return "USRAPTMENU";
        }
    }

    public string MenuItemId
    {
        get
        {
            return menuItemId;
        }
    }

    protected override void ParseParameters(string parameters)
    {
        this.menuItemId = parameters;
    }

    protected override void ExecuteCore()
    {
        string pageredirect = "~/Task.aspx";
        //Appointment apt = Control.SelectedAppointments[0];

        if (MenuItemId == "AddTaskId")
        {
            HttpContext.Current.Session["TaskStartDate"] = Control.SelectedInterval.Start;
        }

        //else if (MenuItemId == "CheckEngineOilId")
        //    UpdateAppointment(apt, "Check engine oil", AppointmentStatusType.Busy, 4);
        //else if (MenuItemId == "WashCarId")
        //    UpdateAppointment(apt, "Wash the car", AppointmentStatusType.OutOfOffice, 1);
        //else if (MenuItemId == "WaxCarId")
        //    UpdateAppointment(apt, "Wax the car", AppointmentStatusType.Tentative, 1);
        //else if (MenuItemId == "CheckTransmissionFluidId")
        //    UpdateAppointment(apt, "Check transmission fluid", AppointmentStatusType.Busy, 6);
        //else if (MenuItemId == "InspectByMechanicId")
        //    UpdateAppointment(apt, "Inspect by mechanic", AppointmentStatusType.Busy, 7);
    }

    //protected void UpdateAppointment(Appointment apt, string subject, AppointmentStatusType statusType, int labelId)
    //{
    //    apt.Subject = subject;
    //    apt.StatusId = (int)statusType;
    //    apt.LabelId = labelId;
    //}
}

#endregion
