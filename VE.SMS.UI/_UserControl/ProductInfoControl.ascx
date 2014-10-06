﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductInfoControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.ProductInfoControl" %>
<div class="generaldiv" style="padding-left: 10px">
    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="保存" OnClick="btnSave_Click" ValidationGroup="Page"/>

</div>
<div class="generaldiv">
    <fieldset style="height: 100%;">
        <legend>材料信息 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        材料代码:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txtProductCode" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="txtProductCode"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        材料名称:
                    </td>
                    <td>
                        <asp:TextBox ID="txtProductName" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rq" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page" ControlToValidate="txtProductName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        荒料码:
                    </td>
                    <td>
                        <asp:TextBox ID="txtHuangliaoCode" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="txtHuangliaoCode"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        纹理:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTexure" runat="server" Width="254px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        架号:
                    </td>
                    <td>
                        <asp:TextBox ID="txtJiaCode" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="txtJiaCode"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" nowrap="nowrap">
                        片号:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPianCode" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="txtPianCode"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" nowrap="nowrap">
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
                    <td align="right" nowrap="nowrap">
                        厚:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDeepth" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="txtDeepth"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtDeepth"
                            Type="Integer" ValidationGroup="Page"></asp:CompareValidator>
                    </td>
                    <td align="right" nowrap="nowrap">
                        颜色:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlColor" runat="server" Width="254px"></asp:DropDownList>
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
                        平方数:
                    </td>
                    <td>
                        <asp:Label ID="lblSquare" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        供应商:
                    </td>
                    <td>
                        <%if (VE.SMS.Common.ACLUtility.IsAccessible(VE.SMS.Common.ACLConsts.ViewProductSupplier))
                          {  %>
                          <asp:DropDownList ID="ddlSupplier" runat="server" Width="254px"></asp:DropDownList>
                        <%} %>
                    </td>
                    <td align="right" nowrap="nowrap">
                        进价(M2):
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceInM2" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="txtPriceInM2"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceInM2"
                            Type="Double" ValidationGroup="Page"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" nowrap="nowrap">
                        单价(M):
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceM" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="txtPriceM"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator6" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceM"
                            Type="Double" ValidationGroup="Page"></asp:CompareValidator>
                    </td>
                    <td align="right">
                        单价(M2):
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceM2" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="txtPriceM2"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator7" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceM2"
                            Type="Double" ValidationGroup="Page"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                 <td align="right">
                 单价(其他):
                    </td>
                    <td>
                    <asp:TextBox ID="txtPriceOther" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Page"
                            ControlToValidate="txtPriceOther"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator8" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceOther"
                            Type="Double" ValidationGroup="Page"></asp:CompareValidator>
                    </td>
                    <td align="right" nowrap="nowrap">
                        样品:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSampleList" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr>
                    <td align="right" nowrap="nowrap">
                        别称1:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAlias1" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td align="right">
                        别称2:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAlias2" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" nowrap="nowrap">
                        成本(M2):
                    </td>
                    <td>
                    <%if (VE.SMS.Common.ACLUtility.IsAccessible(VE.SMS.Common.ACLConsts.ViewProductCost))
                      { %>
                        <%if (!string.IsNullOrEmpty(txtPriceInM2.Text) && !string.IsNullOrEmpty(lblSquare.Text))
                          {  %>
                        <%=double.Parse(txtPriceInM2.Text) * double.Parse(lblSquare.Text)%>
                        <%} %>
                        <%} %>
                    </td>
                    <td align="right">
                        金额(M2):
                    </td>
                    <td>
                    <%if (VE.SMS.Common.ACLUtility.IsAccessible(VE.SMS.Common.ACLConsts.ViewProductTotalAmount))
                      { %>
                        <%if (!string.IsNullOrEmpty(txtPriceM2.Text) && !string.IsNullOrEmpty(lblSquare.Text))
                          {  %>
                        <%=double.Parse(txtPriceM2.Text) * double.Parse(lblSquare.Text)%>
                        <%} %>
                        <%} %>
                    </td>
                </tr>

                <tr>
                    <td align="right">
                        说明:
                    </td>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="txtIntro" runat="server" CssClass="text" Width="690px"
                            Height="60px"></asp:TextBox>
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
    <asp:Image ID="imgPath" runat="server" Width="100%" Height="100%" />
</div>
