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
    public partial class CaseType : System.Web.UI.Page
    {
        Diary.BLL.Case currentCase = new Diary.BLL.Case();
        Diary.Entity.CaseTypeEntity caseTypeEntity = new CaseTypeEntity();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnCaseTypeId.Value = Master.GetQueryStringValueByKey(Request, com.Enum.QueryStringParameters.CaseTypeId.ToString());

                if (hdnCaseTypeId.Value != string.Empty)
                {
                    this.DisplayRecord(new Guid(hdnCaseTypeId.Value));
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            caseTypeEntity.CaseDescription = txtCaseTypeDescription.Text.Trim();
            caseTypeEntity.CaseCode = txtCaseCode.Text.Trim();

            if (hdnCaseTypeId.Value == string.Empty)
            {
                caseTypeEntity.CreatedBy = Master.LoggedUser.UserId.Value; 
                
                if (!currentCase.IsCaseCodeExists(caseTypeEntity.CaseCode))
                {
                    currentCase.InsertCaseType(caseTypeEntity);
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

                caseTypeEntity.UpdatedBy = Master.LoggedUser.UserId.Value; 

                currentCase.UpdateCaseType(caseTypeEntity);
                Master.ShowMessage( Diary.Common.Constant.Message_Success);                

                this.ClearFormFields();

            }
        }

        private void DisplayRecord(Guid id)
        {
            DataSet ds = currentCase.SelectCaseTypeByCaseTypeId(id);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                txtCaseTypeDescription.Text = ds.Tables[0].Rows[0]["CaseDescription"] != null ? ds.Tables[0].Rows[0]["CaseDescription"].ToString() : string.Empty;
                txtCaseCode.Text = ds.Tables[0].Rows[0]["CaseCode"] != null ? ds.Tables[0].Rows[0]["CaseCode"].ToString() : string.Empty;
            }
        }

        private void ClearFormFields()
        {
            txtCaseTypeDescription.Text = string.Empty;
            txtCaseCode.Text = string.Empty;
            hdnCaseTypeId.Value = string.Empty;
            txtCaseTypeDescription.Focus();
            
        }
    }
}