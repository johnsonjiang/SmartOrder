<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RoleManagementControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.RoleManagementControl" %>
<div style="width: 960px">
    <fieldset style="height: 100%;">
        <legend>角色查询 </legend>角色名:
        <asp:TextBox ID="txtRoleName" runat="server" CssClass="text" Width="254px"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="button" OnClick="btnSearch_Click" />
    </fieldset>
</div>
<div style="width: 960px">
    <fieldset style="height: 100%;">
        <legend>角色列表</legend>
        <asp:Repeater ID="rpRoleList" runat="server" OnItemCommand="rpRoleList_ItemCommand">
            <HeaderTemplate>
                <table width="930px">
                    <tbody>
                        <tr class="gridheader">
                            <td>
                                角色名
                            </td>
                            <td>
                                操作
                            </td>
                        </tr>
                        <tr class="gridrowadd">
                            <td>
                                <asp:TextBox ID="txtRoleNameAdd" runat="server" CssClass="text" Width="80%"></asp:TextBox>
                            </td>
                            <td>
                                <asp:LinkButton ID="btnCreate" runat="server" Text="新增" CssClass="button" CommandName="Add" />
                            </td>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="gridrow">
                    <td>
                    <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("Role_Id") %>' />
                        <%#Eval("Role_Name") %>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="gridrowalt">
                    <td>
                    <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("Role_Id") %>' />
                        <%#Eval("Role_Name") %>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </tbody></table>
            </FooterTemplate>
        </asp:Repeater>
    </fieldset>
</div>
