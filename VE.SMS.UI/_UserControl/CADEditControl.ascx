<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CADEditControl.ascx.cs" Inherits="VE.SMS.UI._UserControl.CADEditControl" %>
<div class="generaldiv">
            <asp:CheckBox ID="chkRefinement" runat="server" Text="提供CAD细化" 
                AutoPostBack="True" oncheckedchanged="chkRefinement_CheckedChanged" />
            <asp:Panel ID="pnlOA" runat="server">
            细化说明：
            <asp:TextBox ID="txtRefineIntro" runat="server" CssClass="text" Width="254px"></asp:TextBox>
            <asp:CheckBox ID="chkCADCustomerConfirm" runat="server" Text="需客户确认" />
            </asp:Panel>
        </div>