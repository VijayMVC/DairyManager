using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diary.Common;
using Diary.Entity;
using Diary.BLL;
using com = Diary.Common;
using System.Data;

namespace DairyManager
{
    public partial class TaskType : System.Web.UI.Page
    {
        Diary.BLL.Task currentTask = new Diary.BLL.Task();
        Diary.Entity.TaskTypeEntity taskTypeEntity = new TaskTypeEntity();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnTaskTypeId.Value = Master.GetQueryStringValueByKey(Request, com.Enum.QueryStringParameters.CaseId.ToString());

                if (hdnTaskTypeId.Value != string.Empty)
                {
                    this.DisplayRecord(new Guid(hdnTaskTypeId.Value));
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {


            if (hdnTaskTypeId.Value == string.Empty)
            {
                taskTypeEntity.TaskDescription = txtTaskDescription.Text.Trim();
                taskTypeEntity.TaskCode = txtTaskCode.Text.Trim();
                taskTypeEntity.CreatedBy = (Guid)Master.LogedUser.ProviderUserKey;

                if (!currentTask.IsTaskTypeExists(taskTypeEntity.TaskCode))
                {
                    currentTask.InsertTaskType(taskTypeEntity);
                }
                else
                {
                    //message already exists.
                }
            }
            else
            {
                taskTypeEntity.TaskDescription = txtTaskDescription.Text.Trim();
                taskTypeEntity.TaskCode = txtTaskCode.Text.Trim();
                taskTypeEntity.UpdatedBy = (Guid)Master.LogedUser.ProviderUserKey;

                currentTask.UpdateTaskType(taskTypeEntity);

            }


        }

        private void DisplayRecord(Guid id)
        {
            DataSet ds = currentTask.SelectTaskByTaskId(id);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                txtTaskDescription.Text = taskTypeEntity.TaskDescription;
                txtTaskCode.Text = taskTypeEntity.TaskCode;
            }
        }
    }
}