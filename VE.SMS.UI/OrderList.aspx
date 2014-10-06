<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="OrderList.aspx.cs" Inherits="VE.SMS.UI.OrderList" %>

<%@ Import Namespace="VE.SMS.Common" %>
<%@ Register Src="_UserControl/FollowUpTop3UserControl.ascx" TagName="FollowUpTop3UserControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#<% =txtBeginDate.ClientID%>").datepicker();
            $("#<% =txtEndDate.ClientID%>").datepicker();
        });
    </script>
    <fieldset style="height: 100%;">
        <legend>订单查询 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        订单号:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txtOrderNo" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td width="16%" nowrap="nowrap" align="right">
                        客户公司名称:
                    </td>
                    <td width="34%">
                        <asp:DropDownList ID="ddlCompany" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" align="right">
                        客户联系人:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlContact" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        联系电话:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        起始时间:
                    </td>
                    <td>
                        <asp:TextBox ID="txtBeginDate" runat="server" CssClass="text" Style="width: 254px"
                            ReadOnly="false"></asp:TextBox>
                    </td>
                    <td align="right">
                        截止时间:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="text" Style="width: 254px"
                            ReadOnly="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        订单状态:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOrderStatus" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        订单负责人：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOrdMan" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td>
                    </td>
                    <td align="right">
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="查询订单" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>订单汇总 </legend>
        <asp:Button ID="btnCreate" runat="server" Text="新建订单" CssClass="button" OnClick="btnCreate_Click" />
        <div class="generaldiv">
            <asp:Repeater ID="rpOrderList" runat="server" OnItemCommand="rpOrderList_ItemCommand"
                OnItemDataBound="rpOrderList_ItemDataBound">
                <HeaderTemplate>
                    <table class="listtable">
                        <tbody>
                            <tr class="gridheader">
                                <td>
                                    序号
                                </td>
                                <td>
                                    <asp:LinkButton ID="Order_No" runat="server" Text="订单号" CommandName="Order_No"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="CreatedDate" runat="server" Text="日期" CommandName="CreatedDate"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="OrderMan" runat="server" Text="订单负责人" CommandName="OrderMan"></asp:LinkButton>
                                </td>
                                <%--<td>
                                    <asp:LinkButton ID="CustomerCompanyName" runat="server" Text="公司名" CommandName="CustomerCompanyName"></asp:LinkButton>
                                </td>--%>
                                <td>
                                    <asp:LinkButton ID="CustomerContactName" runat="server" Text="客户联系人" CommandName="CustomerContactName"></asp:LinkButton>
                                </td>
                                <%--<td>
                                    电话
                                </td>--%>
                                <% if (ACLUtility.IsAccessible(ACLConsts.ViewOrdListContractAmount))
                                   {%>
                                <td>
                                    合同金额
                                </td>
                                <%} %>
                                <% if (ACLUtility.IsAccessible(ACLConsts.ViewOrdListSettlementAmount))
                                   {%>
                                <td>
                                    结算金额
                                </td>
                                <%} %>
                                <% if (ACLUtility.IsAccessible(ACLConsts.ViewOrdListTotalReceivedAmount))
                                   {%>
                                <td>
                                    累计已收
                                </td>
                                <%} %>
                                <% if (ACLUtility.IsAccessible(ACLConsts.ViewOrdListTotalNeedAmount))
                                   {%>
                                <td>
                                    累计应收
                                </td>
                                <%} %>
                                <td>
                                    <asp:LinkButton ID="Status" runat="server" Text="状态" CommandName="Status"></asp:LinkButton>
                                </td>
                                <td>
                                    跟踪记录
                                </td>
                                <td>
                                    订单说明
                                </td>
                                <td style="width:50px">
                                    操作
                                </td>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="gridrow">
                        <td>
                            <%#Container.ItemIndex + 1%>
                        </td>
                        <td>
                            <a href="OrderForm.aspx?ordid=<%#Eval("Order_Id") %>&ordno=<%#Eval("Order_No") %>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%#Eval("SourceNo") %>">
                                <%#Eval("Order_No") %></a>
                            <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Order_Id") %>' />
                        </td>
                        <td>
                            <%#Eval("CreatedDate") %>
                        </td>
                        <td>
                            <%#Eval("OrderMan") %>
                        </td>
                        <%--<td>
                            <%#Eval("CustomerCompanyName")%>
                        </td>--%>
                        <td>
                            <%#Eval("CustomerContactName")%>
                        </td>
                        <%--<td>
                            <%#Eval("CustomerPhone1")%>/<%#Eval("CustomerPhone2")%>
                        </td>--%>
                        <% if (ACLUtility.IsAccessible(ACLConsts.ViewOrdListContractAmount))
                           {%>
                        <td>
                            <asp:Label ID="lblContractAmount" runat="server"></asp:Label>
                        </td>
                        <%} %>
                        <% if (ACLUtility.IsAccessible(ACLConsts.ViewOrdListSettlementAmount))
                           {%>
                        <td>
                            <asp:Label ID="lblSettlementAmount" runat="server"></asp:Label>
                        </td>
                        <%} %>
                        <% if (ACLUtility.IsAccessible(ACLConsts.ViewOrdListTotalReceivedAmount))
                           {%>
                        <td>
                            <asp:Label ID="lblReceivedAmount" runat="server"></asp:Label>
                        </td>
                        <%} %>
                        <% if (ACLUtility.IsAccessible(ACLConsts.ViewOrdListTotalNeedAmount))
                           {%>
                        <td>
                            <asp:Label ID="lblNeedAmount" runat="server"></asp:Label>
                        </td>
                        <%} %>
                        <td>
                            <%#Eval("Status")%>
                        </td>
                        <td>
                            <uc1:FollowUpTop3UserControl ID="followUpTop3UserControl" runat="server" />
                        </td>
                        <td>
                            <%#Eval("OrderIntro") %>
                        </td>
                        <td>
                            <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="gridrowalt">
                        <td>
                            <%#Container.ItemIndex + 1%>
                        </td>
                        <td>
                            <a href="OrderForm.aspx?ordid=<%#Eval("Order_Id") %>&ordno=<%#Eval("Order_No") %>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%#Eval("SourceNo") %>">
                                <%#Eval("Order_No") %></a>
                            <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Order_Id") %>' />
                        </td>
                        <td>
                            <%#Eval("CreatedDate") %>
                        </td>
                        <td>
                            <%#Eval("OrderMan") %>
                        </td>
                        <%--<td>
                            <%#Eval("CustomerCompanyName")%>
                        </td>--%>
                        <td>
                            <%#Eval("CustomerContactName")%>
                        </td>
                        <%--<td>
                            <%#Eval("CustomerPhone1")%>/<%#Eval("CustomerPhone2")%>
                        </td>--%>
                        <% if (ACLUtility.IsAccessible(ACLConsts.ViewOrdListContractAmount))
                           {%>
                        <td>
                            <asp:Label ID="lblContractAmount" runat="server"></asp:Label>
                        </td>
                        <%} %>
                        <% if (ACLUtility.IsAccessible(ACLConsts.ViewOrdListSettlementAmount))
                           {%>
                        <td>
                            <asp:Label ID="lblSettlementAmount" runat="server"></asp:Label>
                        </td>
                        <%} %>
                        <% if (ACLUtility.IsAccessible(ACLConsts.ViewOrdListTotalReceivedAmount))
                           {%>
                        <td>
                            <asp:Label ID="lblReceivedAmount" runat="server"></asp:Label>
                        </td>
                        <%} %>
                        <% if (ACLUtility.IsAccessible(ACLConsts.ViewOrdListTotalNeedAmount))
                           {%>
                        <td>
                            <asp:Label ID="lblNeedAmount" runat="server"></asp:Label>
                        </td>
                        <%} %>
                        <td>
                            <%#Eval("Status")%>
                        </td>
                        <td>
                            <uc1:FollowUpTop3UserControl ID="followUpTop3UserControl" runat="server" />
                        </td>
                        <td>
                            <%#Eval("OrderIntro") %>
                        </td>
                        <td>
                            <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                <tr>
                    <td colspan="13" align="right">
                <b>合同金额总计:</b><asp:Label ID="lblTotalContract" runat="server"></asp:Label>
                <b>结算金额总计:</b><asp:Label ID="lblTotalST" runat="server"></asp:Label>
                <b>已收金额总计:</b><asp:Label ID="lblTotalRec" runat="server"></asp:Label>
                <b>应收金额总计:</b><asp:Label ID="lblTotalNeed" runat="server"></asp:Label>
                    </td>
                </tr>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
            <div>

            </div>
        </div>
        <div class="generaldiv">
        </div>
    </fieldset>
</asp:Content>
