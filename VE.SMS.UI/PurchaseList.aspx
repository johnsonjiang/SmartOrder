<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="PurchaseList.aspx.cs" Inherits="VE.SMS.UI.PurchaseList" %>

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
        <legend>采购单查询 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        采购单号:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txtPurchaseId" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td align="right">
                        采购单状态:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPurchaseStatus" runat="server" CssClass="dropdownlist">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" align="right">
                        订单负责人:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOrdMan" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                    <td width="16%" nowrap="nowrap" align="right">
                        开加工单人员:
                    </td>
                    <td width="34%">
                        <asp:DropDownList ID="ddlMachMan" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="16%" nowrap="nowrap" align="right">
                        采购人员:
                    </td>
                    <td width="34%">
                        <asp:DropDownList ID="ddlPurchaseMan" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                    <td width="16%" nowrap="nowrap" align="right">
                        申请采购人员:
                    </td>
                    <td width="34%">
                        <asp:DropDownList ID="ddlApplyPurchaseMan" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="16%" nowrap="nowrap" align="right">
                        开加工表人员:
                    </td>
                    <td width="34%">
                        <asp:DropDownList ID="ddlMachTableMan" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                    <td width="16%" nowrap="nowrap" align="right">
                        批准人:
                    </td>
                    <td width="34%">
                        <asp:DropDownList ID="ddlApproveMan" runat="server" Width="254px">
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
                    <td align="right">
                    </td>
                    <td>
                    </td>
                    <td align="right">
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="查询采购单" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>采购单汇总 </legend>
        <asp:Button ID="btnCreate" runat="server" Text="新建采购单" CssClass="button" OnClick="btnCreate_Click" />
        <div class="generaldiv">
            <asp:Repeater ID="rpPurchaseList" runat="server" OnItemCommand="rpPurchaseList_ItemCommand"
                OnItemDataBound="rpPurchaseList_ItemDataBound">
                <HeaderTemplate>
                    <table class="listtable">
                        <tbody>
                            <tr class="gridheader">
                                <td>
                                    序号
                                </td>
                                <td>
                                    <asp:LinkButton ID="Purchase_No" runat="server" Text="采购单号" CommandName="Purchase_No"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="SourceNo" runat="server" Text="源单号" CommandName="SourceNo"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="PurchaseMan" runat="server" Text="采购人员" CommandName="PurchaseMan"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="PurchaseApplyMan" runat="server" Text="申请人" CommandName="PurchaseApplyMan"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="ApproveMan" runat="server" Text="批准人" CommandName="ApproveMan"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="ApplyPurchaseDate" runat="server" Text="申请日期" CommandName="ApplyPurchaseDate"></asp:LinkButton>
                                    <td>
                                        <asp:LinkButton ID="ExpectedCompleteDate" runat="server" Text="预定完成日期" CommandName="ExpectedCompleteDate"></asp:LinkButton>
                                    </td>
                                </td>
                                <td>
                                    <asp:LinkButton ID="Status" runat="server" Text="状态" CommandName="Status"></asp:LinkButton>
                                </td>
                                <td>
                                    跟踪记录
                                </td>
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
                            <a href="PurchaseForm.aspx?poid=<%#Eval("Purchase_Id") %>&pono=<%#Eval("Purchase_No") %>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%#Eval("SourceNo") %>">
                                <%#Eval("Purchase_No") %></a>
                            <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Purchase_Id") %>' />
                        </td>
                        <td>
                            <%#Eval("SourceNo")%>
                        </td>
                        <td>
                            <%#Eval("PurchaseMan")%>
                        </td>
                        <td>
                            <%#Eval("PurchaseApplyMan")%>
                        </td>
                        <td>
                            <%#Eval("ApproveMan")%>
                        </td>
                        <td>
                            <%#Eval("ApplyPurchaseDate")%>
                        </td>
                        <td>
                            <%#Eval("ExpectedCompleteDate")%>
                        </td>
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
                            <a href="PurchaseForm.aspx?poid=<%#Eval("Purchase_Id") %>&pono=<%#Eval("Purchase_No") %>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%#Eval("SourceNo") %>">
                                <%#Eval("Purchase_No") %></a>
                            <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Purchase_Id") %>' />
                        </td>
                        <td>
                            <%#Eval("SourceNo")%>
                        </td>
                        <td>
                            <%#Eval("PurchaseMan")%>
                        </td>
                        <td>
                            <%#Eval("PurchaseApplyMan")%>
                        </td>
                        <td>
                            <%#Eval("ApproveMan")%>
                        </td>
                        <td>
                            <%#Eval("ApplyPurchaseDate")%>
                        </td>
                        <td>
                            <%#Eval("ExpectedCompleteDate")%>
                        </td>
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
