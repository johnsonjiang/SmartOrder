<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="EnquiryForm.aspx.cs" Inherits="VE.SMS.UI.EnquiryForm" %>

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
<%@ Register src="_UserControl/SampleControl.ascx" tagname="SampleControl" tagprefix="uc2" %>
<%@ Register src="_UserControl/FooterIntroControl.ascx" tagname="FooterIntroControl" tagprefix="uc3" %>
<%@ Register src="_UserControl/SurveyEditControl.ascx" tagname="SurveyEditControl" tagprefix="uc4" %>
<%@ Register src="_UserControl/CADEditControl.ascx" tagname="CADEditControl" tagprefix="uc5" %>
<%@ Register src="_UserControl/DeliveryEditControl.ascx" tagname="DeliveryEditControl" tagprefix="uc6" %>
<%@ Register src="_UserControl/InstallEditControl.ascx" tagname="InstallEditControl" tagprefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#<% =txtCreatedDate.ClientID%>").datepicker();
            $("#<% =txtBeginDate.ClientID%>").datepicker();
            $("#<% =txtEndDate.ClientID%>").datepicker();
        });
        function openPrintOut() {
            var enqNo = "<%=EnqNo%>";
            window.open("printout/enquiryprintout.aspx?enqno=" + enqNo);
        }
    </script>

    <fieldset style="height: 100%;">
        <legend>基本信息  
            
        </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        咨询单号:
                    </td>
                    <td width="35%">
                        <asp:textbox ID="txtEnqNo" runat="server"></asp:textbox>
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtEnqNo" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:LinkButton ID="btnUpdateEnqNo" runat="server" Text="更改订单号" OnClick="btnUpdateEnqNo_Click"></asp:LinkButton>
                    </td>
                    <td align="right">
                        录入日期:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCreatedDate" runat="server" CssClass="text" Width="254px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        预计开工日期:
                    </td>
                    <td>
                        <asp:TextBox ID="txtBeginDate" runat="server" CssClass="text" Style="width: 254px" ReadOnly="false"></asp:TextBox>
                    </td>
                    <td align="right" nowrap="nowrap">
                        预计完工日期:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="text" Style="width: 254px" ReadOnly="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        工期说明:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTimeLimitRemark" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td align="right">
                        咨询单状态:
                    </td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        咨询单负责人:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEnqMan" runat="server" Width="254px"></asp:DropDownList>
                        <asp:RequiredFieldValidator
                            ID="rqEnqMan" runat="server" ErrorMessage="*" ForeColor="Red"  ValidationGroup="Page" ControlToValidate="ddlEnqMan" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        备注:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemark" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        咨询单摘要:
                    </td>
                    <td colspan="3">
                        
                        <asp:TextBox TextMode="MultiLine" ID="txtEnqSummary" runat="server" CssClass="text"
                            Width="720px" Height="100px" MaxLength="256"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
        </table>

    </fieldset>
    <fieldset style="height: 100%">
        <legend>客户信息 </legend>
        <uc1:CustomerInfoControl ID="customerInfoControl" runat="server" />
    </fieldset>
    <fieldset style="height: 100%">
        <legend>咨询内容</legend>
        <uc1:LineItemsControl ID="lineItemsControl" runat="server" />
        <div style="margin: 10px 10px 10px 10px; width: 980px">
            <uc1:EnquiryImageControl ID="enquiryImageControl" runat="server" />
        </div>
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
        <legend>相关操作</legend>
        <div class="generaldiv">
            <div>
                <uc1:QuotationControl ID="quotationControl" runat="server" />
            </div>
            <div>
                <uc1:SurveyControl ID="surveyControl" runat="server" />
            </div>
            <div>
                <uc1:CADRefinementControl ID="cADRefinementControl" runat="server" />
            </div>
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
                咨询单状态:
                <asp:DropDownList ID="ddlEnquiryStatus" runat="server" CssClass="dropdownlist">
                </asp:DropDownList>
                <asp:Button ID="btnChangeStatus" runat="server" CssClass="button" Text="更改状态" OnClick="btnChangeStatus_OnClick" />
            </div>
            <div>
                <uc1:FollowUpControl ID="followUpControl" runat="server"/>
            </div>
        </div>
    </fieldset>
    <div class="generaldiv">
        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="保存咨询单" 
            onclick="btnSave_Click"  ValidationGroup="Page"/>
        <input type="button" ID="btnPrint" runat="server" class="button" value="打印咨询单" onclick='javascript:openPrintOut();' />
        <asp:Button ID="btnGenerateOrder" runat="server" CssClass="button" Text="生成订单草稿"  ValidationGroup="Page" OnClick="btnGenerateOrder_Click" />
    </div>
</asp:Content>
