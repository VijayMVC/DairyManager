﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com = Diary.Common;
using Diary.Common;

namespace DairyManager
{
    public partial class TimeRestriction : System.Web.UI.Page
    {
        Diary.BLL.TimeRestriction currentTimeRestriction = new Diary.BLL.TimeRestriction();
        Diary.Entity.TimeRestrictionEntity timeRestrictionEntity = new Diary.Entity.TimeRestrictionEntity();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master.LoggedUser == null)
            {
                Session[Constant.SESSION_LOGGEDUSER] = null;
                Response.Redirect(Constant.URL_LOGIN, false);
                return;
            }

            if (!IsPostBack)
            {

                this.DisplayRecord();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            timeRestrictionEntity.TimeRestrictionId = new Guid(hdnTimeRestrictionId.Value);
            timeRestrictionEntity.MaximumRecordingPerDay = Decimal.Parse(seMaximumTime.Text);
            timeRestrictionEntity.WarningAfterLimitExceed = txtTimeExceed.Text.Trim();

            if (hdnTimeRestrictionId.Value == string.Empty)
            {
              
                timeRestrictionEntity.CreatedBy = Master.LoggedUser.UserId.Value;
                hdnTimeRestrictionId.Value = currentTimeRestriction.InsertTimeRestriction(timeRestrictionEntity).ToString();

            }
            else
            {
             
                timeRestrictionEntity.UpdatedBy = Master.LoggedUser.UserId.Value;
                currentTimeRestriction.UpdateTimeRestriction(timeRestrictionEntity);

            }

            Master.ShowMessage( Diary.Common.Constant.Message_Success);

        }

        private void DisplayRecord()
        {
            DataSet ds = currentTimeRestriction.SelectTimeRestrictionAll();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                hdnTimeRestrictionId.Value = ds.Tables[0].Rows[0]["TimeRestrictionId"].ToString();
                seMaximumTime.Text = ds.Tables[0].Rows[0]["MaximumRecordingPerDay"] != null ? ds.Tables[0].Rows[0]["MaximumRecordingPerDay"].ToString() : "0";
                txtTimeExceed.Text = ds.Tables[0].Rows[0]["WarningAfterLimitExceed"] != null ? ds.Tables[0].Rows[0]["WarningAfterLimitExceed"].ToString() : string.Empty;
            }
        }

    }
}