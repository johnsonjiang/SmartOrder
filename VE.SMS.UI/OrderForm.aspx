<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="OrderForm.aspx.cs" Inherits="VE.SMS.UI.OrderForm" %>
<%@ Import Namespace="VE.SMS.Common" %>
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
<%@ Register Src="_UserControl/SettlementControl.ascx" TagName="SettlementControl"
    TagPrefix="uc2" %>
<%@ Register Src="_UserControl/MachiningControl.ascx" TagName="MachiningControl"
    TagPrefix="uc3" %>
<%@ Register Src="_UserControl/PurchaseControl.ascx" TagName="PurchaseControl" TagPrefix="uc4" %>
<%@ Register Src="_UserControl/DeliveryControl.ascx" TagName="DeliveryControl" TagPrefix="uc5" %>
<%@ Register Src="_UserControl/SampleControl.ascx" TagName="SampleControl" TagPrefix="uc2" %>
<%@ Register Src="_UserControl/ReceiptControl.ascx" TagName="ReceiptControl" TagPrefix="uc6" %>
<%@ Register Src="_UserControl/FooterIntroControl.ascx" TagName="FooterIntroControl"
    TagPrefix="uc3" %>
<%@ Register Src="_UserControl/CADEditControl.ascx" TagName="CADEditControl" TagPrefix="uc5" %>
<%@ Register Src="_UserControl/SurveyEditControl.ascx" TagName="SurveyEditControl"
    TagPrefix="uc4" %>
<%@ Register Src="_UserControl/DeliveryEditControl.ascx" TagName="DeliveryEditControl"
    TagPrefix="uc6" %>
<%@ Register Src="_UserControl/InstallEditControl.ascx" TagName="InstallEditControl"
    TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#<% =txtCreatedDate.ClientID%>").datepicker();
        });
        function openPrintOut() {
            var no = "<%=OrdNo%>";
            window.open("printout/orderprintout.aspx?ordno=" + no);
        }
    </script>
    <fieldset style="height: 100%;">
        <legend>基本信息 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        订单源类型:
                    </td>
                    <td width="35%">
                        <%=SourceType %>
                    </td>
                    <td align="right" width="15%">
                        源单号:
                    </td>
                    <td width="35%">
                        <asp:HyperLink ID="lnkSource" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        订单号:
                    </td>
                    <td>
                        <asp:textbox ID="txtOrdNo" runat="server" CssClass="text"></asp:textbox>
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtOrdNo" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:LinkButton ID="btnUpdateOrdNo" runat="server" Text="更改订单号" OnClick="btnUpdateOrdNo_Click"></asp:LinkButton>
                    </td>
                    <td align="right" width="15%">
                        日期:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txtCreatedDate" runat="server" CssClass="text" Style="width: 100px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        订单负责人:
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlOrdMan" runat="server" Width="254px"></asp:DropDownList>
                        
                        <asp:RequiredFieldValidator
                            ID="rqEnqMan" runat="server" ErrorMessage="*" ForeColor="Red"  ValidationGroup="Page" ControlToValidate="ddlOrdMan" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" width="15%">
                        订单状态:
                    </td>
                    <td width="35%">
                        <%=this.ddlOrderStatus.SelectedItem.Text %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        订单说明:
                    </td>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="txtOrderSummary" runat="server" CssClass="text"
                            Width="700px" Height="100px" MaxLength="256"></asp:TextBox>
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
        <legend>订单内容</legend>
        <uc1:LineItemsControl ID="lineItemsControl" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>样品</legend>
        <uc2:SampleControl ID="SampleControl1" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>客户图纸</legend>
        <uc1:CustomerDrawingControl ID="customerDrawingControl" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>测量</legend>
        <uc4:SurveyEditControl ID="SurveyEditControl1" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>CAD图纸</legend>
        <uc5:CADEditControl ID="CADEditControl1" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>送货方式</legend>
        <uc6:DeliveryEditControl ID="DeliveryEditControl1" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>安装</legend>
        <uc7:InstallEditControl ID="InstallEditControl1" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>历史报价单 </legend>
        <div class="generaldiv">
            <uc1:QuotationControl ID="quotationControl" runat="server" />
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>测量单 </legend>
        <div class="generaldiv">
            <uc1:SurveyControl ID="surveyControl" runat="server" />
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>细化单</legend>
        <div class="generaldiv">
            <uc1:CADRefinementControl ID="cADRefinementControl" runat="server" />
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>生产单</legend>
        <div class="generaldiv">
            <uc3:MachiningControl ID="MachiningControl1" runat="server" />
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>采购单</legend>
        <div class="generaldiv">
            <uc4:PurchaseControl ID="PurchaseControl1" runat="server" />
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>送货安装单</legend>
        <div class="generaldiv">
            <uc5:DeliveryControl ID="DeliveryControl1" runat="server" />
        </div>
    </fieldset>
                        <%if (ACLUtility.IsAccessible(ACLConsts.ViewOrdSettlement))
                          { %>
    <fieldset style="height: 100%;">
        <legend>结算单</legend>
        <div class="generaldiv">
            <uc2:SettlementControl ID="SettlementControl1" runat="server" />
        </div>
    </fieldset>
    <%} %>
    <%if (ACLUtility.IsAccessible(ACLConsts.ViewOrdReceipt))
      { %>
    <fieldset style="height: 100%;">
        <legend>收款管理</legend>
        <div class="generaldiv">
            <uc6:ReceiptControl ID="ReceiptControl1" runat="server" />
        </div>
    </fieldset>
    <%} %>
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
                订单状态:
                <asp:DropDownList ID="ddlOrderStatus" runat="server" CssClass="dropdownlist">
                </asp:DropDownList>
                <asp:Button ID="btnChangeStatus" runat="server" CssClass="button" Text="更改状态" 
                    onclick="btnChangeStatus_Click" />
            </div>
            <div>
                <uc1:FollowUpControl ID="followUpControl" runat="server" />
            </div>
        </div>
        <div class="generaldiv">
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="保存订单" OnClick="btnSave_Click" />
            <asp:Button ID="btnSaveFormalOrder" runat="server" CssClass="button" Text="生成正式订单" OnClick="btnSaveFormalOrder_Click" />
            <asp:Button ID="btnPrint" runat="server" CssClass="button" Text="打印" OnClientClick="javascript:openPrintOut();" />
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterConter" runat="server">
</asp:Content>
