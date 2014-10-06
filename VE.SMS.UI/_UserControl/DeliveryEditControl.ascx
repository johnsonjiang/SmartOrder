<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeliveryEditControl.ascx.cs" Inherits="VE.SMS.UI._UserControl.DeliveryEditControl" %>
<div class="generaldiv">
            <div>
                送货方式:
                <asp:DropDownList ID="ddlDeliveryType" runat="server" CssClass="dropdownlist">
                </asp:DropDownList>
                送货说明：
                <asp:TextBox ID="txtDeliveryIntro" runat="server" CssClass="text" Width="254px"></asp:TextBox>
            </div>
            <div>
                送货地址:
                <asp:RadioButton ID="rbSame" runat="server" Text="同上" GroupName="ins" 
                    AutoPostBack="True" oncheckedchanged="rbSame_CheckedChanged"/>
                <asp:RadioButton ID="rbOther" runat="server" Text="另选" GroupName="ins" 
                    AutoPostBack="True" oncheckedchanged="rbOther_CheckedChanged"/>
                <asp:TextBox ID="txtShippingToAddress" runat="server" CssClass="text" Style="width: 488px"></asp:TextBox>
            </div>
        </div>