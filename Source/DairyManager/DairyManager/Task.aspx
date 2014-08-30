<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task.aspx.cs" Inherits="DairyManager.Task" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div class="page-header">
            <h1>Task</h1>
        </div>

        <asp:HiddenField ID="hdnTaskId" runat="server" />
        <div class="form-group">
            <div>
                <span>Date</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxDateEdit ID="dtDate" runat="server" EditFormat="DateTime" EditFormatString="dd-MMM-yy HH:mm" UseMaskBehavior="True">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxDateEdit>
            </div>
        </div>

        <div class="form-group">
            <div>
                <span>Task Creator</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxComboBox ID="cmbTaskCreator" runat="server" ValueType="System.String" IncrementalFilteringMode="Contains">
                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </div>
        </div>

        <div class="form-group">
            <div>
                <span>Fee Earner</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxComboBox ID="cmbFeeEarner" runat="server" ValueType="System.String" IncrementalFilteringMode="Contains">
                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </div>
        </div>

        <div class="form-group">
            <div>
                <span>Case</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxComboBox ID="cmbCase" runat="server" ValueType="System.String" IncrementalFilteringMode="Contains">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </div>
        </div>
        <div class="form-group">
            <div>
                <span>Task Type</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxComboBox ID="cmbTaskType" runat="server" ValueType="System.String" IncrementalFilteringMode="Contains">
                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </div>
        </div>

        <div class="form-group">
            <div>
                <span>Task Description</span>
                <em>*</em>
            </div>
            <div class="input-group">
               <dx:ASPxTextBox ID="txtTaskDescription" runat="server" Width="170px" MaxLength="100">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </div>
        </div>

        <div class="form-group">
            <div>
                <span>Total number of hours remaining</span>
                <span></span>
            </div>
            <div class="input-group">
                <dx:ASPxSpinEdit ID="seRemaingHours" runat="server" Height="21px" Number="0">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxSpinEdit>
            </div>
        </div>
        <div class="form-group">
            <div>
                <span>Task start time</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxTimeEdit ID="teStartTime" runat="server" EditFormatString="HH:mm">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTimeEdit>
            </div>
        </div>
        <div class="form-group">
            <div>
                <span>Task end time</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxTimeEdit ID="teEndTime" runat="server" EditFormat="Custom" EditFormatString="HH:mm">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTimeEdit>
            </div>
        </div>
        <div class="form-group">
            <div>
                <span>Total number of hours</span>
                <span></span>
            </div>
            <div class="input-group">
                <dx:ASPxSpinEdit ID="seTotalHours" runat="server" Height="21px" Number="0">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxSpinEdit>
            </div>
        </div>
        <div class="clearfix form-actions">
            <div>
                <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vgSave"></dx:ASPxButton>
            </div>
              <div>
                <dx:ASPxButton ID="btnClear" runat="server" Text="Clear" CausesValidation="False" OnClick="btnClear_Click"></dx:ASPxButton>

            </div>
            <div>
                <dx:ASPxButton ID="btnSearch" runat="server" Text="Search" PostBackUrl="~/TaskSearch.aspx"></dx:ASPxButton>
            </div>


        </div>
    </div>
</asp:Content>





