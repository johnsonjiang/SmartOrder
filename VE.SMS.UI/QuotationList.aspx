﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="QuotationList.aspx.cs" Inherits="VE.SMS.UI.QuotationList" %>

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
        <legend>报价单查询 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        报价单号:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txtQuotationNo" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td width="16%" nowrap="nowrap" align="right">
                        报价人员:
                    </td>
                    <td width="34%">
                        <asp:DropDownList ID="ddlQuoteMan" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" align="right">
                        咨询单/订单负责人:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEnqOrdMan" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        报价单状态:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlQuotationStatus" runat="server" CssClass="dropdownlist">
                        </asp:DropDownList>
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
                    <td width="16%" nowrap="nowrap" align="right">
                        客户公司名称:
                    </td>
                    <td width="34%">
                        <asp:DropDownList ID="ddlCompany" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                    <td nowrap="nowrap" align="right">
                        客户联系人:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlContact" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        电子邮箱:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
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
                        QQ:
                    </td>
                    <td>
                        <asp:TextBox ID="txtQQ" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td align="right">
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="查询报价单" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>报价单汇总 </legend>
        <div class="generaldiv">
            <asp:Repeater ID="rpQuotationList" runat="server" OnItemDataBound="rpQuotationList_ItemDataBound"
                OnItemCommand="rpQuotationList_ItemCommand">
                <HeaderTemplate>
                    <table class="listtable">
                        <tbody>
                            <tr class="gridheader">
                                <td>
                                    序号
                                </td>
                                <td>
                                    <asp:LinkButton ID="Quotation_No" runat="server" Text="报价单号" CommandName="Quotation_No"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="CreatedDate" runat="server" Text="录入日期" CommandName="CreatedDate"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="QuotationMan" runat="server" Text="报价人员" CommandName="QuotationMan"></asp:LinkButton>
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
                                <td>
                                    <asp:LinkButton ID="Status" runat="server" Text="状态" CommandName="Status"></asp:LinkButton>
                                </td>
                                <td>
                                    跟踪记录
                                </td>
                                <%--
                                <td>
                                    测量单
                                </td>
                                <td>
                                    细化单
                                </td>
                                <td>
                                    报价单
                                </td>--%>
                                <td>
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
                            <a href="QuotationForm.aspx?quoid=<%#Eval("Quotation_Id") %>&quono=<%#Eval("Quotation_No") %>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%#Eval("SourceNo") %>">
                                <%#Eval("Quotation_No") %></a>
                            <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Quotation_Id") %>' />
                        </td>
                        <td>
                            <%#Convert.ToDateTime(Eval("CreatedDate")).ToShortDateString()%>
                        </td>
                        <td>
                            <%#Eval("QuotationMan")%>
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
                        <td>
                            <%#Eval("Status")%>
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
                            <a href="QuotationForm.aspx?quoid=<%#Eval("Quotation_Id") %>&quono=<%#Eval("Quotation_No") %>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%#Eval("SourceNo") %>">
                                <%#Eval("Quotation_No") %></a>
                            <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Quotation_Id") %>' />
                        </td>
                        <td>
                            <%#Convert.ToDateTime(Eval("CreatedDate")).ToShortDateString()%>
                        </td>
                        <td>
                            <%#Eval("QuotationMan")%>
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
                        <td>
                            <%#Eval("Status")%>
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
    </fieldset>
    <div class="generaldiv">
    </div>
</asp:Content>