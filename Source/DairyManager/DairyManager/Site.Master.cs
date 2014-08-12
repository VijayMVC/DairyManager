using System;
using System.Collections.Specialized;
using System.Web;
using Diary.Common;
using UM = Diary.UserManagement;
using System.Web.UI.WebControls;

namespace DairyManager
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        /// <summary>
        /// Logged User
        /// </summary>
        public UM.User LoggedUser
        {
            get
            {
                UM.User user;

                if (Session[Constant.SESSION_LOGGEDUSER] != null)
                {
                    user = (UM.User)Session[Constant.SESSION_LOGGEDUSER];
                }
                else
                {
                    user = null;
                    Session[Constant.SESSION_LOGGEDUSER] = null;
                    Response.Redirect(Constant.URL_LOGIN, false);
                }

                return user;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoggedUser == null)
            {
                return;
            }

            Label lblUserName = (Label) HeadLoginView.Controls[0].Controls[0].FindControl("lblLoggedName");
            lblUserName.Text = this.LoggedUser.UserName;
    
        }

        public string GetQueryStringValueByKey(HttpRequest request, string name)
        {
            string returnValue = "";
            NameValueCollection items = request.QueryString;
            if (items[name] != null)
            {
                returnValue = items[name];
            }

            return returnValue;
        }

        public void ShowMessage(string message)
        {           
                     
            if (message==Constant.Message_Success)
            {
                this.dvSuccessMessage.Visible = true;
                this.ltlSuccesMessage.Text = message;

                this.dvWarningMessage.Visible = false;

            }
            else if (message == Constant.Message_AlreadyExists)
            {
                this.dvWarningMessage.Visible = true;
                this.ltlWariningMessage.Text = message;
                this.dvSuccessMessage.Visible = false;

            }

        }
    }
}
