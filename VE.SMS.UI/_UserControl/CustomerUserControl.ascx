<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerUserControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.CustomerUserControl" %>
<div class="generaldiv">
    <asp:Repeater ID="rpCustomer" runat="server" OnItemCommand="rpCustomer_ItemCommand">
        <HeaderTemplate>
            <table class="listtable">
                <tbody>
                    <tr class="gridheader">
                        <td width="15%">
                            客户公司名称
                        </td>
                        <td width="10%">
                            客户联系人
                        </td>
                        <td width="15%">
                            客户联系地址
                        </td>
                        <td width="10%">
                            电子邮箱
                        </td>
                        <td width="10%">
                            联系电话1
                        </td>
                        <td width="10%">
                            联系电话2
                        </td>
                        <td width="10%">
                            QQ
                        </td>
                        <td width="10%">
                            其他
                        </td>
                        <td width="10%">
                            操作
                        </td>
                    </tr>
                    <tr class="gridrowadd">
                        <td>
                            <asp:TextBox ID="txtCustomerCompanyNameAdd" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactNameAdd" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddressAdd" runat="server" CssClass="text" Width="90%" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmailAdd" runat="server" CssClass="text" Width="90%" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhone1Add" runat="server" CssClass="text" Width="90%" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhone2Add" runat="server" CssClass="text" Width="90%" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtQQAdd" runat="server" CssClass="text" Width="90%" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtOthersAdd" runat="server" CssClass="text" Width="90%" />
                        </td>
                        <td>
                            <asp:LinkButton ID="btnAdd" runat="server" Text="新增" CssClass="button" CommandName="Add" />
                        </td>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="gridrow">
                <td width="15%">
                    <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("Customer_Id") %>' />
                    <asp:TextBox ID="txtCustomerCompanyName" runat="server" Text='<%#Eval("CustomerCompanyName") %>'
                        CssClass="text" Width="90%"></asp:TextBox>
                </td>
                <td width="10%">
                    <asp:TextBox ID="txtContactName" runat="server" Text='<%#Eval("ContactName") %>'
                        CssClass="text" Width="90%"></asp:TextBox>
                </td>
                <td width="15%">
                    <asp:TextBox ID="txtAddress" runat="server" Text='<%#Eval("Address") %>' CssClass="text" Width="90%"></asp:TextBox>
                </td>
                <td width="10%">
                    <asp:TextBox ID="txtEmail" runat="server" Text='<%#Eval("Email") %>' CssClass="text" Width="90%"></asp:TextBox>
                </td>
                <td width="10%">
                    <asp:TextBox ID="txtPhone1" runat="server" Text='<%#Eval("Phone1") %>' CssClass="text" Width="90%"></asp:TextBox>
                </td>
                <td width="10%">
                    <asp:TextBox ID="txtPhone2" runat="server" Text='<%#Eval("Phone2") %>' CssClass="text" Width="90%"></asp:TextBox>
                </td>
                <td width="10%">
                    <asp:TextBox ID="txtQQ" runat="server" Text='<%#Eval("QQ") %>' CssClass="text" Width="90%"></asp:TextBox>
                </td>
                <td width="10%">
                    <asp:TextBox ID="txtOthers" runat="server" Text='<%#Eval("CustomerOthers") %>' CssClass="text" Width="90%"></asp:TextBox>
                </td>
                <td width="10%">
                    <asp:LinkButton ID="btnSave" runat="server" Text="保存" CssClass="button" CommandName="Save" />
                    <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" />
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="gridrowalt">
                <td width="15%">
                    <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("Customer_Id") %>' />
                    <asp:TextBox ID="txtCustomerCompanyName" runat="server" Text='<%#Eval("CustomerCompanyName") %>'
                        CssClass="text" Width="90%"></asp:TextBox>
                </td>
                <td width="10%">
                    <asp:TextBox ID="txtContactName" runat="server" Text='<%#Eval("ContactName") %>'
                        CssClass="text" Width="90%"></asp:TextBox>
                </td>
                <td width="15%">
                    <asp:TextBox ID="txtAddress" runat="server" Text='<%#Eval("Address") %>' CssClass="text" Width="90%"></asp:TextBox>
                </td>
                <td width="10%">
                    <asp:TextBox ID="txtEmail" runat="server" Text='<%#Eval("Email") %>' CssClass="text" Width="90%"></asp:TextBox>
                </td>
                <td width="10%">
                    <asp:TextBox ID="txtPhone1" runat="server" Text='<%#Eval("Phone1") %>' CssClass="text" Width="90%"></asp:TextBox>
                </td>
                <td width="10%">
                    <asp:TextBox ID="txtPhone2" runat="server" Text='<%#Eval("Phone2") %>' CssClass="text" Width="90%"></asp:TextBox>
                </td>
                <td width="10%">
                    <asp:TextBox ID="txtQQ" runat="server" Text='<%#Eval("QQ") %>' CssClass="text" Width="90%"></asp:TextBox>
                </td>
                <td width="10%">
                    <asp:TextBox ID="txtOthers" runat="server" Text='<%#Eval("CustomerOthers") %>' CssClass="text" Width="90%"></asp:TextBox>
                </td>
                <td width="10%">
                    <asp:LinkButton ID="btnSave" runat="server" Text="保存" CssClass="button" CommandName="Save" />
                    <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
</div>
