<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="DeliveryList.aspx.cs" Inherits="VE.SMS.UI.DeliveryList" %>

<%@ Register Src="_UserControl/FollowUpTop3UserControl.ascx" TagName="FollowUpTop3UserControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" media="all" type="text/css" href="Styles/jquery-ui.css" />
    <script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
    <script language="javascript" type="text/javascript" src="Scripts/jquery-ui.min.js"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#<% =txtBeginDate.ClientID%>").datepicker();
            $("#<% =txtEndDate.ClientID%>").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset style="height: 100%;">
        <legend>送货安装单查询 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        送货安装单号:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txtDeliveryNo" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
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
                        送货人：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDeliveryDriverMan" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        安装人:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlInstallMan" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        送货安装单状态:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDeliveryStatus" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        订单号:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrderNo" runat="server" CssClass="text" Width="254px"></asp:TextBox>
                        
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
                        
                <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="查询送货安装单" OnClick="btnSearch_Click" />
                        
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>送货安装单汇总 </legend>
        <div class="generaldiv">
            <asp:Repeater ID="rpDeliveryList" runat="server" OnItemCommand="rpDeliveryList_ItemCommand"
                OnItemDataBound="rpDeliveryList_ItemDataBound">
                <HeaderTemplate>
                    <table class="listtable">
                        <tbody>
                            <tr class="gridheader">
                                <td>
                                    序号
                                </td>
                                <td>
                                    <asp:LinkButton ID="Delivery_No" runat="server" Text="送货安装单号" CommandName="Delivery_No"></asp:LinkButton>
                                </td>
                                <%--<td>
                                    <asp:LinkButton ID="CustomerCompanyName" runat="server" Text="公司名" CommandName="CustomerCompanyName"></asp:LinkButton>
                                </td>--%>
                                <td>
                                    <asp:LinkButton ID="Order_No" runat="server" Text="订单号" CommandName="Order_No"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="CustomerContactName" runat="server" Text="客户联系人" CommandName="CustomerContactName"></asp:LinkButton>
                                </td>
                                <%--<td>
                                    电话
                                </td>--%>
                                <td>
                                    <asp:LinkButton ID="Status" runat="server" Text="状态" CommandName="Status"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="DeliveryDriverMan" runat="server" Text="送货人" CommandName="DeliveryDriverMan"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="ExpectedDeliveryDate" runat="server" Text="预定送货日期" CommandName="ExpectedDeliveryDate"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="InstallMan" runat="server" Text="安装人" CommandName="InstallMan"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="InstallDate" runat="server" Text="安装日期" CommandName="InstallDate"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="InsteadOfSettlement" runat="server" Text="是否代替结算单" CommandName="InsteadOfSettlement"></asp:LinkButton>
                                </td>
                                <td>
                                    跟踪记录
                                </td>
                                <td style="width: 50px">
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
                            <a href='DeliveryForm.aspx?dlid=<%#Eval("Delivery_Id")%>&dlno=<%#Eval("Delivery_No")%>&sourceno=<%#Eval("Order_No")%>&sourcetype=O'>
                                <%#Eval("Delivery_No") %></a>
                            <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Delivery_Id") %>' />
                        </td>
                        <%--<td>
                            <%#Eval("CustomerCompanyName")%>
                        </td>--%>
                        <td>
                                    <%#Eval("Order_No") %>
                                </td>
                        <td>
                            <%#Eval("CustomerContactName")%>
                        </td>
                        <%--<td>
                            <%#Eval("CustomerPhone1")%>/<%#Eval("CustomerPhone2")%>
                        </td>--%>
                        <td>
                            <%#Eval("Status")%>
                        </td>
                        <td>
                            <%#Eval("DeliveryDriverMan")%>
                        </td>
                        <td>
                            <%#Eval("ExpectedDeliveryDate")%>
                        </td>
                        <td>
                            <%#Eval("InstallMan")%>
                        </td>
                        <td>
                            <%#Eval("InstallDate")%>
                        </td>
                        <td>
                            <%#string.Equals(Eval("InsteadOfSettlement").ToString(),"True", StringComparison.OrdinalIgnoreCase) ? "是":"否"%>
                        </td>
                        <td>
                            <uc1:FollowUpTop3UserControl ID="followUpTop3UserControl" runat="server" />
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
                            <a href='DeliveryForm.aspx?dlid=<%#Eval("Delivery_Id")%>&dlno=<%#Eval("Delivery_No")%>&sourceno=<%#Eval("Order_No")%>&sourcetype=O'>
                                <%#Eval("Delivery_No") %></a>
                            <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Delivery_Id") %>' />
                        </td>
                        <%--<td>
                            <%#Eval("CustomerCompanyName")%>
                        </td>--%>
                        <td>
                                    <%#Eval("Order_No") %>
                                </td>
                        <td>
                            <%#Eval("CustomerContactName")%>
                        </td>
                        <%--<td>
                            <%#Eval("CustomerPhone1")%>/<%#Eval("CustomerPhone2")%>
                        </td>--%>
                        <td>
                            <%#Eval("Status")%>
                        </td>
                        <td>
                            <%#Eval("DeliveryDriverMan")%>
                        </td>
                        <td>
                            <%#Eval("ExpectedDeliveryDate")%>
                        </td>
                        <td>
                            <%#Eval("InstallMan")%>
                        </td>
                        <td>
                            <%#Eval("InstallDate")%>
                        </td>
                        <td>
                            <%#string.Equals(Eval("InsteadOfSettlement").ToString(),"True", StringComparison.OrdinalIgnoreCase) ? "是":"否"%>
                        </td>
                        <td>
                            <uc1:FollowUpTop3UserControl ID="followUpTop3UserControl" runat="server" />
                        </td>
                        <td>
                            <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="generaldiv">
        </div>
    </fieldset>
</asp:Content>
