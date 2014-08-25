using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll = Diary.BLL;
using com = Diary.Common;


namespace DairyManager
{
    public partial class CaseTypeSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadData();
            this.AuthoriseUser();
        }

        private void AuthoriseUser()
        {
            btnBack.Visible = (Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_CaseType_Add));
            gvCaseTypeSearch.Columns["CaseTypeId"].Visible = Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_CaseType_Edit);

            if (!Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_CaseType_Search))
            {
                Response.Redirect(com.Constant.URL_UNAUTHORISEDACTION, false);
            }
        }

        private void LoadData()
        {
            bll.Case currentCase = new bll.Case();
            gvCaseTypeSearch.DataSource = currentCase.SelectAllCaseType().Tables[0];
            gvCaseTypeSearch.DataBind();
        }
    }
}