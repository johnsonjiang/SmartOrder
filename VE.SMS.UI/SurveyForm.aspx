<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="SurveyForm.aspx.cs" Inherits="VE.SMS.UI.SurveyForm" %>

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
<%@ Register Src="_UserControl/SurveyLineItemControl.ascx" TagName="SurveyLineItemControl"
    TagPrefix="uc1" %>
<%@ Register src="_UserControl/LineItemsControl.ascx" tagname="LineItemsControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#<% =txtCreatedDate.ClientID%>").datepicker();
            $("#<% =txtExpectedSurveyDate.ClientID%>").datepicker();
        });
    </script>
    <fieldset style="height: 100%;">
        <legend>基本信息 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        测量单源类型:
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
                        测量单号:
                    </td>
                    <td>
                        <%=this.SVNo %>
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
                            ID="rqEnqMan" runat="server" ErrorMessage="*" ForeColor="Red"  ValidationGroup="Page" ControlToValidate="ddlEnqOrdMan" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        预定测量日期:
                    </td>
                    <td>
                        <asp:TextBox ID="txtExpectedSurveyDate" runat="server" CssClass="text" Style="width: 254px" ReadOnly="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        现场联系人:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOnsiteContactName" runat="server" CssClass="text" Width="180px"></asp:TextBox>
                        <asp:CheckBox ID="chkSametoContact" runat="server" Text="同客户信息" 
                            AutoPostBack="True" oncheckedchanged="chkSametoContact_CheckedChanged" />
                    </td>
                    <td align="right">
                        现场联系人电话:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOnsiteContactPhone" runat="server" CssClass="text" Width="180px"></asp:TextBox>
                        <asp:CheckBox ID="chkSametocontactphone" runat="server" Text="同客户信息" 
                            AutoPostBack="True" oncheckedchanged="chkSametocontactphone_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        测量说明:
                    </td>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="txtSurveyIntro" runat="server" CssClass="text"
                            Width="810px" Height="100px" MaxLength="256"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        测量单状态:
                    </td>
                    <td>
                        <%=this.ddlSurveyStatus.SelectedItem.Text %>
                    </td>
                </tr>
                <tr>
                    <td align="right" nowrap="nowrap">
                        测量人员:
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlSurveyMan" runat="server" Width="254px"></asp:DropDownList>
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red"  ValidationGroup="Page" ControlToValidate="ddlSurveyMan" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        需带物品:
                    </td>
                    <td>
                        <asp:CheckBoxList ID="chklToos" runat="server" RepeatDirection="Horizontal" RepeatColumns="3"
                            Width="254px">
                        </asp:CheckBoxList>
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
        <legend>测量内容</legend>
        <uc2:LineItemsControl ID="LineItemsControl1" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>历史测量单 </legend>
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
        <legend>上传测量单数据</legend>
        <div class="generaldiv" runat="server" id="divOperate">
            <asp:FileUpload ID="fileUploadSurveyImg" runat="server" CssClass="file_input" />
            <asp:Button ID="btnUpload" runat="server" Text="上传测量数据" CssClass="button" 
                onclick="btnUpload_Click" />
        </div>
        <div class="generaldiv">
            <asp:Image ID="imgSurveyData" runat="server" Width="95%" Height="95%" />
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>跟踪记录</legend>
        <div class="generaldiv">
            <div class="generaldiv">
                测量单状态:
                <asp:DropDownList ID="ddlSurveyStatus" runat="server" CssClass="dropdownlist">
                </asp:DropDownList>
                <asp:Button ID="btnChangeStatus" runat="server" CssClass="button" Text="更改状态" 
                    onclick="btnChangeStatus_Click" />
            </div>
            <div>
                <uc1:FollowUpControl ID="followUpControl" runat="server" />
            </div>
        </div>
    </fieldset>
    <div class="generaldiv">
        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="保存测量单" ValidationGroup="Page"
            onclick="btnSave_Click" />
        <asp:Button ID="btnPrint" runat="server" CssClass="button" Text="打印测量单" OnClientClick="javascript:window.open('printout/surveyprintout.aspx');"/>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterConter" runat="server">
</asp:Content>
