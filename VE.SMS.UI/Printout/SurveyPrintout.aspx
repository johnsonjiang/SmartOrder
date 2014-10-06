<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SurveyPrintout.aspx.cs" Inherits="VE.SMS.UI.Printout.SurveyPrintout" %>


<%@ Register src="../_UserControl/PrintoutControl.ascx" tagname="PrintoutControl" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" media="all" type="text/css" href="../Styles/menu_style.css" />
    <link rel="stylesheet" rev="stylesheet" href="../Styles/style.css" type="text/css"
        media="all" />
    <link rel="stylesheet" media="all" type="text/css" href="../Styles/jquery-ui.css" />
    <script language="javascript" type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <script language="javascript" type="text/javascript" src="../Scripts/jquery-ui.min.js"></script>
</head>
<body>
    <%--<OBJECT id=wb height=0 width=0 classid=CLSID:8856F961-340A-11D0-A96B-00C04FD705A2 name=wb></OBJECT>--%>
    <form id="form1" runat="server">
    <div class="generaldiv">
    </div>
    <div class="printsection">
        <div class="printheader">
            上海竞业石材测量单</div>
        <div style="text-align: center">
            <table border="1" cellpadding="0" cellspacing="0" style="width: 90%; margin: auto">
                <tr>
                    <td align="right">
                        测量单号:
                    </td>
                    <td>
                        S1000
                    </td>
                    <td align="right">
                        测量人员
                    </td>
                    <td>
                        姜苏
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        咨询单/订单负责人:
                    </td>
                    <td>
                        姜苏
                    </td>
                    <td align="right">
                        预计测量日期
                    </td>
                    <td>
                        2011-11-11
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        现场联系人:
                    </td>
                    <td>
                        姜苏
                    </td>
                    <td align="right">
                        现场联系人电话:
                    </td>
                    <td>
                        42342342
                    </td>
                </tr>
                                <tr>
                    <td align="right">
                        测量说明:
                    </td>
                    <td>
                        要全面测量
                    </td>
                    <td align="right">
                        需带物品:
                    </td>
                    <td>
                        卷尺，激光测距仪
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        客户公司名称:
                    </td>
                    <td>
                    </td>
                    <td align="right">
                        客户联系人:
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        客户联系地址:
                    </td>
                    <td>
                    </td>
                    <td align="right">
                        电子邮箱:
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        QQ:
                    </td>
                    <td>
                    </td>
                    <td align="right">
                        联系电话:
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align:left">
                        测量内容
                    </td>
                </tr>
            </table>
            <asp:Repeater ID="rpItems" runat="server">
                <HeaderTemplate>
                    <table border="1" cellpadding="0" cellspacing="0" style="width: 90%; margin: auto">
                        <tbody>
                        <tr>
                                <td>
                                    项目
                                </td>
                                <td>
                                    说明
                                </td>
                                <td>
                                    名称
                                </td>
                                <td>
                                    规格
                                </td>
                                <td>
                                    单位
                                </td>
                                <td>
                                    数量
                                </td>
                                <td>
                                    备注
                                </td>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td width="8%">
                            项目
                        </td>
                        <td height="20" width="8%" align="center">
                            说明
                        </td>
                        <td width="8%" align="center">
                            材料名称+代码
                        </td>
                        <td width="8%" align="center">
                            规格
                        </td>
                        <td width="8%" align="center">
                            单位
                        </td>
                        <td width="8%" align="center">
                            数量
                        </td>
                        <td width="10%" align="center">
                            备注
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
            <div class="generaldiv">
            </div>
        </div>
    </div>

    <uc1:PrintoutControl ID="PrintoutControl1" runat="server" />

    </form>
</body>
</html>
