<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task.aspx.cs" Inherits="DairyManager.Task" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Task</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Task</h2>
            <div>
                <div>
                    <span>Date</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxDateEdit ID="dtDate" runat="server"></dx:ASPxDateEdit>
                </div>
            </div>
            <div>
                <div>
                    <span>Case</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxComboBox ID="cmbCase" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                </div>
            </div>
            <div>
                <div>
                    <span>Case Type</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxComboBox ID="cmbCaseType" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                </div>
            </div>
            <div>
                <div>
                    <span>Total number of hours remaining</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxSpinEdit ID="seRemaingHours" runat="server" Height="21px" Number="0">
                    </dx:ASPxSpinEdit>
                </div>
            </div>
            <div>
                <div>
                    <span>Task start time</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxTimeEdit ID="teStartTime" runat="server"></dx:ASPxTimeEdit>
                </div>
            </div>
            <div>
                <div>
                    <span>Task end time</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxTimeEdit ID="teEndTime" runat="server"></dx:ASPxTimeEdit>
                </div>
            </div>
            <div>
                <div>
                    <span>Total number of hours</span>
                    <span>*</span>
                </div>
                <div>
                    <dx:ASPxSpinEdit ID="seTotalHours" runat="server" Height="21px" Number="0">
                    </dx:ASPxSpinEdit>
                </div>
            </div>
            <div>
                <div>
                    <dx:ASPxButton ID="btnSave" runat="server" Text="Save"></dx:ASPxButton>
                </div>
                <div>
                    <dx:ASPxButton ID="btnCancel" runat="server" Text="Cancel"></dx:ASPxButton>
                </div>


            </div>
        </div>
    </form>
</body>
</html>
