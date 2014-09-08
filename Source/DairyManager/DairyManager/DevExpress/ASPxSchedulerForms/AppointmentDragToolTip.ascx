<%@ Control Language="C#" AutoEventWireup="true" Inherits="AppointmentDragToolTip" Codebehind="AppointmentDragToolTip.ascx.cs" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

<div style="white-space:nowrap;">
    <dxe:ASPxLabel ID="lblInterval" runat="server" Text="CustomDragAppointmentTooltip" EnableClientSideAPI="true">
        </dxe:ASPxLabel>
    <br />
    <dxe:ASPxLabel ID="lblInfo" runat="server" EnableClientSideAPI="true"></dxe:ASPxLabel>
</div>

<script id="dxss_ASPxClientAppointmentDragTooltip" type="text/javascript"><!--
    ASPxClientAppointmentDragTooltip = _aspxCreateClass(ASPxClientToolTipBase, {
        CalculatePosition: function(bounds) {
            return new ASPxClientPoint(bounds.GetLeft(), bounds.GetTop() - bounds.GetHeight());
        },
        Update: function (toolTipData) {
            var stringInterval = this.GetToolTipContent(toolTipData);
            var oldText = this.controls.lblInterval.GetText();
            if (oldText != stringInterval)
                this.controls.lblInterval.SetText(stringInterval);
        },
        GetToolTipContent: function(toolTipData) {	
	        var interval = toolTipData.GetInterval();
	        return this.ConvertIntervalToString(interval);
        }
    });
//--></script>