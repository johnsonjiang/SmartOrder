<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="RefineForm.aspx.cs" Inherits="VE.SMS.UI.RefineForm" %>

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
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <script language="javascript" type="text/javascript">
      $(document).ready(function () {
          $("#<% =txtCompletedDate.ClientID%>").datepicker();
          $("#<% =txtCreatedDate.ClientID%>").datepicker();
      });
    </script>
    <fieldset style="height: 100%;">
        <legend>基本信息 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        细化单源类型:
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
                        细化单号:
                    </td>
                    <td>
                        <%=RefNo %>
                    </td>
                    <td align="right">
                        日期:
                    </td>
                    <td>
                       <asp:TextBox ID="txtCreatedDate" runat="server" Enabled="false" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        咨询单/订单负责人:
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlEnqOrdMan" runat="server" Width="254px"></asp:DropDownList>
                        <asp:RequiredFieldValidator
                            ID="rqEnqMan" runat="server" ErrorMessage="*" ForeColor="Red"  ValidationGroup="Page" ControlToValidate="ddlEnqOrdMan" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" nowrap="nowrap">
                        作图人员:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRefMan" runat="server" Width="254px"></asp:DropDownList>
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red"  ValidationGroup="Page" ControlToValidate="ddlRefMan" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        要求完成日期:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompletedDate" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td align="right">
                        细化单状态:
                    </td>
                    <td>
                        <%=this.ddlRefineStatus.SelectedItem.Text %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td>
                        <asp:CheckBox ID="chkConfirm" runat="server" Text="是否需要客户确认" />
                    </td>
                    <td align="right">
                        确认说明:
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmIntro" runat="server" CssClass="text" Width="254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td>
                        <asp:CheckBox ID="chkIncludeMachining" runat="server" Text="是否包括加工单" />
                    </td>
                    <td align="right">
                    </td>
                    <td>
                        <asp:CheckBox ID="chkNeedApprove" runat="server" Text="是否需要审核" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        作图说明:
                    </td>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="txtRefineIntro" runat="server" CssClass="text"
                            Width="780px" Height="100px" MaxLength="256"></asp:TextBox>
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
        <legend>历史细化单</legend>
        <div class="generaldiv">
            <uc1:CADRefinementControl ID="cADRefinementControl" runat="server" Editable="false" />
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>客户提供图纸 </legend>
        <div class="generaldiv">
            <uc1:CustomerDrawingControl ID="customerDrawingControl" Editable="false" runat="server" />
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>测量单 </legend>
        <div class="generaldiv">
            <uc1:SurveyControl ID="surveyControl" runat="server" Editable="false" />
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>上传细化CAD </legend>
        <div class="generaldiv">
            <uc1:CADFileListControl ID="cADFileListControl" runat="server" />
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>跟踪记录 </legend>
        <div class="generaldiv">
            <div class="generaldiv">
                细化单状态:
                <asp:DropDownList ID="ddlRefineStatus" runat="server" CssClass="dropdownlist">
                </asp:DropDownList>
                <asp:Button ID="btnChangeStatus" runat="server" CssClass="button" Text="更改状态" 
                    onclick="btnChangeStatus_Click" />
            </div>
            <uc1:FollowUpControl ID="followUpControl" runat="server" />
        </div>
    </fieldset>
    <div class="generaldiv">
        <asp:Button ID="btnSave" runat="server" Text="保存细化单" CssClass="button"   ValidationGroup="Page" 
            onclick="btnSave_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterConter" runat="server">
</asp:Content>
