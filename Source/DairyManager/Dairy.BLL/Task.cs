using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.DAL;
using Diary.Entity;

namespace Diary.BLL
{
    public class Task
    {
        TaskDao taskDao = new TaskDao();

        public Guid InsertTask(TaskEntity taskEntity)
        {
            return taskDao.InsertTask(taskEntity);

        }

        public bool UpdateTask(TaskEntity taskEntity)
        {
            return taskDao.UpdateTask(taskEntity);

        }

        public DataSet SelectTaskByTaskId(Guid taskId)
        {
            return taskDao.SelectTaskByTaskId(taskId);

        }

        public DataSet SelectTaskAll()
        {
            return taskDao.SelectTaskAll();

        }

        public Guid InsertTaskType(TaskTypeEntity taskTypeEntity)
        {
            return taskDao.InsertTaskType(taskTypeEntity);

        }

        public bool UpdateTaskType(TaskTypeEntity taskTypeEntity)
        {
            return taskDao.UpdateTaskType(taskTypeEntity);

        }

        public DataSet SelectTaskTypeByTaskTypeId(Guid taskTypeId)
        {
            return taskDao.SelectTaskTypeByTaskTypeId(taskTypeId);

        }

        public DataSet SelectTaskTypeAll()
        {
            return taskDao.SelectTaskTypeAll();

        }

        public bool IsTaskTypeExists(string taskCode)
        {
            return taskDao.IsTaskTypeExists(taskCode);

        }

        public bool DeleteTask(Guid taskId)
        {
            return taskDao.DeleteTask(taskId);

        }

        public bool DeleteTaskType(Guid taskTypeId)
        {
            return taskDao.DeleteTaskType(taskTypeId);

        }

        public DataSet CalculateTask(TaskEntity taskEntity)
        {
            return taskDao.CalculateTask(taskEntity);

        }

        public bool IsWithinValidTimeFrame(TaskEntity taskEntity)
        {
            return taskDao.IsWithinValidTimeFrame(taskEntity);

        }

        public DataSet SelectDashboardData(DateTime fromDate, DateTime toDate)
        {
            return taskDao.SelectDashboardData(fromDate, toDate);
        }

    }
}
