<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VE.SMS.UI.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="561" style="background: url(images/lbg.gif)">
                            <table width="940" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    
                                    <td height="238" style="background: url(images/login01.jpg)">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td height="190">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="208" height="190" style="background: url(images/login02.jpg)">
                                                    &nbsp;
                                                </td>
                                                <td width="518" style="background: url(images/login03.jpg)">
                                                    <table width="320" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="40" height="50">
                                                                <img src="images/user.gif" width="30" height="30">
                                                            </td>
                                                            <td width="38" height="50">
                                                                用户
                                                            </td>
                                                            <td width="242" height="50">
                                                                <input type="text" runat="server" name="textfield" id="txtName" style="width: 164px; height: 32px;
                                                                    line-height: 34px; background: url(images/inputbg.gif) repeat-x; border: solid 1px #d1d1d1;
                                                                    font-size: 9pt; font-family: Verdana, Geneva, sans-serif;">
                                                                <asp:RequiredFieldValidator ID="rqName" runat="server" ErrorMessage="*" 
                                                                    ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="50">
                                                                <img src="images/password.gif" width="28" height="32">
                                                            </td>
                                                            <td height="50">
                                                                密码
                                                            </td>
                                                            <td height="50">
                                                                <input type="password" runat="server" name="txtPwd" id="txtPwd" style="width: 164px; height: 32px;
                                                                    line-height: 34px; background: url(images/inputbg.gif) repeat-x; border: solid 1px #d1d1d1;
                                                                    font-size: 9pt;">
                                                                <asp:RequiredFieldValidator ID="rqPwd" runat="server" ErrorMessage="*" 
                                                                    ControlToValidate="txtPwd" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="40">
                                                                &nbsp;
                                                            </td>
                                                            <td height="40">
                                                                &nbsp;
                                                            </td>
                                                            <td height="60">
                                                                <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="~/images/login.gif" Width="95"
                                                                    Height="34" onclick="btnLogin_Click" />
                                                                <p />
                                                                <asp:Label ID="lblMsg" runat="server" ForeColor="#CC0000" Visible="False">您无权访问系统，请输入正确的用户名与密码。</asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="214" style="background: url(images/login04.jpg)">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="133" style="background: url(images/login05.jpg)">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    </div>
    </form>
</body>
</html>
