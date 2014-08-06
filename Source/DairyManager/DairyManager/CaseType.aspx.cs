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
                hdnCaseTypeId.Value = Master.GetQueryStringValueByKey(Request, com.Enum.QueryStringParameters.CaseId.ToString());

                if (hdnCaseTypeId.Value != string.Empty)
                {
                    this.DisplayRecord(new Guid(hdnCaseTypeId.Value));
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (hdnCaseTypeId.Value == string.Empty)
            {
                caseTypeEntity.CaseDescription = txtCaseTypeDescription.Text.Trim();
                caseTypeEntity.CaseCode = txtCaseCode.Text.Trim();
                caseTypeEntity.CreatedBy = (Guid)Master.LogedUser.ProviderUserKey;


                if (!currentCase.IsCaseCodeExists(caseTypeEntity.CaseCode))
                {
                    currentCase.InsertCaseType(caseTypeEntity);
                }
                else
                {
                    //message already exists.
                }
            }
            else
            {
                caseTypeEntity.CaseDescription = txtCaseTypeDescription.Text.Trim();
                caseTypeEntity.CaseCode = txtCaseCode.Text.Trim();
                caseTypeEntity.UpdatedBy = (Guid)Master.LogedUser.ProviderUserKey;

                currentCase.UpdateCaseType(caseTypeEntity);

            }
        }

        private void DisplayRecord(Guid id)
        {
            DataSet ds = currentCase.SelectCaseTypeByCaseTypeId(id);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                txtCaseTypeDescription.Text = caseTypeEntity.CaseDescription;
                txtCaseCode.Text = caseTypeEntity.CaseCode;
            }
        }

    }
}