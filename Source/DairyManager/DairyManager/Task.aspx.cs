using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com = Diary.Common;
using DevExpress.Web.ASPxGridView;
using Diary.Common;

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
            this.LoadDateFromCalender();

            if (!IsPostBack)
            {
                hdnTaskId.Value = Master.GetQueryStringValueByKey(Request, com.Enum.QueryStringParameters.TaskId.ToString());

                if (hdnTaskId.Value != string.Empty)
                {
                    this.DisplayRecord(new Guid(hdnTaskId.Value));
                }

                this.dtDate.Date = DateTime.Now;

            }

            this.AuthoriseUser();



        }

        private void LoadDateFromCalender()
        {
            DateTime TaskDate = new DateTime();
            if (HttpContext.Current.Session["TaskStartDate"] != null && DateTime.TryParse(HttpContext.Current.Session["TaskStartDate"].ToString(), out TaskDate))
            {
                dtDate.Value = TaskDate;
            }
        }

        private void AuthoriseUser()
        {
            if (Master.LoggedUser == null)
            {
                Session[Constant.SESSION_LOGGEDUSER] = null;
                Response.Redirect(Constant.URL_LOGIN, false);
                return;
            }


            btnSave.Visible = (Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Task_Task_Add)
                || Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Task_Task_Edit));

            if (!Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Task_Task_View))
            {
                Response.Redirect(com.Constant.URL_UNAUTHORISEDACTION, false);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.validateToSave())
            {
                return;
            }

            taskEntity.TaskDate = DateTime.Parse(dtDate.Text);
            taskEntity.CaseId = new Guid(cmbCase.Value.ToString());
            
            //taskEntity.TaskCreator = new Guid(cmbTaskCreator.Value.ToString());
            taskEntity.TaskCreator = Master.LoggedUser.UserId.Value;

            taskEntity.FeeEarner = new Guid(cmbFeeEarner.Value.ToString());
            taskEntity.TaskTypeId = new Guid(cmbTaskType.Value.ToString());
            taskEntity.TaskDescription = txtTaskDescription.Text.Trim();
            taskEntity.TotalRemainingHours = decimal.Parse(lblRemainingHours.Text);
            taskEntity.StartTime = DateTime.Parse(teStartTime.Text.ToString());
            taskEntity.EndTime = DateTime.Parse(teEndTime.Text.ToString()); ;
            taskEntity.TotalHours = decimal.Parse(seTotalHours.Value.ToString());

            if (hdnTaskId.Value == string.Empty)
            {
                taskEntity.CreatedBy = Master.LoggedUser.UserId.Value;
                currentTask.InsertTask(taskEntity);
                this.ClearFormFields();
                Master.ShowMessage(Diary.Common.Constant.Message_Success);
                HttpContext.Current.Session["TaskStartDate"] = null;

            }
            else
            {
                taskEntity.TaskId = new Guid(hdnTaskId.Value);
                taskEntity.UpdatedBy = Master.LoggedUser.UserId.Value;
                currentTask.UpdateTask(taskEntity);
                this.ClearFormFields();
                Master.ShowMessage(Diary.Common.Constant.Message_Success);

            }
        }

        private void DisplayRecord(Guid id)
        {
            DataSet ds = currentTask.SelectTaskByTaskId(id);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                dtDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["TaskDate"].ToString());
                cmbCase.Value = ds.Tables[0].Rows[0]["CaseId"].ToString();
                //cmbTaskCreator.Value = ds.Tables[0].Rows[0]["TaskCreator"].ToString();
                cmbFeeEarner.Value = ds.Tables[0].Rows[0]["FeeEarner"].ToString();
                cmbTaskType.Value = ds.Tables[0].Rows[0]["TaskTypeId"].ToString();
                txtTaskDescription.Value = ds.Tables[0].Rows[0]["TaskDescription"] != null ? ds.Tables[0].Rows[0]["TaskDescription"].ToString() : string.Empty;
                lblRemainingHours.Value = ds.Tables[0].Rows[0]["TotalRemainingHours"] != null ? ds.Tables[0].Rows[0]["TotalRemainingHours"].ToString() : "0";
                teStartTime.Value = Convert.ToDateTime( ds.Tables[0].Rows[0]["StartTime"] != null ? ds.Tables[0].Rows[0]["StartTime"].ToString() : "0");
                teEndTime.Value = Convert.ToDateTime( ds.Tables[0].Rows[0]["EndTime"] != null ? ds.Tables[0].Rows[0]["EndTime"].ToString() : "0");
                seTotalHours.Value = ds.Tables[0].Rows[0]["TotalHours"] != null ? ds.Tables[0].Rows[0]["TotalHours"].ToString() : "0";

                this.LoadTaskGrid();
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
            //cmbTaskCreator.DataSource = currentUser.SelectAllDataset().Tables[0];
            //cmbTaskCreator.TextField = "UserName";
            //cmbTaskCreator.ValueField = "UserId";
            //cmbTaskCreator.DataBind();
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
            dtDate.Date = DateTime.Now;
            cmbCase.SelectedIndex = -1;
            //cmbTaskCreator.SelectedIndex = -1;
            cmbFeeEarner.SelectedIndex = -1;
            cmbTaskType.SelectedIndex = -1;
            txtTaskDescription.Text = string.Empty;
            lblRemainingHours.Text = "0";
            teStartTime.Text = "0";
            teEndTime.Text = "0";
            seTotalHours.Text = "0";
            hdnTaskId.Value = string.Empty;
            seTotalHours.MaxValue = 50;
            seTotalHours.MinValue = 0;
            lblMaximumRecording.Text = "0";

            gvHistory.Visible = false;
            gvHistory.DataSource = null;
            gvHistory.DataBind();
            dvGridSection.Visible = false;

            
            
        }

        private void LoadTaskGrid()
        {
            Diary.Entity.TaskEntity taskentity = new Diary.Entity.TaskEntity();
            taskentity.TaskDate = DateTime.Parse(dtDate.Text);
            taskentity.FeeEarner = new Guid(cmbFeeEarner.Value.ToString());
            taskentity.CaseId = new Guid(cmbCase.Value.ToString());

            DataSet taskCalculateDataSet = currentTask.CalculateTask(taskentity);

            if (taskCalculateDataSet != null && taskCalculateDataSet.Tables.Count > 0 && taskCalculateDataSet.Tables[0] != null && taskCalculateDataSet.Tables[0].Rows.Count > 0)
            {
                string remainingHours = taskCalculateDataSet.Tables[0].Rows[0]["BalanceHours"].ToString();
                lblRemainingHours.Text = remainingHours;

                if (int.Parse(decimal.Parse(remainingHours).ToString("N0")) < 0)
                {
                    seTotalHours.MaxValue = 50;
                }
                //else
                //{
                //    seTotalHours.MaxValue = int.Parse(decimal.Parse(remainingHours).ToString("N0"));

                //}

                string maximumRecording = taskCalculateDataSet.Tables[0].Rows[0]["TimeRestriction"].ToString();
                lblMaximumRecording.Text = maximumRecording;

            }


            if (taskCalculateDataSet != null && taskCalculateDataSet.Tables.Count > 0 && taskCalculateDataSet.Tables[1] != null && taskCalculateDataSet.Tables[1].Rows.Count > 0)
            {

                gvHistory.Visible = true;
                dvGridSection.Visible = true;
                gvHistory.DataSource = taskCalculateDataSet.Tables[1];
                gvHistory.DataBind();
            }
            else
            {
                dvGridSection.Visible = false;
                gvHistory.Visible = false;
                gvHistory.DataSource = null;
                gvHistory.DataBind();
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
         this.ClearFormFields();
        }

        protected void cmbCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty( dtDate.Text ) || string.IsNullOrEmpty(cmbFeeEarner.Text))
            {
                cmbCase.SelectedIndex = -1;
                return;
            }

            this.LoadTaskGrid();
        }

        private bool validateToSave()
        {
            bool result = true;

            string maximumRecording = "0";
            string consumedHours = "0";

            maximumRecording = lblMaximumRecording.Text;

            if (gvHistory.GetTotalSummaryValue(gvHistory.TotalSummary["TotalHours", DevExpress.Data.SummaryItemType.Sum]) != null)
            {
                consumedHours = gvHistory.GetTotalSummaryValue(gvHistory.TotalSummary["TotalHours", DevExpress.Data.SummaryItemType.Sum]).ToString();
            }

            if (maximumRecording == consumedHours)
            {
                result = false;
                Master.ShowMessage(Diary.Common.Constant.Message_AllTimeConsumed);
                
            }
            
            //// Check for over to maximum readin time

            decimal totalHours =0;
            decimal maximumRecordingTime = 0;

            if (seTotalHours.Text != string.Empty)
            {
                totalHours = Convert.ToDecimal(seTotalHours.Text);
            }

            maximumRecordingTime = Convert.ToDecimal(maximumRecording);

            if (totalHours > maximumRecordingTime)
            {
                result = false;
                Master.ShowMessage(Diary.Common.Constant.Message_MoreThanReadingHours);
            }



            //// Check start/end time on insert
            if (hdnTaskId.Value == string.Empty)
            {

                Diary.Entity.TaskEntity taskentity = new Diary.Entity.TaskEntity();

                taskentity.TaskDate = DateTime.Parse(dtDate.Text);
                taskentity.CaseId = new Guid(cmbCase.Value.ToString());
                taskentity.FeeEarner = new Guid(cmbFeeEarner.Value.ToString());
                taskentity.StartTime = DateTime.Parse(teStartTime.Text);
                taskentity.EndTime = DateTime.Parse(teEndTime.Text);

                if (currentTask.IsWithinValidTimeFrame(taskentity))
                {
                    result = false;
                    Master.ShowMessage(Diary.Common.Constant.Message_TimeNotAllowed);

                }

            }

            //// Check start/end time on update

            if (hdnTaskId.Value != string.Empty)
            {

                Diary.Entity.TaskEntity taskentity = new Diary.Entity.TaskEntity();

                taskentity.TaskId = new Guid(hdnTaskId.Value);
                taskentity.TaskDate = DateTime.Parse(dtDate.Text);
                taskentity.CaseId = new Guid(cmbCase.Value.ToString());
                taskentity.FeeEarner = new Guid(cmbFeeEarner.Value.ToString());
                taskentity.StartTime = DateTime.Parse(teStartTime.Text);
                taskentity.EndTime = DateTime.Parse(teEndTime.Text);

                if (currentTask.IsWithinValidTimeFrameOnUpdate(taskentity))
                {
                    result = false;
                    Master.ShowMessage(Diary.Common.Constant.Message_TimeNotAllowed);

                }

            }

            return result;
        }

        protected void teStartTime_DateChanged(object sender, EventArgs e)
        {

        }
    }
}