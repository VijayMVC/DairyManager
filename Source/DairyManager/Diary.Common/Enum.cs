using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Common
{
    public class Enum
    {
        public enum QueryStringParameters
        {
            CaseId = 1,
            TaskId = 2,            
            CaseTypeId=3,
            TimeRestrictionId=4,
            ClientId=5,
            TaskTypeId=6,
        }

        /// <summary>
        /// Use the Below format to add new Items to this Enum
        /// MODULE_SUBMODULE_RIGHT
        /// </summary>
        public enum Rights
        {
            UserManagement_User_Add = 1,
            UserManagement_User_Edit = 2,
            UserManagement_User_Delete = 3,
            UserManagement_User_View = 4,
            UserManagement_Roles_Add = 5,
            UserManagement_Roles_Edit = 6,
            UserManagement_Roles_Delete = 7,
            UserManagement_Roles_View = 8,
            UserManagement_User_Search = 9,
            UserManagement_Roles_Search = 10,
        }
    }
}
