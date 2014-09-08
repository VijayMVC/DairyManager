<%@ Control Language="C#" AutoEventWireup="true" Inherits="SelectionToolTip" Codebehind="SelectionToolTip.ascx.cs" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<div runat="server" id="buttonDiv">
    <dxe:ASPxButton ID="btnShowMenu" runat="server" AutoPostBack="False" AllowFocus="False">
        <Border BorderWidth="0px" />
        <Paddings Padding="0px" />
        <FocusRectPaddings Padding="4px" />
        <FocusRectBorder BorderStyle="None" BorderWidth="0px" />
    </dxe:ASPxButton>
</div>