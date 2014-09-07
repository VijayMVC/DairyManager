using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Diary.Entity;
using System.Data.Common;
using Diary.Common;
using System.Data;


namespace Diary.DAL
{
    public class TaskDao
    {
        public Guid InsertTask(TaskEntity taskEntity)
        {
            Guid result;

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TaskInsert");

            db.AddInParameter(dbCommand, "@TaskDate", DbType.DateTime, taskEntity.TaskDate);
            db.AddInParameter(dbCommand, "@CaseId", DbType.Guid, taskEntity.CaseId);
            db.AddInParameter(dbCommand, "@TaskCreator", DbType.Guid, taskEntity.TaskCreator);
            db.AddInParameter(dbCommand, "@FeeEarner", DbType.Guid, taskEntity.FeeEarner);
            db.AddInParameter(dbCommand, "@TaskTypeId", DbType.Guid, taskEntity.TaskTypeId);
            db.AddInParameter(dbCommand, "@TaskDescription", DbType.String, taskEntity.TaskDescription);
            db.AddInParameter(dbCommand, "@TotalRemainingHours", DbType.Decimal, taskEntity.TotalRemainingHours);
            db.AddInParameter(dbCommand, "@StartTime", DbType.Time, taskEntity.StartTime);
            db.AddInParameter(dbCommand, "@EndTime", DbType.Time, taskEntity.EndTime);
            db.AddInParameter(dbCommand, "@TotalHours", DbType.Decimal, taskEntity.TotalHours);   
            db.AddInParameter(dbCommand, "@CreatedBy", DbType.Guid, taskEntity.CreatedBy);

            db.AddOutParameter(dbCommand, "@TaskId", DbType.Guid, 30);

            db.ExecuteNonQuery(dbCommand);

            result = new Guid(db.GetParameterValue(dbCommand, "@TaskId").ToString());

            return result;
        }

        public bool UpdateTask(TaskEntity taskEntity)
        {
            bool result;

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TaskUpdate");

            db.AddInParameter(dbCommand, "@TaskId", DbType.Guid, taskEntity.TaskId);
            db.AddInParameter(dbCommand, "@TaskDate", DbType.DateTime, taskEntity.TaskDate);
            db.AddInParameter(dbCommand, "@TaskCreator", DbType.Guid, taskEntity.TaskCreator);
            db.AddInParameter(dbCommand, "@FeeEarner", DbType.Guid, taskEntity.FeeEarner);
            db.AddInParameter(dbCommand, "@CaseId", DbType.Guid, taskEntity.CaseId);
            db.AddInParameter(dbCommand, "@TaskTypeId", DbType.Guid, taskEntity.TaskTypeId);
            db.AddInParameter(dbCommand, "@TaskDescription", DbType.String, taskEntity.TaskDescription);
            db.AddInParameter(dbCommand, "@TotalRemainingHours", DbType.Decimal, taskEntity.TotalRemainingHours);
            db.AddInParameter(dbCommand, "@StartTime", DbType.Time, taskEntity.StartTime);
            db.AddInParameter(dbCommand, "@EndTime", DbType.Time, taskEntity.EndTime);
            db.AddInParameter(dbCommand, "@TotalHours", DbType.Decimal, taskEntity.TotalHours);
            db.AddInParameter(dbCommand, "@UpdatedBy", DbType.Guid, taskEntity.UpdatedBy);
            
            db.ExecuteNonQuery(dbCommand);

            result = true;

            return result;
        }

        public DataSet SelectTaskByTaskId(Guid taskId)
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_TaskSelectById");

            db.AddInParameter(command, "@TaskId", DbType.Guid, taskId);

            return db.ExecuteDataSet(command);
        }

        public DataSet SelectTaskAll()
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_TaskSelectAll");

