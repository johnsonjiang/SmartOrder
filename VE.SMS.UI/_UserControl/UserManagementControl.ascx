<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserManagementControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.UserManagementControl" %>
<div style="width: 960px">
    <fieldset style="height: 100%;">
        <legend>用户查询 </legend>用户名:
        <asp:TextBox ID="txtUserName" runat="server" CssClass="text" Width="254px"></asp:TextBox>
        真实姓名:
        <asp:TextBox ID="txtRealName" runat="server" CssClass="text" Width="254px"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="button" OnClick="btnSearch_Click" />
    </fieldset>
</div>
<div style="width: 960px">
    <fieldset style="height: 100%;">
        <legend>用户列表</legend>
        <asp:Repeater ID="rpUserList" runat="server" OnItemCommand="rpUserList_ItemCommand">
            <HeaderTemplate>
                <table width="930px">
                    <tbody>
                        <tr class="gridheader">
                            <td width="15%">
                                用户名
                            </td>
                            <td width="15%">
                                真实姓名
                            </td>
                            <td width="15%">
                                密码
                            </td>
                            <td width="15%">
                                电话1
                            </td>
                            <td width="15%">
                                电话2
                            </td>
                            <td width="15%">
                                部门
                            </td>
                            <td>
                                操作
                            </td>
                        </tr>
                        <tr class="gridrowadd">
                            <td>
                                <asp:TextBox ID="txtUserNameAdd" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRealNameAdd" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPasswordAdd" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhone1Add" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhone2Add" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDepartmentAdd" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                            </td>
                            <td>
                                <asp:LinkButton ID="btnCreate" runat="server" Text="新增" CssClass="button" CommandName="Add" />
                            </td>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="gridrow">
                    <td>
                        <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("User_Id") %>' />
                        <%#Eval("UserName") %>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRealName" runat="server" Text='<%#Eval("RealName") %>' CssClass="text"
                            Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPwd" runat="server" Text='<%#Eval("Password") %>' CssClass="text"
                            Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone1" runat="server" Text='<%#Eval("Phone1") %>' CssClass="text"
                            Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone2" runat="server" Text='<%#Eval("Phone2") %>' CssClass="text"
                            Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDepartment" runat="server" Text='<%#Eval("Department") %>' CssClass="text"
                            Width="90%"></asp:TextBox>
                    </td>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnSave" runat="server" Text="保存" CommandName="Save"></asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete"/>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="gridrowalt">
                    <td>
                        <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("User_Id") %>' />
                        <%#Eval("UserName") %>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRealName" runat="server" Text='<%#Eval("RealName") %>' CssClass="text"
                            Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPwd" runat="server" Text='<%#Eval("Password") %>' CssClass="text"
                            Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone1" runat="server" Text='<%#Eval("Phone1") %>' CssClass="text"
                            Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone2" runat="server" Text='<%#Eval("Phone2") %>' CssClass="text"
                            Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDepartment" runat="server" Text='<%#Eval("Department") %>' CssClass="text"
                            Width="90%"></asp:TextBox>
                    </td>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnSave" runat="server" Text="保存" CommandName="Save"></asp:LinkButton>
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
