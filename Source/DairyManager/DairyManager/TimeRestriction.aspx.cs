using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DairyManager
{
    public partial class TimeRestriction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Diary.BLL.TimeRestriction timeRestriction = new Diary.BLL.TimeRestriction();
            Diary.Entity.TimeRestrictionEntity timeRestrictionEntity = new Diary.Entity.TimeRestrictionEntity();

            if (hdnTimeRestrictionId.Value == string.Empty)
            {
                timeRestrictionEntity.MaximumRecordingPerDay = Decimal.Parse(txtMaximumTime.Text);
                timeRestrictionEntity.WarningAfterLimitExceed = txtTimeExceed.Text.Trim();
                timeRestrictionEntity.CreatedBy = (Guid)Master.LogedUser.ProviderUserKey;
                timeRestriction.InsertTimeRestriction(timeRestrictionEntity);

            }
            else
            {
                timeRestrictionEntity.TimeRestrictionId = new Guid(hdnTimeRestrictionId.Value);
                timeRestrictionEntity.MaximumRecordingPerDay = Decimal.Parse(txtMaximumTime.Text);
                timeRestrictionEntity.WarningAfterLimitExceed = txtTimeExceed.Text.Trim();
                timeRestrictionEntity.CreatedBy = (Guid)Master.LogedUser.ProviderUserKey;
                timeRestriction.UpdateTimeRestriction(timeRestrictionEntity);

            }
        }
    }
}