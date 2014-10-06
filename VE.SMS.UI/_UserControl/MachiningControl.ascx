<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MachiningControl.ascx.cs" Inherits="VE.SMS.UI._UserControl.MachiningControl" %>

<div>
    <asp:Button ID="btnCreateMachining" runat="server" Text="创建生产单" 
        CssClass="button" onclick="btnCreateMachining_Click" />
</div>
<div class="generaldiv">
    <asp:Repeater ID="rpMachining" runat="server">
        <HeaderTemplate>
                    <table class="listtable">
                <tbody>
                <tr class="gridheader">
            <td>生产单</td>
            <td>状态</td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr class="gridrow">
            <td><a href='MachiningForm.aspx?machid=<%#Eval("Mach_Id") %>&machno=<%#Eval("Mach_No") %>&sourceno=<%#Eval("SourceNo") %>&sourcetype=<%#Eval("SourceType") %>'><%# Eval("Mach_No") %></a></td>
            <td><%#Eval("Status") %></td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
        <tr class="gridrowalt">
            <td><a href='MachiningForm.aspx?machid=<%#Eval("Mach_Id") %>&machno=<%#Eval("Mach_No") %>&sourceno=<%#Eval("SourceNo") %>&sourcetype=<%#Eval("SourceType") %>'><%# Eval("Mach_No") %></a></td>
            <td><%#Eval("Status") %></td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
</div>
