using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diary.Common;
using Diary.Entity;
using Diary.BLL;
using com = Diary.Common;
using System.Data;

namespace DairyManager
{
    public partial class Court : System.Web.UI.Page
    {
        Diary.BLL.Court currentCourt = new Diary.BLL.Court();
        Diary.Entity.CourtEntity courtEntity = new CourtEntity();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.AuthoriseUser();

            if (!IsPostBack)
            {
                hdnCourtId.Value = Master.GetQueryStringValueByKey(Request, com.Enum.QueryStringParameters.CourtId.ToString());

                if (hdnCourtId.Value != string.Empty)
                {
                    this.DisplayRecord(new Guid(hdnCourtId.Value));
                }

                this.LoadCourtTypes();

            }

            
        }

        private void AuthoriseUser()
        {
            if (Master.LoggedUser == null)
            {
                Session[Constant.SESSION_LOGGEDUSER] = null;
                Response.Redirect(Constant.URL_LOGIN, false);
                return;
            }

            btnSave.Visible = (Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_CaseType_Add)
                || Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_CaseType_Edit));

            if (!Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_CaseType_View))
            {
                Response.Redirect(com.Constant.URL_UNAUTHORISEDACTION, false);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Master.LoggedUser == null)
            {
                return;
            }

            courtEntity.Court = txtCourt.Text.Trim();
            courtEntity.CourtTypeId = new Guid(cmbCourtType.Value.ToString()); 
            courtEntity.PoliceStation = txtPoliceStation.Text.Trim();

            if (hdnCourtId.Value == string.Empty)
            {
                courtEntity.CreatedBy = Master.LoggedUser.UserId.Value;

                if (!currentCourt.IsCourtExists(courtEntity.Court))
                {
                    currentCourt.InsertCourt(courtEntity);
                    Master.ShowMessage( Diary.Common.Constant.Message_Success);

                    this.ClearFormFields();
                }
                else
                {
                    Master.ShowMessage(Diary.Common.Constant.Message_AlreadyExists);                
                }
            }
            else
            {

                courtEntity.CourtId = new Guid(hdnCourtId.Value);
                courtEntity.UpdatedBy = Master.LoggedUser.UserId.Value; 

                currentCourt.UpdateCourt(courtEntity);
                Master.ShowMessage( Diary.Common.Constant.Message_Success);                

                this.ClearFormFields();

            }
        }

        private void DisplayRecord(Guid id)
        {
            DataSet ds = currentCourt.SelectCourtBycourtId(id);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                txtCourt.Text = ds.Tables[0].Rows[0]["Court"] != null ? ds.Tables[0].Rows[0]["Court"].ToString() : string.Empty;
                cmbCourtType.Value = ds.Tables[0].Rows[0]["CourtTypeId"].ToString();
                txtPoliceStation.Text = ds.Tables[0].Rows[0]["PoliceStation"] != null ? ds.Tables[0].Rows[0]["PoliceStation"].ToString() : string.Empty;
            }
        }

        private void ClearFormFields()
        {
            txtCourt.Text = string.Empty;
            cmbCourtType.SelectedIndex = -1;
            txtPoliceStation.Text = string.Empty;
            hdnCourtId.Value = string.Empty;
            txtCourt.Focus();
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearFormFields();
        }

        private void LoadCourtTypes()
        {
            cmbCourtType.DataSource = currentCourt.SelectAllCourtTypes().Tables[0];
            cmbCourtType.ValueField = "CourtTypeId";
            cmbCourtType.TextField = "CourtType";
            cmbCourtType.DataBind();

        }
    }
}