            return db.ExecuteDataSet(command);
        }

        public Guid InsertTaskType(TaskTypeEntity taskTypeEntity)
        {
            Guid result;

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TaskTypeInsert");

            db.AddInParameter(dbCommand, "@TaskDescription", DbType.String, taskTypeEntity.TaskDescription);
            db.AddInParameter(dbCommand, "@TaskCode", DbType.String, taskTypeEntity.TaskCode);
            db.AddInParameter(dbCommand, "@CreatedBy", DbType.Guid, taskTypeEntity.CreatedBy);

            db.AddOutParameter(dbCommand, "@TaskTypeId", DbType.Guid, 30);

            db.ExecuteNonQuery(dbCommand);

            result = new Guid(db.GetParameterValue(dbCommand, "@TaskTypeId").ToString());

            return result;
        }

        public bool UpdateTaskType(TaskTypeEntity taskTypeEntity)
        {
            bool result;

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TaskTypeUpdate");

            db.AddInParameter(dbCommand, "@TaskTypeId", DbType.Guid, taskTypeEntity.TaskTypeId);
            db.AddInParameter(dbCommand, "@TaskDescription", DbType.String, taskTypeEntity.TaskDescription);
            db.AddInParameter(dbCommand, "@TaskCode", DbType.String, taskTypeEntity.TaskCode);
            db.AddInParameter(dbCommand, "@UpdatedBy", DbType.Guid, taskTypeEntity.UpdatedBy);
            
            db.ExecuteNonQuery(dbCommand);

            result = true;

            return result;
        }

        public DataSet SelectTaskTypeByTaskTypeId(Guid taskTypeId)
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_TaskTypeSelectById");

            db.AddInParameter(command, "@TaskTypeId", DbType.Guid, taskTypeId);

            return db.ExecuteDataSet(command);
        }

        public DataSet SelectTaskTypeAll()
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_TaskTypeSelectAll");
                        
            return db.ExecuteDataSet(command);
        }

        public bool IsTaskTypeExists(string taskCode)
        {
            bool result = false;
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_TaskTypeIsExists");

            db.AddInParameter(command, "@TaskCode", DbType.String, taskCode);
            db.AddOutParameter(command, "@IsExists", DbType.Boolean, 1);

            db.ExecuteNonQuery(command);

            result = bool.Parse(db.GetParameterValue(command, "IsExists").ToString());

            return result;


        }

        public bool DeleteTask(Guid taskId)
        {
            bool result = false;
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_TaskDelete");

            db.AddInParameter(command, "@TaskId", DbType.Guid, taskId);
           
            db.ExecuteNonQuery(command);

            

            return result;


        }

        public bool DeleteTaskType(Guid taskTypeId)
        {
            bool result = false;
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_TaskTypeDelete");

            db.AddInParameter(command, "@TaskTypeId", DbType.Guid, taskTypeId);

            db.ExecuteNonQuery(command);



            return result;


        }

        public DataSet CalculateTask(TaskEntity taskEntity)
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_TaskCalculate");

            db.AddInParameter(command, "@TaskDate", DbType.Date, taskEntity.TaskDate);
            db.AddInParameter(command, "@FeeEarner", DbType.Guid, taskEntity.FeeEarner);
            db.AddInParameter(command, "@CaseId", DbType.Guid, taskEntity.CaseId);

            return db.ExecuteDataSet(command);
        }

        public bool IsWithinValidTimeFrame(TaskEntity taskEntity)
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_TaskIsValidTimeFrame");

            db.AddInParameter(command, "@TaskDate", DbType.Date, taskEntity.TaskDate);
            db.AddInParameter(command, "@FeeEarner", DbType.Guid, taskEntity.FeeEarner);
            db.AddInParameter(command, "@CaseId", DbType.Guid, taskEntity.CaseId);
            db.AddInParameter(command, "@StartTime", DbType.Time, taskEntity.StartTime);
            db.AddInParameter(command, "@EndTime", DbType.Time, taskEntity.EndTime);

            db.AddOutParameter(command, "@result", DbType.Boolean, 2);

            db.ExecuteNonQuery(command);

            bool result = false;
            
            result = bool.Parse(db.GetParameterValue(command, "@result").ToString());

            return result;
            
        }

        public bool IsWithinValidTimeFrameOnUpdate(TaskEntity taskEntity)
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_TaskIsValidTimeFrameOnUpdate");

            db.AddInParameter(command, "@TaskId", DbType.Guid, taskEntity.TaskId);           
            db.AddInParameter(command, "@TaskDate", DbType.Date, taskEntity.TaskDate);
            db.AddInParameter(command, "@FeeEarner", DbType.Guid, taskEntity.FeeEarner);
            db.AddInParameter(command, "@CaseId", DbType.Guid, taskEntity.CaseId);
            db.AddInParameter(command, "@StartTime", DbType.Time, taskEntity.StartTime);
            db.AddInParameter(command, "@EndTime", DbType.Time, taskEntity.EndTime);

            db.AddOutParameter(command, "@result", DbType.Boolean, 2);

            db.ExecuteNonQuery(command);

            bool result = false;

            result = bool.Parse(db.GetParameterValue(command, "@result").ToString());

            return result;

        }

        public DataSet SelectDashboardData(DateTime fromDate, DateTime toDate)
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_TaskSelectDashboardDataByDateRange");

            db.AddInParameter(command, "FromDate", DbType.Time, fromDate);
            db.AddInParameter(command, "ToDate", DbType.Time, toDate);

            return db.ExecuteDataSet(command);
        }
    }
}
