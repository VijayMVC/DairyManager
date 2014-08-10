using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.UserManagement
{
    public class UserManager
    {
        public bool IsUserAuthorised(Common.Enum.Rights right, User user)
        {
            bool returnValue = false;
            int count = user.AllRights.FindAll(e => e.RightId == (int)right).Count();
            if (count > 0)
            {
                returnValue = true;
            }
            return returnValue;
        }

        public bool IsUserInModule(string module, User user)
        {
            bool returnValue = false;
            int count = user.AllRights.FindAll(e => e.ModuleName.Trim() == module.Trim()).Count();
            if (count > 0)
            {
                returnValue = true;
            }
            return returnValue;
        }

        public bool IsUserInSubModule(string subModule, User user)
        {
            bool returnValue = false;
            int count = user.AllRights.FindAll(e => e.SubModuleName.Trim() == subModule.Trim()).Count();
            if (count > 0)
            {
                returnValue = true;
            }
            return returnValue;
        }
    }
}
