using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Diary.Entity
{
    public class ReportEntity
    {
        public string ReportType { get; set; }
        public DataSet ReportData { get; set; }
    }
}
