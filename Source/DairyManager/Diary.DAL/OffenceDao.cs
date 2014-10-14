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
    public class OffenceDao
    {
        public Guid InsertOffence(OffenceEntity offenceEntity)
        {
            Guid result;

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_OffenceInsert");

            db.AddInParameter(dbCommand, "@Offence", DbType.String, offenceEntity.Offence);
            db.AddInParameter(dbCommand, "@CreatedBy", DbType.Guid, offenceEntity.CreatedBy);

            db.AddOutParameter(dbCommand, "@OffenceTypeId", DbType.Guid, 30);

            db.ExecuteNonQuery(dbCommand);

            result = new Guid(db.GetParameterValue(dbCommand, "@OffenceTypeId").ToString());

            return result;
        }

        public bool UpdateOffence(OffenceEntity offenceEntity)
        {
            bool result = false;

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_OffenceUpdate");

            db.AddInParameter(dbCommand, "@OffenceTypeId", DbType.Guid, offenceEntity.OffenceTypeId);
            db.AddInParameter(dbCommand, "@Offence", DbType.String, offenceEntity.Offence);
            db.AddInParameter(dbCommand, "@UpdatedBy", DbType.Guid, offenceEntity.UpdatedBy);

            db.ExecuteNonQuery(dbCommand);

            result = true;

            return result;
        }

        public bool DeleteOffence(Guid offenceTypeId)
        {

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_OffenceDelete");

            db.AddInParameter(command, "@OffenceTypeId", DbType.Guid, offenceTypeId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectOffenceByOffenceTypeId(Guid offenceTypeId)
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_OffenceSelectById");

            db.AddInParameter(command, "@OffenceTypeId", DbType.Guid, offenceTypeId);

            return db.ExecuteDataSet(command);
        }

        public DataSet SelectAllOffence()
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_OffenceSelectAll");

            return db.ExecuteDataSet(command);
        }

        public bool IsOffenceExists(string offence)
        {
            bool result = false;
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_OffenceIsExists");

            db.AddInParameter(command, "@Offence", DbType.String, offence);
            db.AddOutParameter(command, "@IsExists", DbType.Boolean, 1);

            db.ExecuteNonQuery(command);

            result = bool.Parse(db.GetParameterValue(command, "IsExists").ToString());

            return result;


        }
    }
}
