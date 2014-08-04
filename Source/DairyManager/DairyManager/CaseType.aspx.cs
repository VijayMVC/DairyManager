using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diary.Common;
using Diary.Entity;
using Diary.BLL;

namespace DairyManager
{
    public partial class CaseType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Diary.BLL.Case currentCase = new Diary.BLL.Case();
            Diary.Entity.CaseTypeEntity caseTypeEntity = new CaseTypeEntity();


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
    }
}