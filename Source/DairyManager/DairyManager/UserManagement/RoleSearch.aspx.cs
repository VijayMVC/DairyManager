using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diary.Common;
using Diary.UserManagement;

namespace DairyManager.UserManagement
{
    public partial class RoleSearch : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            gvRoles.SettingsPager.PageSize = Constant.GRID_PAGESIZE;
            gvRoles.SettingsText.ConfirmDelete = Messages.Delete_Confirm;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadRoles();

                AuthoriseUser();
            }
            catch (System.Exception)
            {

            }
        }

        private void AuthoriseUser()
        {
            if (Master.LoggedUser == null)
            {
                Session[Constant.SESSION_LOGGEDUSER] = null;
                Response.Redirect(Constant.URL_LOGIN, false);
                return;
            }

            gvRoles.Columns["Actions"].Visible = Master.LoggedUser.IsUserAuthorised(Diary.Common.Enum.Rights.UserManagement_Roles_Delete);
            gvRoles.Columns[1].Visible = Master.LoggedUser.IsUserAuthorised(Diary.Common.Enum.Rights.UserManagement_Roles_Edit)
                     || Master.LoggedUser.IsUserAuthorised(Diary.Common.Enum.Rights.UserManagement_Roles_View);
            gvRoles.Columns[2].Visible = !gvRoles.Columns[1].Visible;

            if (!Master.LoggedUser.IsUserAuthorised(Diary.Common.Enum.Rights.UserManagement_Roles_Search))
            {
               // Response.Redirect(Constant.URL_UNAUTHORISEDACTION, false);
                //Todo:
            }
        }

        protected void gvRoles_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvRoles.FindVisibleIndexByKeyValue(e.Keys[gvRoles.KeyFieldName]);
            e.Cancel = true;

            Role roles = new Role();

            roles.RoleId = new Guid(e.Keys[gvRoles.KeyFieldName].ToString());

            if (roles.Delete())
            {
                this.LoadRoles();
            }
        }


        private void LoadRoles()
        {
            Role roles = new Role();
            gvRoles.DataSource = roles.SelectAllDataset();
            gvRoles.DataBind();
        }

    }
}