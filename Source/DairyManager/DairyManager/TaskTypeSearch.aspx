<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskTypeSearch.aspx.cs" Inherits="DairyManager.TaskTypeSearch" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Task Type Search</h1>
            <div>
                <dx:ASPxGridView ID="gvTaskTypeSearch" runat="server" AutoGenerateColumns="False" KeyFieldName="TaskTypeId">
                    <Columns>
                        <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Task Code">
                            <DataItemTemplate>
                                <a id="clickElement" target="_blank" href="/TaskType.aspx?TaskTypeId=<%# Container.KeyValue%>"><%#  Eval("TaskCode").ToString()%> </a>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Task Description" FieldName="TaskDescription" ShowInCustomizationForm="True">
                        </dx:GridViewDataTextColumn>

                    </Columns>
                    <Settings ShowFilterRow="True" />
                </dx:ASPxGridView>
            </div>

            <div>
                <dx:ASPxButton ID="btnBack" runat="server" Text="Back" PostBackUrl="~/TaskType.aspx"></dx:ASPxButton>
            </div>


        </div>
    </form>
</body>
</html>
