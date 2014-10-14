using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Diary.UserManagement
{
    public class RoleDAO
    {
        public bool Insert(Role roles, Database db, DbTransaction transaction)
        {
            DbCommand command = db.GetStoredProcCommand("usp_RoleInsert");

            roles.RoleId = Guid.NewGuid();
            db.AddInParameter(command, "@RoleName", DbType.String, roles.RoleName);
            db.AddInParameter(command, "@RoleDescription", DbType.String, roles.RoleDescription);
            db.AddInParameter(command, "@CreatedBy", DbType.Guid, roles.CreatedBy);
            db.AddInParameter(command, "@RoleId", DbType.Guid, roles.RoleId);

            db.ExecuteNonQuery(command, transaction);

            return true;
        }

        public bool Update(Role roles, Database db, DbTransaction transaction)
        {
            DbCommand command = db.GetStoredProcCommand("usp_RoleUpdate");

            db.AddInParameter(command, "@RoleId", DbType.Guid, roles.RoleId);
            db.AddInParameter(command, "@RoleName", DbType.String, roles.RoleName);
            db.AddInParameter(command, "@RoleDescription", DbType.String, roles.RoleDescription);
            db.AddInParameter(command, "@UpdatedBy", DbType.Guid, roles.UpdatedBy);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete(Role roles)
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_RoleDelete");
            db.AddInParameter(command, "@RoleId", DbType.String, roles.RoleId);
            db.AddInParameter(command, "@UpdatedBy", DbType.Guid, roles.UpdatedBy);

            return true;
        }

        public DataSet SelectAll(Role roles)
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RoleSelectAll");
            return db.ExecuteDataSet(dbCommand);
        }

        public bool InsertRoleRights(Role roles, Database db, DbTransaction transaction)
        {
            DbCommand command = db.GetStoredProcCommand("usp_RoleRightInsert");

            db.AddInParameter(command, "@RoleId", DbType.Guid, roles.RoleId);
            db.AddInParameter(command, "@RightId", DbType.Int32, roles.RightId);
            db.AddInParameter(command, "@CreatedBy", DbType.Guid, roles.CreatedBy);

            db.ExecuteNonQuery(command, transaction);

            return true;
        }

        public bool DeleteRoleRightsByRoleId(Role roles, Database db, DbTransaction transaction)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("usp_RoleRightDelete");
            db.AddInParameter(dbCommand, "RoleId", DbType.Guid, roles.RoleId);
            db.ExecuteNonQuery(dbCommand, transaction);
            return true;

        }

        public bool IsDuplicateRoleName(string roleName)
        {
            bool result = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
                DbCommand dbCommand = db.GetStoredProcCommand("usp_RoleIsDuplicateRoleName");

                db.AddInParameter(dbCommand, "@RoleName", DbType.String, roleName);
                db.AddOutParameter(dbCommand, "@IsExist", DbType.Boolean, 1);

                db.ExecuteNonQuery(dbCommand);

                result = Convert.ToBoolean(db.GetParameterValue(dbCommand, "@IsExist").ToString());

            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}
