<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SurveyControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.SurveyControl" %>
<div class="generatediv" runat="server" id="divOperate">
    <asp:Button ID="btnCreateSurvey" runat="server" Text="创建测量单" CssClass="button" OnClick="btnCreateSurvey_Click" />
</div>
<div class="generaldiv">
    <asp:Repeater ID="rpSurveyList" runat="server" 
        onitemdatabound="rpSurveyList_ItemDataBound">
        <HeaderTemplate>
            <table class="listtable">
                <tbody>
                    <tr class="gridheader">
                        <td>
                            历史测量单
                        </td>
                        <td>
                            状态
                        </td>
                        <td>
                            最新测量文件
                        </td>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="gridrow">
                <td>
                    <a href='SurveyForm.aspx?svid=<%#Eval("Survey_Id") %>&svno=<%#Eval("Survey_No") %>&sourceno=<%#Eval("SourceNo") %>&sourcetype=<%#Eval("SourceType") %>'>
                        <%# Eval("Survey_No") %></a>
                </td>
                <td>
                    <%# Eval("Status")%>
                </td>
                <td>
                    <asp:HyperLink ID="lnkLatestFile" runat="server"></asp:HyperLink>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="gridrowalt">
                <td>
                    <a href='SurveyForm.aspx?svid=<%#Eval("Survey_Id") %>&svno=<%#Eval("Survey_No") %>&sourceno=<%#Eval("SourceNo") %>&sourcetype=<%#Eval("SourceType") %>'>
                        <%# Eval("Survey_No") %></a>
                </td>
                <td>
                    <%# Eval("Status")%>
                </td>
                <td>
                    <asp:HyperLink ID="lnkLatestFile" runat="server"></asp:HyperLink>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
</div>
