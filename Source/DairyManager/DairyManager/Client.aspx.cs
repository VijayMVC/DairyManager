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
                hdnClientId.Value = Master.GetQueryStringValueByKey(Request, com.Enum.QueryStringParameters.CaseId.ToString());

                if (hdnClientId.Value != string.Empty)
                {
                    this.DisplayRecord(new Guid(hdnClientId.Value));
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (hdnClientId.Value == string.Empty)
            {
                clientEntity.Name = txtName.Text.Trim();
                clientEntity.AddressLine1 = txtAddressLine1.Text.Trim();
                clientEntity.AddressLine2 = txtAddressLine2.Text.Trim();
                clientEntity.AddressLine3 = txtAddressLine3.Text.Trim();
                clientEntity.Telephone = txtTelephone.Text.Trim();
                clientEntity.Fax = txtFax.Text.Trim();
                clientEntity.Email = txtEmail.Text.Trim();
                clientEntity.ContactPerson = txtContactPerson.Text.Trim();    
                clientEntity.CreatedBy = (Guid)Master.LogedUser.ProviderUserKey;

                currentclient.InsertClient(clientEntity);
            }
            else
            {
                clientEntity.Name = txtName.Text.Trim();
                clientEntity.AddressLine1 = txtAddressLine1.Text.Trim();
                clientEntity.AddressLine2 = txtAddressLine2.Text.Trim();
                clientEntity.AddressLine3 = txtAddressLine3.Text.Trim();
                clientEntity.Telephone = txtTelephone.Text.Trim();
                clientEntity.Fax = txtFax.Text.Trim();
                clientEntity.Email = txtEmail.Text.Trim();
                clientEntity.ContactPerson = txtContactPerson.Text.Trim();
                clientEntity.UpdatedBy = (Guid)Master.LogedUser.ProviderUserKey;

                currentclient.UpdateClient(clientEntity);

            }     
        }

        private void DisplayRecord(Guid id)
        {
            DataSet ds = currentclient.SelectClientByClientId(id);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                txtName.Text = clientEntity.Name;
                txtAddressLine1.Text = clientEntity.AddressLine1;
                txtAddressLine2.Text = clientEntity.AddressLine2;
                txtAddressLine3.Text = clientEntity.AddressLine3;
                txtTelephone.Text = clientEntity.Telephone;
                txtFax.Text = clientEntity.Fax;
                txtEmail.Text = clientEntity.Email;
                txtContactPerson.Text = clientEntity.ContactPerson;    
            }
        }

    }

}