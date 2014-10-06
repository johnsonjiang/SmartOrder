<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SettlementsPrintout.aspx.cs"
    Inherits="VE.SMS.UI.Printout.SettlementsPrintout" %>

<%@ Register Src="../_UserControl/PrintoutControl.ascx" TagName="PrintoutControl"
    TagPrefix="uc1" %>
<%@ Register Src="SettlementPrintoutControl.ascx" TagName="SettlementPrintoutControl"
    TagPrefix="uc2" %>
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
    <style>
        .PageNext
        {
            page-break-after: always;
        }
    </style>
</head>
<body>
    <%--<OBJECT id=wb height=0 width=0 classid=CLSID:8856F961-340A-11D0-A96B-00C04FD705A2 name=wb></OBJECT>--%>
    <form id="form1" runat="server">
    <div class="generaldiv" style="padding-left:150px">
        选择打印结算单
        <asp:CheckBoxList ID="cblSettlements" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem>S1232</asp:ListItem>
            <asp:ListItem>S1231</asp:ListItem>
            <asp:ListItem>S1230</asp:ListItem>
            <asp:ListItem>S1235</asp:ListItem>
        </asp:CheckBoxList>
        <uc1:PrintoutControl ID="PrintoutControl1" runat="server" />
    </div>
    <div class="printsection">
        <div class="printheader">
            上海竞业石材结算单汇总</div>
        <div style="text-align: center">
            <table border="1" cellpadding="0" cellspacing="0" style="width: 90%; margin: auto">
                <tr>
                    <td align="right">
                        汇总单号:
                    </td>
                    <td>
                        O10000
                    </td>
                    <td align="right">
                        参与结算人员：
                    </td>
                    <td>
                        姜苏
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        制表：
                    </td>
                    <td>
                        姜苏
                    </td>
                    <td align="right">
                        日期:
                    </td>
                    <td>
                        2011-11-11
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        审核签字:
                    </td>
                    <td>
                        姜苏
                    </td>
                    <td align="right">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="4">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left">
                        结算单内容
                    </td>
                </tr>
            </table>
            <asp:Repeater ID="rpSettlements" runat="server">
                <HeaderTemplate>
                    <table border="1" cellpadding="0" cellspacing="0" style="width: 90%; margin: auto">
                        <tbody>
                            <tr>
                                <td>
                                    结算单号
                                </td>
                                <td>
                                    材料费
                                </td>
                                <td>
                                    加工费
                                </td>
                                <td>
                                    安装费
                                </td>
                                <td>
                                    合计
                                </td>
                                <td>
                                    备注
                                </td>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            结算单号
                        </td>
                        <td>
                            材料费
                        </td>
                        <td>
                            加工费
                        </td>
                        <td>
                            安装费
                        </td>
                        <td>
                            合计
                        </td>
                        <td>
                            备注
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr>
                        <td align="right">
                            合计:
                        </td>
                        <td>
                            432423.3
                        </td>
                        <td>
                            86868686
                        </td>
                        <td>
                            432423.3
                        </td>
                        <td>
                            8888888888
                        </td>
                        <td>
                        </td>
                    </tr>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
            <table border="1" cellpadding="0" cellspacing="0" style="width: 90%; margin: auto">
                <tr>
                    <td align="right" colspan="6" style="float: left">
                        已收金额记录:
                    </td>
                </tr>
            </table>
            <asp:Repeater ID="rpIncome" runat="server">
                <HeaderTemplate>
                    <table border="1" cellpadding="0" cellspacing="0" style="width: 90%; margin: auto">
                        <tbody>
                            <tr>
                                <td>
                                    日期
                                </td>
                                <td>
                                    结算单号
                                </td>
                                <td>
                                    已收金额
                                </td>
                                <td>
                                    备注
                                </td>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            2011-11-11
                        </td>
                        <td>
                            S102323
                        </td>
                        <td>
                            88888
                        </td>
                        <td>
                            备注
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody> </table>
                </FooterTemplate>
            </asp:Repeater>
            <table border="1" cellpadding="0" cellspacing="0" style="width: 90%; margin: auto">
                <tr>
                    <td align="right" colspan="6" style="float: left">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        累计金额:
                    </td>
                    <td>
                        66666666
                    </td>
                    <td align="right">
                        已收金额:
                    </td>
                    <td>
                        88888888
                    </td>
                    <td align="right">
                        应收金额:
                    </td>
                    <td>
                        888888
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        甲方签字:
                    </td>
                    <td>
                    </td>
                    <td align="right">
                        日期:
                    </td>
                    <td>
                    </td>
                    <td align="right">
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <div class="generaldiv">
            </div>
        </div>

        <div class="PageNext">
        </div>

        <asp:Repeater ID="rpSettlementList" runat="server">
            <ItemTemplate>
                <div class="PageNext">
                    <uc2:SettlementPrintoutControl ID="SettlementPrintoutControl1" runat="server" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    
    </form>
</body>
</html>
