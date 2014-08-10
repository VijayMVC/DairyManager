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
    public class CaseDao
    {
        public Guid InsertCase(CaseEntity caseEntity)
        {
            Guid result;

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CaseInsert");

            db.AddInParameter(dbCommand, "@Case", DbType.String, caseEntity.Case);
            db.AddInParameter(dbCommand, "@Code", DbType.String, caseEntity.Code);
            db.AddInParameter(dbCommand, "@ClientID", DbType.Guid, caseEntity.ClientId);
            db.AddInParameter(dbCommand, "@OffenceTypeId", DbType.Guid, caseEntity.OffenceTypeId);
            db.AddInParameter(dbCommand, "@CourtId", DbType.Guid, caseEntity.CourtId);
            db.AddInParameter(dbCommand, "@CaseTypeId", DbType.Guid, caseEntity.CaseTypeId);
            db.AddInParameter(dbCommand, "@Email", DbType.String, caseEntity.Email);
            db.AddInParameter(dbCommand, "@Contact", DbType.String, caseEntity.Contact);
            db.AddInParameter(dbCommand, "@CreatedBy", DbType.Guid, caseEntity.CreatedBy);

            db.AddOutParameter(dbCommand, "@CaseId", DbType.Guid, 30);

            db.ExecuteNonQuery(dbCommand);

            result = new Guid(db.GetParameterValue(dbCommand, "@CaseId").ToString());

            return result;
        }

        public bool UpdateCase(CaseEntity caseEntity)
        {
            bool result = false;

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CaseUpdate");

            db.AddInParameter(dbCommand, "@CaseId", DbType.Guid, caseEntity.CaseId);
            db.AddInParameter(dbCommand, "@Code", DbType.String, caseEntity.Code);
            db.AddInParameter(dbCommand, "@Case", DbType.String, caseEntity.Case);
            db.AddInParameter(dbCommand, "@ClientID", DbType.Guid, caseEntity.ClientId);
            db.AddInParameter(dbCommand, "@OffenceTypeId", DbType.Guid, caseEntity.OffenceTypeId);
            db.AddInParameter(dbCommand, "@CourtId", DbType.Guid, caseEntity.CourtId);
            db.AddInParameter(dbCommand, "@CaseTypeId", DbType.Guid, caseEntity.CaseTypeId);
            db.AddInParameter(dbCommand, "@Email", DbType.String, caseEntity.Email);
            db.AddInParameter(dbCommand, "@Contact", DbType.String, caseEntity.Contact);
            db.AddInParameter(dbCommand, "@UpdatedBy", DbType.Guid, caseEntity.UpdatedBy);

            db.ExecuteNonQuery(dbCommand);

            result = true;

            return result;
        }

        public bool DeleteCase(CaseEntity caseEntity)
        {

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_CaseDelete");

            db.AddInParameter(command, "@CaseId", DbType.Guid, caseEntity.CaseId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectCaseByCaseId(Guid caseId)
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_CaseSelectById");

            db.AddInParameter(command, "@CaseId", DbType.Guid, caseId);

            return db.ExecuteDataSet(command);
        }

        public DataSet SelectAllCase()
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_CaseSelectAll");

            return db.ExecuteDataSet(command);
        }

        public Guid InsertCaseType(CaseTypeEntity caseTypeEntity)
        {
            Guid result;

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CaseTypeInsert");

            db.AddInParameter(dbCommand, "@CaseDescription", DbType.String, caseTypeEntity.CaseDescription);
            db.AddInParameter(dbCommand, "@CaseCode", DbType.String, caseTypeEntity.CaseCode);
            db.AddInParameter(dbCommand, "@CreatedBy", DbType.Guid, caseTypeEntity.CreatedBy);

            db.AddOutParameter(dbCommand, "@CaseTypeId", DbType.Guid, 30);

            db.ExecuteNonQuery(dbCommand);

            result = new Guid(db.GetParameterValue(dbCommand, "@CaseTypeId").ToString());

            return result;
        }

        public bool UpdateCaseType(CaseTypeEntity caseTypeEntity)
        {
            bool result = false;

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CaseTypeUpdate");

            db.AddInParameter(dbCommand, "@CaseTypeId", DbType.Guid, caseTypeEntity.CaseTypeId);
            db.AddInParameter(dbCommand, "@CaseDescription", DbType.String, caseTypeEntity.CaseDescription);
            db.AddInParameter(dbCommand, "@CaseCode", DbType.String, caseTypeEntity.CaseCode);
            db.AddInParameter(dbCommand, "@UpdatedBy", DbType.Guid, caseTypeEntity.UpdatedBy);

            db.ExecuteNonQuery(dbCommand);

            result = true;

            return result;
        }

        public bool DeleteCaseType(CaseTypeEntity caseTypeEntity)
        {

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_CaseTypeDelete");

            db.AddInParameter(command, "@CaseTypeId", DbType.Guid, caseTypeEntity.CaseTypeId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public DataSet SelectCaseTypeByCaseTypeId(Guid caseTypeId)
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_CaseTypeSelectById");

            db.AddInParameter(command, "@CaseTypeId", DbType.Guid, caseTypeId);

            return db.ExecuteDataSet(command);
        }

        public DataSet SelectAllCaseType()
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_CaseTypeSelectAll");

            return db.ExecuteDataSet(command);
        }

        public bool IsCaseCodeExists(string caseCode)
        {
            bool result = false;
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_CaseTypeIsExists");

            db.AddInParameter(command, "@CaseCode", DbType.String, caseCode);
            db.AddOutParameter(command, "@IsExists", DbType.Boolean, 1);

            db.ExecuteNonQuery(command);

            result = bool.Parse(db.GetParameterValue(command, "IsExists").ToString());

            return result;


        }

        public DataSet SelectAllOffence()
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_OffenceSelectAll");

            return db.ExecuteDataSet(command);
        }

        public DataSet SelectAllCourt()
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_CourtSelectAll");

            return db.ExecuteDataSet(command);
        }


    }
}
