using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Diary.UserManagement
{
    [Serializable]
    public class Role
    {
        #region Properties

        public Guid? RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public int RightId { get; set; }
        public int CompanyId { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        #endregion

        #region Methods

        #region Save

        public bool Save(Database db, DbTransaction transaction)
        {
            bool result = false;
            try
            {
                if (this.RoleId.HasValue)
                {
                    result = (new RoleDAO()).Update(this, db, transaction);
                }
                else
                {
                    result = (new RoleDAO()).Insert(this, db, transaction);
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                throw;
            }
            return result;
        }

        public bool SaveRoleRights(Database db, DbTransaction transaction)
        {
            bool result = false;
            try
            {
                result = (new RoleDAO()).InsertRoleRights(this, db, transaction);
            }
            catch (System.Exception ex)
            {
                result = false;
                throw;
            }
            return result;
        }

        public bool DeleteByRoleId(Database db, DbTransaction transaction)
        {
            bool result = false;
            try
            {
                result = (new RoleDAO()).DeleteByRoleId(this, db, transaction);
            }
            catch (System.Exception ex)
            {
                result = false;
                throw;
            }
            return result;
        }


        #endregion

        #region Delete

        public bool Delete()
        {
            bool result = false;
            try
            {
                if (this.RoleId.HasValue)
                {
                    result = (new RoleDAO()).Delete(this);
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

        public Role Select()
        {
            return Dairy.Utility.Generic.Get<Role>(this.RoleId.Value);
        }

        public List<Role> SelectAllList()
        {
            return Dairy.Utility.Generic.GetAll<Role>();
        }

        public DataSet SelectAllDataset()
        {
            return (new RoleDAO()).SelectAll(this);
        }

        public bool IsDuplicateRoleName(string roleName)
        {
            return (new RoleDAO()).IsDuplicateRoleName(roleName);
        }

        #endregion
    }
}
