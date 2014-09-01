<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Case.aspx.cs" Inherits="DairyManager.Case" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div class="page-header">
            <h1>Case</h1>
        </div>
        <asp:HiddenField ID="hdnCaseId" runat="server" />
        <div class="form-group">
            <div>
                <span>UFN</span>
                <em>*</em>

            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtCode" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </div>
        </div>
        <div class="form-group" style="display: none">
            <div>
                <span>Case</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtCase" runat="server" Width="170px" MaxLength="50">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </div>
        </div>
        <div class="form-group">
            <div>
                <span>Court</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxComboBox ID="cmbCourt" runat="server" ValueType="System.String" IncrementalFilteringMode="Contains">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </div>
        </div>
        <div class="form-group">
            <div>
                <span>Offence</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxComboBox ID="cmbOffence" runat="server" ValueType="System.String" IncrementalFilteringMode="Contains">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </div>
        </div>
        <div class="form-group">
            <div>
                <span>Client</span>
                <em>*</em>
            </div>
            <div class="input-group">

                <dx:ASPxGridView ID="gvClients" runat="server" AutoGenerateColumns="False" OnCellEditorInitialize="gvClients_CellEditorInitialize" OnRowDeleting="gvClients_RowDeleting" OnRowInserting="gvClients_RowInserting" OnRowUpdating="gvClients_RowUpdating" KeyFieldName="CaseDescriptionId">
                    <Columns>
                        <dx:GridViewCommandColumn VisibleIndex="0" ButtonType="Image">
                            <NewButton Visible="True">
                                <Image Url="~/Images/new.png">
                                </Image>
                            </NewButton>
                            <DeleteButton Visible="True">
                                <Image Url="~/Images/delete.png">
                                </Image>
                            </DeleteButton>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Clients" FieldName="ClientId"
                            VisibleIndex="3">
                            <PropertiesComboBox TextField="Name" ValueField="ClientId"
                                ValueType="System.Guid">
                                <ValidationSettings>
                                    <RequiredField ErrorText="Required" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                    </Columns>
                    <SettingsBehavior ConfirmDelete="True" />
                </dx:ASPxGridView>
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <dx:GridViewCommandColumn VisibleIndex="0">
                            <NewButton Visible="True">
                            </NewButton>
                            <DeleteButton Visible="True">
                            </DeleteButton>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Client" VisibleIndex="1">
                        </dx:GridViewDataComboBoxColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
        <div class="form-group">
            <div>
                <span>Case Type</span>
                <em>*</em>
            </div>
            <div class="input-group">
                <dx:ASPxComboBox ID="cmbCaseType" runat="server" ValueType="System.String" IncrementalFilteringMode="Contains">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="vgSave">
                        <RequiredField ErrorText="Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxComboBox>
            </div>
        </div>
        <div class="form-group" style="display: none">
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
        <div class="form-group" style="display: none">
            <div>
                <span>Contact</span>
                <span></span>
            </div>
            <div class="input-group">
                <dx:ASPxTextBox ID="txtContact" runat="server" Width="170px" MaxLength="50"></dx:ASPxTextBox>
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
                <dx:ASPxButton ID="btnSearch" runat="server" Text="Search" PostBackUrl="~/CaseSearch.aspx" CausesValidation="False"></dx:ASPxButton>
            </div>


        </div>
    </div>
</asp:Content>
