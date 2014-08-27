﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using Diary.Entity;
using bll = Diary.BLL;
using com = Diary.Common;

namespace DairyManager
{
    public partial class Case : System.Web.UI.Page
    {
        CaseEntity caseEntity = new CaseEntity();
        bll.Client currentClient = new bll.Client();
        bll.Case currentCase = new bll.Case();

        DataSet dsData = new DataSet();
        DataSet dsclients= new DataSet();



        protected void Page_Init(object sender, EventArgs e)
        {
            this.LoadClients();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            this.LoadCaseType();
            this.LoadCourt();
            this.LoadOffence();

            if (!IsPostBack)
            {
                hdnCaseId.Value = Master.GetQueryStringValueByKey(Request, com.Enum.QueryStringParameters.CaseId.ToString());

                if (hdnCaseId.Value != string.Empty)
                {
                    this.DisplayRecord(new Guid(hdnCaseId.Value));
                }
            }
            this.AuthoriseUser();
        }

        private void AuthoriseUser()
        {
            btnSave.Visible = (Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_Case_Add)
                || Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_Case_Edit));

            if (!Master.LoggedUser.IsUserAuthorised(com.Enum.Rights.Case_Case_View))
            {
                Response.Redirect(com.Constant.URL_UNAUTHORISEDACTION, false);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            caseEntity.Code = txtCode.Text.Trim();
            caseEntity.Case = txtCase.Text.Trim();
            caseEntity.ClientId = new Guid(cmbClient.Value.ToString());
            caseEntity.CaseTypeId = new Guid(cmbCaseType.Value.ToString());
            caseEntity.OffenceTypeId = new Guid(cmbOffence.Value.ToString());
            caseEntity.CourtId = new Guid(cmbCourt.Value.ToString());
            caseEntity.Email = txtEmail.Text.Trim();
            caseEntity.Contact = txtContact.Text.Trim();

            caseEntity.CreatedBy = Master.LoggedUser.UserId.Value;
            caseEntity.UpdatedBy = Master.LoggedUser.UserId.Value;

            bll.Case caseBll = new bll.Case();

            if (hdnCaseId.Value == string.Empty)
            {
                if (!caseBll.IsCaseExists(caseEntity.Code))
                {
                    caseBll.InsertCase(caseEntity);
                    Master.ShowMessage(Diary.Common.Constant.Message_Success);
                    this.ClearFormFields();
                }
                else
                {
                    Master.ShowMessage(Diary.Common.Constant.Message_AlreadyExists);    
                }                

            }
            else
            {
                caseEntity.CaseId = new Guid(hdnCaseId.Value);
                caseBll.UpdateCase(caseEntity);
                Master.ShowMessage(Diary.Common.Constant.Message_Success);
                this.ClearFormFields();

            }

        }

        //private void LoadClient()
        //{
        //    cmbClient.DataSource = currentClient.SelectClientAll().Tables[0];
        //    cmbClient.TextField = "Name";
        //    cmbClient.ValueField = "ClientId";
        //    cmbClient.DataBind();

        //}

        private void LoadCaseType()
        {
            cmbCaseType.DataSource = currentCase.SelectAllCaseType().Tables[0];
            cmbCaseType.TextField = "CaseDescription";
            cmbCaseType.ValueField = "CaseTypeId";
            cmbCaseType.DataBind();
        }

        private void LoadCourt()
        {
            cmbCourt.DataSource = currentCase.SelectAllCourt().Tables[0];
            cmbCourt.TextField = "Court";
            cmbCourt.ValueField = "CourtId";
            cmbCourt.DataBind();
        }

        private void LoadOffence()
        {
            cmbOffence.DataSource = currentCase.SelectAllOffence().Tables[0];
            cmbOffence.TextField = "Offence";
            cmbOffence.ValueField = "OffenceTypeId";
            cmbOffence.DataBind();
        }

