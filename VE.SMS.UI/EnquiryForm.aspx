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
        <legend>������Ϣ  
            
        </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        ��ѯ����:
                    </td>
                    <td width="35%">
                        <asp:textbox ID="txtEnqNo" runat="server"></asp:textbox>
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtEnqNo" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:LinkButton ID="btnUpdateEnqNo" runat="server" Text="���Ķ�����" OnClick="btnUpdateEnqNo_Click"></asp:LinkButton>
                    </td>
                    <td align="right">
                        ¼������:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCreatedDate" runat="server" CssClass="text" Width="254px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Ԥ�ƿ�������:
                    </td>
                    <td>
                        <asp:TextBox ID="txtBeginDate" runat="server" CssClass="text" Style="width: 254px" ReadOnly="false"></asp:TextBox>
                    </td>
                    <td align="right" nowrap="nowrap">
                        Ԥ���깤����:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="text" Style="width: 254px" ReadOnly="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        ����˵��:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTimeLimitRemark" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td align="right">
                        ��ѯ��״̬:
                    </td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        ��ѯ��������:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEnqMan" runat="server" Width="254px"></asp:DropDownList>
                        <asp:RequiredFieldValidator
                            ID="rqEnqMan" runat="server" ErrorMessage="*" ForeColor="Red"  ValidationGroup="Page" ControlToValidate="ddlEnqMan" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        ��ע:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemark" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        ��ѯ��ժҪ:
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
        <legend>�ͻ���Ϣ </legend>
        <uc1:CustomerInfoControl ID="customerInfoControl" runat="server" />
    </fieldset>
    <fieldset style="height: 100%">
        <legend>��ѯ����</legend>
        <uc1:LineItemsControl ID="lineItemsControl" runat="server" />
        <div style="margin: 10px 10px 10px 10px; width: 980px">
            <uc1:EnquiryImageControl ID="enquiryImageControl" runat="server" />
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>��Ʒ</legend>
        <uc2:SampleControl ID="SampleControl1" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>�ͻ�ͼֽ</legend>
        <uc1:CustomerDrawingControl ID="customerDrawingControl" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>����</legend>
                <uc4:SurveyEditControl ID="SurveyEditControl1" runat="server" />
        
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>CADͼֽ</legend>
        <uc5:CADEditControl ID="CADEditControl1" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>�ͻ���ʽ</legend>
        
        <uc6:DeliveryEditControl ID="DeliveryEditControl1" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>��װ</legend>
        
        <uc7:InstallEditControl ID="InstallEditControl1" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>��ز���</legend>
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
        <legend>˵��</legend>
        <div class="generaldiv">
            <uc3:FooterIntroControl ID="FooterIntroControl1" runat="server" />
        </div>
    </fieldset>
    
    <fieldset style="height: 100%;">
        <legend>���ټ�¼</legend>
        <div class="generaldiv">
            <div class="generaldiv">
                ��ѯ��״̬:
                <asp:DropDownList ID="ddlEnquiryStatus" runat="server" CssClass="dropdownlist">
                </asp:DropDownList>
                <asp:Button ID="btnChangeStatus" runat="server" CssClass="button" Text="����״̬" OnClick="btnChangeStatus_OnClick" />
            </div>
            <div>
                <uc1:FollowUpControl ID="followUpControl" runat="server"/>
            </div>
        </div>
    </fieldset>
    <div class="generaldiv">
        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="������ѯ��" 
            onclick="btnSave_Click"  ValidationGroup="Page"/>
        <input type="button" ID="btnPrint" runat="server" class="button" value="��ӡ��ѯ��" onclick='javascript:openPrintOut();' />
        <asp:Button ID="btnGenerateOrder" runat="server" CssClass="button" Text="���ɶ����ݸ�"  ValidationGroup="Page" OnClick="btnGenerateOrder_Click" />
    </div>
</asp:Content>
