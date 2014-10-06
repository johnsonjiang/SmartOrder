<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="DeliveryForm.aspx.cs" Inherits="VE.SMS.UI.DeliveryForm" %>

<%@ Register Src="_UserControl/SurveyControl.ascx" TagName="SurveyControl" TagPrefix="uc1" %>
<%@ Register Src="_UserControl/CADRefinementControl.ascx" TagName="CADRefinementControl"
    TagPrefix="uc1" %>
<%@ Register Src="_UserControl/CustomerDrawingControl.ascx" TagName="CustomerDrawingControl"
    TagPrefix="uc1" %>
<%@ Register Src="_UserControl/EnquiryImageControl.ascx" TagName="EnquiryImageControl"
    TagPrefix="uc1" %>
<%@ Register Src="_UserControl/FollowUpControl.ascx" TagName="FollowUpControl" TagPrefix="uc1" %>
<%@ Register Src="_UserControl/QuotationControl.ascx" TagName="QuotationControl"
    TagPrefix="uc1" %>
<%@ Register Src="_UserControl/CustomerInfoControl.ascx" TagName="CustomerInfoControl"
    TagPrefix="uc1" %>
<%@ Register Src="_UserControl/LineItemsControl.ascx" TagName="LineItemsControl"
    TagPrefix="uc1" %>
