<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task.aspx.cs" Inherits="DairyManager.Task" MasterPageFile="~/Site.master" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master"%>
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
                    <span>*</span>
                </div>
                <div class="input-group">
                    <dx:ASPxDateEdit ID="dtDate" runat="server">
                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                            <RequiredField ErrorText="Required" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxDateEdit>
                </div>
            </div>
            <div class="form-group">
                <div>
                    <span>Case</span>
                    <span>*</span>
                </div>
                <div class="input-group">
                    <dx:ASPxComboBox ID="cmbCase" runat="server" ValueType="System.String">
                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                            <RequiredField ErrorText="Required" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                </div>
            </div>
            <div class="form-group">
                <div>
                    <span>Case Type</span>
                    <span>*</span>
                </div>
                <div class="input-group">
                    <dx:ASPxComboBox ID="cmbCaseType" runat="server" ValueType="System.String">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                            <RequiredField ErrorText="Required" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                </div>
            </div>
            <div class="form-group">
                <div>
                    <span>Total number of hours remaining</span>
                    <span>*</span>
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
                    <span>*</span>
                </div>
                <div class="input-group">
                    <dx:ASPxTimeEdit ID="teStartTime" runat="server">
                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                            <RequiredField ErrorText="Required" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTimeEdit>
                </div>
            </div>
            <div class="form-group">
                <div>
                    <span>Task end time</span>
                    <span>*</span>
                </div>
                <div class="input-group">
                    <dx:ASPxTimeEdit ID="teEndTime" runat="server">
                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                            <RequiredField ErrorText="Required" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTimeEdit>
                </div>
            </div>
            <div class="form-group">
                <div>
                    <span>Total number of hours</span>
                    <span>*</span>
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
                    <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vgSave" ></dx:ASPxButton>
                </div>
                <div>
                    <dx:ASPxButton ID="btnSearch" runat="server" Text="Search" PostBackUrl="~/TaskSearch.aspx"></dx:ASPxButton>
                </div>


            </div>
        </div>
</asp:Content>





