using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.Entity;
using System.Data.Common;
using System.Data;


namespace Diary.BLL
{
    public class Reports
    {
        Diary.DAL.ReportsDao reportDao = new DAL.ReportsDao();

        public Dictionary<int, string> GetReportTypes()
        {
            return reportDao.GetReportTypes();

        }

        public DataSet ReportCaseInfo()
        {
            return reportDao.ReportCaseInfo();
        }
    }
}