<%@ Register Src="_UserControl/FooterIntroControl.ascx" TagName="FooterIntroControl"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#<% =txtCreatedDate.ClientID%>").datepicker();
            $("#<% =txtExpectDeliveryDate.ClientID%>").datepicker();
            $("#<% =txtRealDelDate.ClientID%>").datepicker();
            $("#<% =txtInstallDate.ClientID %>").datepicker();
            if ($("#chkInsteadSettlement").attr("checked") == true) {
                $("#divAmount").show();
            }
            else {
                $("#divAmount").hide();
            }

            $("#chkInsteadSettlement").click(function () {
                if ($("#chkInsteadSettlement").attr("checked") == true) {
                    $("#divAmount").show();
                }
                else {
                    $("#divAmount").hide();
                }
            });

        });
    </script>
    <fieldset style="height: 100%;">
        <legend>基本信息 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        送货安装号:
                    </td>
                    <td width="35%">
                        <%=this.DeliveryNo %>
                    </td>
                    <td align="right">
                        日期:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCreatedDate" runat="server" CssClass="text" Width="254px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        订单销售人员:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSalesMan" runat="server" Width="254px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rq" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="ddlSalesMan"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        相关订单:
                    </td>
                    <td>
                        <asp:HyperLink ID="lnkOrder" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        送货安装单创建人:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDelCreateMan" runat="server" Width="254px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="ddlDelCreateMan"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        生产单列表:
                    </td>
                    <td>
                        <asp:CheckBoxList ID="cblMach" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
                        </asp:CheckBoxList>
                        <asp:LinkButton ID="btnImport" runat="server" Text="导入加工项目统计" OnClick="btnImport_Click"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        送货安装单状态:
                    </td>
                    <td>
                        <%=this.ddlDeliveryStatus.SelectedItem.Text %>
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <fieldset style="height: 100%">
        <legend>客户信息 </legend>
        <uc1:CustomerInfoControl ID="customerInfoControl" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>送货</legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        送货方式：
                    </td>
                    <td width="35%">
                        <asp:DropDownList ID="ddlDeliveryMethod" runat="server" Width="254px">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        送货说明:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDelIntro" runat="server" CssClass="text" Width="254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        司机/送货人:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txtDeliveryDriverMan" runat="server" CssClass="text" Width="254px"></asp:TextBox>
                    </td>
                    <td align="right">
                        司机电话:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDelPhone" runat="server" CssClass="text" Width="254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        车辆类型:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCarType" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td align="right">
                        送货地址:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDeliveryToAddress" runat="server" CssClass="text" Width="254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        预定送货日期:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txtExpectDeliveryDate" runat="server" CssClass="text" Width="254px"
                            ReadOnly="false"></asp:TextBox>
                    </td>
                    <td width="15%" nowrap="nowrap" align="right">
                        实际送货日期:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txtRealDelDate" runat="server" CssClass="text" Width="254px" ReadOnly="false"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>安装</legend>
        <div class="generaldiv">
            <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
                <tbody>
                    <tr>
                        <td width="15%" nowrap="nowrap" align="right">
                        </td>
                        <td width="35%">
                            <asp:CheckBox ID="chkProvideInstall" runat="server" Text="提供安装" />
                        </td>
                        <td align="right">
                            安装类型:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlInstallType" runat="server" Width="254px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            安装说明:
                        </td>
                        <td>
                            <asp:TextBox ID="txtInstallIntro" runat="server" CssClass="text" Width="254px"></asp:TextBox>
                        </td>
                        <td align="right">
                            安装人:
                        </td>
                        <td>
                            <asp:TextBox ID="txtInstallMan" runat="server" CssClass="text" Width="254px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            电话:
                        </td>
                        <td>
                            <asp:TextBox ID="txtInstallPhone" runat="server" CssClass="text" Width="254px"></asp:TextBox>
                        </td>
                        <td align="right">
                            安装日期:
                        </td>
                        <td>
                            <asp:TextBox ID="txtInstallDate" runat="server" CssClass="text" Width="254px" ReadOnly="false"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>送货内容</legend>
        <div class="generaldiv">
            <asp:CheckBox ID="chkInsteadSettlement" runat="server" Text="是否代替结算单" ClientIDMode="Static"/>
        </div>
        <div class="generaldiv">
            <uc1:LineItemsControl ID="lineItemControl" runat="server" />
        </div>

            <div class="generaldiv" id="divAmount" style="display:none">
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
                            <asp:TextBox ID="txtTotalAmount" runat="server" Text="" CssClass="text" Width="90%"
                                ValidationGroup="Amount"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Amount"
                                ControlToValidate="txtTotalAmount"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtTotalAmount"
                                Type="Double" ValidationGroup="Amount"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr class="gridrowadd">
                        <td>
                            首次应收：
                        </td>
                        <td>
                            <asp:TextBox ID="txtReceivedFirst" runat="server" Text="" CssClass="text" Width="90%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Amount"
                                ControlToValidate="txtReceivedFirst"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtReceivedFirst"
                                Type="Double" ValidationGroup="Amount"></asp:CompareValidator>
                        </td>
                        <td>
                            已收金额：
                        </td>
                        <td>
                            <asp:TextBox ID="txtReceived" runat="server" Text="" CssClass="text" Width="90%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Amount"
                                ControlToValidate="txtReceived"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtReceived"
                                Type="Double" ValidationGroup="Amount"></asp:CompareValidator>
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
                            <asp:LinkButton ID="btnSaveAmount" runat="server" Text="保存金额" ValidationGroup="Amount"
                                OnClick="btnSaveAmount_OnClick"></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>说明</legend>
        <div class="generaldiv">
            <uc3:FooterIntroControl ID="FooterIntroControl1" runat="server" />
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>跟踪记录</legend>
        <div class="generaldiv">
            <div class="generaldiv">
                送货安装单状态:
                <asp:DropDownList ID="ddlDeliveryStatus" runat="server" CssClass="dropdownlist">
                </asp:DropDownList>
                <asp:Button ID="btnChangeStatus" runat="server" CssClass="button" Text="更改状态" OnClick="btnChangeStatus_Click" />
            </div>
            <div>
                <uc1:FollowUpControl ID="followUpControl" runat="server" />
            </div>
        </div>
    </fieldset>
    <div class="generaldiv">
        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="保存" ValidationGroup="Page"
            OnClick="btnSave_Click" />
        <asp:Button ID="btnPrint" runat="server" CssClass="button" Text="打印" OnClientClick="javascript:window.open('printout/deliveryprintout.aspx');" />
        <asp:Button ID="btnGenerateOrder" runat="server" CssClass="button" Text="生成正式单" ValidationGroup="Page" />
    </div>
</asp:Content>
