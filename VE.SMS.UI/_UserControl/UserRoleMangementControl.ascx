<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserRoleMangementControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.UserRoleMangementControl" %>
<div style="width: 960px">
    <fieldset style="height: 100%;">
        <legend>用户角色查询 </legend>用户名:
        <asp:DropDownList ID="ddlUserName" runat="server" CssClass="dropdownlist" Width="254px">
        </asp:DropDownList>
        角色名:
        <asp:DropDownList ID="ddlRole" runat="server" CssClass="dropdownlist" Width="254px">
        </asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="button" OnClick="btnSearch_Click" />
    </fieldset>
</div>
<div style="width: 960px">
    <fieldset style="height: 100%;">
        <legend>用户角色列表</legend>
        <asp:Repeater ID="rpUserRoleList" runat="server" 
            OnItemCommand="rpUserRoleList_ItemCommand" 
            onitemdatabound="rpUserRoleList_ItemDataBound">
            <HeaderTemplate>
                <table width="930px">
                    <tbody>
                        <tr class="gridheader">
                            <td>
                                用户名/真实姓名
                            </td>
                            <td>
                                角色
                            </td>
                            <td>
                                操作
                            </td>
                        </tr>
                        <tr class="gridrowadd">
                            <td>
                                <asp:DropDownList ID="ddlUserNameAdd" runat="server" CssClass="dropdownlist" Width="254px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRoleAdd" runat="server" CssClass="dropdownlist" Width="254px">
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
                        <asp:HiddenField ID="hfUrId" runat="server" Value='<%#Eval("UserRole_Id") %>' />
                        <%#Eval("UserName") %>/<%#Eval("RealName") %></td>
                    </td>
                    <td>
                        <%#Eval("RoleName") %>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="gridrowalt">
                    <td>
                        <asp:HiddenField ID="hfUrId" runat="server" Value='<%#Eval("UserRole_Id") %>' />
                        <%#Eval("UserName") %>/<%#Eval("RealName") %></td>
                    </td>
                    <td>
                        <%#Eval("RoleName") %>
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
