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
            OffenceTypeId = 7,
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
            //Case Relted
            Case_Case_Add = 11,
            Case_Case_Edit = 12,
            Case_Case_Delete = 13,
            Case_Case_View = 14,
            Case_Case_Search = 15,

            //Case Type
            Case_CaseType_Add = 16,
            Case_CaseType_Edit = 17,
            Case_CaseType_Delete = 18,
            Case_CaseType_View = 19,
            Case_CaseType_Search = 20,

            //Client
            Client_Client_Add = 21,
            Client_Client_Edit = 22,
            Client_Client_Delete = 23,
            Client_Client_View = 24,
            Client_Client_Search = 25,

            //Task
            Task_Task_Add = 26,
            Task_Task_Edit = 27,
            Task_Task_Delete = 28,
            Task_Task_View = 29,
            Task_Task_Search = 30,

            //Task Type
            Task_TaskType_Add = 31,
            Task_TaskType_Edit = 32,
            Task_TaskType_Delete = 33,
            Task_TaskType_View = 34,
            Task_TaskType_Search = 35,
        }

        public enum ReportTypes
        {
            CaseInfo = 1,
        }
    }

   
}
