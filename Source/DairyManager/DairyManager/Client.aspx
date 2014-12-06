﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="DairyManager.Client" MasterPageFile="~/Site.Master" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div class="page-header">
            <h1>Client</h1>
        </div>
        <asp:HiddenField ID="hdnClientId" runat="server" />

        <div class="form-group">
            <div>
                <span>Initials</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtInitials" runat="server" Width="170px" MaxLength="10">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
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
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </div>
        </div>



        <div class="form-group">
            <div>
                <span>Middle Name</span>
               <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtMiddleName" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
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
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </div>
        </div>

         <div class="form-group">
            <div>
                <span>DOB</span>              
            </div>
            <div class="input-group">
                <dx:ASPxDateEdit ID="dtDOB" runat="server" EditFormat="Custom" 
                    EditFormatString="dd-MMM-yy">
                </dx:ASPxDateEdit>
            </div>
        </div>

        <div class="form-group">
            <div>
                <span>Address Line 1</span>
              
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtAddressLine1" runat="server" Width="170px" 
                    MaxLength="100">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" />
                    </ValidationSettings>
                </dx:ASPxTextBox>

            </div>
        </div>

        <div class="form-group">
            <div>
                <span>Address Line 2</span>
                
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtAddressLine2" runat="server" Width="170px" 
                    MaxLength="100">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" 
                        ValidationGroup="vgSave">
                        <RequiredField ErrorText="Require" />
                    </ValidationSettings>
                </dx:ASPxTextBox>

            </div>
        </div>

        <div class="form-group">
            <div>
                <span>Address Line 3</span>
               
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtAddressLine3" runat="server" Width="170px" 
                    MaxLength="100">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" 
                        ValidationGroup="vgSave">
                        <RequiredField ErrorText="Require" />
                    </ValidationSettings>
                </dx:ASPxTextBox>

            </div>
        </div>


        <div class="form-group">
            <div>
                <span>Telephone</span>
               
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtTelephone" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" />
                    </ValidationSettings>
                </dx:ASPxTextBox>

            </div>
        </div>


        <div class="form-group">
            <div>
                <span>Fax</span>
                <span></span>
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtFax" runat="server" Width="170px" MaxLength="50"></dx:ASPxTextBox>

            </div>
        </div>


        <div class="form-group">
            <div>
                <span>Email</span>
                <span></span>
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtEmail" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                        <RegularExpression ErrorText="Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                    </ValidationSettings>
                </dx:ASPxTextBox>

            </div>
        </div>

        <div class="form-group">
            <div>
                <span>Contact Person</span>
                <span></span>
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtContactPerson" runat="server" Width="170px" 
                    MaxLength="50"></dx:ASPxTextBox>

            </div>
        </div>

        <div class="clearfix form-actions">
            <div>
                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vgSave"></dx:ASPxButton>

            </div>
              <div>
                <dx:ASPxButton ID="btnClear" runat="server" Text="Clear" CausesValidation="False" OnClick="btnClear_Click">
                    <ClientSideEvents Click="function(s, e) {
	e.processOnServer = confirm('Do you wish to clear the form?');
}" />
                  </dx:ASPxButton>

            </div>
            <div>
                <dx:ASPxButton ID="btnSearch" runat="server" Text="Search" PostBackUrl="~/ClientSearch.aspx" CausesValidation="False"></dx:ASPxButton>
            </div>


        </div>
    </div>
</asp:Content>