        protected void LoadClients()
        {
            try
            {

                //cmbClient.DataSource = currentClient.SelectClientAll().Tables[0];
                //cmbClient.TextField = "Name";
                //cmbClient.ValueField = "ClientId";
                //cmbClient.DataBind();

                dsclients = currentClient.SelectClientAll();
                dsclients.Tables[0].TableName = "clients";
                ((GridViewDataComboBoxColumn)gvClients.Columns["ClientId"]).PropertiesComboBox.DataSource = dsclients.Tables[0];

            }
            catch (System.Exception)
            {


            }
        }

        private void ClearFormFields()
        {
            txtCode.Text = string.Empty;
            txtCase.Text = string.Empty;
            cmbClient.SelectedIndex = -1;
            cmbCaseType.SelectedIndex = -1;
            cmbOffence.SelectedIndex = -1;
            cmbCourt.SelectedIndex = -1;
            txtEmail.Text = string.Empty;
            txtContact.Text = string.Empty;
            hdnCaseId.Value = string.Empty;
            txtCode.Focus();

        }

        private void DisplayRecord(Guid id)
        {
            DataSet ds = currentCase.SelectCaseByCaseId(id);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                txtCode.Text = ds.Tables[0].Rows[0]["Code"] != null ? ds.Tables[0].Rows[0]["Code"].ToString() : string.Empty;
                txtCase.Text = ds.Tables[0].Rows[0]["Case"] != null ? ds.Tables[0].Rows[0]["Case"].ToString() : string.Empty;
                cmbClient.Value = ds.Tables[0].Rows[0]["ClientId"] != null ? ds.Tables[0].Rows[0]["ClientId"].ToString() : string.Empty;
                cmbOffence.Value = ds.Tables[0].Rows[0]["OffenceTypeId"] != null ? ds.Tables[0].Rows[0]["OffenceTypeId"].ToString() : string.Empty;
                cmbCourt.Value = ds.Tables[0].Rows[0]["CourtId"] != null ? ds.Tables[0].Rows[0]["CourtId"].ToString() : string.Empty;
                cmbCaseType.Value = ds.Tables[0].Rows[0]["CaseTypeId"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"] != null ? ds.Tables[0].Rows[0]["Email"].ToString() : string.Empty;
                txtContact.Text = ds.Tables[0].Rows[0]["Contact"] != null ? ds.Tables[0].Rows[0]["Contact"].ToString() : string.Empty;

            }
        }

        protected void gvClients_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            dsData = Session["ClientData"] as DataSet;
            ASPxGridView gridView = sender as ASPxGridView;
            DataRow row = dsData.Tables[0].NewRow();
            Random rd = new Random();
            e.NewValues["ClientId"] = rd.Next();            
            //e.NewValues["CreatedUser"] = SessionHandler.LoggedUser.UsersId;

            IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString() != "Count")
                {
                    row[enumerator.Key.ToString()] = enumerator.Value == null ? DBNull.Value : enumerator.Value;
                }
            }
            gridView.CancelEdit();
            e.Cancel = true;

            dsData.Tables[0].Rows.Add(row);

           
        }

        protected void gvClients_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int i = gvClients.FindVisibleIndexByKeyValue(e.Keys[gvClients.KeyFieldName]);
            e.Cancel = true;
            dsData = Session["ClientData"] as DataSet;
            //dsData.Tables[0].Rows.Remove(dsData.Tables[0].Rows.Find(e.Keys[gvData.KeyFieldName]));

            dsData.Tables[0].DefaultView.Delete(dsData.Tables[0].Rows.IndexOf(dsData.Tables[0].Rows.Find(e.Keys[gvClients.KeyFieldName])));


            //if (additionalService.Save(dsData))
            //{
            //    this.LoadAdditionalService();
            //}
        }

        protected void gvClients_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName != "ClientId" ) return;

            ASPxComboBox combo = e.Editor as ASPxComboBox;
            combo.DataBindItems();
        }

    }
}