using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DairyManager
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadReportList();
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

                case "1":

                    break;
            }

        }

        private void LoadCaseReport()
        {

        }
    }
}