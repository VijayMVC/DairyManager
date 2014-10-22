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
    public partial class Offence : System.Web.UI.Page
    {
        Diary.BLL.Offence currentOffence = new Diary.BLL.Offence();
        Diary.Entity.OffenceEntity offenceEntity = new OffenceEntity();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnOffenceTypeId.Value = Master.GetQueryStringValueByKey(Request, com.Enum.QueryStringParameters.OffenceTypeId.ToString());

                if (hdnOffenceTypeId.Value != string.Empty)
                {
                    this.DisplayRecord(new Guid(hdnOffenceTypeId.Value));                    
                }

            }
            this.AuthoriseUser();
        }

        private void AuthoriseUser()
        {
             if (Master.LoggedUser == null)
            {
                Session[Constant.SESSION_LOGGEDUSER] = null;
                Response.Redirect(Constant.URL_LOGIN, false);
                return;
            }

            btnSave.Visible = (Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Offence_Add)
                || Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Offence_Edit));

            if (!Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_Case_View))
            {
                Response.Redirect(com.Constant.URL_UNAUTHORISEDACTION, false);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            offenceEntity.Offence = txtOffence.Text.Trim();
         
            if (hdnOffenceTypeId.Value == string.Empty)
            {
                offenceEntity.CreatedBy = Master.LoggedUser.UserId.Value;

                if (!currentOffence.IsOffenceExists(offenceEntity.Offence))
                {
                    currentOffence.InsertOffence(offenceEntity);
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

                offenceEntity.OffenceTypeId = new Guid(hdnOffenceTypeId.Value);
                offenceEntity.UpdatedBy = Master.LoggedUser.UserId.Value; 

                currentOffence.UpdateOffence(offenceEntity);
                Master.ShowMessage( Diary.Common.Constant.Message_Success);                

                this.ClearFormFields();

            }
        }

        private void DisplayRecord(Guid id)
        {
            DataSet ds = currentOffence.SelectOffenceByOffenceTypeId(id);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {              
                txtOffence.Text = ds.Tables[0].Rows[0]["Offence"] != null ? ds.Tables[0].Rows[0]["Offence"].ToString() : string.Empty;
                
            }
        }

        private void ClearFormFields()
        {
            txtOffence.Text = string.Empty;           
            hdnOffenceTypeId.Value = string.Empty;
            txtOffence.Focus();
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearFormFields();
        }
    }
}