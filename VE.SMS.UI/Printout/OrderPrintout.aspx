<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPrintout.aspx.cs" Inherits="VE.SMS.UI.Printout.OrderPrintout" %>

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
    <style>
        /* cnwebshow.com */
        body
        {
            margin: 0px;
            padding: 0px;
            font-size: 9px;
            line-height: 1.8;
            font-family: Verdana,宋体;
        }
        .info
        {
            width: 100%;
            float: left;
        }
        .left
        {
            float: left;
            width: 10%;
        }
        .center
        {
            width:30%;
            margin: 0 180px;
        }
        .right
        {
            margin-left: -300px;
            float: left;
            width: 300px
        }
    </style>
</head>
<body>
    <object id="WebBrowser" width="0" height="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"> 
</object> 
    <form id="form1" runat="server">
    <div class="printsection">
        <div class="printheader" style="height: 70px">
            <div class="info">
                <div class="left">
                    <img src="../Images/logo.png" width="180px" height="70px" /></div>
                <div class="center" style="font-size: 24px">
                    订单
                    <div style="font-size: 24px">
                        Order</div>
                </div>
            </div>
            <div class="right" style="font-size: 9px; font-weight: normal; text-align: left">
                上海竞业石材有限公司<br />
                SHANGHAI GINYEE STONE ART CO. LTD.<br />
                Add:上海市浦东区杨高南路4108号恒大石材交易中心B区712号
                <br />
                Tel:021-51338679 Fax:021-51969095 QQ:1653009082
                <br />
                E-mail: info@ginyeestone.com Web: www.ginyeestone.com
                <br />
            </div>
        </div>
        <div>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                
            </table>

            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
            <tr>
                    <td align="left" style="font-size: 18px">
                        订单号: <u><%=OrdNo %></u>
                    </td>
                    <td style="font-size: 18px">
                        日期：<u> <asp:Label ID="lblDate" runat="server"></asp:Label></u>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        客户: <u><asp:Label ID="lblContactName" runat="server"></asp:Label></u> &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 联系电话:<u><asp:Label ID="lblPhone" runat="server"></asp:Label></u>
                    </td>
                    <td>
                        电子邮箱:<u><asp:Label ID="lblEmail" runat="server"></asp:Label></u> &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; QQ:<u><asp:Label ID="lblQQ" runat="server"></asp:Label></u>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        客户联系地址:<u><asp:Label ID="lblAddress" runat="server"></asp:Label></u>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        客户提供图纸:<asp:Label ID="lblIsCustomerProvideImage" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        提供样品给客户:<asp:Label ID="lblSampleToCustomer" runat="server"></asp:Label> <asp:Label ID="lblTextSampleCode" runat="server" Text="样品号码:" Visible="false"></asp:Label><asp:Label ID="lblSampleCode" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        是否上门测量:<asp:Label ID="lblSurveyNeeded" runat="server"></asp:Label> <asp:Label ID="lblSurveyType" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        是否提供细化:<asp:Label ID="lblProvideRefine" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        送货:<asp:Label ID="lblProvideDelivery" runat="server"></asp:Label> <asp:Label ID="lblDeliveryType" runat="server"></asp:Label> 送货地址：<asp:Label ID="lblDeliveryAddress" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        安装:<asp:Label ID="lblProvideInstall" runat="server"></asp:Label> <asp:Label ID="lblInstallType" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: left">
                       <%-- 工期要求：<asp:Label ID="lblTimeLimited" runat="server"></asp:Label>--%>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:Repeater ID="rpItems" runat="server" OnItemDataBound="rpItems_ItemDataBound">
                <HeaderTemplate>
                    <table border="1" cellpadding="0" cellspacing="0" style="width: 100%; margin: auto">
                        <tbody>
                            <tr>
                                <td align="center">
                                    项目
                                </td>
                                <td align="center">
                                    说明
                                </td>
                                <td align="center">
                                    名称
                                </td>
                                <td align="center">
                                    规格
                                </td>
                                <td align="center">
                                    单位
                                </td>
                                <td align="center">
                                    单价
                                </td>
                                <td align="center">
                                    数量
                                </td>
                                <td align="center">
                                    小计
                                </td>
                                <td align="center">
                                    备注
                                </td>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td width="8%">
                            <%#Eval("Project")%>
                        </td>
                        <td height="20" width="8%" align="center">
                        <%#Eval("Intro")%>
                        </td>
                        <td width="8%" align="center">
                        <%#Eval("Name")%>
                        </td>
                        <td width="8%" align="center">
                        <%#string.IsNullOrEmpty(Eval("Spec").ToString()) ? "&nbsp;" : Eval("Spec")%>
                        </td>
                        <td width="8%" align="center">
                        <%#Eval("Unit")%>
                        </td>
                        <td width="8%" align="center">
                            <%#Eval("UnitPrice")%>
                        </td>
                        <td width="8%" align="center">
                            <%#Eval("Quantity")%>
                        </td>
                        <td width="8%" align="center">
                            <%#Convert.ToDouble(Eval("UnitPrice")) * Convert.ToDouble(Eval("Quantity"))%>
                        </td>
                        <td width="10%" align="center">
                            <%#Eval("Remark")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr>
                        <td colspan="7" style="text-align: right">
                            合计
                        </td>
                        <td align="center">
                            <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                        </td>
                        <td></td>
                    </tr>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
            <div class="generaldiv" style="width:100%">
                <table width="100%">
                    <tr>
                        <td width="75%">
                            <%
                                VE.SMS.DAL.FooterDAL dal = new VE.SMS.DAL.FooterDAL();
                                var footers = dal.GetFooterBySource(OrdNo, VE.SMS.Common.SysConst.SourceTypeOrder);
                                for (int i = 0; i < footers.Count; i++)
                                {%>
                                    <%=i + 1 %>:<%=footers[i].Intro %><br />
                                <%}
                                 %>
                            <br />
                        </td>
                        <td width="25%">
                            <div>
                            <asp:DropDownList ID="ddlBankInfo" ClientIDMode="Static" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBankInfo_SelectedIndexChanged">
                            </asp:DropDownList>
                            <br />
                            账户信息<br />
                            银行：<asp:Label ID="lblBankName" runat="server"></asp:Label>
                            <br />户名：<asp:Label ID="lblName" runat="server"></asp:Label> 
                            <br />账号：<asp:Label ID="lblAccount" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <uc1:PrintoutControl ID="PrintoutControl1" runat="server" />
    </form>
</body>
</html>
