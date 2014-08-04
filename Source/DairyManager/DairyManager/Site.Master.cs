using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DairyManager
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        public MembershipUser LogedUser
        {
            get
            {
                return Membership.GetUser();
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
