using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com = Diary.Common;

namespace DairyManager
{
    public partial class TimeRestriction : System.Web.UI.Page
    {
        Diary.BLL.TimeRestriction currentTimeRestriction = new Diary.BLL.TimeRestriction();
        Diary.Entity.TimeRestrictionEntity timeRestrictionEntity = new Diary.Entity.TimeRestrictionEntity();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnTimeRestrictionId.Value = Master.GetQueryStringValueByKey(Request, com.Enum.QueryStringParameters.TimeRestrictionId.ToString());

                if (hdnTimeRestrictionId.Value != string.Empty)
                {
                    this.DisplayRecord(new Guid(hdnTimeRestrictionId.Value));
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (hdnTimeRestrictionId.Value == string.Empty)
            {
                timeRestrictionEntity.MaximumRecordingPerDay = Decimal.Parse(txtMaximumTime.Text);
                timeRestrictionEntity.WarningAfterLimitExceed = txtTimeExceed.Text.Trim();
                timeRestrictionEntity.CreatedBy = (Guid)Master.LogedUser.ProviderUserKey;
                currentTimeRestriction.InsertTimeRestriction(timeRestrictionEntity);

            }
            else
            {
                timeRestrictionEntity.TimeRestrictionId = new Guid(hdnTimeRestrictionId.Value);
                timeRestrictionEntity.MaximumRecordingPerDay = Decimal.Parse(txtMaximumTime.Text);
                timeRestrictionEntity.WarningAfterLimitExceed = txtTimeExceed.Text.Trim();
                timeRestrictionEntity.CreatedBy = (Guid)Master.LogedUser.ProviderUserKey;
                currentTimeRestriction.UpdateTimeRestriction(timeRestrictionEntity);

            }
        }

        private void DisplayRecord(Guid id)
        {
            DataSet ds = currentTimeRestriction.SelectTimeRestrictionByTimeRestrictionId(id);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                txtMaximumTime.Text = timeRestrictionEntity.MaximumRecordingPerDay.ToString();
                txtTimeExceed.Text = timeRestrictionEntity.WarningAfterLimitExceed;
            }
        }

    }
}