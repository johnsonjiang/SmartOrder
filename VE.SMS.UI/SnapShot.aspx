<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SnapShot.aspx.cs" Inherits="VE.SMS.UI.SnapShot" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" media="all" type="text/css" href="Styles/menu_style.css" />
    <link rel="stylesheet" rev="stylesheet" href="Styles/style.css" type="text/css" media="all" />
    <link rel="stylesheet" media="all" type="text/css" href="Styles/jquery-ui.css" />
    <script language="javascript" type="text/javascript" src="Scripts/jquery.min.js"></script>
    <script language="javascript" type="text/javascript" src="Scripts/jquery-ui.min.js"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
        type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="generaldiv">
        <div class="generaldiv" style="font-size: 24px; font-weight: 600; text-align: center">
            生产单<%=MachNo %>
            加工说明表</div>
            <div class="generaldiv"></div>
        <div class="generaldiv">
            <asp:Repeater ID="rpItemExport" runat="server" OnItemDataBound="rpItems_ItemDataBound">
                <HeaderTemplate>
                    <table class="listtable">
                        <tbody>
                            <tr class="gridheader">
                                <td width="3%">
                                    序号
                                </td>
                                <td width="8%">
                                    说明
                                </td>
                                <td width="8%" align="center">
                                    材料
                                </td>
                                <td width="4%" align="center">
                                    编号
                                </td>
                                <td width="17%" align="center">
                                    长
                                </td>
                                <td width="17%" align="center">
                                    宽
                                </td>
                                <td width="17%" align="center">
                                    厚
                                </td>
                                <td width="4%" align="center">
                                    数量
                                </td>
                                <td width="4%" align="center">
                                    面积
                                </td>
                                <td width="10%" align="center">
                                    加工说明
                                </td>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="gridrow">
                        <td valign="top">
                            <%#Container.ItemIndex + 1 %>
                        </td>
                        <td valign="top">
                            <%#Eval("Intro") %>
                        </td>
                        <td height="20" align="left" valign="top">
                            <%#Eval("Product_Code") %>
                        </td>
                        <td align="left" valign="top">
                            <%#Eval("Code") %>
                        </td>
                        <td align="left" valign="top">
                            <%#Eval("Long") %>
                            <asp:Repeater ID="rpDisplayL" runat="server" OnItemDataBound="rpDisplay_ItemDataBound">
                                <HeaderTemplate>
                                    <ol>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <asp:Image ID="imgMach" runat="server" /></li>
                                        <div>
                                <asp:Label ID="lblMachType" runat="server"></asp:Label></div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ol>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                        <td align="left" valign="top">
                            <%#Eval("Width") %>
                            <asp:Repeater ID="rpDisplayW" runat="server" OnItemDataBound="rpDisplay_ItemDataBound">
                                <HeaderTemplate>
                                    <ol>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <asp:Image ID="imgMach" runat="server" /></li>
                                        <div>
                                <asp:Label ID="lblMachType" runat="server"></asp:Label></div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ol>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                        <td align="left" valign="top">
                            <%#Eval("Deepth") %>
                            <asp:Repeater ID="rpDisplayD" runat="server" OnItemDataBound="rpDisplay_ItemDataBound">
                                <HeaderTemplate>
                                    <ol>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <asp:Image ID="imgMach" runat="server" /></li>
                                        <div>
                                <asp:Label ID="lblMachType" runat="server"></asp:Label></div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ol>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                        <td align="left" valign="top">
                            <%#Eval("Quantity") %>
                        </td>
                        <td valign="top" align="left">
                            <%#Eval("Square") %>
                        </td>
                        <td valign="top">
                            <%#Eval("MachIntro") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    </form>
</body>
</html>
