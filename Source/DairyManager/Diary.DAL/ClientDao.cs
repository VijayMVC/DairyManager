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
    public class ClientDao
    {
        public Guid InsertClient( ClientEntity clientEntity)
        {
            Guid result;

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientInsert");


            db.AddInParameter(dbCommand, "@Initials", DbType.String, clientEntity.Initials);
            db.AddInParameter(dbCommand, "@Firstname", DbType.String, clientEntity.Firstname);
            db.AddInParameter(dbCommand, "@LastName", DbType.String, clientEntity.LastName);
            db.AddInParameter(dbCommand, "@AddressLine1", DbType.String, clientEntity.AddressLine1);
            db.AddInParameter(dbCommand, "@AddressLine2", DbType.String, clientEntity.AddressLine2);
            db.AddInParameter(dbCommand, "@AddressLine3", DbType.String, clientEntity.AddressLine3);

            db.AddInParameter(dbCommand, "@Telephone", DbType.String, clientEntity.Telephone);
            db.AddInParameter(dbCommand, "@Fax", DbType.String, clientEntity.Fax);
            db.AddInParameter(dbCommand, "@Email", DbType.String, clientEntity.Email);
            db.AddInParameter(dbCommand, "@ContactPerson", DbType.String, clientEntity.ContactPerson);

            db.AddInParameter(dbCommand, "@CreatedBy", DbType.Guid, clientEntity.CreatedBy);

            db.AddOutParameter(dbCommand, "@ClientId", DbType.Guid, 30);

            db.ExecuteNonQuery(dbCommand);

            result = new Guid(db.GetParameterValue(dbCommand, "@ClientId").ToString());

            return result;
        }

        public bool UpdateClient(ClientEntity clientEntity)
        {
            bool result;

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClientUpdate");

            db.AddInParameter(dbCommand, "@ClientId", DbType.Guid, clientEntity.ClientId);
            db.AddInParameter(dbCommand, "@Initials", DbType.String, clientEntity.Initials);
            db.AddInParameter(dbCommand, "@Firstname", DbType.String, clientEntity.Firstname);
            db.AddInParameter(dbCommand, "@LastName", DbType.String, clientEntity.LastName);
            db.AddInParameter(dbCommand, "@AddressLine1", DbType.String, clientEntity.AddressLine1);
            db.AddInParameter(dbCommand, "@AddressLine2", DbType.String, clientEntity.AddressLine2);
            db.AddInParameter(dbCommand, "@AddressLine3", DbType.String, clientEntity.AddressLine3);
            db.AddInParameter(dbCommand, "@Telephone", DbType.String, clientEntity.Telephone);
            db.AddInParameter(dbCommand, "@Fax", DbType.String, clientEntity.Fax);
            db.AddInParameter(dbCommand, "@Email", DbType.String, clientEntity.Email);
            db.AddInParameter(dbCommand, "@ContactPerson", DbType.String, clientEntity.ContactPerson);
            db.AddInParameter(dbCommand, "@UpdatedBy", DbType.Guid, clientEntity.UpdatedBy);
            
            db.ExecuteNonQuery(dbCommand);

            result = true;

            return result;
        }

        public DataSet SelectClientByClientId(Guid clientId)
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_ClientSelectById");

            db.AddInParameter(command, "@ClientId", DbType.Guid, clientId);

            return db.ExecuteDataSet(command);
        }

        public DataSet SelectClientAll()
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_ClientSelectAll");

            return db.ExecuteDataSet(command);
        }

        public DataSet DeleteClientByClientId(Guid clientId)
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_ClientDelete");

            db.AddInParameter(command, "@ClientId", DbType.Guid, clientId);

            return db.ExecuteDataSet(command);
        }

    }
}
