using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DairyManager
{
    public partial class Task : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Diary.BLL.Task currentTask = new Diary.BLL.Task();
            Diary.Entity.TaskEntity taskEntity = new Diary.Entity.TaskEntity();

            if (hdnTaskId.Value == string.Empty)
            {
                taskEntity.TaskDate = DateTime.Parse(dtDate.Text);
                taskEntity.CaseTypeId = (Guid)cmbCaseType.Value;
                taskEntity.TotalRemainingHours = decimal.Parse(seRemaingHours.Text);
                taskEntity.StartTime =DateTime.Parse( teStartTime.Text);
                taskEntity.EndTime = DateTime.Parse(teEndTime.Text); ;
                taskEntity.TotalHours =decimal.Parse(seTotalHours.Text);
                taskEntity.CreatedBy = (Guid)Master.LogedUser.ProviderUserKey;

                currentTask.InsertTask(taskEntity);

            }
            else
            {
                taskEntity.TaskId = new Guid(hdnTaskId.Value);
                taskEntity.TaskDate = DateTime.Parse(dtDate.Text);
                taskEntity.CaseTypeId = (Guid)cmbCaseType.Value;
                taskEntity.TotalRemainingHours = decimal.Parse(seRemaingHours.Text);
                taskEntity.StartTime = DateTime.Parse(teStartTime.Text);
                taskEntity.EndTime = DateTime.Parse(teEndTime.Text); ;
                taskEntity.TotalHours = decimal.Parse(seTotalHours.Text);
                taskEntity.CreatedBy = (Guid)Master.LogedUser.ProviderUserKey;

                currentTask.UpdateTask(taskEntity);


            }

        }
    }
}