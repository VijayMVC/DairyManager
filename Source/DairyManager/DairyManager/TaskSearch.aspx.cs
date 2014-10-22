using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll = Diary.BLL;
using com = Diary.Common;
using Diary.Common;

namespace DairyManager
{
    public partial class TaskSearch : System.Web.UI.Page
    {
        bll.Task currentTask = new bll.Task();


        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadData();
            this.AuthoriseUser();
        }

        private void AuthoriseUser()
        {
            if (Master.LoggedUser == null)
            {
                Session[Constant.SESSION_LOGGEDUSER] = null;
                Response.Redirect(Constant.URL_LOGIN, false);
                return;
            }

            btnBack.Visible = (Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Task_Task_Add));
            gvTaskSearch.Columns["TaskId"].Visible = Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Task_Task_Edit);

            if (!Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Task_Task_Search))
            {
                Response.Redirect(com.Constant.URL_UNAUTHORISEDACTION, false);
            }
        }

        private void LoadData()
        {
            gvTaskSearch.DataSource = currentTask.SelectTaskAll().Tables[0];
            gvTaskSearch.DataBind();
        }

        protected void gvTaskSearch_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;

            currentTask.DeleteTask((Guid)e.Keys[gvTaskSearch.KeyFieldName]);
            this.LoadData();
        }
    }
}