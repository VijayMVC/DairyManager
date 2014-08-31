﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Common
{
    public class Constant
    {
        public static readonly string DiaryDBConnectionString = "ApplicationServices";
        public static readonly string Message_Success = "Successfully Saved.";
        public static readonly string URL_LOGIN = "~/Login.aspx";
        public static readonly string URL_DEFAULTBACKPAGE = "~/Dashboard.aspx";
        public static readonly string Message_AlreadyExists= "Record Already Exists";
        public static readonly string URL_UNAUTHORISEDACTION = "~/UnauthorisedAction.aspx";

        #region Session Names

        public static readonly string SESSION_LOGGEDUSER = "SESSION_LOGGEDUSER";

        #endregion

        #region Common Settings

        public static readonly int GRID_PAGESIZE = 15;

        #endregion

        public static string CreateURLQueryString(string urlToNavigate, object mykey)
        {
            string url = urlToNavigate + (object)(mykey.ToString()).ToString();
            return url;
        }
    }
}
