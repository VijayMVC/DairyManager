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
    public class ReportsDao
    {
        public Dictionary<int, string> GetReportTypes()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(0, "Case Info");
            dictionary.Add(1, "");        
     
            return dictionary;

        }

        public DataSet ReportCaseInfo()
        {
            Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
            DbCommand command = db.GetStoredProcCommand("usp_ReportCaseInfo");
                   
            return db.ExecuteDataSet(command);
        }

    }
}
