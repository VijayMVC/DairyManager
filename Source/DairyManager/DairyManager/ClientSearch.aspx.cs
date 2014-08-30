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
        bll.Client currentClient = new bll.Client();


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
            gvClientSearch.DataSource = currentClient.SelectClientAll().Tables[0];
            gvClientSearch.DataBind();                               
        }

        protected void gvClientSearch_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            //int i = gvRoles.FindVisibleIndexByKeyValue(e.Keys[gvRoles.KeyFieldName]);
            

            //UserMan.Roles roles = new UserMan.Roles();
            e.Cancel = true;

            currentClient.DeleteClientByClientId((Guid)e.Keys[gvClientSearch.KeyFieldName]);
            this.LoadData();
            
        }
    }
}