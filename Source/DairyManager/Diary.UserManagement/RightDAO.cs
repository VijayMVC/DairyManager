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
    public class RightDAO
    {
        public DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RightSelectAll");
            return db.ExecuteDataSet(dbCommand);
        }

        public DataSet SelectByRolesId(Right right)
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RightSelectByRoleId");
            db.AddInParameter(dbCommand, "@RoleId", DbType.Guid, right.RoleId);
            return db.ExecuteDataSet(dbCommand);
        }
    }
}
