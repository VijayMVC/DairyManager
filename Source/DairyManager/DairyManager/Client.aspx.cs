using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diary.Entity;
using bll = Diary.BLL;
using com = Diary.Common;


namespace DairyManager
{
    public partial class Client : System.Web.UI.Page
    {
        Diary.BLL.Client currentclient = new Diary.BLL.Client();
        Diary.Entity.ClientEntity clientEntity = new Diary.Entity.ClientEntity();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnClientId.Value = Master.GetQueryStringValueByKey(Request, com.Enum.QueryStringParameters.ClientId.ToString());

                if (hdnClientId.Value != string.Empty)
                {
                    this.DisplayRecord(new Guid(hdnClientId.Value));
                }

            }
            this.AuthoriseUser();
        }

        private void AuthoriseUser()
        {
            btnSave.Visible = (Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Client_Client_Add)
                || Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Client_Client_Edit));

            if (!Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Client_Client_View))
            {
                Response.Redirect(com.Constant.URL_UNAUTHORISEDACTION, false);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            clientEntity.Name = txtName.Text.Trim();
            clientEntity.AddressLine1 = txtAddressLine1.Text.Trim();
            clientEntity.AddressLine2 = txtAddressLine2.Text.Trim();
            clientEntity.AddressLine3 = txtAddressLine3.Text.Trim();
            clientEntity.Telephone = txtTelephone.Text.Trim();
            clientEntity.Fax = txtFax.Text.Trim();
            clientEntity.Email = txtEmail.Text.Trim();
            clientEntity.ContactPerson = txtContactPerson.Text.Trim();

            if (hdnClientId.Value == string.Empty)
            {                 
                clientEntity.CreatedBy = (Guid)Master.LoggedUser.UserId.Value;
                currentclient.InsertClient(clientEntity);
                Master.ShowMessage(Diary.Common.Constant.Message_Success);
                this.ClearFormData();
            }
            else
            {
                clientEntity.UpdatedBy = Master.LoggedUser.UserId.Value;
                currentclient.UpdateClient(clientEntity);
                Master.ShowMessage(Diary.Common.Constant.Message_Success);
                this.ClearFormData();

            }     
        }

        private void DisplayRecord(Guid id)
        {
            DataSet ds = currentclient.SelectClientByClientId(id);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                txtName.Text = ds.Tables[0].Rows[0]["Name"] != null ? ds.Tables[0].Rows[0]["Name"].ToString() : string.Empty;
                txtAddressLine1.Text = ds.Tables[0].Rows[0]["AddressLine1"] != null ? ds.Tables[0].Rows[0]["AddressLine1"].ToString() : string.Empty;
                txtAddressLine2.Text = ds.Tables[0].Rows[0]["AddressLine2"] != null ? ds.Tables[0].Rows[0]["AddressLine2"].ToString() : string.Empty;
                txtAddressLine3.Text = ds.Tables[0].Rows[0]["AddressLine3"] != null ? ds.Tables[0].Rows[0]["AddressLine3"].ToString() : string.Empty;
                txtTelephone.Text = ds.Tables[0].Rows[0]["Telephone"] != null ? ds.Tables[0].Rows[0]["Telephone"].ToString() : string.Empty;
                txtFax.Text = ds.Tables[0].Rows[0]["Fax"] != null ? ds.Tables[0].Rows[0]["Fax"].ToString() : string.Empty;
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"] != null ? ds.Tables[0].Rows[0]["Email"].ToString() : string.Empty;
                txtContactPerson.Text = ds.Tables[0].Rows[0]["ContactPerson"] != null ? ds.Tables[0].Rows[0]["ContactPerson"].ToString() : string.Empty;
            }
        }

        private void ClearFormData()
        {
            txtName.Text = string.Empty;
            txtAddressLine1.Text = string.Empty;
            txtAddressLine2.Text = string.Empty;
            txtAddressLine3.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtEmail.Text = string.Empty;            
            txtContactPerson.Text = string.Empty;
            hdnClientId.Value = string.Empty;
            txtName.Focus();
        }

    }

}