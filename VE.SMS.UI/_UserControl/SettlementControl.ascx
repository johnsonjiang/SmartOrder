<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettlementControl.ascx.cs" Inherits="VE.SMS.UI._UserControl.SettlementControl" %>

<div>
    <asp:Button ID="btnSettlement" runat="server" Text="创建结算单" CssClass="button" 
        onclick="btnSettlement_Click" />
    <asp:Button ID="btnView" runat="server" Text="查看结算单汇总" CssClass="button" OnClientClick="javascript:window.open('printout/settlementsprintout.aspx');" />
</div>
<div class="generaldiv">
    <asp:Repeater ID="rpItems" runat="server" 
        onitemdatabound="rpItems_ItemDataBound">
        <HeaderTemplate>
                    <table class="listtable">
                <tbody>
                <tr class="gridheader">
            <td>结算单</td>
            <td>日期</td>
            <td>结算人员</td>
            <td>相关送货单号</td>
            <td>本单金额</td>
            <td>首次应收</td>
            <td>已收</td>
            <td>余额</td>
            <td>状态</td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr class="gridrow">
            <td><a href='SettlementForm.aspx?stid=<%# Eval("St_Id")%>&stno=<%# Eval("St_No")%>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%# Eval("SourceNo")%>'><%#Eval("St_No") %></a></td>
            <td><%#Convert.ToDateTime(Eval("CreatedDate")).ToString("yyyy-MM-dd") %></td>
            <td><%#Eval("StMan") %></td>
            <td><%#Eval("DeliveryList") %></td>
            <td><%#Eval("TotalAmount") %></td>
            <td><%#Eval("FirstAmount") %></td>
            <td><%#Eval("AmountReceived")%></td>
            <td><%# Convert.ToDouble(Eval("TotalAmount")) - Convert.ToDouble(Eval("AmountReceived"))%></td>
            <td><%# Eval("Status")%></td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
        <tr class="gridrowalt">
           <td><a href='SettlementForm.aspx?stid=<%# Eval("St_Id")%>&stno=<%# Eval("St_No")%>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%# Eval("SourceNo")%>'><%#Eval("St_No") %></a></td>
            <td><%#Convert.ToDateTime(Eval("CreatedDate")).ToString("yyyy-MM-dd") %></td>
            <td><%#Eval("StMan") %></td>
            <td><%#Eval("DeliveryList") %></td>
            <td><%#Eval("TotalAmount") %></td>
            <td><%#Eval("FirstAmount") %></td>
            <td><%#Eval("AmountReceived")%></td>
            <td><%# Convert.ToDouble(Eval("TotalAmount")) - Convert.ToDouble(Eval("AmountReceived"))%></td>
            <td><%#Eval("Status")%></td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            <tr>
                <td colspan="9" align="right" style="font-weight:bolder">
                    总计金额：<asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                    首次应收金额：<asp:Label ID="lblFirstAmount" runat="server"></asp:Label>
                    已收金额：<asp:Label ID="lblReceivedAmount" runat="server"></asp:Label>
                    余额：<asp:Label ID="lblEnd" runat="server"></asp:Label>
                </td>
            </tr>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
</div>
