<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="SettlementList.aspx.cs" Inherits="VE.SMS.UI.SettlementList" %>

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
        <legend>结算单查询 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        结算单号:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txtSettlementId" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td width="16%" nowrap="nowrap" align="right">
                        结算人员:
                    </td>
                    <td width="34%">
                    <asp:DropDownList ID="ddlSettlementMan" runat="server" Width="254px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        起始时间:
                    </td>
                    <td>
                        <asp:TextBox ID="txtBeginDate" runat="server" CssClass="text" Style="width: 254px" ReadOnly="false"></asp:TextBox>
                    </td>
                    <td align="right">
                        截止时间:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="text" Style="width: 254px" ReadOnly="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="16%" nowrap="nowrap" align="right">
                        订单号:
                    </td>
                    <td width="34%">
                        <asp:TextBox ID="txtOrderId" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td align="right">
                        结算单状态:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSettlementStatus" runat="server" CssClass="dropdownlist">
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
                        <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="查询结算单" 
                            onclick="btnSearch_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>结算单汇总 </legend>
        <div class="generaldiv">
            <asp:Repeater ID="rpSettlementList" runat="server" OnItemDataBound="rpSettlementList_ItemDataBound"
                OnItemCommand="rpSettlementList_ItemCommand">
                <HeaderTemplate>
                    <table class="listtable">
                        <tbody>
                            <tr class="gridheader">
                                <td>
                                    序号
                                </td>
                                <td>
                                    <asp:LinkButton ID="St_No" runat="server" Text="结算单号" CommandName="St_No"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="SourceNo" runat="server" Text="订单号" CommandName="SourceNo"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="CustomerContactName" runat="server" Text="客户联系人" CommandName="CustomerContactName"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="CreatedDate" runat="server" Text="录入日期" CommandName="CreatedDate"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="StMan" runat="server" Text="结算人员" CommandName="StMan"></asp:LinkButton>
                                </td>
                                <td>
                                    相关送货单
                                </td>
                                <td>
                                    <asp:LinkButton ID="TotalAmount" runat="server" Text="本单金额" CommandName="TotalAmount"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="FirstAmount" runat="server" Text="本次应收" CommandName="FirstAmount"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="AmountReceived" runat="server" Text="已收" CommandName="AmountReceived"></asp:LinkButton>
                                </td>
                                <td>
                                    余额
                                </td>
                                <td>
                                    <asp:LinkButton ID="Status" runat="server" Text="状态" CommandName="Status"></asp:LinkButton>
                                </td>
                                <td>
                                    跟踪记录
                                </td>
                                <td>操作</td>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="gridrow">
                        <td>
                            <%#Container.ItemIndex + 1%>
                        </td>
                        <td>
                            <a href='SettlementForm.aspx?stid=<%#Eval("St_Id")%>&stno=<%#Eval("St_No")%>&sourcetype=<%#Eval("SourceType")%>&sourceno=<%#Eval("SourceNo")%>'>
                                <%#Eval("St_No") %></a>
                                <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("St_Id") %>' />
                        </td>
                        <td>
                            <%#Eval("SourceNo")%>
                        </td>
                        <td>
                             <%#Eval("CustomerContactName")%>
                        </td>
                        <td>
                            <%#Convert.ToDateTime(Eval("CreatedDate")).ToString("yyyy-MM-dd") %>
                        </td>
                        <td>
                            <%#Eval("StMan") %>
                        </td>
                        <td>
                            <asp:Repeater ID="rpDelList" runat="server">
                                <HeaderTemplate>
                                    <ol>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li><%#Eval("Delivery_No") %></li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ol>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                        <td>
                            <%#Eval("TotalAmount")%>
                        </td>
                        <td>
                            <%#Eval("FirstAmount")%>
                        </td>
                        <td>
                            <%#Eval("AmountReceived")%>
                        </td>
                        <td>
                            <%#Convert.ToDouble(Eval("TotalAmount")) - Convert.ToDouble(Eval("AmountReceived"))%>
                        </td>
                        <td>
                            <%#Eval("Status")%>
                        </td>
                        <td>
                            <uc1:FollowUpTop3UserControl ID="followUpTop3UserControl" runat="server" />
                        </td>
                        <td><asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" /></td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="gridrowalt">
                        <td>
                            <%#Container.ItemIndex + 1%>
                        </td>
                        <td>
                            <a href='SettlementForm.aspx?stid=<%#Eval("St_Id")%>&stno=<%#Eval("St_No")%>&sourcetype=<%#Eval("SourceType")%>&sourceno=<%#Eval("SourceNo")%>'>
                                <%#Eval("St_No") %></a>
                                <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("St_Id") %>' />
                        </td>
                        <td>
                            <%#Eval("SourceNo")%>
                        </td>
                        <td>
                             <%#Eval("CustomerContactName")%>
                        </td>
                        <td>
                            <%#Convert.ToDateTime(Eval("CreatedDate")).ToString("yyyy-MM-dd") %>
                        </td>
                        <td>
                            <%#Eval("StMan") %>
                        </td>
                        <td>
                            <asp:Repeater ID="rpDelList" runat="server">
                                <HeaderTemplate>
                                    <ol>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li><%#Eval("Delivery_No") %></li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ol>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                        <td>
                            <%#Eval("TotalAmount")%>
                        </td>
                        <td>
                            <%#Eval("FirstAmount")%>
                        </td>
                        <td>
                            <%#Eval("AmountReceived")%>
                        </td>
                        <td>
                            <%#Convert.ToDouble(Eval("TotalAmount")) - Convert.ToDouble(Eval("AmountReceived"))%>
                        </td>
                        <td>
                            <%#Eval("Status")%>
                        </td>
                        <td>
                            <uc1:FollowUpTop3UserControl ID="followUpTop3UserControl" runat="server" />
                        </td>
                        <td><asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" /></td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    <tr>
                        <td colspan="14" align="right">
                            <b>结算单金额总计:</b><asp:Label ID="lblTotal" runat="server"></asp:Label>
                            <b>应收金额总计:</b><asp:Label ID="lblNeed" runat="server"></asp:Label>
                            <b>已收金额总计:</b><asp:Label ID="lblRec" runat="server"></asp:Label>
                            <b>余额总计:</b><asp:Label ID="lblEnd" runat="server"></asp:Label>
                        </td>
                    </tr>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </fieldset>
    <div class="generaldiv">
    </div>
</asp:Content>
