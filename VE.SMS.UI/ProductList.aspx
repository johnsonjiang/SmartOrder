<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="ProductList.aspx.cs" Inherits="VE.SMS.UI.ProductList" %>

<%@ Register Src="_UserControl/PianProductLineItemControl.ascx" TagName="PianProductLineItemControl"
    TagPrefix="uc1" %>
<%@ Register Src="_UserControl/JiaProductLineItemControl.ascx" TagName="JiaProductLineItemControl"
    TagPrefix="uc2" %>
<%@ Register Src="_UserControl/HuangliaoProductLineItemControl.ascx" TagName="HuangliaoProductLineItemControl"
    TagPrefix="uc3" %>
<%@ Register Src="_UserControl/CaiLiaoProductLineItemControl.ascx" TagName="CaiLiaoProductLineItemControl"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" media="all" type="text/css" href="Styles/jquery-ui.css" />
    <script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
    <script language="javascript" type="text/javascript" src="Scripts/jquery-ui.min.js"></script>
    <script language="javascript" type="text/javascript">
        function ViewProduct(choose) {
            if (choose == "片号") {
                $("#caiLiaoProductLineItemControl").hide();
                $("#huangliaoProductLineItemControl").hide();
                $("#jiaProductLineItemControl").hide();
                $("#pianProductLineItemControl").show();
            }
            if (choose == "架号") {
                $("#caiLiaoProductLineItemControl").hide();
                $("#huangliaoProductLineItemControl").hide();
                $("#jiaProductLineItemControl").show();
                $("#pianProductLineItemControl").hide();
            }
            if (choose == "荒料") {
                $("#caiLiaoProductLineItemControl").hide();
                $("#huangliaoProductLineItemControl").show();
                $("#jiaProductLineItemControl").hide();
                $("#pianProductLineItemControl").hide();
            }
            if (choose == "材料") {
                $("#caiLiaoProductLineItemControl").show();
                $("#huangliaoProductLineItemControl").hide();
                $("#jiaProductLineItemControl").hide();
                $("#pianProductLineItemControl").hide();
            }
        }
    </script>
    <%-- <uc1:PianProductLineItemControl ID="pianProductLineItemControl1" runat="server" ClientIDMode="St--%><%--atic" />
                <uc2:JiaProductLineItemControl ID="jiaProductLineItemControl1" runat="server"  />
                <uc3:HuangliaoProductLineItemControl ID="huangliaoProductLineItemControl1" runat="server"   />
                <uc4:CaiLiaoProductLineItemControl ID="CaiLiaoProductLineItemControl1" runat="server"  ClientIDM--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="generaldiv">
        <fieldset style="height: 100%;">
            <legend>材料信息 </legend>
            <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
                <tbody>
                    <tr>
                        <td width="15%" nowrap="nowrap" align="right">
                            材料代码:
                        </td>
                        <td width="35%">
                            <asp:DropDownList ID="ddlProductCode" runat="server" Width="254px"></asp:DropDownList>
                            
                        </td>
                        <td align="right">
                            材料名称:
                        </td>
                        <td>
                        <asp:DropDownList ID="ddlProductName" runat="server" Width="254px"></asp:DropDownList>
                            
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            荒料码:
                        </td>
                        <td>
                            <asp:TextBox ID="txtHuangliaoCode" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        </td>
                        <td align="right">
                            架号:
                        </td>
                        <td>
                            <asp:TextBox ID="txtJiaCode" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" nowrap="nowrap">
                            片号:
                        </td>
                        <td>
                            <asp:TextBox ID="txtPianCode" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        </td>
                        <td align="right">
                            位置:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLocation" runat="server" Width="254px"></asp:DropDownList>
                            
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            颜色:
                        </td>
                        <td>
                        <asp:DropDownList ID="ddlColor" runat="server" Width="254px"></asp:DropDownList>
                        </td>
                        <td align="right">
                            纹理:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTexure" runat="server" Width="254px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            供应商:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSupplierProduct" runat="server" Width="254px">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            长:
                        </td>
                        <td>
                            <asp:TextBox ID="txtLong" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            宽:
                        </td>
                        <td>
                            <asp:TextBox ID="txtWidth" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        </td>
                        <td align="right">
                            厚:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDeep" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            单价(M2):
                        </td>
                        <td>
                            <asp:TextBox ID="txtPriceM2" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        </td>
                        <td align="right">
                            单价(M):
                        </td>
                        <td>
                            <asp:TextBox ID="txtPriceM" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>

                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="button" float="right"
                                OnClick="btnSearch_Click" />
                            <asp:Button ID="btnCreate" runat="server" Text="创建材料" CssClass="button" float="right"
                                name="createproduct" OnClientClick="javascript:window.open('productform.aspx?type=p&viewtype=create');return false;" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </fieldset>
    </div>
    <div id="Div1" class="generaldiv" runat="server" visible="true">
        <fieldset style="height: 100%;">
            <legend>材料信息汇总 </legend>
            <div class="generaldiv">
                请选择查看方式
                <input id="cailiao" type="radio" onclick="javascript:ViewProduct('材料')" value="材料" name="group" />材料
                <input id="huangliao" type="radio" onclick="javascript:ViewProduct('荒料')" value="荒料" name="group" />荒料
                <input id="jiahao" type="radio" onclick="javascript:ViewProduct('架号')" value="架号" name="group" />架号
                <input id="pianhao" type="radio" onclick="javascript:ViewProduct('片号')" value="片号" name="group"
                    checked="checked" />片号
            </div>
            <div class="generaldiv">
                <div id="pianProductLineItemControl">
                    <uc1:PianProductLineItemControl ID="pianProductLineItemControl1" runat="server" />
                </div>
                <div id="jiaProductLineItemControl" style="display: none">
                    <uc2:JiaProductLineItemControl ID="jiaProductLineItemControl1" runat="server" />
                </div>
                <div id="huangliaoProductLineItemControl" style="display: none">
                    <uc3:HuangliaoProductLineItemControl ID="huangliaoProductLineItemControl1" runat="server" />
                </div>
                <div id="caiLiaoProductLineItemControl" style="display: none">
                    <uc4:CaiLiaoProductLineItemControl ID="caiLiaoProductLineItemControl1" runat="server" />
                </div>
            </div>
        </fieldset>
    </div>
    <div class="generaldiv">
    </div>
</asp:Content>
