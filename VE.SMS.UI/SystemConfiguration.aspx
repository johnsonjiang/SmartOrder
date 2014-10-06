<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="SystemConfiguration.aspx.cs" Inherits="VE.SMS.UI.SystemConfiguration" %>

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
<%@ Register Src="_UserControl/SupplierUserControl.ascx" TagName="SupplierUserControl"
    TagPrefix="uc2" %>
<%@ Register Src="_UserControl/CustomerUserControl.ascx" TagName="CustomerUserControl"
    TagPrefix="uc3" %>
<%@ Register Src="_UserControl/MachiningInstallUserControl.ascx" TagName="MachiningInstallUserControl"
    TagPrefix="uc4" %>
<%@ Register Src="_UserControl/InstallConfigurationControl.ascx" TagName="InstallConfigurationControl"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset style="height: 100%;">
        <legend>基本信息 </legend>
        <table width="98%">
            <tr>
                <td colspan="2">
                    <div class="generaldiv">
                        <asp:TextBox ID="txtGroupName" runat="server" CssClass="text" Width="254px"></asp:TextBox>
                        <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="添加新组" OnClick="btnAdd_Click" />
                    </div>
                </td>
            </tr>
            <tr>
                <td width="20%">
                    <div class="generaldiv">
                        <asp:TreeView ID="trvConfig" runat="server" OnSelectedNodeChanged="trvConfig_SelectedNodeChanged"
                            ShowLines="True">
                            <SelectedNodeStyle BackColor="#FFFF66" />
                        </asp:TreeView>
                    </div>
                </td>
                <td width="80%" valign="top">
                    <div class="generaldiv" width="100%">
                        <asp:Repeater ID="rpConfigItemList" runat="server" OnItemCommand="rpConfigItemList_ItemCommand">
                            <HeaderTemplate>
                                <table class="listtable">
                                    <tbody>
                                        <tr class="gridheader">
                                            <td>
                                                序号
                                            </td>
                                            <td>
                                                基本信息组
                                            </td>
                                            <td>
                                                标示
                                            </td>
                                            <td>
                                                值
                                            </td>
                                            <td>
                                                默认
                                            </td>
                                            <td>
                                                操作
                                            </td>
                                        </tr>
                                        <tr class="gridrowadd">
                                            <td>
                                            </td>
                                            <td>
                                                <%=CurrentGroupName %>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIdentityAdd" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtValueAdd" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkDefaultAdd" runat="server" />
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="btnItemAdd" runat="server" Text="新增" CommandName="Add"></asp:LinkButton>
                                            </td>
                                        </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="gridrow">
                                    <td>
                                        <%#Container.ItemIndex + 1%>
                                        <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("ConfigItem_Id") %>' />
                                    </td>
                                    <td>
                                        <%=CurrentGroupName %>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtIdentity" runat="server" Text='<%#Eval("ConfigItem_Key")%>' CssClass="text"
                                            Width="90%"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtValue" runat="server" Text='<%#Eval("ConfigItem_Value")%>' CssClass="text"
                                            Width="90%"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkDefault" runat="server" Checked='<%#Eval("IsDefault")%>' />
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="btnSave" runat="server" Text="保存" CommandName="Save"></asp:LinkButton>
                                        <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="Delete"></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="gridrowalt">
                                    <td>
                                        <%#Container.ItemIndex + 1%>
                                        <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("ConfigItem_Id") %>' />
                                    </td>
                                    <td>
                                        <%=CurrentGroupName %>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtIdentity" runat="server" Text='<%#Eval("ConfigItem_Key")%>' CssClass="text"
                                            Width="90%"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtValue" runat="server" Text='<%#Eval("ConfigItem_Value")%>' CssClass="text"
                                            Width="90%"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkDefault" runat="server" Checked='<%#Eval("IsDefault")%>' />
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="btnSave" runat="server" Text="保存" CommandName="Save"></asp:LinkButton>
                                        <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="Delete"></asp:LinkButton>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                            <FooterTemplate>
                                </tbody></table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>供应商</legend>
        <uc2:SupplierUserControl ID="SupplierUserControl1" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>客户</legend>
        <uc3:CustomerUserControl ID="CustomerUserControl1" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>加工项目</legend>
        <uc4:MachiningInstallUserControl ID="MachiningInstallUserControl1" runat="server" />
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>安装项目</legend>
        <uc4:InstallConfigurationControl ID="InstallConfigurationControl" runat="server" />
    </fieldset>
</asp:Content>
