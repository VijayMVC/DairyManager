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
    public partial class CourtSearch : System.Web.UI.Page
    {
        bll.Court currentCourt = new bll.Court();


        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadData();
            this.AuthoriseUser();
        }

        private void AuthoriseUser()
        {
            btnBack.Visible = (Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Court_Add));
            gvCaseTypeSearch.Columns["CourtId"].Visible = Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Court_Edit);

            if (!Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Court_Search))
            {
                Response.Redirect(com.Constant.URL_UNAUTHORISEDACTION, false);
            }
        }

        private void LoadData()
        {
            gvCaseTypeSearch.DataSource = currentCourt.SelectAllCourt().Tables[0];
            gvCaseTypeSearch.DataBind();
        }

        protected void gvCaseTypeSearch_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;

            currentCourt.DeleteCourt((Guid)e.Keys[gvCaseTypeSearch.KeyFieldName]);
            this.LoadData();
        }
    }
}