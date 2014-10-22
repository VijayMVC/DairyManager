using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll = Diary.BLL;
using com = Diary.Common;
using Diary.Common;


namespace DairyManager
{
    public partial class CaseTypeSearch : System.Web.UI.Page
    {
        bll.Case currentCase = new bll.Case();


        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadData();
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

            btnBack.Visible = (Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_CaseType_Add));
            gvCaseTypeSearch.Columns["CaseTypeId"].Visible = Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_CaseType_Edit);

            if (!Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_CaseType_Search))
            {
                Response.Redirect(com.Constant.URL_UNAUTHORISEDACTION, false);
            }
        }

        private void LoadData()
        {
            gvCaseTypeSearch.DataSource = currentCase.SelectAllCaseType().Tables[0];
            gvCaseTypeSearch.DataBind();
        }

        protected void gvCaseTypeSearch_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;

            currentCase.DeleteCaseType((Guid)e.Keys[gvCaseTypeSearch.KeyFieldName]);
            this.LoadData();
        }
    }
}