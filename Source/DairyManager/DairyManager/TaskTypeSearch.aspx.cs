using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            bll.Task currentTask = new bll.Task();
            gvTaskTypeSearch.DataSource = currentTask.SelectTaskTypeAll().Tables[0];
            gvTaskTypeSearch.DataBind();
        }
    }
}