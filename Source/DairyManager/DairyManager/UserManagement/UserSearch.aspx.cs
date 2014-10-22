using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diary.Common;
using Diary.UserManagement;

namespace DairyManager.UserManagement
{
    public partial class UserSearch : System.Web.UI.Page
    {
        User UserObj = new User();

        protected void Page_Init(object sender, EventArgs e)
        {
            gvUsers.SettingsPager.PageSize = Constant.GRID_PAGESIZE;
            gvUsers.SettingsText.ConfirmDelete = Diary.Common.Messages.Delete_Confirm;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadUsers();
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

            gvUsers.Columns[0].Visible = Master.LoggedUser.IsUserAuthorised(Diary.Common.Enum.Rights.UserManagement_User_Delete);
            gvUsers.Columns[1].Visible = Master.LoggedUser.IsUserAuthorised(Diary.Common.Enum.Rights.UserManagement_User_Edit) ||
                Master.LoggedUser.IsUserAuthorised(Diary.Common.Enum.Rights.UserManagement_User_View);
            gvUsers.Columns[2].Visible = !gvUsers.Columns[1].Visible;

            if (!Master.LoggedUser.IsUserAuthorised(Diary.Common.Enum.Rights.UserManagement_User_Search))
            {
                //Response.Redirect(Constant.URL_UNAUTHORISEDACTION, false);
                //Todo
            }
        }

        protected void gvUsers_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvUsers.FindVisibleIndexByKeyValue(e.Keys[gvUsers.KeyFieldName]);
            e.Cancel = true;

            UserObj.UserId = (Guid)e.Keys[gvUsers.KeyFieldName];

            if (UserObj.Delete())
            {
                this.LoadUsers();
            }
        }

        private void LoadUsers()
        {

            gvUsers.DataSource = UserObj.SelectAllDataset();
            gvUsers.DataBind();
        }

    }
}