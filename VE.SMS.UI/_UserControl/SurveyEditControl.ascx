<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SurveyEditControl.ascx.cs" Inherits="VE.SMS.UI._UserControl.SurveyEditControl" %>
        <div class="generaldiv">
            <asp:CheckBox ID="chkSurveyOnsite" runat="server" Text="上门测量" 
                AutoPostBack="True" oncheckedchanged="chkSurveyOnsite_CheckedChanged" />
            <asp:Panel ID="pnlOA" runat="server">
            <asp:DropDownList ID="ddlSurveyType" runat="server" CssClass="dropdownlist">
            </asp:DropDownList>
            测量说明：
            <asp:TextBox ID="txtSurveyIntro" runat="server" CssClass="text" Width="254px"></asp:TextBox>
            </asp:Panel>
        </div>