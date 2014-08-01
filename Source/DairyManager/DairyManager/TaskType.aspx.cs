using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diary.Common;
using Diary.Entity;
using Diary.BLL;


namespace DairyManager
{
    public partial class TaskType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Diary.BLL.Task currentTask = new Diary.BLL.Task();
            Diary.Entity.TaskTypeEntity taskTypeEntity = new TaskTypeEntity();


            if (hdnTaskTypeId.Value == string.Empty)
            {           
                taskTypeEntity.TaskDescription = txtTaskDescription.Text.Trim();
                taskTypeEntity.TaskCode = txtTaskCode.Text.Trim();
                taskTypeEntity.CreatedBy = new Guid();

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
                taskTypeEntity.UpdatedBy = new Guid();

                currentTask.UpdateTaskType(taskTypeEntity);

            }
          

        }
    }
}