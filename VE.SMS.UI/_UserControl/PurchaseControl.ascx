<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PurchaseControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.PurchaseControl" %>
<div>
    <asp:Button ID="btnCreatePurchase" runat="server" Text="创建采购单" CssClass="button"
        OnClick="btnCreatePurchase_Click" />
</div>
<div class="generaldiv">
    <asp:Repeater ID="rpPurchase" runat="server">
        <HeaderTemplate>
            <table class="listtable">
                <tbody>
                    <tr class="gridheader">
                        <td>
                            采购单
                        </td>
                        <td>
                            状态
                        </td>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="gridrow">
                <td>
                    <a href='PurchaseForm.aspx?poid=<%#Eval("Purchase_Id") %>&pono=<%#Eval("Purchase_No") %>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%#Eval("SourceNo") %>'>
                        <%#Eval("Purchase_No") %></a>
                </td>
                <td>
                    <%#Eval("Status") %>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="gridrowalt">
                <td>
                    <a href='PurchaseForm.aspx?poid=<%#Eval("Purchase_Id") %>&pono=<%#Eval("Purchase_No") %>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%#Eval("SourceNo") %>'>
                       <%#Eval("Purchase_No") %></a>
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
