<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerInfoControl.ascx.cs" Inherits="VE.SMS.UI._UserControl.CustomerInfoControl" %>
<table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="16%" nowrap="nowrap" align="right">
                        客户公司名称:
                    </td>
                    <td width="34%">
                        <asp:TextBox ID="txtCustomerCompanyName" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td nowrap="nowrap" align="right">
                        客户联系人:
                    </td>
                    <td>
                        <asp:TextBox ID="txtContactName" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        客户联系地址:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustomerAddress" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td align="right">
                        电子邮箱:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="text" Style="width: 254px" 
                            ValidationGroup="Page"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ErrorMessage="Email格式不正确" Display="Dynamic" EnableViewState="True" 
                            SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="txtEmail" 
                            ForeColor="Red" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        QQ:
                    </td>
                    <td>
                        <asp:TextBox ID="txtQQ" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td align="right">
                        联系电话1:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone1" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        联系电话2:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone2" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                                        <td align="right">
                        其他:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOther" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                       
                    </td>
                    <td>
                       <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        
                    </td>
                    <td>
                        <asp:LinkButton ID="btnLoad" runat="server" Text="载入客户信息" OnClick="btnLoad_Click"></asp:LinkButton>
                    </td>
                </tr>
            </tbody>
        </table>