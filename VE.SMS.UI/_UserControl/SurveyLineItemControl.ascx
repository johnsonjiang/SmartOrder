<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SurveyLineItemControl.ascx.cs" Inherits="VE.SMS.UI._UserControl.SurveyLineItemControl" %>

<div class="generaldiv">

            <asp:Repeater ID="rpItems" runat="server">
                <HeaderTemplate>
                    <table class="listtable">
                        <tbody>
                            <tr class="gridheader">
                                <td width="10%">
                                    项目
                                </td>
                                <td width="10%" align="center">
                                    说明
                                </td>
                                <td width="10%" align="center">
                                    名称
                                </td>
                                <td width="10%" align="center">
                                    规格
                                </td>
                                <td width="10%" align="center">
                                    单位
                                </td>
                                <td width="10%" align="center">
                                    数量
                                </td>
                                <td width="10%" align="center">
                                    备注
                                </td>
                                <%--                            <td bgcolor="#eeeeee" width="8%" align="center">
                                精准报价
                            </td>--%>
                                <td width="10%" align="center">
                                    操作
                                </td>
                            </tr>
                            <tr class="gridrowadd">
                                  <td width="10%">
                                    <asp:DropDownList ID="ddlProject" runat="server" CssClass="dropdownlist" Width="80%"></asp:DropDownList>
                                </td>
                                <td width="10%" align="center">
                                    <asp:TextBox ID="txtIntro" runat="server" CssClass="text" Width="80%"></asp:TextBox>
                                </td>
                                <td width="10%" align="center">
                                    <asp:TextBox ID="txtProductNameAndCode" runat="server" CssClass="text" Width="80%" Text="材料信息" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td width="10%" align="center">
                                    <asp:TextBox ID="txtSpec" runat="server" CssClass="text" Width="80%" Text="规格" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td width="10%" align="center">
                                    <asp:DropDownList ID="ddlUnit" runat="server" CssClass="dropdownlist" Width="80%"  ClientIDMode="Static"></asp:DropDownList>
                                </td>
                                <td width="10%" align="center">
                                    <asp:TextBox ID="txtQty" runat="server" CssClass="text" Width="80%" Text="数量"  ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td width="10%" align="center">
                                    <asp:TextBox ID="txtRemark" runat="server" CssClass="text" Width="80%"></asp:TextBox>
                                </td>
                                <%--                            <td bgcolor="#eeeeee" width="8%" align="center">
                                精准报价
                            </td>--%>
                                <td width="10%" align="center">
                                    <asp:LinkButton ID="btnAdd" runat="server" CssClass="button" Text="新增"></asp:LinkButton>
                                </td>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                     <tr class="gridrow">
                                <td width="10%">
                                    项目
                                </td>
                                <td height="20" width="10%" align="center">
                                    说明
                                </td>
                                <td width="10%" align="center">
                                    材料名称+代码
                                </td>
                                <td width="10%" align="center">
                                    规格
                                </td>
                                <td width="10%" align="center">
                                    单位
                                </td>
                                <td width="10%" align="center">
                                    数量
                                </td>
                                <td width="10%" align="center">
                                    备注
                                </td>
                                <%--                            <td bgcolor="#eeeeee" width="8%" align="center">
                                精准报价
                            </td>--%>
                                <td width="10%" align="center">
                                    <asp:LinkButton ID="btnSave" runat="server" Text="保存" CssClass="button"></asp:LinkButton>
                                    <asp:LinkButton ID="btnDelete" runat="server" Text="刪除" CssClass="button"></asp:LinkButton>
                                </td>
                            </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                 <tr class="gridrowalt">
                                <td width="10%">
                                    项目
                                </td>
                                <td height="20" width="10%" align="center">
                                    说明
                                </td>
                                <td width="10%" align="center">
                                    名称
                                </td>
                                <td width="10%" align="center">
                                    规格
                                </td>
                                <td width="10%" align="center">
                                    单位
                                </td>
                                <td width="10%" align="center">
                                    数量
                                </td>
                                <td width="10%" align="center">
                                    备注
                                </td>
                                <%--                            <td bgcolor="#eeeeee" width="8%" align="center">
                                精准报价
                            </td>--%>
                                <td width="10%" align="center">
                                    <asp:LinkButton ID="btnSave" runat="server" Text="保存" CssClass="button"></asp:LinkButton>
                                    <asp:LinkButton ID="btnDelete" runat="server" Text="刪除" CssClass="button"></asp:LinkButton>
                                </td>
                            </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
        