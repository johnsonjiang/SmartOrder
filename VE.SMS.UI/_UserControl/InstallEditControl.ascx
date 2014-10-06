<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstallEditControl.ascx.cs" Inherits="VE.SMS.UI._UserControl.InstallEditControl" %>
<div class="generaldiv">
            <div>
                <asp:CheckBox ID="chkInstall" runat="server" Text="提供安装" AutoPostBack="True" 
                    oncheckedchanged="chkInstall_CheckedChanged" />
                    <asp:Panel ID="pnlOA" runat="server">
                安装类型：
                <asp:DropDownList ID="ddlInstallType" runat="server" CssClass="dropdownlist">
                </asp:DropDownList>
                </asp:Panel>
            </div>
            <div id="pnlOB" runat="server">
                安装说明：
                <asp:TextBox ID="txtInstallIntro" runat="server" CssClass="text" Width="335px"></asp:TextBox>
            </div>
        </div>