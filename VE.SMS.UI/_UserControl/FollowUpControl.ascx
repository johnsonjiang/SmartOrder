<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FollowUpControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.FollowUpControl" %>
<div class="generaldiv">
<table class="listtable">
                <tbody>
                    <tr class="gridheader">
                        <td width="30%">
                            跟踪时间
                        </td>
                        <td width="30%">
                            跟踪人员
                        </td>
                        <td width="40%">
                            跟踪记录
                        </td>
                    </tr>
                    <tr class="gridrowadd">
                        <td>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlFollowUpPersonAdd" runat="server" Width="90%"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFollowUpNoteAdd" runat="server" CssClass="text" Width="80%"></asp:TextBox>
                            <asp:LinkButton ID="btnCreateFollowUp" runat="server" Text="新增" CssClass="button" onclick="btnCreateFollowUp_Click" />
                        </td>
                    </tr>
    <asp:Repeater ID="rpFollowUp" runat="server" 
         EnableViewState="False">
        <ItemTemplate>
            <tr class="gridrow">
                <td>
                    <%#Eval("FollowUp_Date") %>
                </td>
                <td>
                    <%#Eval("FollowUp_Man") %>
                </td>
                <td>
                    <%#Eval("FollowUp_Notes") %>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="gridrowalt">
                <td>
                    <%#Eval("FollowUp_Date") %>
                </td>
                <td>
                    <%#Eval("FollowUp_Man") %>
                </td>
                <td>
                    <%#Eval("FollowUp_Notes") %>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
</div>
<asp:LinkButton ID="btnFocus" runat="server"></asp:LinkButton>