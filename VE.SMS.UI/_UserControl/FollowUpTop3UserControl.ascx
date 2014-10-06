<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FollowUpTop3UserControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.FollowUpTop3UserControl" %>
<asp:Repeater ID="rpFollowUp" runat="server">
    <HeaderTemplate>
        <ol style="text-align:left">
    </HeaderTemplate>
    <ItemTemplate>
        <li class="list"><%#Convert.ToDateTime(Eval("FollowUp_Date")).ToString("yyyy-MM-dd") %> <%#Eval("FollowUp_Man") %> <%#Eval("FollowUp_Notes") %></li>
    </ItemTemplate>
    <FooterTemplate>
        </ol>
    </FooterTemplate>
</asp:Repeater>
