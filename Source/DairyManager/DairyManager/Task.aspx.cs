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
        Diary.Entity.TaskEntity taskEntity = new Diary.Entity.TaskEntity();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnTaskId.Value = Master.GetQueryStringValueByKey(Request, com.Enum.QueryStringParameters.CaseId.ToString());

                if (hdnTaskId.Value != string.Empty)
                {
                    this.DisplayRecord(new Guid(hdnTaskId.Value));  
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            taskEntity.TaskDate = DateTime.Parse(dtDate.Text);
            taskEntity.CaseTypeId = (Guid)cmbCaseType.Value;
            taskEntity.TotalRemainingHours = decimal.Parse(seRemaingHours.Text);
            taskEntity.StartTime = DateTime.Parse(teStartTime.Text);
            taskEntity.EndTime = DateTime.Parse(teEndTime.Text); ;
            taskEntity.TotalHours = decimal.Parse(seTotalHours.Text);

            if (hdnTaskId.Value == string.Empty)
            {
                
                taskEntity.CreatedBy = new Guid();
                currentTask.InsertTask(taskEntity);
                Master.ShowSuccessMessage(true, Diary.Common.Constant.Message_Success);

            }
            else
            {
                
                taskEntity.UpdatedBy = new Guid();
                currentTask.UpdateTask(taskEntity);
                Master.ShowSuccessMessage(true, Diary.Common.Constant.Message_Success);


            }            
        }

        private void DisplayRecord(Guid id)
        {
            DataSet ds = currentTask.SelectTaskByTaskId(id);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                dtDate.Text = taskEntity.TaskDate.ToString();
                cmbCaseType.Value = taskEntity.CaseTypeId;
                seRemaingHours.Text = taskEntity.TotalRemainingHours.ToString();
                teStartTime.Text = taskEntity.StartTime.ToString();
                teEndTime.Text = taskEntity.EndTime.ToString();
                seTotalHours.Text = taskEntity.TotalHours.ToString();
            }
        }
    }
}