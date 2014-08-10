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
    public class UserDAO
    {
        public DataSet SelectAll(User users)
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_UserSelectAll");
            return db.ExecuteDataSet(command);
        }

        public bool Insert(User users)
        {

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_UserInsert");

            users.UserId = Guid.NewGuid();
            db.AddInParameter(command, "@UserId", DbType.Guid, users.UserId);
            db.AddInParameter(command, "@UserName", DbType.String, users.UserName);
            db.AddInParameter(command, "@Password", DbType.String, users.Password);
            db.AddInParameter(command, "@FirstName", DbType.String, users.FirstName);
            db.AddInParameter(command, "@Contact", DbType.String, users.Contact);
            db.AddInParameter(command, "@LastName", DbType.String, users.LastName);
            db.AddInParameter(command, "@EmailAddress", DbType.String, users.EmailAddress);
            db.AddInParameter(command, "@CreatedBy", DbType.Guid, users.CreatedBy);
            db.AddInParameter(command, "@JobId", DbType.Int32, users.JobId);
            db.AddInParameter(command, "@GradeId", DbType.Int32, users.GradeId);
            db.AddInParameter(command, "@LocationId", DbType.Int32, users.LocationId);
            db.AddInParameter(command, "@RoleId", DbType.Int32, users.RoleId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Update(User users)
        {

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_UserUpdate");

            db.AddInParameter(command, "@UserId", DbType.Guid, users.UserId.Value);
            db.AddInParameter(command, "@Password", DbType.String, users.Password);
            db.AddInParameter(command, "@FirstName", DbType.String, users.FirstName);
            db.AddInParameter(command, "@LastName", DbType.String, users.LastName);
            db.AddInParameter(command, "@Contact", DbType.String, users.Contact);
            db.AddInParameter(command, "@EmailAddress", DbType.String, users.EmailAddress);
            db.AddInParameter(command, "@UpdatedBy", DbType.Guid, users.UpdatedBy);
            db.AddInParameter(command, "@JobId", DbType.Int32, users.JobId);
            db.AddInParameter(command, "@GradeId", DbType.Int32, users.GradeId);
            db.AddInParameter(command, "@LocationId", DbType.Int32, users.LocationId);
            db.AddInParameter(command, "@RolesId", DbType.Int32, users.RoleId);

            db.ExecuteNonQuery(command);

            return true;
        }

        public bool Delete(User users)
        {

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_UserDelete");

            db.AddInParameter(command, "@UserId", DbType.Guid, users.UserId);
            db.ExecuteNonQuery(command);

            return true;
        }

        public bool IsUserAuthenticated(string userName, string password, out Guid UsersId)
        {
            bool result = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
                DbCommand dbCommand = db.GetStoredProcCommand("usp_UserIsAuthenticated");

                db.AddInParameter(dbCommand, "@UserName", DbType.String, userName);
                db.AddInParameter(dbCommand, "@Password", DbType.String, password);
                db.AddOutParameter(dbCommand, "@UserId", DbType.Guid, 40);

                db.ExecuteNonQuery(dbCommand);

                object returnVal = db.GetParameterValue(dbCommand, "@UserId");
                if (returnVal != null && returnVal.ToString().Trim() != string.Empty)
                {
                    UsersId = new Guid(returnVal.ToString().Trim());
                }
                else
                {
                    UsersId = new Guid();
                }
               

                if (UsersId != new Guid())
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            catch (Exception ex)
            {
                UsersId = new Guid();
                throw;

            }

            return result;



        }

        public bool IsUserIsDuplicateUserName(string userName)
        {
            bool result = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
                DbCommand dbCommand = db.GetStoredProcCommand("usp_UserIsDuplicateUserName");

                db.AddInParameter(dbCommand, "@UserName", DbType.String, userName);
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

        public bool IsDuplicateEmail(string email)
        {
            bool result = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
                DbCommand dbCommand = db.GetStoredProcCommand("usp_UserIsDuplicateEmail");

                db.AddInParameter(dbCommand, "@EmailAddress", DbType.String, email);
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
