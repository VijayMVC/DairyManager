using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diary.Entity;
using bll = Diary.BLL;
using com = Diary.Common;

namespace DairyManager
{
    public partial class Case : System.Web.UI.Page
    {
        CaseEntity caseEntity = new CaseEntity();
        bll.Client currentClient = new bll.Client();
        bll.Case currentCase = new bll.Case();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadClient();
            this.LoadCaseType();

            if (!IsPostBack)
            {
                hdnCaseId.Value = Master.GetQueryStringValueByKey(Request, com.Enum.QueryStringParameters.CaseId.ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            caseEntity.Code = txtCode.Text.Trim();
            caseEntity.Case = txtCase.Text.Trim();
            caseEntity.ClientId = (Guid)cmbClient.Value;
            caseEntity.CaseTypeId = (Guid)cmbCaseType.Value;
            caseEntity.Email = txtEmail.Text.Trim();
            caseEntity.Contact = txtContact.Text.Trim();

            caseEntity.CreatedBy = new Guid();
            caseEntity.UpdatedBy = new Guid();

            bll.Case caseBll = new bll.Case();

            Guid caseid;
            bool isUpdated = true;
            if (Guid.TryParse(hdnCaseId.Value, out caseid))
            {
                caseEntity.CaseId = caseid;
                isUpdated = caseBll.UpdateCase(caseEntity);
            }
            else
            {
                caseEntity.CaseId = new Guid();
                caseEntity.CaseId = caseBll.InsertCase(caseEntity);
            }


            //Todo show save succesfully message            

        }

        private void LoadClient()
        {
            cmbClient.DataSource = currentClient.SelectClientAll().Tables[0];
            cmbClient.TextField = "Name";
            cmbClient.ValueField = "ClientId";
            cmbClient.DataBind();

        }

        private void LoadCaseType()
        {
            cmbCaseType.DataSource = currentCase.SelectAllCaseType().Tables[0];
            cmbCaseType.TextField = "CaseDescription";
            cmbCaseType.ValueField = "CaseTypeId";
            cmbCaseType.DataBind();
        }

    }
}