<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PermissionControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.PermissionControl" %>
<div style="width: 960px">
    <fieldset style="height: 100%;">
        <legend>权限查询 </legend>角色:
        <asp:DropDownList ID="ddlRoleName" runat="server" CssClass="dropdownlist" Width="254px">
        </asp:DropDownList>
        权限名:
        <asp:DropDownList ID="ddlPermission" runat="server" CssClass="dropdownlist" Width="254px">
        </asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="button" 
            onclick="btnSearch_Click" />
    </fieldset>
</div>
<div style="width: 960px">
    <fieldset style="height: 100%;">
        <legend>用户角色列表</legend>
        <asp:Repeater ID="rpPermissionList" runat="server" OnItemCommand="rpPermissionList_ItemCommand"
            OnItemDataBound="rpPermissionList_ItemDataBound">
            <HeaderTemplate>
                <table width="930px">
                    <tbody>
                        <tr class="gridheader">
                            <td>
                                角色
                            </td>
                            <td>
                                权限
                            </td>
                            <td>
                                操作
                            </td>
                        </tr>
                        <tr class="gridrowadd">
                            <td>
                                <asp:DropDownList ID="ddlRoleNameAdd" runat="server" CssClass="dropdownlist" Width="254px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPermissionAdd" runat="server" CssClass="dropdownlist" Width="254px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:LinkButton ID="btnCreate" runat="server" Text="新增" CssClass="button" CommandName="Add" />
                            </td>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="gridrow">
                    <td>
                        <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("Id") %>' />
                        <%#Eval("RoleName") %>
                    </td>
                    </td>
                    <td>
                        <%#Eval("PermissionName") %>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="gridrowalt">
                    <td>
                        <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("Id") %>' />
                        <%#Eval("RoleName") %>
                    </td>
                    </td>
                    <td>
                        <%#Eval("PermissionName") %>
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
