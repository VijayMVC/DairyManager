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
                hdnTaskTypeId.Value = Master.GetQueryStringValueByKey(Request, com.Enum.QueryStringParameters.TaskTypeId.ToString());

                if (hdnTaskTypeId.Value != string.Empty)
                {
                    this.DisplayRecord(new Guid(hdnTaskTypeId.Value));
                }

            }
            this.AuthoriseUser();
        }

        private void AuthoriseUser()
        {
            btnSave.Visible = (Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Task_TaskType_Add)
                || Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Task_TaskType_Edit));

            if (!Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Task_TaskType_View))
            {
                Response.Redirect(com.Constant.URL_UNAUTHORISEDACTION, false);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            taskTypeEntity.TaskDescription = txtTaskDescription.Text.Trim();
            taskTypeEntity.TaskCode = txtTaskCode.Text.Trim();

            if (hdnTaskTypeId.Value == string.Empty)
            {
                taskTypeEntity.CreatedBy = Master.LoggedUser.UserId.Value; 

                if (!currentTask.IsTaskTypeExists(taskTypeEntity.TaskCode))
                {
                    currentTask.InsertTaskType(taskTypeEntity);
                    Master.ShowMessage( Diary.Common.Constant.Message_Success);
                    this.ClearFormFields();
                }
                else
                {
                    //message already exists.
                }
            }
            else
            {
                taskTypeEntity.TaskTypeId = new Guid(this.hdnTaskTypeId.Value);
                taskTypeEntity.UpdatedBy =  Master.LoggedUser.UserId.Value; 

                currentTask.UpdateTaskType(taskTypeEntity);
                Master.ShowMessage( Diary.Common.Constant.Message_Success);
                this.ClearFormFields();
            }


        }

        private void DisplayRecord(Guid id)
        {
            DataSet ds = currentTask.SelectTaskTypeByTaskTypeId(id);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                txtTaskDescription.Text = ds.Tables[0].Rows[0]["TaskDescription"] != null ? ds.Tables[0].Rows[0]["TaskDescription"].ToString() : string.Empty;
                txtTaskCode.Text = ds.Tables[0].Rows[0]["TaskCode"] != null ? ds.Tables[0].Rows[0]["TaskCode"].ToString() : string.Empty;
            }
        }

        private void ClearFormFields()
        {
            this.txtTaskDescription.Text = string.Empty;
            this.txtTaskCode.Text = string.Empty;
            this.hdnTaskTypeId.Value = string.Empty;
            this.txtTaskDescription.Focus();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearFormFields();
        }
    }
}