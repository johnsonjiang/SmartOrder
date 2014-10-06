<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="MachiningForm.aspx.cs" Inherits="VE.SMS.UI.MachiningForm" %>

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
<%@ Register src="_UserControl/MachiningLineItem.ascx" tagname="MachiningLineItem" tagprefix="uc2" %>
<%@ Register src="_UserControl/PurchaseControl.ascx" tagname="PurchaseControl" tagprefix="uc3" %>
<%@ Register src="_UserControl/MachiningSummaryControl.ascx" tagname="MachiningSummaryControl" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#<% =txtCreatedDate.ClientID%>").datepicker();
            $("#<% =txtApplyDate.ClientID%>").datepicker();
            $("#<% =txtExpectedCompletedDate.ClientID%>").datepicker();
            $("#<% =txtCompletedDate.ClientID%>").datepicker();
            $("#<% =txtExpectedDeliveryDate.ClientID%>").datepicker();
            $("#<% =txtExpectedInstallDate.ClientID%>").datepicker();
        });
    </script>
    <fieldset style="height: 100%;">
        <legend>基本信息 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        生产单号:
                    </td>
                    <td width="35%">
                        <%=this.MachNo %>
                    </td>
                    <td align="right">
                        订单号:
                    </td>
                    <td>
                        <asp:HyperLink ID="lnkSource" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                                    <td align="right">
                        生产单状态:
                    </td>
                    <td>
                        <%=this.ddlMachiningStatus.SelectedItem.Text %>
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
                        开生产单人员:
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlMachCreateMan" runat="server" Width="254px"></asp:DropDownList>
                        
                            <asp:RequiredFieldValidator ID="rq" runat="server" ErrorMessage="*" ForeColor="Red"  Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="ddlMachCreateMan" ></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" nowrap="nowrap">
                        开加工表人员:
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlMachTableMan" runat="server" Width="254px"></asp:DropDownList>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red"  Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="ddlMachTableMan" ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                                <tr>
                    <td align="right">
                        销售人员:
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlSalesMan" runat="server" Width="254px"></asp:DropDownList>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red"  Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="ddlSalesMan" ></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" nowrap="nowrap">
                        CAD细化人员:
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlRefineMan" runat="server" Width="254px"></asp:DropDownList>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red"  Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="ddlRefineMan" ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                  <tr>
                    <td align="right">
                        测量人员:
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlSurveyMan" runat="server" Width="254px"></asp:DropDownList>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red"  Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="ddlSurveyMan" ></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" nowrap="nowrap">
                        加工人员:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMachProcessor" runat="server" Width="254px"></asp:DropDownList>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red"  Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="ddlMachProcessor" ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        申请加工日期:
                    </td>
                    <td>
                        <asp:TextBox ID="txtApplyDate" runat="server" CssClass="text" Style="width: 254px" ReadOnly="false"></asp:TextBox>
                    </td>
                    <td align="right">
                        预定完成日期:
                    </td>
                    <td>
                        <asp:TextBox ID="txtExpectedCompletedDate" runat="server" CssClass="text" Width="254px" ReadOnly="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red"  Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="txtExpectedCompletedDate" ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        完成日期：
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompletedDate" runat="server" CssClass="text" Width="254px" ReadOnly="false"></asp:TextBox>
                    </td>
                    
                    <td align="right">
                    预定送货日期
                    </td>
                    <td>
                    <asp:TextBox ID="txtExpectedDeliveryDate" runat="server" CssClass="text" Width="254px" ReadOnly="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        预定安装日期：
                    </td>
                    <td>
                        <asp:TextBox ID="txtExpectedInstallDate" runat="server" CssClass="text" Width="254px" ReadOnly="false"></asp:TextBox>
                    </td>
                    
                    <td align="right">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        生产单说明:
                    </td>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="txtMachiningSummary" runat="server" CssClass="text"
                            Width="720px" Height="100px" MaxLength="256"></asp:TextBox>
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
        <legend>采购单</legend>
        <div class="generaldiv">
             <uc3:PurchaseControl ID="PurchaseControl1" runat="server" />
        </div>
    </fieldset>
   
    <fieldset style="height: 100%;">
        <legend>加工表</legend>
        <uc2:MachiningLineItem ID="MachiningLineItem1" runat="server" />
    </fieldset>
        <fieldset style="height: 100%;">
        <legend>加工项目统计</legend>
        <uc4:MachiningSummaryControl ID="MachiningSummaryControl1" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>跟踪记录 </legend>
        <div class="generaldiv">
            <div class="generaldiv">
                生产单状态:
                <asp:DropDownList ID="ddlMachiningStatus" runat="server" CssClass="dropdownlist">
                </asp:DropDownList>
                <asp:Button ID="btnChangeStatus" runat="server" CssClass="button" Text="更改状态" OnClick="btnChangeStatus_Click" />
            </div>
            <uc1:FollowUpControl ID="followUpControl" runat="server" />
        </div>
    </fieldset>
    <div class="generaldiv">
        <asp:Button ID="btnSave" runat="server" Text="保存生产单" CssClass="button" ValidationGroup="Page"
            onclick="btnSave_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterConter" runat="server">
</asp:Content>
