<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuotationControl.ascx.cs" Inherits="VE.SMS.UI._UserControl.QuotationControl" %>

<div>
    <asp:Button ID="btnCreateQuotation" runat="server" Text="创建报价单" 
        CssClass="button" onclick="btnCreateQuotation_Click" />
</div>

<div style="padding-top:10px">
    <asp:Repeater ID="rpQuotation" runat="server">
        <HeaderTemplate>
                    <table class="listtable">
                <tbody>
                <tr class="gridheader">
            <td>历史报价单</td>
            <td>状态</td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr class="gridrow">
            <td><a href="QuotationForm.aspx?quoid=<%#Eval("Quotation_Id")%>&quono=<%#Eval("Quotation_No") %>&sourcetype=<%=SourceType %>&sourceno=<%=SourceNo %>"><%#Eval("Quotation_No")%></a></td>
            <td><%#Eval("Status") %></td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
        <tr class="gridrowalt">
            <td><a href="QuotationForm.aspx?quoid=<%#Eval("Quotation_Id")%>&quono=<%#Eval("Quotation_No") %>"><%#Eval("Quotation_No")%></a></td>
            <td><%#Eval("Status") %></td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
</div>