using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diary.DAL;
using System.Data;

namespace Diary.BLL
{
    public class Reports
    {
        ReportsDao reportDao = new ReportsDao();

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
