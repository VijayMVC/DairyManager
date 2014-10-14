using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diary.Common;
using Diary.UserManagement;
using Diary.Entity;

namespace DairyManager.UserManagement
{
    public partial class Users : System.Web.UI.Page
    {
        string currentPassword = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDropdowns();

            if (!IsPostBack)
            {
                if (Request.QueryString["UserId"] != null)
                {
                    this.hdnUserId.Value = Request.QueryString["UserId"].Trim();
                    this.DisplayData();
                }
            }

            AuthoriseUser();
        }

        private void AuthoriseUser()
        {
            btnSave.Visible = Master.LoggedUser.IsUserAuthorised(Diary.Common.Enum.Rights.UserManagement_User_Add)
                || Master.LoggedUser.IsUserAuthorised(Diary.Common.Enum.Rights.UserManagement_User_Edit);

            if (!Master.LoggedUser.IsUserAuthorised(Diary.Common.Enum.Rights.UserManagement_User_View))
            {
                //Response.Redirect(Constant.URL_UNAUTHORISEDACTION, false);
                //Todo:
            }
        }

        private void LoadDropdowns()
        {
            ddlJob.DataSource = Dairy.Utility.Generic.GetAll<JobEntity>();
            ddlJob.ValueField = "JobId";
            ddlJob.TextField = "JobName";
            ddlJob.DataBind();

            ddlRoles.DataSource = Dairy.Utility.Generic.GetAll<Role>();
            ddlRoles.ValueField = "RoleId";
            ddlRoles.TextField = "RoleName";
            ddlRoles.DataBind();

            ddlGrade.DataSource = Dairy.Utility.Generic.GetAll<GradeEntity>();
            ddlGrade.ValueField = "GradeId";
            ddlGrade.TextField = "GradeName";
            ddlGrade.DataBind();

            ddlLocation.DataSource = Dairy.Utility.Generic.GetAll<LocationEntity>();
            ddlLocation.ValueField = "LocationId";
            ddlLocation.TextField = "LocationName";
            ddlLocation.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.hdnUserId.Value != string.Empty)
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

        protected bool SaveData()
        {
            bool result = false;

            try
            {
                User users = new User();

                ////Check for existing uername
                users.UserName = txtUserName.Text.Trim();

                if (!users.IsUserIsDuplicateUserName(users.UserName))
                {
                    users.EmailAddress = txtEmail.Text.Trim();

                    if (!users.IsDuplicateEmail(users.EmailAddress))
                    {
                        users.FirstName = txtFirstName.Text.Trim();
                        users.LastName = txtLastName.Text.Trim();

                        users.Password = txtPassword.Text.Trim();
                        users.RoleId = new Guid(ddlRoles.Value.ToString());
                        users.LocationId = Convert.ToInt32(ddlLocation.Value);
                        users.GradeId = Convert.ToInt32(ddlGrade.Value);
                        users.JobId = Convert.ToInt32(ddlJob.Value);
                        users.Contact = txtContact.Text.Trim();

                        users.CreatedBy = Master.LoggedUser.UserId.Value;
                        
                        if (users.Save())
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowSuccessMessage('" + Messages.Save_Success + "')", true);
                            this.ClearFormData();
                        }
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowInfoMessage('" + Messages.Duplicate_Email + "')", true);
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "javascript:ShowInfoMessage('" + Messages.Duplicate_Username + "')", true);
                }


            }
            catch (System.Exception)
            {

            }

            return result;
        }

        protected bool UpdateData()
        {
            bool result = false;

            try
            {
                User users = new User();
                users.UserId = new Guid(this.hdnUserId.Value);
                users.UserName = txtUserName.Text.Trim();
                users.FirstName = txtFirstName.Text.Trim();
                users.LastName = txtLastName.Text.Trim();
                users.EmailAddress = txtEmail.Text.Trim();
                users.Password = txtPassword.Text.Trim();
                users.UpdatedBy = Master.LoggedUser.UserId.Value;
                
                users.RoleId = new Guid(ddlRoles.Value.ToString());
                users.JobId = Convert.ToInt32(ddlJob.Value);
                users.LocationId = Convert.ToInt32(ddlLocation.Value);
                users.GradeId = Convert.ToInt32(ddlGrade.Value);

                if (users.Save())
                {
                    this.ClearFormData();
                }

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

                Guid currentUserId = new Guid(this.hdnUserId.Value);
                User users = new User();
                users.UserId = currentUserId;
                users = users.Select();
                txtUserName.Text = users.UserName;
                txtFirstName.Text = users.FirstName;
                txtLastName.Text = users.LastName;
                txtEmail.Text = users.EmailAddress;
                txtPassword.Text = users.Password;
                txtContact.Text = users.Contact;
                ddlRoles.SelectedItem = ddlRoles.Items.FindByValue(users.RoleId);
                ddlGrade.SelectedItem = ddlGrade.Items.FindByValue(users.GradeId);
                ddlJob.SelectedItem = ddlJob.Items.FindByValue(users.JobId);
                ddlLocation.SelectedItem = ddlLocation.Items.FindByValue(users.LocationId);
                currentPassword = users.Password;

            }
            catch (System.Exception)
            {


            }
        }

        protected void ClearFormData()
        {
            try
            {
                this.txtUserName.Text = string.Empty;
                this.txtFirstName.Text = string.Empty;
                this.txtLastName.Text = string.Empty;
                this.txtEmail.Text = string.Empty;
                this.txtPassword.Text = string.Empty;
                this.txtContact.Text = string.Empty;
                this.txtConfirmPassword.Text = string.Empty;
                this.ddlRoles.SelectedIndex = -1;
                this.ddlJob.SelectedIndex = -1;
                this.ddlGrade.SelectedIndex = -1;
                this.ddlLocation.SelectedIndex = -1;
                this.txtFirstName.Focus();

            }
            catch (System.Exception)
            {

            }
        }

        protected void txtPassword_CustomJSProperties(object sender, DevExpress.Web.ASPxClasses.CustomJSPropertiesEventArgs e)
        {
            e.Properties["cp_myPassword"] = currentPassword;
        }

        protected void txtConfirmPassword_CustomJSProperties(object sender, DevExpress.Web.ASPxClasses.CustomJSPropertiesEventArgs e)
        {
            e.Properties["cp_myPassword"] = currentPassword;

        }

    }
}