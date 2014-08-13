using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.DAL;
using Diary.Entity;

namespace Diary.UserManagement
{
    /// <summary>
    /// Keep this class simple as possible
    /// </summary>   
    public class User
    {
        #region Properties

        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }

        public int JobId { get; set; }
        public int? GradeId { get; set; }
        public int LocationId { get; set; }

        public string EmailAddress { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid RoleId { get; set; }
        public List<Right> AllRights { get; set; }
        public int LoginAttempts { get; set; }
        public bool IsLocked { get; set; }

        #endregion

        #region Methods

        #region Save

        public bool Save()
        {
            bool result = false;
            try
            {
                if (this.UserId.HasValue)
                {
                    AddGradeHistory();
                    result = (new UserDAO()).Update(this);
                }
                else
                {
                    result = (new UserDAO()).Insert(this);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw;
            }
            return result;
        }

        private void AddGradeHistory()
        {
            User user = Dairy.Utility.Generic.Get<User>(this.UserId.Value);
            if (user.GradeId != this.GradeId)
            {
                GradeHistoryEntity gradeHistory = new GradeHistoryEntity();
                gradeHistory.UserId = this.UpdatedBy;
                gradeHistory.OldGradeId = user.GradeId;
                gradeHistory.NewGradeId = this.GradeId.Value;
                gradeHistory.CreatedBy = this.UpdatedBy;
                new GradeHistoryDao().Insert(gradeHistory);
            }
        }

        #endregion


        #region Delete

        public bool Delete()
        {
            bool result = false;
            try
            {
                if (this.UserId.HasValue)
                {
                    result = (new UserDAO()).Delete(this);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw;
            }
            return result;
        }

        #endregion


        public User Select()
        {
            User user = Dairy.Utility.Generic.Get<User>(this.UserId.Value);
            user.AllRights = new Right().SelectRightsByUserId(this.UserId.Value);
            return user;
        }

        public List<User> SelectAllList()
        {
            return Dairy.Utility.Generic.GetAll<User>();
        }

        public DataSet SelectAllDataset()
        {
            return (new UserDAO()).SelectAll(this);
        }

        public bool IsUserAuthenticated(string userName, string password, out Guid UserId)
        {
            return (new UserDAO()).IsUserAuthenticated(userName, password, out UserId);
        }

        public bool IsUserIsDuplicateUserName(string userName)
        {
            return (new UserDAO()).IsUserIsDuplicateUserName(userName);
        }

        public bool IsDuplicateEmail(string email)
        {
            return (new UserDAO()).IsDuplicateEmail(email);

        }

        public bool IsUserAuthorised(Common.Enum.Rights right)
        {
            return new UserManager().IsUserAuthorised(right, this);
        }

        public bool IsUserInModule(string module)
        {
            return new UserManager().IsUserInModule(module, this);
        }

        public bool IsUserInSubModule(string subModule)
        {
            return new UserManager().IsUserInSubModule(subModule, this);
        }

        #endregion
    }
}
