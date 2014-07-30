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
    public class TimeRestrictionDao
    {
        public Guid InsertTimeRestriction(TimeRestrictionEntity timeRestrictionEntity)
        {
            Guid result;

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TimeRestrictionInsert");

            db.AddInParameter(dbCommand, "@MaximumRecordingPerDay", DbType.Decimal, timeRestrictionEntity.MaximumRecordingPerDay);
            db.AddInParameter(dbCommand, "@WarningAfterLimitExceed", DbType.String, timeRestrictionEntity.WarningAfterLimitExceed);
            db.AddInParameter(dbCommand, "@CreatedBy", DbType.Guid, timeRestrictionEntity.CreatedBy);

            db.AddOutParameter(dbCommand, "@TimeRestrictionId", DbType.Guid, 30);

            db.ExecuteNonQuery(dbCommand);

            result = new Guid(db.GetParameterValue(dbCommand, "@TimeRestrictionId").ToString());

            return result;
        }

        public bool UpdateTimeRestriction(TimeRestrictionEntity timeRestrictionEntity)
        {
            bool result;

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TimeRestrictionUpdate");

            db.AddInParameter(dbCommand, "@TimeRestrictionId", DbType.Guid, timeRestrictionEntity.TimeRestrictionId);           
            db.AddInParameter(dbCommand, "@MaximumRecordingPerDay", DbType.Decimal, timeRestrictionEntity.MaximumRecordingPerDay);
            db.AddInParameter(dbCommand, "@WarningAfterLimitExceed", DbType.String, timeRestrictionEntity.WarningAfterLimitExceed);
            db.AddInParameter(dbCommand, "@UpdatedBy", DbType.Guid, timeRestrictionEntity.UpdatedBy);

            db.ExecuteNonQuery(dbCommand);

            result = true;

            return result;
        }

        public DataSet SelectTimeRestrictionByTimeRestrictionId(Guid timeRestrictionId)
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_TimeRestrictionSelectById");

            db.AddInParameter(command, "@TimeRestrictionId", DbType.Guid, timeRestrictionId);

            return db.ExecuteDataSet(command);
        }

        public DataSet SelectTimeRestrictionAll()
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_TimeRestrictionSelectAll");

            return db.ExecuteDataSet(command);
        }

    }
}
