using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diary.Common;
using Diary.UserManagement;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DairyManager.UserManagement
{
    public partial class Roles : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            gvRights.SettingsPager.PageSize = Constant.GRID_PAGESIZE;

            if (!IsPostBack)
            {
                if (Request.QueryString["RoleId"] != null)
                {
                    this.hdnRoleId.Value = Request.QueryString["RoleId"];
                    this.DisplayData();

                }
            }

            this.LoadRights();
            this.AuthoriseUser();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void AuthoriseUser()
        {
            btnSave.Visible = (Master.LoggedUser.IsUserAuthorised(Diary.Common.Enum.Rights.UserManagement_Roles_Add)
                || Master.LoggedUser.IsUserAuthorised(Diary.Common.Enum.Rights.UserManagement_Roles_Edit));

            if (!Master.LoggedUser.IsUserAuthorised(Diary.Common.Enum.Rights.UserManagement_Roles_View))
            {
                //Response.Redirect(Constant.URL_UNAUTHORISEDACTION, false);
                //Todo:
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.hdnRoleId.Value != string.Empty)
                {
                    this.UpdateData();
                }
                else
                {
                    this.SaveData();
                }
            }
            catch (System.Exception)
            {


            }
        }

        protected void LoadRights()
        {
            try
            {
                Right RightsObj = new Right();

                if (this.hdnRoleId.Value != string.Empty)
                {
                    RightsObj.RoleId = new Guid(this.hdnRoleId.Value);
                }

                gvRights.DataSource = RightsObj.SelectByRolesId();
                gvRights.DataBind();

                if (this.hdnRoleId.Value != string.Empty)
                {

                    for (int i = 0; i <= gvRights.VisibleRowCount - 1; i++)
                    {
                        if (gvRights.GetRowValues(i, "RoleId").ToString() != string.Empty)
                        {
                            gvRights.Selection.SelectRow(i);
                        }
                    }

                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        protected bool SaveData()
        {

            bool result = false;

            DbConnection connection = null;
            DbTransaction transaction = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
                connection = db.CreateConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                Role RolesObj = new Role();

                RolesObj.RoleName = txtRoleName.Text.Trim();

                if (!RolesObj.IsDuplicateRoleName(RolesObj.RoleName))
                {

                    RolesObj.RoleDescription = txtRoleDescription.Text.Trim();
                    RolesObj.CreatedBy = Master.LoggedUser.UserId.Value;
                    RolesObj.UpdatedBy = Master.LoggedUser.UserId.Value;

                    if (RolesObj.Save(db, transaction))
                    {
                        List<object> myList = gvRights.GetSelectedFieldValues("RightId");

                        if (myList.Count > 0)
                        {
                            for (int i = 0; i <= myList.Count - 1; i++)
                            {
                                RolesObj.RightId = Convert.ToInt32(myList[i].ToString());
                                RolesObj.SaveRoleRights(db, transaction);
                            }
                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Select_Role + "')", true);
                            transaction.Rollback();

                        }
                    }

                    transaction.Commit();
                    result = true;
                    hdnRoleId.Value = RolesObj.RoleId.HasValue ? RolesObj.RoleId.Value.ToString() : string.Empty;
                    this.DisplayData();

                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Success + "')", true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowInfoMessage('" + Messages.Duplicate_Rolename + "')", true);

                }


            }
            catch (System.Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }

            return result;
        }

        protected bool UpdateData()
        {
            bool result = false;

            DbConnection connection = null;
            DbTransaction transaction = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constant.DiaryDBConnectionString);
                connection = db.CreateConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                Role RolesObj = new Role();
                RolesObj.RoleId = new Guid(this.hdnRoleId.Value);
                RolesObj.RoleName = txtRoleName.Text.Trim();
                RolesObj.RoleDescription = txtRoleDescription.Text.Trim();
                RolesObj.UpdatedBy = Master.LoggedUser.UserId.Value;

                if (RolesObj.Save(db, transaction))
                {

                    //Delete exiting role rights
                    RolesObj.DeleteByRoleId(db, transaction);

                    List<object> myList = gvRights.GetSelectedFieldValues("RightId");

                    if (myList.Count > 0)
                    {
                        for (int i = 0; i <= myList.Count - 1; i++)
                        {
                            RolesObj.RightId = Convert.ToInt32(myList[i].ToString());
                            RolesObj.SaveRoleRights(db, transaction);
                        }
                    }
                }

                transaction.Commit();
                result = true;

                this.DisplayData();

                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Success + "')", true);

            }
            catch (System.Exception)
            {

            }

            return result;
        }

        protected void DisplayData()
        {
            try
            {

                Guid currentRoleId = new Guid(this.hdnRoleId.Value);
                Role RolesObj = new Role();
                RolesObj.RoleId = currentRoleId;
                RolesObj = RolesObj.Select();
                this.txtRoleName.Text = RolesObj.RoleName;
                this.txtRoleDescription.Text = RolesObj.RoleDescription;

                Right RightsObj = new Right();
                RightsObj.RoleId = RolesObj.RoleId.Value;
                gvRights.DataSource = RightsObj.SelectByRolesId();
                gvRights.DataBind();

            }
            catch (System.Exception)
            {


            }
        }

    }
}