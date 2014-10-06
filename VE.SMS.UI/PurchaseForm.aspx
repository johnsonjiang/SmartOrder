<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="PurchaseForm.aspx.cs" Inherits="VE.SMS.UI.PurchaseForm" %>

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
            $("#<% =txtPurchaseCreatedDate.ClientID%>").datepicker();
            $("#<% =txtApplyPurchaseDate.ClientID%>").datepicker();
            $("#<% =txtExpectedCompleteDate.ClientID%>").datepicker();
        });
    </script>
    <fieldset style="height: 100%;">
        <legend>基本信息 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        采购单源类型:
                    </td>
                    <td width="35%">
                        <%=this.SourceType %>
                    </td>
                    <td align="right">
                        源单号:
                    </td>
                    <td>
                        <%=this.SourceNo %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        采购单号:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPurchaseId" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td align="right">
                        日期:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPurchaseCreatedDate" runat="server" CssClass="text" Style="width: 254px"
                            Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        申请采购日期:
                    </td>
                    <td>
                        <asp:TextBox ID="txtApplyPurchaseDate" runat="server" CssClass="text" Style="width: 254px"
                            ReadOnly="false"></asp:TextBox>
                    </td>
                    <td align="right" nowrap="nowrap">
                        预定完成日期:
                    </td>
                    <td>
                        <asp:TextBox ID="txtExpectedCompleteDate" runat="server" CssClass="text" Style="width: 254px"
                            ReadOnly="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        销售人员:
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlSalesMan" runat="server" Width="254px"></asp:DropDownList>

                        <asp:RequiredFieldValidator ID="rq" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="ddlSalesMan"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" nowrap="nowrap">
                        开生产单人员:
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlMachMan" runat="server" Width="254px"></asp:DropDownList>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="ddlMachMan"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        采购人员:
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlPurchaseMan" runat="server" Width="254px"></asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="ddlPurchaseMan"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        申请采购人员:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlApplyPurchaseMan" runat="server" Width="254px"></asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="ddlApplyPurchaseMan"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        批准人:
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlApproveMan" runat="server" Width="254px"></asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="ddlApproveMan"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        开加工表人员:
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlMachTableMan" runat="server" Width="254px"></asp:DropDownList>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="ddlMachTableMan"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        采购单状态:
                    </td>
                    <td>
                        <%=this.ddlPurchaseStatus.SelectedItem.Text %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        采购说明:
                    </td>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="txtPurchaseSummary" runat="server" CssClass="text"
                            Width="700px" Height="100px" MaxLength="256"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>采购内容</legend>
        <div class="generaldiv">
            <asp:Repeater ID="rpItems" runat="server" OnItemCommand="rpItems_ItemCommand" OnItemDataBound="rpItems_ItemDataBound">
                <HeaderTemplate>
                    <table class="listtable">
                        <tbody>
                            <tr class="gridheader">
                                <td width="10%">
                                    序号
                                </td>
                                <td width="10%">
                                    说明
                                </td>
                                <td width="10%" align="center">
                                    材料
                                </td>
                                <td width="10%" align="center">
                                    编号
                                </td>
                                <td width="10%" align="center">
                                    长
                                </td>
                                <td width="10%" align="center">
                                    宽
                                </td>
                                <td width="10%" align="center">
                                    厚
                                </td>
                                <td width="10%" align="center">
                                    数量
                                </td>
                                <td width="10%" align="center">
                                    面积
                                </td>
                                <td width="10%" align="center">
                                    操作
                                </td>
                            </tr>
                            <tr class="gridrowadd">
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIntroAdd" runat="server" CssClass="text" Width="80%"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtProductAdd" runat="server" CssClass="text" Width="80%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rq" runat="server" ErrorMessage="*" ForeColor="Red"
                                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItemAdd" ControlToValidate="txtProductAdd"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCodeAdd" runat="server" CssClass="text" Width="80%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                        ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItemAdd"
                                        ControlToValidate="txtCodeAdd"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLongAdd" runat="server" CssClass="text" Width="80%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                        ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItemAdd"
                                        ControlToValidate="txtLongAdd"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                        ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtLongAdd"
                                        Type="Integer" ValidationGroup="POItemAdd"></asp:CompareValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtWidthAdd" runat="server" CssClass="text" Width="80%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                        ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItemAdd"
                                        ControlToValidate="txtWidthAdd"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                        ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtWidthAdd"
                                        Type="Integer" ValidationGroup="POItemAdd"></asp:CompareValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDeepAdd" runat="server" CssClass="text" Width="80%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*"
                                        ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItemAdd"
                                        ControlToValidate="txtDeepAdd"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                        ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtDeepAdd"
                                        Type="Integer" ValidationGroup="POItemAdd"></asp:CompareValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQtyAdd" runat="server" CssClass="text" Width="80%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                                        ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItemAdd"
                                        ControlToValidate="txtQtyAdd"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                        ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtQtyAdd"
                                        Type="Integer" ValidationGroup="POItemAdd"></asp:CompareValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSquareAdd" runat="server" CssClass="text" Width="80%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
                                        ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItemAdd"
                                        ControlToValidate="txtSquareAdd"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                        ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtSquareAdd"
                                        Type="Double" ValidationGroup="POItemAdd"></asp:CompareValidator>
                                </td>
                                <td>
                                    <asp:LinkButton ID="btnAdd" runat="server" CssClass="button" Text="新增" CommandName="Add"
                                        ValidationGroup="POItemAdd"></asp:LinkButton>
                                </td>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="gridrow">
                        <td>
                            <%#Container.ItemIndex + 1 %>
                        </td>
                        <td>
                            <asp:HiddenField ID="hdId" Value='<%#Eval("PurchaseOrderItem_Id") %>' runat="server" />
                            <asp:TextBox ID="txtIntro" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Intro") %>'></asp:TextBox>
                        </td>
                        <td height="20">
                            <asp:TextBox ID="txtProduct" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Product_Code") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rq" runat="server" ErrorMessage="*" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItem" ControlToValidate="txtProduct"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCode" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Code") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItem"
                                ControlToValidate="txtCode"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtLong" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Long") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItem"
                                ControlToValidate="txtLong"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtLong"
                                Type="Integer" ValidationGroup="POItem"></asp:CompareValidator>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtWidth" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Width") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItem"
                                ControlToValidate="txtWidth"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator6" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtWidth"
                                Type="Integer" ValidationGroup="POItem"></asp:CompareValidator>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDeep" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Deepth") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItem"
                                ControlToValidate="txtDeep"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator7" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtDeep"
                                Type="Integer" ValidationGroup="POItem"></asp:CompareValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtQty" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Quantity") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItem"
                                ControlToValidate="txtQty"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator8" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtQty"
                                Type="Integer" ValidationGroup="POItem"></asp:CompareValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSquare" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Square") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItem"
                                ControlToValidate="txtSquare"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator9" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtSquare"
                                Type="Double" ValidationGroup="POItem"></asp:CompareValidator>
                        </td>
                        <td>
                            <asp:LinkButton ID="btnSave" runat="server" CssClass="button" Text="保存" CommandName="Save"
                                ValidationGroup="POItem"></asp:LinkButton>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="button" Text="删除" CommandName="Delete"></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="gridrowalt">
                        <td>
                            <%#Container.ItemIndex + 1 %>
                        </td>
                        <td>
                            <asp:HiddenField ID="hdId" Value='<%#Eval("PurchaseOrderItem_Id") %>' runat="server" />
                            <asp:TextBox ID="txtIntro" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Intro") %>'></asp:TextBox>
                        </td>
                        <td height="20">
                            <asp:TextBox ID="txtProduct" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Product_Code") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rq" runat="server" ErrorMessage="*" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItem" ControlToValidate="txtProduct"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCode" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Code") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItem"
                                ControlToValidate="txtCode"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtLong" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Long") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItem"
                                ControlToValidate="txtLong"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtLong"
                                Type="Integer" ValidationGroup="POItem"></asp:CompareValidator>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtWidth" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Width") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItem"
                                ControlToValidate="txtWidth"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator6" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtWidth"
                                Type="Integer" ValidationGroup="POItem"></asp:CompareValidator>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDeep" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Deepth") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItem"
                                ControlToValidate="txtDeep"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator7" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtDeep"
                                Type="Integer" ValidationGroup="POItem"></asp:CompareValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtQty" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Quantity") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItem"
                                ControlToValidate="txtQty"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator8" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtQty"
                                Type="Integer" ValidationGroup="POItem"></asp:CompareValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSquare" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Square") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="POItem"
                                ControlToValidate="txtSquare"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator9" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtSquare"
                                Type="Double" ValidationGroup="POItem"></asp:CompareValidator>
                        </td>
                        <td>
                            <asp:LinkButton ID="btnSave" runat="server" CssClass="button" Text="保存" CommandName="Save"
                                ValidationGroup="POItem"></asp:LinkButton>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="button" Text="删除" CommandName="Delete"></asp:LinkButton>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </fieldset>
    <fieldset style="height: 100%;">
        <legend>跟踪记录</legend>
        <div class="generaldiv">
            <asp:DropDownList ID="ddlPurchaseStatus" runat="server" CssClass="dropdownlist">
            </asp:DropDownList>
            <asp:Button ID="btnChangeStatus" runat="server" CssClass="button" Text="更改状态" OnClick="btnChangeStatus_Click" />
            <uc1:FollowUpControl ID="followUpControl" runat="server" />
        </div>
    </fieldset>
    <div class="generaldiv">
        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="保存采购单" OnClick="btnSave_Click"
            ValidationGroup="Page" />
        <asp:Button ID="btnPrint" runat="server" CssClass="button" Text="打印" OnClientClick="javascript:window.open('printout/purchaseprintout.aspx');" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterConter" runat="server">
</asp:Content>
