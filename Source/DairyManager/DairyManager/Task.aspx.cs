using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com = Diary.Common;


namespace DairyManager
{
    public partial class Task : System.Web.UI.Page
    {
        Diary.BLL.Task currentTask = new Diary.BLL.Task();
        Diary.BLL.Case currentCase = new Diary.BLL.Case();
        Diary.Entity.TaskEntity taskEntity = new Diary.Entity.TaskEntity();

        Diary.UserManagement.User currentUser = new Diary.UserManagement.User();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadCase();
            this.LoadTaskType();
            this.LoadTaskCreator();
            this.LoadFeeEarner();

            if (!IsPostBack)
            {
                hdnTaskId.Value = Master.GetQueryStringValueByKey(Request, com.Enum.QueryStringParameters.TaskId.ToString());

                if (hdnTaskId.Value != string.Empty)
                {
                    this.DisplayRecord(new Guid(hdnTaskId.Value));
                }

            }
            this.AuthoriseUser();
        }
        
        private void AuthoriseUser()
        {
            btnSave.Visible = (Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Task_Task_Add)
                || Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Task_Task_Edit));

            if (!Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Task_Task_View))
            {
                Response.Redirect(com.Constant.URL_UNAUTHORISEDACTION, false);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            taskEntity.TaskDate = DateTime.Parse(dtDate.Text);
            taskEntity.CaseId = new Guid(cmbCase.Value.ToString());
            taskEntity.TaskCreator = new Guid(cmbTaskCreator.Value.ToString());
            taskEntity.FeeEarner = new Guid(cmbFeeEarner.Value.ToString());
            taskEntity.TaskTypeId = new Guid(cmbTaskType.Value.ToString());
            taskEntity.TaskDescription = txtTaskDescription.Text.Trim();
            taskEntity.TotalRemainingHours = decimal.Parse(seRemaingHours.Text);
            taskEntity.StartTime = DateTime.Parse(teStartTime.Text);
            taskEntity.EndTime = DateTime.Parse(teEndTime.Text); ;
            taskEntity.TotalHours = decimal.Parse(seTotalHours.Text);

            if (hdnTaskId.Value == string.Empty)
            {
                taskEntity.CreatedBy = Master.LoggedUser.UserId.Value;
                currentTask.InsertTask(taskEntity);                                       
                currentTask.InsertTask(taskEntity);
                this.ClearFormFields();
                Master.ShowMessage( Diary.Common.Constant.Message_Success);

            }
            else
            {
                taskEntity.TaskId = new Guid(hdnTaskId.Value);             
                taskEntity.UpdatedBy = Master.LoggedUser.UserId.Value;
                currentTask.UpdateTask(taskEntity);
                this.ClearFormFields();
                Master.ShowMessage( Diary.Common.Constant.Message_Success);

            }
        }

        private void DisplayRecord(Guid id)
        {
            DataSet ds = currentTask.SelectTaskByTaskId(id);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                dtDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["TaskDate"].ToString()).ToString("dd-MMM-yy HH:mm");
                cmbCase.Value = ds.Tables[0].Rows[0]["CaseId"].ToString();
                cmbTaskCreator.Value = ds.Tables[0].Rows[0]["TaskCreator"].ToString();
                cmbFeeEarner.Value = ds.Tables[0].Rows[0]["FeeEarner"].ToString();
                cmbTaskType.Value = ds.Tables[0].Rows[0]["TaskTypeId"].ToString();
                txtTaskDescription.Text = ds.Tables[0].Rows[0]["TaskDescription"] != null ? ds.Tables[0].Rows[0]["TaskDescription"].ToString() : string.Empty;
                seRemaingHours.Text = ds.Tables[0].Rows[0]["TotalRemainingHours"] != null ? ds.Tables[0].Rows[0]["TotalRemainingHours"].ToString() : "0";
                teStartTime.Text = ds.Tables[0].Rows[0]["StartTime"] != null ? ds.Tables[0].Rows[0]["StartTime"].ToString() : "0";
                teEndTime.Text = ds.Tables[0].Rows[0]["EndTime"] != null ? ds.Tables[0].Rows[0]["EndTime"].ToString() : "0";
                seTotalHours.Text = ds.Tables[0].Rows[0]["TotalHours"] != null ? ds.Tables[0].Rows[0]["TotalHours"].ToString() : "0";
            }
        }

        private void LoadCase()
        {
            cmbCase.DataSource = currentCase.SelectAllCase().Tables[0];
            cmbCase.TextField = "Code";
            cmbCase.ValueField = "CaseId";
            cmbCase.DataBind();
        }

        private void LoadTaskType()
        {
            cmbTaskType.DataSource = currentTask.SelectTaskTypeAll().Tables[0];
            cmbTaskType.TextField = "TaskDescription";
            cmbTaskType.ValueField = "TaskTypeId";
            cmbTaskType.DataBind();
        }

        private void LoadTaskCreator()
        {
            cmbTaskCreator.DataSource = currentUser.SelectAllDataset().Tables[0];
            cmbTaskCreator.TextField = "UserName";
            cmbTaskCreator.ValueField = "UserId";
            cmbTaskCreator.DataBind();
        }

        private void LoadFeeEarner()
        {
            cmbFeeEarner.DataSource = currentUser.SelectAllDataset().Tables[0];
            cmbFeeEarner.TextField = "UserName";
            cmbFeeEarner.ValueField = "UserId";
            cmbFeeEarner.DataBind();
        }

        private void ClearFormFields()
        {
            dtDate.Text = string.Empty;
            cmbCase.SelectedIndex = -1;
            cmbTaskCreator.SelectedIndex = -1;
            cmbFeeEarner.SelectedIndex = -1;
            cmbTaskType.SelectedIndex = -1;
            txtTaskDescription.Text = string.Empty;
            seRemaingHours.Text = "0";
            teStartTime.Text = "0";
            teEndTime.Text = "0";
            seTotalHours.Text = "0";
            hdnTaskId.Value = string.Empty;
            dtDate.Focus();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearFormFields();
        }
    }
}