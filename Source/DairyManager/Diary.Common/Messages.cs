﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Common
{
    public class Messages
    {
        public static readonly string Save_Success = "Successfully Saved";
        public static readonly string Update_Success = "Successfully Updated";
        public static readonly string Delete_Success = "Successfully Deleted";

        public static readonly string Save_Unsuccess = "Cannot Save";
        public static readonly string Update_Unsuccess = "Cannot Update";
        public static readonly string Delete_Unsuccess = "Cannot Delete";

        public static readonly string Select_Role = "Please select a role";
        public static readonly string Duplicate_record = "Can not continue. Record is already exists!";
        public static readonly string UnauthorisedExceptionMessage = "You are not authorised to do this task";
        public static readonly string Duplicate_Username = "Username already exists";
        public static readonly string Duplicate_Email = "Email already exists";
        public static readonly string Duplicate_Rolename = "Role name already exists";
        public static readonly string Invalid_Credentials = "Invalid Credentials";
        public static readonly string Delete_Confirm = "Are you sure you want to delete this record?";
    }
}
