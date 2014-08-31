﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll = Diary.BLL;
using com = Diary.Common;

namespace DairyManager
{
    public partial class TaskTypeSearch : System.Web.UI.Page
    {
        bll.Task currentTask = new bll.Task();


        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadData();
            this.AuthoriseUser();
        }

        private void AuthoriseUser()
        {
            btnBack.Visible = (Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Task_TaskType_Add));
            gvTaskTypeSearch.Columns["TaskTypeId"].Visible = Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Task_TaskType_Edit);

            if (!Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Task_TaskType_Search))
            {
                Response.Redirect(com.Constant.URL_UNAUTHORISEDACTION, false);
            }
        }

        private void LoadData()
        {
            gvTaskTypeSearch.DataSource = currentTask.SelectTaskTypeAll().Tables[0];
            gvTaskTypeSearch.DataBind();
        }

        protected void gvTaskTypeSearch_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;

            currentTask.DeleteTaskType((Guid)e.Keys[gvTaskTypeSearch.KeyFieldName]);
            this.LoadData();
        }
    }
}