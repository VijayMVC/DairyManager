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
    public partial class OffenceSearch : System.Web.UI.Page
    {
        bll.Offence currentOffence = new bll.Offence();


        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadData();
            this.AuthoriseUser();
        }

        private void AuthoriseUser()
        {
            btnBack.Visible = (Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Offence_Add));
            //gvCaseTypeSearch.Columns["OffenceTypeId"].Visible = Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_CaseType_Edit);

            if (!Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Offence_Search))
            {
                Response.Redirect(com.Constant.URL_UNAUTHORISEDACTION, false);
            }
        }

        private void LoadData()
        {
            gvCaseTypeSearch.DataSource = currentOffence.SelectAllOffence().Tables[0];
            gvCaseTypeSearch.DataBind();
        }

        protected void gvCaseTypeSearch_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;

            currentOffence.DeleteOffence((Guid)e.Keys[gvCaseTypeSearch.KeyFieldName]);
            this.LoadData();
        }
    }
}