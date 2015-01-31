using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diary.Entity;
using Diary.Common;

namespace DairyManager
{
    public partial class Reports : System.Web.UI.Page
    {
        Diary.BLL.Reports reports = new Diary.BLL.Reports();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master.LoggedUser == null)
            {
                Session[Constant.SESSION_LOGGEDUSER] = null;
                Response.Redirect(Constant.URL_LOGIN, false);
                return;
            }

            var now = DateTime.Now;
            var startOfMonth = new DateTime(now.Year, now.Month, 1);
            
            this.LoadReportList();

            if (!IsPostBack)
            {
                deFromDate.Value = startOfMonth;
                deToDate.Value = DateTime.Today;
            }

        }

        private void LoadReportList()
        {
            Diary.BLL.Reports report = new Diary.BLL.Reports();

            cmbReportTyppe.DataSource = report.GetReportTypes();
            cmbReportTyppe.ValueField = "key";
            cmbReportTyppe.TextField = "Value";
            cmbReportTyppe.DataBind();
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            switch (cmbReportTyppe.SelectedItem.Value.ToString())
            {

                case "0":
                    this.LoadCaseReport();
                    break;
            }

            iframePage.Attributes["src"] = "/ReportPreview.aspx";
        }

        private void LoadCaseReport()
        {
            Diary.Entity.ReportEntity reportEntity=new Diary.Entity.ReportEntity();
            reportEntity.ReportType = Diary.Common.Enum.ReportTypes.CaseInfo.ToString();

            DataSet ds = new DataSet();

            DateTime fromDate =DateTime.Parse(deFromDate.Value.ToString());
            DateTime toDate = DateTime.Parse(deToDate.Value.ToString());

            ds = reports.ReportCaseInfo(fromDate, toDate);
            reportEntity.ReportData = ds;
            Session["CurrentReport"] = reportEntity;
            
        }
    }
}