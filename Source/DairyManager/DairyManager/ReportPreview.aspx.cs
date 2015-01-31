using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Data;
using Diary.Entity;
using DevExpress.Web.ASPxGridView;
using Diary.Common;

namespace DairyManager
{
    public partial class ReportPreview : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {

            if (Session[Constant.SESSION_LOGGEDUSER] == null)
            {
                Response.Redirect(Constant.URL_LOGIN, false);
                return;
            }

            if (Session["CurrentReport"] != null)
            {
                Diary.Entity.ReportEntity reportEntity = new Diary.Entity.ReportEntity();
                reportEntity = (Diary.Entity.ReportEntity)Session["CurrentReport"];
                gvReports.DataSource = reportEntity.ReportData;
                gvReports.DataBind();
                cbmExporter.Visible = true;

                if (reportEntity.ReportType == Diary.Common.Enum.ReportTypes.CaseInfo.ToString())
                {

                    //GridViewDataDateColumn col = gvReports.Columns["TaskDate"] as GridViewDataDateColumn;
                    //col.PropertiesDateEdit.DisplayFormatString = "dd-MMM-yy";

                    DevExpress.Web.ASPxGridView.ASPxSummaryItem totalHours = new DevExpress.Web.ASPxGridView.ASPxSummaryItem();
                    totalHours.FieldName = "TotalHours";
                    totalHours.ShowInColumn = "TotalHours";
                    totalHours.SummaryType = SummaryItemType.Sum;
                    totalHours.DisplayFormat = "Total {0}";
                    totalHours.ShowInGroupFooterColumn = "TotalHours";
                    gvReports.TotalSummary.Add(totalHours);


                    DevExpress.Web.ASPxGridView.ASPxSummaryItem totalHoursGroup = new DevExpress.Web.ASPxGridView.ASPxSummaryItem();
                    totalHoursGroup.FieldName = "TotalHours";
                    totalHoursGroup.SummaryType = SummaryItemType.Sum;
                    totalHoursGroup.DisplayFormat = "Total {0}";

                    gvReports.GroupSummary.Add(totalHoursGroup);

                }

            }
            else
            {
                cbmExporter.Visible = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cbmExporter_ButtonClick(object source, DevExpress.Web.ASPxEditors.ButtonEditClickEventArgs e)
        {
            if (e.ButtonIndex == 0)
            {
                switch (cbmExporter.Text)
                {
                    case "PDF":
                        gvExporter.GridViewID = gvReports.ID;
                        gvExporter.Landscape = true;
                        gvExporter.WritePdfToResponse();
                        break;

                    case "RTF":
                        gvExporter.GridViewID = gvReports.ID;
                        gvExporter.WriteRtfToResponse();
                        break;

                    case "Excel":
                        gvExporter.GridViewID = gvReports.ID;
                        gvExporter.WriteXlsToResponse();
                        break;

                    case "CSV":
                        gvExporter.GridViewID = gvReports.ID;
                        gvExporter.WriteCsvToResponse();
                        break;
                }
            }
        }

        protected void rbGroupBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (GridViewDataColumn gvc in gvReports.Columns)
            {
                if (gvc.GroupIndex > -1)
                {
                    gvReports.UnGroup(gvc);
                }
            }

            switch (rbGroupBy.SelectedIndex)
            {
                case 0:                   
                    gvReports.GroupBy(gvReports.Columns["UFN"]);
                    break;
                case 1:
                    gvReports.GroupBy(gvReports.Columns["TaskType"]);
                    break;
                case 2:
                    gvReports.GroupBy(gvReports.Columns["Client"]);
                    break;
                case 3:
                    gvReports.GroupBy(gvReports.Columns["TaskCreator"]);
                    break;
                case 4:
                    gvReports.GroupBy(gvReports.Columns["FeeEarner"]);
                    break;
                case 5:
                    foreach (GridViewDataColumn gvc in gvReports.Columns)
                    {
                        if (gvc.GroupIndex > -1)
                        {
                            gvReports.UnGroup(gvc);
                        }
                    }
                    break;
            }





        }

    }
}