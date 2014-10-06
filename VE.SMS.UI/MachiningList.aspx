<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="MachiningList.aspx.cs" Inherits="VE.SMS.UI.MachiningList" %>

<%@ Register Src="_UserControl/FollowUpTop3UserControl.ascx" TagName="FollowUpTop3UserControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#<% =txtExpectedDateBegin.ClientID%>").datepicker();
            $("#<% =txtExpectedDateEnd.ClientID%>").datepicker();
        });
    </script>
    <div class="generaldiv">
        <fieldset style="height: 100%;">
            <legend>基本信息 </legend>
            <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
                <tbody>
                    <tr>
                        <td width="15%" nowrap="nowrap" align="right">
                            生产单号:
                        </td>
                        <td width="35%">
                            <asp:TextBox ID="txtMachinineId" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        </td>
                        <td align="right">
                            订单号:
                        </td>
                        <td>
                            <asp:TextBox ID="txtOrderId" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            开生产单人员:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCreator" runat="server" Width="258px">
                            </asp:DropDownList>
                        </td>
                        <td align="right" nowrap="nowrap">
                            加工人员:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMachMan" runat="server" Width="258px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            起始预定完成日期:
                        </td>
                        <td>
                            <asp:TextBox ID="txtExpectedDateBegin" runat="server" CssClass="text" Style="width: 254px"
                                ReadOnly="false"></asp:TextBox>
                        </td>
                        <td align="right">
                            截止预定完成日期:
                        </td>
                        <td>
                            <asp:TextBox ID="txtExpectedDateEnd" runat="server" CssClass="text" Width="254px"
                                ReadOnly="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" nowrap="nowrap">
                            开加工表人员:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMachTableMan" runat="server" Width="258px">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            生产单状态:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMachiningStatus" runat="server" CssClass="dropdownlist">
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
                            <asp:Button ID="btnSearch" runat="server" Text="查询生产单" CssClass="button" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </fieldset>
    </div>
    <div class="generaldiv">
        <fieldset style="height: 100%;">
            <legend>生产单汇总 </legend>
            <div class="generaldiv">
                <asp:Repeater ID="rpMachiningList" runat="server" OnItemCommand="rpMachiningList_ItemCommand"
                    OnItemDataBound="rpMachiningList_ItemDataBound">
                    <HeaderTemplate>
                        <table class="listtable">
                            <tbody>
                                <tr class="gridheader">
                                    <td>
                                        序号
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="Mach_No" runat="server" Text="生产单号" CommandName="Mach_No"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="SourceNo" runat="server" Text="订单号" CommandName="SourceNo"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButton1" runat="server" Text="客户联系人" CommandName="CustomerContactName"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="MachCreateMan" runat="server" Text="开加工单人员" CommandName="MachCreateMan"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="ProcessCreateMan" runat="server" Text="开加工表人员" CommandName="ProcessCreateMan"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="MachMan" runat="server" Text="加工人员" CommandName="MachMan"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="ApplyDate" runat="server" Text="申请加工日期" CommandName="ApplyDate"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="ExpectedCompleteDate" runat="server" Text="预定完成日期" CommandName="ExpectedCompleteDate"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="Status" runat="server" Text="状态" CommandName="Status"></asp:LinkButton>
                                    </td>
                                    <td>
                                        跟踪记录
                                    </td>
                                    <td>
                                        生产单说明
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
                                <a href="MachiningForm.aspx?machid=<%#Eval("Mach_Id") %>&machno=<%#Eval("Mach_No") %>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%#Eval("SourceNo") %>">
                                    <%#Eval("Mach_No")%></a>
                                <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Mach_Id") %>' />
                            </td>
                            <td>
                                <%#Eval("SourceNo") %>
                            </td>
                            <td>
                                <%#Eval("CustomerContactName") %>
                            </td>
                            <td>
                                <%#Eval("MachCreateMan")%>
                            </td>
                            <td>
                                <%#Eval("ProcessCreateMan")%>
                            </td>
                            <td>
                                <%#Eval("MachMan")%>
                            </td>
                            <td>
                                <%#Eval("ApplyDate")%>
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
                                <%#Eval("MachIntro")%>
                            </td>
                            <td>
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
                                <a href="MachiningForm.aspx?machid=<%#Eval("Mach_Id") %>&machno=<%#Eval("Mach_No") %>&sourcetype=<%#Eval("SourceType") %>&sourceno=<%#Eval("SourceNo") %>">
                                    <%#Eval("Mach_No")%></a>
                                <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Mach_Id") %>' />
                            </td>
                            <td>
                                <%#Eval("SourceNo") %>
                            </td>
                            <td>
                                <%#Eval("CustomerContactName") %>
                            </td>
                            <td>
                                <%#Eval("MachCreateMan")%>
                            </td>
                            <td>
                                <%#Eval("ProcessCreateMan")%>
                            </td>
                            <td>
                                <%#Eval("MachMan")%>
                            </td>
                            <td>
                                <%#Eval("ApplyDate")%>
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
                                <%#Eval("MachIntro")%>
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
    </div>
    <div class="generaldiv">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterConter" runat="server">
</asp:Content>
