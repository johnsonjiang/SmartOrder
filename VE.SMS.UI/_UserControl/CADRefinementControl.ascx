<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CADRefinementControl.ascx.cs" Inherits="VE.SMS.UI._UserControl.CADRefinementControl" %>

<div>
    <asp:Button ID="btnCreateCADRefinement" runat="server" Text="创建细化单" 
        CssClass="button" onclick="btnCreateCADRefinement_Click" />
</div>
<div class="generaldiv">
    <asp:Repeater ID="rpRefinement" runat="server" 
        onitemdatabound="rpRefinement_ItemDataBound">
        <HeaderTemplate>
                    <table class="listtable">
                <tbody>
                <tr class="gridheader">
            <td>历史细化单</td>
            <td>状态</td>
            <td>最新细化文件</td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr class="gridrow">
            <td><a href="RefineForm.aspx?refid=<%#Eval("Refine_Id")%>&refno=<%#Eval("Refine_No") %>&sourcetype=<%=SourceType %>&sourceno=<%=SourceNo %>"><%#Eval("Refine_No")%></a></td>
            <td><%#Eval("Status") %></td>
            <td><asp:HyperLink ID="lnkLatestFile" runat="server"></asp:HyperLink></td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
        <tr class="gridrowalt">
            <td><a href="RefineForm.aspx?refid=<%#Eval("Refine_Id")%>&refno=<%#Eval("Refine_No") %>&sourcetype=<%=SourceType %>&sourceno=<%=SourceNo %>"><%#Eval("Refine_No")%></a></td>
            <td><%#Eval("Status") %></td>
            <td><asp:HyperLink ID="lnkLatestFile" runat="server"></asp:HyperLink></td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
</div>
