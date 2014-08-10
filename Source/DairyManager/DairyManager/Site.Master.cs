using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using UM = Diary.UserManagement;

using Diary.Common;namespace DairyManager
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
                    //Response.Redirect(Constant.URL_LOGIN, false);
                    //Todo:
                }

                return user;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
    
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
    }
}
