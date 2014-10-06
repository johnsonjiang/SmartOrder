<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FinishProductEditControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.FinishProductEditControl" %>
<div class="generaldiv" style="padding-left: 10px">
    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="保存" OnClick="btnSave_Click" ValidationGroup="Page"/>
</div>
<div class="generaldiv">
    <fieldset style="height: 100%;">
        <legend>成品信息 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        代码:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txtCode" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rq" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="txtCode"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        名称:
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="txtName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        分类:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCatelog" runat="server" Width="254px"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="ddlCatelog"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        细类:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSubCatelog" runat="server" Width="254px"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="ddlSubCatelog"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        长:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLong" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="txtLong"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtLong"
                            Type="Integer" ValidationGroup="Page"></asp:CompareValidator>
                    </td>
                    <td align="right">
                        宽:
                    </td>
                    <td>
                        <asp:TextBox ID="txtWidth" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="txtWidth"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtWidth"
                            Type="Integer" ValidationGroup="Page"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        厚:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDeep" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="txtDeep"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtDeep"
                            Type="Integer" ValidationGroup="Page"></asp:CompareValidator>
                    </td>
                    <td align="right" nowrap="nowrap">
                        材料:
                    </td>
                    <td>
                        <asp:TextBox ID="txtMaterial" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="txtMaterial"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        单价:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="txtPrice"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPrice"
                            Type="Double" ValidationGroup="Page"></asp:CompareValidator>
                    </td>
                    <td align="right">
                        进价:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceIn" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="txtPriceIn"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceIn"
                            Type="Double" ValidationGroup="Page"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" nowrap="nowrap">
                        数量:
                    </td>
                    <td>
                        <asp:TextBox ID="txtQty" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="txtQty"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator6" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtQty"
                            Type="Integer" ValidationGroup="Page"></asp:CompareValidator>
                    </td>
                    <td align="right">
                        供应商:
                    </td>
                    <td>
                        <%if (VE.SMS.Common.ACLUtility.IsAccessible(VE.SMS.Common.ACLConsts.ViewEndProductSupplier))
                          { %>
                          <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="dropdownlist" Width="254px">
                        </asp:DropDownList>
                        <%} %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        位置:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLocation" runat="server" Width="254px"></asp:DropDownList>
                    </td>
                    <td align="right" nowrap="nowrap">
                        备注:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemark" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        成本:
                    </td>
                    <td>
                    <%if (VE.SMS.Common.ACLUtility.IsAccessible(VE.SMS.Common.ACLConsts.ViewEndProductCost))
                      { %>
                        <%if (!string.IsNullOrEmpty(txtPriceIn.Text) && !string.IsNullOrEmpty(txtQty.Text))
                          {  %>
                        <%=double.Parse(txtPriceIn.Text) * int.Parse(txtQty.Text)%>
                        <%} %>
                        <%} %>
                    </td>
                    <td align="right" nowrap="nowrap">
                        金额:
                    </td>
                    <td>
                    <%if (VE.SMS.Common.ACLUtility.IsAccessible(VE.SMS.Common.ACLConsts.ViewEndProductTotalAmount))
                      { %>
                        <%if (!string.IsNullOrEmpty(txtPriceIn.Text) && !string.IsNullOrEmpty(txtQty.Text))
                          {  %>
                        <%=double.Parse(txtPrice.Text) * int.Parse(txtQty.Text)%>
                        <%} %>
                        <%} %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        上传图片:
                    </td>
                    <td>
                        <asp:FileUpload ID="filePic" runat="server" CssClass="file_input" Width="200px" />
                    </td>
                    <td align="right" nowrap="nowrap">
                    </td>
                    <td>
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
</div>
<div class="generaldiv" style="border: 1px solid #c8d9e4;">
    <asp:Image ID="imgPath" Width="100%" Height="100%" runat="server" />
</div>
<div class="generaldiv" style="padding-top: 10px">
</div>
