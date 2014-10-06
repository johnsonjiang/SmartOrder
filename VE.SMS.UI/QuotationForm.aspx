<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="QuotationForm.aspx.cs" Inherits="VE.SMS.UI.QuotationForm" %>

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
<%@ Register Src="_UserControl/SampleControl.ascx" TagName="SampleControl" TagPrefix="uc2" %>
<%@ Register Src="_UserControl/FooterIntroControl.ascx" TagName="FooterIntroControl"
    TagPrefix="uc3" %>
<%@ Register Src="_UserControl/SurveyEditControl.ascx" TagName="SurveyEditControl"
    TagPrefix="uc4" %>
<%@ Register Src="_UserControl/CADEditControl.ascx" TagName="CADEditControl" TagPrefix="uc5" %>
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
            var no = "<%=QuoteNo%>";
            window.open("printout/quotationprintout.aspx?quono=" + no);
        }
    </script>
    <fieldset style="height: 100%;">
        <legend>基本信息 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        报价单源类型:
                    </td>
                    <td width="35%">
                        <%=this.SourceType %>
                    </td>
                    <td align="right">
                        源单号:
                    </td>
                    <td>
                        <asp:HyperLink ID="lnkSource" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        报价单号:
                    </td>
                    <td>
                        <%=GetQueryStringValue("quono") %>
                    </td>
                    <td align="right">
                        日期:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCreatedDate" runat="server" CssClass="text" Style="width: 254px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        咨询单/订单负责人:
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlEnqOrdMan" runat="server" Width="254px"></asp:DropDownList>
                        
                        <asp:RequiredFieldValidator
                            ID="rqEnqMan" runat="server" ErrorMessage="*" ForeColor="Red"  ValidationGroup="Page" ControlToValidate="ddlEnqOrdMan" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" nowrap="nowrap">
                        报价人员:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlQuoteMan" runat="server" Width="254px"></asp:DropDownList>
                        
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red"  ValidationGroup="Page" ControlToValidate="ddlQuoteMan" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        报价单状态:
                    </td>
                    <td colspan="3">
                        <%=this.ddlQuotationStatus.SelectedItem.Text %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        报价说明:
                    </td>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="txtQuoteIntro" runat="server" CssClass="text"
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
        <legend>报价内容</legend>
        <uc1:LineItemsControl ID="lineItemsControl" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>样品</legend>
        <uc2:SampleControl ID="SampleControl1" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>客户图纸</legend>
        <uc1:CustomerDrawingControl ID="customerDrawingControl1" runat="server" />
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
            <uc1:QuotationControl ID="quotationControl" runat="server" Editable="false" />
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>测量单</legend>
        <div class="generaldiv">
            <uc1:SurveyControl ID="surveyControl" runat="server" Editable="false" />
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>客户提供图纸 </legend>
        <div class="generaldiv">
            <uc1:CustomerDrawingControl ID="customerDrawingControl" Editable="false" runat="server" />
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>细化单</legend>
        <div class="generaldiv">
            <uc1:CADRefinementControl ID="cADRefinementControl" runat="server" Editable="false" />
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
                报价单状态:
                <asp:DropDownList ID="ddlQuotationStatus" runat="server" CssClass="dropdownlist">
                </asp:DropDownList>
                <asp:Button ID="btnChangeStatus" runat="server" CssClass="button" Text="更改状态" OnClick="btnChangeStatus_Click"  />
            </div>
            <div>
                <uc1:FollowUpControl ID="followUpControl" runat="server" />
            </div>
        </div>
    </fieldset>
    <div class="generaldiv">
        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="保存报价单" ValidationGroup="Page"
            onclick="btnSave_Click" />
        <asp:Button ID="btnGenerateFormalQuoation" runat="server" CssClass="button" Text="生成正式报价" OnClick="btnGenerateFormalQuoation_Click" ValidationGroup="Page"/>
        <input type="button" ID="btnPrint" runat="server" class="button" value="打印报价单" onclick="javascript:openPrintOut();" />
        <asp:Button ID="btnCopy" runat="server" CssClass="button" Text="复制新增" OnClick="btnCopy_Click" ValidationGroup="Page"/>
        <asp:Button ID="btnGenerateOrder" runat="server" CssClass="button" Text="生成订单草稿" OnClick="btnGenerateOrder_Click"  ValidationGroup="Page"/>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterConter" runat="server">
</asp:Content>
