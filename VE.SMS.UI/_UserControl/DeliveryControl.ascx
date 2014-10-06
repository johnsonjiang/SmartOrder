<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeliveryControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.DeliveryControl" %>
<div>
    <asp:Button ID="btnCreateDelivery" runat="server" Text="创建送货安装单" CssClass="button"
        OnClick="btnCreateDelivery_Click" />
</div>
<div class="generaldiv">
    <asp:Repeater ID="rpDelivery" runat="server">
        <HeaderTemplate>
            <table class="listtable">
                <tbody>
                    <tr class="gridheader">
                        <td>
                            送货安装单
                        </td>
                        <td>
                            状态
                        </td>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="gridrow">
                <td>
                    <a href='DeliveryForm.aspx?dlid=<%#Eval("Delivery_Id") %>&dlno=<%#Eval("Delivery_No") %>&sourceno=<%#Eval("Order_No") %>&sourcetype=O'>
                        <%#Eval("Delivery_No") %></a>
                </td>
                <td>
                    <%#Eval("Status") %>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="gridrowalt">
                <td>
                    <a href='DeliveryForm.aspx?dlid=<%#Eval("Delivery_Id") %>&dlno=<%#Eval("Delivery_No") %>&sourceno=<%#Eval("Order_No") %>&sourcetype=O'>
                        <%#Eval("Delivery_No") %></a>
                </td>
                <td>
                    <%#Eval("Status") %>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
</div>
