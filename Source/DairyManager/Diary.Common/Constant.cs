using System;
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

        #region Session Names

        public static readonly string SESSION_LOGGEDUSER = "SESSION_LOGGEDUSER";

        #endregion

        #region Common Settings

        public static readonly int GRID_PAGESIZE = 15;

        #endregion
    }
}
