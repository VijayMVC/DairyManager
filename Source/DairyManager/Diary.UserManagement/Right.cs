using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.UserManagement;

namespace Diary.UserManagement
{
    public class Right
    {
        #region Properties

        public int RightId { get; set; }
        public Guid RoleId { get; set; }
        public string RightName { get; set; }
        public string RightDescription { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string ModuleName { get; set; }
        public string SubModuleName { get; set; }

        #endregion

        #region Methods

        public Right Select()
        {
            return Dairy.Utility.Generic.Get<Right>(this.RightId);
        }

        public List<Right> SelectAllList()
        {
            return Dairy.Utility.Generic.GetAll<Right>();
        }

        public DataSet SelectAllDataset()
        {
            return (new RightDAO()).SelectAll();
        }

        public DataSet SelectByRolesId()
        {
            return (new RightDAO()).SelectByRolesId(this);
        }

        public List<Right> SelectRightsByUserId(Guid userId)
        {
            return Dairy.Utility.Generic.GetAllByFieldValue<Right>("UserId", userId.ToString());
        }

        #endregion
    }
}
