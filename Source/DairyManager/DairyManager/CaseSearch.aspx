<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaseSearch.aspx.cs" Inherits="DairyManager.CaseSearch" %>

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
            <h1>Search Case</h1>
            <div>



                <dx:ASPxGridView ID="gvCaseSearch" runat="server" AutoGenerateColumns="False" KeyFieldName="CaseId">
                    <Columns>
                        <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Case Code">
                            <DataItemTemplate>
                                <a id="clickElement" target="_blank" href="/Case.aspx?CaseId=<%# Container.KeyValue%>"><%#  Eval("Code").ToString()%> </a>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Case" FieldName="Case" ShowInCustomizationForm="True">
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn VisibleIndex="3" Caption="Name" FieldName="Name" ShowInCustomizationForm="True">
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn VisibleIndex="4" Caption="CaseCode" FieldName="CaseCode" ShowInCustomizationForm="True">
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn VisibleIndex="5" Caption="Email" FieldName="Email" ShowInCustomizationForm="True">
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn VisibleIndex="6" Caption="Contact" FieldName="Contact" ShowInCustomizationForm="True">
                        </dx:GridViewDataTextColumn>

                    </Columns>
                    <Settings ShowFilterRow="True" />
                </dx:ASPxGridView>

            </div>
            <div>

                <dx:ASPxButton ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Case.aspx"></dx:ASPxButton>
            </div>

        </div>
    </form>
</body>
</html>
