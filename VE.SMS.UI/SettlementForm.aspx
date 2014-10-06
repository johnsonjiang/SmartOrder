<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="SettlementForm.aspx.cs" Inherits="VE.SMS.UI.SettlementForm" %>

<%@ Register Src="_UserControl/CADRefinementControl.ascx" TagName="CADRefinementControl"
    TagPrefix="uc1" %>
<%@ Register Src="_UserControl/CustomerDrawingControl.ascx" TagName="CustomerDrawingControl"
    TagPrefix="uc1" %>
<%@ Register Src="_UserControl/SurveyControl.ascx" TagName="SurveyControl" TagPrefix="uc1" %>
<%@ Register Src="_UserControl/CADFileListControl.ascx" TagName="CADFileListControl"
    TagPrefix="uc1" %>
<%@ Register Src="_UserControl/FollowUpControl.ascx" TagName="FollowUpControl" TagPrefix="uc1" %>
<%@ Register Src="_UserControl/CustomerInfoControl.ascx" TagName="CustomerInfoControl"
    TagPrefix="uc1" %>
<%@ Register Src="_UserControl/LineItemsControl.ascx" TagName="LineItemsControl"
    TagPrefix="uc1" %>
<%@ Register Src="_UserControl/QuotationControl.ascx" TagName="QuotationControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#<% =txtCreatedDate.ClientID%>").datepicker();
            $("#<% =txtDeliveryDate.ClientID%>").datepicker();
        });
    </script>
    <fieldset style="height: 100%;">
        <legend>基本信息 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td align="right">
                        结算单号:
                    </td>
                    <td>
                        <%=this.StNo %>
                    </td>
                    <td align="right">
                        日期:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCreatedDate" runat="server" CssClass="text" Enabled="false"
                            Style="width: 254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        送货日期:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDeliveryDate" runat="server" CssClass="text" Width="254px" ReadOnly="false"></asp:TextBox>
                    </td>
                    <td align="right">
                        结算单人员:
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlSettlementMan" runat="server" Width="254px"></asp:DropDownList>
                        
                        <asp:RequiredFieldValidator ID="rq" runat="server" ErrorMessage="*" ForeColor="Red"  Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="ddlSettlementMan" ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        相关订单:
                    </td>
                    <td>
                        <asp:HyperLink ID="lnkOrderId" runat="server"></asp:HyperLink>
                    </td>
                    <td align="right">
                        结算单状态:
                    </td>
                    <td><%=this.ddlSettlementStatus.SelectedItem.Text%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        送货单列表:
                    </td>
                    <td>
                        <asp:CheckBoxList ID="cblDeliveryList" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="cblDeliveryList_SelectedIndexChanged" AutoPostBack="true"
                            RepeatColumns="4">
                        </asp:CheckBoxList>
                        <asp:linkbutton ID="btnImport" runat="server" Text="导入" OnClick="btnImport_Click"></asp:linkbutton>
                    </td>
                    <td align="right">
                        结算位置:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSettleLocation" runat="server" CssClass="text" Width="254px"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>客户信息</legend>
        <uc1:CustomerInfoControl ID="customerInfoControl" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>结算内容
        </legend>
        <div class="generaldiv">
        <uc1:LineItemsControl ID="LineItemsControl1" runat="server" />
           
        </div>
        <div class="generaldiv">
            <table>
                <tr class="gridrowadd">
                    <td>
                        材料金额：
                    </td>
                    <td>
                        <asp:Label ID="lblMaterialAmount" runat="server"></asp:Label>
                    </td>
                    <td>
                        加工金额：
                    </td>
                    <td>
                        <asp:Label ID="lblMachAmount" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="gridrowadd">
                    <td>
                        安装金额：
                    </td>
                    <td>
                        <asp:Label ID="lblInstallAmount" runat="server"></asp:Label>
                    </td>
                                        <td>
                        本单金额：
                    </td>
                    <td>
                        <asp:TextBox ID="txtTotalAmount" runat="server" Text="" CssClass="text" Width="90%" ValidationGroup="Page"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red"  Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="txtTotalAmount" ></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"  Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtTotalAmount" Type="Double"  ValidationGroup="Page"></asp:CompareValidator>
                    </td>
                </tr>
                <tr class="gridrowadd">

                    <td>
                        首次应收：
                    </td>
                    <td>
                        <asp:TextBox ID="txtReceivedFirst" runat="server" Text="" CssClass="text" Width="90%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red"  Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="txtReceivedFirst" ></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"  Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtReceivedFirst" Type="Double"  ValidationGroup="Page"></asp:CompareValidator>
                    </td>
                         <td>
                        已收金额：
                    </td>
                    <td>
                        <asp:TextBox ID="txtReceived" runat="server" Text="" CssClass="text" Width="90%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red"  Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="txtReceived" ></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"  Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtReceived" Type="Double"  ValidationGroup="Page"></asp:CompareValidator>
                    </td>
                </tr>
                
                <tr class="gridrowadd">
                    <td>
                        本次应收说明：
                    </td>
                    <td>
                        <asp:TextBox ID="txtBalanceIntro" runat="server" Text="30%首付" CssClass="text" Width="95%"></asp:TextBox>
                    </td>
                                        <td>
                        余额：
                    </td>
                    <td>
                        <asp:Label ID="lblEndBalance" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="gridrowadd">
                    <td>
                        累计总额：
                    </td>
                    <td>
                        <asp:Label ID="lblAccumulateAmount" runat="server"></asp:Label>
                        (此结算单及以前的结算单总金额)
                    </td>
                    <td>
                        累计已收：
                    </td>
                    <td>
                        <asp:Label ID="lblReceivableTotal" runat="server"></asp:Label>（此结算单及以前的日期的收款）
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="btnSaveAmount" runat="server" Text="保存金额" ValidationGroup="Page"
                            onclick="btnSaveAmount_Click"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>跟踪记录</legend>
        <div class="generaldiv">
            <div class="generaldiv">
                结算单状态:
                <asp:DropDownList ID="ddlSettlementStatus" runat="server" CssClass="dropdownlist">
                    
                </asp:DropDownList>
                <asp:Button ID="btnChangeStatus" runat="server" CssClass="button" Text="更改状态" OnClick="btnChangeStatus_Click" />
            </div>
            <div>
                <uc1:FollowUpControl ID="followUpControl" runat="server" />
            </div>
        </div>
    </fieldset>
    <div class="generaldiv">
        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="保存结算单" ValidationGroup="Page"
            onclick="btnSave_Click" />
        <asp:Button ID="btnPrint" runat="server" CssClass="button" Text="打印" OnClientClick="javascript:window.open('printout/settlementprintout.aspx');" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterConter" runat="server">
</asp:Content>
