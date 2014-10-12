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
    public class CourtDao
    {
        public Guid InsertCourt(CourtEntity courtEntity)
        {
            Guid result;

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CourtInsert");
                        
            db.AddInParameter(dbCommand, "@Court", DbType.String, courtEntity.Court);
            db.AddInParameter(dbCommand, "@CourtTypeId", DbType.Guid, courtEntity.CourtTypeId);
            db.AddInParameter(dbCommand, "@PoliceStation", DbType.String, courtEntity.PoliceStation);

            db.AddInParameter(dbCommand, "@CreatedBy", DbType.Guid, courtEntity.CreatedBy);

            db.AddOutParameter(dbCommand, "@CourtId", DbType.Guid, 30);

            db.ExecuteNonQuery(dbCommand);

            result = new Guid(db.GetParameterValue(dbCommand, "@CourtId").ToString());

            return result;
        }

        public bool UpdateCourt(CourtEntity courtEntity)
        {
            bool result = false;

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CourtUpdate");
            
            db.AddInParameter(dbCommand, "@CourtId", DbType.Guid, courtEntity.CourtId);
            db.AddInParameter(dbCommand, "@Court", DbType.String, courtEntity.Court);
            db.AddInParameter(dbCommand, "@CourtTypeId", DbType.Guid, courtEntity.CourtTypeId);
            db.AddInParameter(dbCommand, "@PoliceStation", DbType.String, courtEntity.PoliceStation);
            db.AddInParameter(dbCommand, "@UpdatedBy", DbType.Guid, courtEntity.UpdatedBy);
         
            db.ExecuteNonQuery(dbCommand);

            result = true;

            return result;
        }

        public bool DeleteCourt(Guid courtId)
        {

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_CourtDelete");

            db.AddInParameter(command, "@CourtId", DbType.Guid, courtId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectCourtBycourtId(Guid courtId)
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_CourtSelectById");

            db.AddInParameter(command, "@CourtId", DbType.Guid, courtId);

            return db.ExecuteDataSet(command);
        }

        public DataSet SelectAllCourt()
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_CourtSelectAll");

            return db.ExecuteDataSet(command);
        }

        public bool IsCourtExists(string court)
        {
            bool result = false;
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_CourtIsExists");

            db.AddInParameter(command, "@Court", DbType.String, court);
            db.AddOutParameter(command, "@IsExists", DbType.Boolean, 1);

            db.ExecuteNonQuery(command);

            result = bool.Parse(db.GetParameterValue(command, "IsExists").ToString());

            return result;


        }

        public DataSet SelectAllCourtTypes()
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_CourtTypesSelectAll");

            return db.ExecuteDataSet(command);
        }

    }
}
