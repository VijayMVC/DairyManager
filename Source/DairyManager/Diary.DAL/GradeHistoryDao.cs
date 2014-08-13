using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.Common;
using Diary.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Diary.DAL
{
    public class GradeHistoryDao
    {
        public bool Insert(GradeHistoryEntity gradeHistoryEntity)
        {
            bool result = true;

            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GradeHistoryInsert");

            db.AddInParameter(dbCommand, "@NewGradeId", DbType.Int32, gradeHistoryEntity.NewGradeId);
            db.AddInParameter(dbCommand, "@OldGradeId", DbType.Int32, gradeHistoryEntity.OldGradeId);
            db.AddInParameter(dbCommand, "@UserId", DbType.Guid, gradeHistoryEntity.UserId);
            db.AddInParameter(dbCommand, "@CreatedBy", DbType.Guid, gradeHistoryEntity.CreatedBy);

            db.ExecuteNonQuery(dbCommand);

            return result;
        }
    }
}
