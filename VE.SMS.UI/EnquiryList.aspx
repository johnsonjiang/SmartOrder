<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="EnquiryList.aspx.cs" Inherits="VE.SMS.UI.EnquiryList" %>

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
        <legend>咨询单查询 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        咨询单号:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txtEnqNo" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td width="16%" nowrap="nowrap" align="right">
                        客户公司名称:
                    </td>
                    <td width="34%">
                        <asp:DropDownList ID="ddlCompany" runat="server" Width="254px"></asp:DropDownList>
                        
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" align="right">
                        客户联系人:
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlContact" runat="server" Width="254px"></asp:DropDownList>
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
                    <td align="right">
                        咨询单状态:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEnqStatus" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        咨询单负责人:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEnqMan" runat="server" Width="254px"></asp:DropDownList>
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
                        <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="查询咨询单" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>咨询单汇总 </legend>
        <asp:Button ID="btnCreate" runat="server" Text="新建咨询单" CssClass="button" OnClick="btnCreate_Click" />
        <div class="generaldiv">
            <asp:Repeater ID="rpEnqList" runat="server" 
                OnItemDataBound="rpEnqList_ItemDataBound" onitemcommand="rpEnqList_ItemCommand">
                <HeaderTemplate>
                    <table class="listtable">
                        <tbody>
                            <tr class="gridheader">
                                <td>
                                    序号
                                </td>
                                <td>
                                   <asp:LinkButton ID="Enquiry_No" runat="server" Text="咨询单号" CommandName="Enquiry_No"></asp:LinkButton>
                                </td>
                                <td>
                                   <asp:LinkButton ID="CreatedDate" runat="server" Text="录入日期" CommandName="CreatedDate"></asp:LinkButton> 
                                </td>
                                <td>
                                    <asp:LinkButton ID="EnqMan" runat="server" Text="咨询单负责人" CommandName="EnqMan"></asp:LinkButton> 
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
                                    摘要
                                </td>
                                <td>
                                    <asp:LinkButton ID="Status" runat="server" Text="状态" CommandName="Status"></asp:LinkButton> 
                                </td>
                                <td>
                                    跟踪记录
                                </td>
                                <td>
                                    测量单
                                </td>
                                <td>
                                    细化单
                                </td>
                                <td>
                                    报价单
                                </td>
                                <td style="width:90px">
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
                            <a href="EnquiryForm.aspx?enqid=<%#Eval("Enquiry_Id")%>&enqno=<%#Eval("Enquiry_No") %>">
                                <%#Eval("Enquiry_No") %></a>
                                <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Enquiry_Id") %>' />
                        </td>
                        <td>
                            <%#Convert.ToDateTime(Eval("CreatedDate")).ToString("yyyy-MM-dd")%>
                        </td>
                        <td>
                            <%#Eval("EnqMan") %>
                        </td>
                        <%--<td>
                            <%#Eval("CustomerCompanyName")%>
                        </td>--%>
                        <td>
                            <%#Eval("CustomerContactName")%>
                        </td>
                        <%--<td>
                            <%#Eval("CustomerPhone1")%>/<%#Eval("CustomerPhone2")%></td>--%>
                        <td>
                            <%#Eval("Summary")%>
                        </td>
                        <td>
                            <%#Eval("Status")%>
                        </td>
                        <td>
                            <uc1:FollowUpTop3UserControl ID="followUpTop3UserControl" runat="server" />
                        </td>
                        <td>
                            <asp:Repeater ID="rpSurvey" runat="server">
                            <HeaderTemplate>
                                <ol>
                            </HeaderTemplate>
                                <ItemTemplate>
                                   <li class="list">
                                        <a href='SurveyForm.aspx?svid=<%#Eval("Survey_Id") %>&svno=<%#Eval("Survey_No") %>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%#Eval("SourceNo") %>'><%#Eval("Survey_No") %></a> 
                                        <%#Eval("Status") %>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ol>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                        <td>
                            <asp:Repeater ID="rpRefinement" runat="server">
                                                        <HeaderTemplate>
                                <ol>
                            </HeaderTemplate>
                                <ItemTemplate>
                                   <li class="list">
                                        <a href='RefineForm.aspx?refid=<%#Eval("Refine_Id") %>&refno=<%#Eval("Refine_No") %>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%#Eval("SourceNo") %>'><%#Eval("Refine_No") %></a> 
                                        <%#Eval("Status") %>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                </ol>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                        <td>
                            <asp:Repeater ID="rpQuoation" runat="server">
                                                        <HeaderTemplate>
                                <ol>
                            </HeaderTemplate>
                                <ItemTemplate>
                                   <li class="list">
                                        <a href='QuotationForm.aspx?quoid=<%#Eval("Quotation_Id") %>&quono=<%#Eval("Quotation_No") %>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%#Eval("SourceNo") %>'><%#Eval("Quotation_No") %></a> 
                                        <%#Eval("Status") %>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                </ol>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                        <td>
                            <asp:LinkButton ID="btnGenerateOrder" runat="server" Text="生成订单" CssClass="button" CommandName="GenerateOrder" />
                            <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="gridrow">
                        <td>
                            <%#Container.ItemIndex + 1%>
                        </td>
                        <td>
                            <a href="EnquiryForm.aspx?enqid=<%#Eval("Enquiry_Id")%>&enqno=<%#Eval("Enquiry_No") %>">
                                <%#Eval("Enquiry_No") %></a>
                                <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Enquiry_Id") %>' />
                        </td>
                        <td>
                            <%#Convert.ToDateTime(Eval("CreatedDate")).ToString("yyyy-MM-dd")%>
                        </td>
                        <td>
                            <%#Eval("EnqMan") %>
                        </td>
                        <%--<td>
                            <%#Eval("CustomerCompanyName")%>
                        </td>--%>
                        <td>
                            <%#Eval("CustomerContactName")%>
                        </td>
                        <%--<td>
                            <%#Eval("CustomerPhone1")%>/<%#Eval("CustomerPhone2")%></td>--%>
                        <td>
                            <%#Eval("Summary")%>
                        </td>
                        <td>
                            <%#Eval("Status")%>
                        </td>
                        <td>
                            <uc1:FollowUpTop3UserControl ID="followUpTop3UserControl" runat="server" />
                        </td>
                        <td>
                            <asp:Repeater ID="rpSurvey" runat="server">
                            <HeaderTemplate>
                                <ol>
                            </HeaderTemplate>
                                <ItemTemplate>
                                   <li class="list">
                                        <a href='SurveyForm.aspx?svid=<%#Eval("Survey_Id") %>&svno=<%#Eval("Survey_No") %>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%#Eval("SourceNo") %>'><%#Eval("Survey_No") %></a> 
                                        <%#Eval("Status") %>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ol>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                        <td>
                            <asp:Repeater ID="rpRefinement" runat="server">
                                                        <HeaderTemplate>
                                <ol>
                            </HeaderTemplate>
                                <ItemTemplate>
                                   <li class="list">
                                        <a href='RefineForm.aspx?refid=<%#Eval("Refine_Id") %>&refno=<%#Eval("Refine_No") %>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%#Eval("SourceNo") %>'><%#Eval("Refine_No") %></a> 
                                        <%#Eval("Status") %>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                </ol>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                        <td>
                            <asp:Repeater ID="rpQuoation" runat="server">
                                                        <HeaderTemplate>
                                <ol>
                            </HeaderTemplate>
                                <ItemTemplate>
                                   <li class="list">
                                        <a href='QuotationForm.aspx?quoid=<%#Eval("Quotation_Id") %>&quono=<%#Eval("Quotation_No") %>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%#Eval("SourceNo") %>'><%#Eval("Quotation_No") %></a> 
                                        <%#Eval("Status") %>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                </ol>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                        <td>
                            <asp:LinkButton ID="btnGenerateOrder" runat="server" Text="生成订单" CssClass="button" CommandName="GenerateOrder" />
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
</asp:Content>
