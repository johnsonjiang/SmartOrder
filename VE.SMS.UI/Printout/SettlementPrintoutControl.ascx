<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettlementPrintoutControl.ascx.cs" Inherits="VE.SMS.UI.Printout.SettlementPrintoutControl" %>
        <div class="printheader">
            上海竞业石材结算单</div>
        <div style="text-align: center">
            <table border="1" cellpadding="0" cellspacing="0" style="width: 90%; margin: auto">
                <tr>
                    <td align="right">
                        结算单号:
                    </td>
                    <td>
                        S1000
                    </td>
                    <td align="right">
                        结算单人员：
                    </td>
                    <td>
                        姜苏
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        送货日期:
                    </td>
                    <td>
                        2011-11-11
                    </td>
                    <td align="right">
                        相关订单：
                    </td>
                    <td>
                        O99878
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        结算位置:
                    </td>
                    <td>
                        咖啡厅
                    </td>
                    <td align="right">
                        送货单列表：
                    </td>
                    <td>
                        D1000，D10003
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
                    <td colspan="4" style="text-align: left">
                        结算单内容
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
                                    单价
                                </td>
                                <td>
                                    数量
                                </td>
                                <td>
                                    小计
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
                            单价
                        </td>
                        <td width="8%" align="center">
                            数量
                        </td>
                        <td width="8%" align="center">
                            小计
                        </td>
                        <td width="10%" align="center">
                            备注
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr>
                        <td colspan="9">
                            &nbsp;
                        </td>
                    </tr>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
            <table border="1" cellpadding="0" cellspacing="0" style="width: 90%; margin: auto">
                <tr>
                    <td align="right">
                        本单金额:
                    </td>
                    <td>
                        432423.3
                    </td>
                    <td align="right">
                        本次应付
                    </td>
                    <td>
                        432423.3
                    </td>
                    <td align="right">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        累计总额:
                    </td>
                    <td>
                        432423.3
                    </td>
                    <td align="right">
                        已收金额:
                    </td>
                    <td>
                        132423.3
                    </td>
                    <td align="right">
                        应收金额:
                    </td>
                    <td>
                        300000
                    </td>
                </tr>
            </table>
            <div class="generaldiv">
            </div>
        </div>