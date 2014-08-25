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
    public partial class ClientSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadData();
            this.AuthoriseUser();
        }

        private void AuthoriseUser()
        {
            btnBack.Visible = (Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Client_Client_Add));
            gvClientSearch.Columns["ClientId"].Visible = Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Client_Client_Edit) 
                || Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Client_Client_View);

            if (!Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_Case_View))
            {
                Response.Redirect(com.Constant.URL_UNAUTHORISEDACTION, false);
            }
        }

        private void LoadData()
        {
            bll.Client currentClient = new bll.Client();
            gvClientSearch.DataSource = currentClient.SelectClientAll().Tables[0];
            gvClientSearch.DataBind();                               
        }
    }
}