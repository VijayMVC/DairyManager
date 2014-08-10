using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diary.UserManagement;
using Diary.Common;

namespace DairyManager
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            this.AuthenticateUser();
        }

        protected void AuthenticateUser()
        {
            try
            {
                User users = new User();

                string userName = txtUserName.Text;
                string password = txtPassword.Text;
                Guid userID = new Guid();

                if (users.IsUserAuthenticated(userName, password, out userID))
                {

                    if (userID != new Guid())
                    {
                        users.UserId = userID;
                        Session[Constant.SESSION_LOGGEDUSER] = users.Select();
                        Response.Redirect(Diary.Common.Constant.URL_DEFAULTBACKPAGE, false);
                        //Todo
                    }
                }
                else
                {
                    //trMsg.Visible = true;
                    FailureText.Text = Diary.Common.Messages.Invalid_Credentials;
                    FailureText.Visible = true;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}