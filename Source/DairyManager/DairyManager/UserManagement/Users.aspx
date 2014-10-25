﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="DairyManager.UserManagement.Users" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>

        <div class="page-header">
            <h1>Add User</h1>
            <asp:HiddenField ID="hdnUserId" runat="server" />
        </div>

        <div class="form-group">
            <div>
                <span>Code</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtUserName" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                        <RequiredField IsRequired="True" ErrorText="Required" />
                        <RegularExpression ErrorText="" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </div>
        </div>


        <div class="form-group">
            <div>
                <span>Password</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtPassword" runat="server" Password="True" Width="170px" MaxLength="50"
                    EnableClientSideAPI="True" OnCustomJSProperties="txtPassword_CustomJSProperties"
                    ClientInstanceName="password1">
                    <ClientSideEvents Init="function(s, e) {
	 s.SetValue(s.cp_myPassword);
}" />
                    <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                        <RequiredField IsRequired="True" ErrorText="Required" />
                        <RegularExpression ErrorText="Password requires more than 6 characters including at least 1 upper or lower character, and 1 digit" ValidationExpression="^(?=.*\d)(?=.*[a-zA-Z])(?!.*[\W_\x7B-\xFF]).{6,50}$" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </div>
        </div>


         <div class="form-group">
            <div>
                <span>Confirm Password</span>
                <em>*</em>
            </div>
            <div class="input-group">
                  <dx:ASPxTextBox ID="txtConfirmPassword" runat="server" Password="True" Width="170px"
                    MaxLength="50" OnCustomJSProperties="txtConfirmPassword_CustomJSProperties" ClientInstanceName="password2">
                    <ClientSideEvents Init="function(s, e) {
	s.SetValue(s.cp_myPassword);
}"
                        LostFocus="function(s, e) {
	

 
}"
                        Validation="function(s, e) {
	var originalPasswd = password1.GetText();
    var currentPasswd = s.GetText();
    e.isValid = (originalPasswd  == currentPasswd );
}" />
                    <ValidationSettings ValidationGroup="vgSave" CausesValidation="True" Display="Dynamic"
                        EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" ErrorText="Password must match">
                        <RequiredField IsRequired="True" ErrorText="Required" />
                        <RegularExpression ErrorText="Password must be 6 charactors" ValidationExpression="^[a-zA-Z0-9~!@#$%^&*]{6,20}$" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </div>
        </div>


        <div class="form-group">
            <div>
                <span>First Name</span>
                <em>*</em>
            </div>
            <div class="input-group">
             <dx:ASPxTextBox ID="txtFirstName" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                        <RequiredField IsRequired="True" ErrorText="Required" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </div>
        </div>

         <div class="form-group">
            <div>
                <span>Last Name</span>
                <em>*</em>
            </div>
            <div class="input-group">
            <dx:ASPxTextBox ID="txtLastName" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                        <RequiredField IsRequired="True" ErrorText="Required" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </div>
        </div>

         <div class="form-group">
            <div>
                <span>Job Title</span>
                <em>*</em>
            </div>
            <div class="input-group">
               <dx:ASPxComboBox ID="ddlJob" runat="server" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith"
                    TextFormatString="{0}" ValueType="System.Int32">
                    <Columns>
                        <dx:ListBoxColumn Caption="JobName" FieldName="JobName" />
                    </Columns>
                    <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                        <RequiredField IsRequired="True" ErrorText="Required" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </div>
        </div>

           <div class="form-group">
            <div>
                <span>Location</span>
                <em>*</em>
            </div>
            <div class="input-group">
               <dx:ASPxComboBox ID="ddlLocation" runat="server" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith"
                    TextFormatString="{0}" ValueType="System.Int32">
                    <Columns>
                        <dx:ListBoxColumn Caption="LocationName" FieldName="LocationName" />
                    </Columns>
                    <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                        <RequiredField IsRequired="True" ErrorText="Required" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </div>
        </div>


            <div class="form-group">
            <div>
                <span>Grade</span>
                <em>*</em>
            </div>
            <div class="input-group">
               <dx:ASPxComboBox ID="ddlGrade" runat="server" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith"
                    TextFormatString="{0}" ValueType="System.Int32">
                    <Columns>
                        <dx:ListBoxColumn Caption="GradeName" FieldName="GradeName" />
                    </Columns>
                    <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                        <RequiredField IsRequired="True" ErrorText="Required" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </div>
        </div>

            <div class="form-group">
            <div>
                <span>Email</span>
                <em>*</em>
            </div>
            <div class="input-group">
           <dx:ASPxTextBox ID="txtEmail" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                        <RegularExpression ErrorText="Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                        <RequiredField IsRequired="True" ErrorText="Required" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </div>
        </div>


          <div class="form-group">
            <div>
                <span>Contact</span>
                <em>*</em>
            </div>
            <div class="input-group">
            <dx:ASPxTextBox ID="txtContact" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                        <RequiredField IsRequired="True" ErrorText="Required" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </div>
        </div>

         <div class="form-group">
            <div>
                <span>User Type</span>
                <em>*</em>
            </div>
            <div class="input-group">
             <dx:ASPxComboBox ID="ddlRoles" runat="server" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith"
                    TextFormatString="{0}" ValueType="System.Guid">
                    <Columns>
                        <dx:ListBoxColumn Caption="RoleName" FieldName="RoleName" />
                        <dx:ListBoxColumn Caption="RoleDescription" FieldName="RoleDescription" />
                    </Columns>
                    <ValidationSettings ValidationGroup="vgSave" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                        <RequiredField IsRequired="True" ErrorText="Required" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </div>
        </div>

        <div class="clearfix form-actions">
            <div>
                  <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vgSave"></dx:ASPxButton>
            </div>
        </div>

    </div>


</asp:Content>



