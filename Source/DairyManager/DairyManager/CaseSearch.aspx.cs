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
    public partial class CaseSearch : System.Web.UI.Page
    {
        bll.Case currentCase = new bll.Case();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ClientData"] = null;
            this.LoadData();
            this.AuthoriseUser();
        }

        private void AuthoriseUser()
        {
            btnBack.Visible = (Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_Case_Add));
            gvCaseSearch.Columns["CaseId"].Visible = Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_Case_Edit) || Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_Case_View);

            if (!Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_Case_Search))
            {
                Response.Redirect(com.Constant.URL_UNAUTHORISEDACTION, false);
            }
        }

        private void LoadData()
        {
            gvCaseSearch.DataSource = currentCase.SelectAllCase().Tables[0];
            gvCaseSearch.DataBind();
        }

        protected void gvCaseSearch_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;

            currentCase.DeleteCase((Guid)e.Keys[gvCaseSearch.KeyFieldName]);
            this.LoadData();
        }
    }
}