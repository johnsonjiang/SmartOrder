<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MachiningLineItem.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.MachiningLineItem" %>
    <%@ Import Namespace="VE.SMS.Common" %>
<script language="javascript">
    function openParam(miId, type, link) {
        var returnValue = window.showModalDialog("ParamEditForm.aspx?miid=" + miId + "&type=" + type);
        if (returnValue == "Ok") {
            document.location.href = document.location.href;
            document.execCommand('Refresh');
        }
    }
</script>
<div class="generaldiv">
    <asp:CheckBox ID="chkRefine" runat="server" Text="用细化单代替" AutoPostBack="True" OnCheckedChanged="chkRefine_CheckedChanged" />
    <asp:DropDownList ID="ddlRefineList" runat="server" CssClass="dropdownlist" Width="254px"
        Visible="false">
    </asp:DropDownList>
    <asp:TextBox ID="txtRefineIntro" runat="server" CssClass="text" Visible="false" Text="细化单替代说明"></asp:TextBox>
</div>
<div class="generaldiv">
    <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="button" OnClick="btnExport_Click" />
    <asp:Repeater ID="rpItems" runat="server" OnItemCommand="rpItems_ItemCommand" OnItemDataBound="rpItems_ItemDataBound">
        <HeaderTemplate>
            <table class="listtable">
                <tbody>
                    <tr class="gridheader">
                        <td width="3%">
                            序号
                        </td>
                        <td width="8%">
                            说明
                        </td>
                        <td width="8%" align="center">
                            材料
                        </td>
                        <td width="4%" align="center">
                            编号
                        </td>
                        <td width="17%" align="center">
                            长
                        </td>
                        <td width="17%" align="center">
                            宽
                        </td>
                        <td width="17%" align="center">
                            厚
                        </td>
                        <td width="4%" align="center">
                            数量
                        </td>
                        <td width="4%" align="center">
                            面积
                        </td>
                        <td width="10%" align="center">
                            加工说明
                        </td>
                        <td width="7%" align="center">
                            操作
                        </td>
                    </tr>
                    <tr class="gridrowadd">
                        <td>
                        </td>
                        <td>
                            <asp:TextBox ID="txtIntroAdd" runat="server" CssClass="text" Width="80%"></asp:TextBox>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtProductAdd" runat="server" CssClass="text" Width="80%" ValidationGroup="MachLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rq" runat="server" ErrorMessage="*" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLine" ControlToValidate="txtProductAdd"></asp:RequiredFieldValidator>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtCodeAdd" runat="server" CssClass="text" Width="80%" ValidationGroup="MachLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLine"
                                ControlToValidate="txtCodeAdd"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtLongAdd" runat="server" CssClass="text" Width="80%" ValidationGroup="MachLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLine"
                                ControlToValidate="txtLongAdd"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtLongAdd"
                                Type="Integer" ValidationGroup="MachLine"></asp:CompareValidator>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtWidthAdd" runat="server" CssClass="text" Width="80%" ValidationGroup="MachLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLine"
                                ControlToValidate="txtWidthAdd"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtWidthAdd"
                                Type="Integer" ValidationGroup="MachLine"></asp:CompareValidator>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDeepAdd" runat="server" CssClass="text" Width="80%" ValidationGroup="MachLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLine"
                                ControlToValidate="txtDeepAdd"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtDeepAdd"
                                Type="Integer" ValidationGroup="MachLine"></asp:CompareValidator>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtQtyAdd" runat="server" CssClass="text" Width="80%" ValidationGroup="MachLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLine"
                                ControlToValidate="txtQtyAdd"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtQtyAdd"
                                Type="Integer" ValidationGroup="MachLine"></asp:CompareValidator>
                        </td>
                        <td align="center">
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtRemarkAdd" runat="server" CssClass="text" Width="80%"></asp:TextBox>
                        </td>
                        <%--                            <td bgcolor="#eeeeee" width="8%" align="center">
                                精准报价
                            </td>--%>
                        <td align="center">
                            <asp:LinkButton ID="btnAdd" runat="server" CssClass="button" Text="新增" CommandName="Add"
                                ValidationGroup="MachLine"></asp:LinkButton>
                        </td>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="gridrow">
                <td valign="top">
                    <%#Container.ItemIndex + 1 %>
                </td>
                <td valign="top">
                    <asp:HiddenField ID="hdId" Value='<%#Eval("MI_Id") %>' runat="server" />
                    <asp:TextBox ID="txtIntro" runat="server" CssClass="text" Width="90%" Text='<%#Eval("Intro") %>'></asp:TextBox>
                </td>
                <td height="20" align="left" valign="top">
                    <asp:TextBox ID="txtProduct" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Product_Code") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rq" runat="server" ErrorMessage="*" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLineItem" ControlToValidate="txtProduct"></asp:RequiredFieldValidator>
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="txtCode" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Code") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLineItem" ControlToValidate="txtCode"></asp:RequiredFieldValidator>
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="txtLong" runat="server" CssClass="text" Width="70%" Text='<%#Eval("Long") %>'></asp:TextBox>
                    <a href='javascript:openParam(<%#Eval("MI_Id") %>,"l", this);'>参数</a>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLineItem" ControlToValidate="txtLong"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtLong"
                                Type="Integer" ValidationGroup="MachLineItem"></asp:CompareValidator>
                    <asp:Repeater ID="rpDisplayL" runat="server" OnItemDataBound="rpDisplay_ItemDataBound">
                        <HeaderTemplate>
                            <ol>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:Image ID="imgMach" runat="server" />
                                <div>
                                <asp:Label ID="lblMachType" runat="server"></asp:Label></div>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ol>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="txtWidth" runat="server" CssClass="text" Width="70%" Text='<%#Eval("Width") %>'></asp:TextBox>
                    <a href='javascript:openParam(<%#Eval("MI_Id") %>,"w", this);'>参数</a>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLineItem" ControlToValidate="txtWidth"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator6" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtWidth"
                                Type="Integer" ValidationGroup="MachLineItem"></asp:CompareValidator>
                    <asp:Repeater ID="rpDisplayW" runat="server" OnItemDataBound="rpDisplay_ItemDataBound">
                        <HeaderTemplate>
                            <ol>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:Image ID="imgMach" runat="server" />
                                <div>
                                <asp:Label ID="lblMachType" runat="server"></asp:Label></div>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ol>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="txtDeep" runat="server" CssClass="text" Width="70%" Text='<%#Eval("Deepth") %>'></asp:TextBox>
                    <a href='javascript:openParam(<%#Eval("MI_Id") %>,"d", this);'>参数</a>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLineItem" ControlToValidate="txtDeep"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator7" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtDeep"
                                Type="Integer" ValidationGroup="MachLineItem"></asp:CompareValidator>
                    <asp:Repeater ID="rpDisplayD" runat="server" OnItemDataBound="rpDisplay_ItemDataBound">
                        <HeaderTemplate>
                            <ol>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:Image ID="imgMach" runat="server" />
                                <div>
                                <asp:Label ID="lblMachType" runat="server"></asp:Label></div>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ol>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="txtQty" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Quantity") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLineItem" ControlToValidate="txtQty"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator8" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtQty"
                                Type="Integer" ValidationGroup="MachLineItem"></asp:CompareValidator>
                </td>
                <td valign="top" align="left">
                    <asp:Label ID="lblSquare" runat="server" CssClass="text" Width="80%" Text='<%#Utility.Round(Eval("Square")) %>'></asp:Label>
                </td>
                <td valign="top">
                    <asp:TextBox ID="txtRemark" runat="server" CssClass="text" Width="95%" Text='<%#Eval("MachIntro") %>' TextMode="MultiLine"></asp:TextBox>
                </td>
                <td align="center" valign="top">
                    <asp:LinkButton ID="btnSave" runat="server" CssClass="button" Text="保存" CommandName="Save" ValidationGroup="MachLineItem"></asp:LinkButton>
                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="button" Text="删除" CommandName="Delete" ValidationGroup="MachLineItem"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="gridrowalt">
                <td valign="top">
                    <%#Container.ItemIndex + 1 %>
                </td>
                <td valign="top">
                    <asp:HiddenField ID="hdId" Value='<%#Eval("MI_Id") %>' runat="server" />
                    <asp:TextBox ID="txtIntro" runat="server" CssClass="text" Width="90%" Text='<%#Eval("Intro") %>'></asp:TextBox>
                </td>
                <td height="20" align="left" valign="top">
                    <asp:TextBox ID="txtProduct" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Product_Code") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rq" runat="server" ErrorMessage="*" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLineItem" ControlToValidate="txtProduct"></asp:RequiredFieldValidator>
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="txtCode" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Code") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLineItem" ControlToValidate="txtCode"></asp:RequiredFieldValidator>
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="txtLong" runat="server" CssClass="text" Width="70%" Text='<%#Eval("Long") %>'></asp:TextBox>
                    <a href='javascript:openParam(<%#Eval("MI_Id") %>,"l", this);'>参数</a>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLineItem" ControlToValidate="txtLong"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtLong"
                                Type="Integer" ValidationGroup="MachLineItem"></asp:CompareValidator>
                    <asp:Repeater ID="rpDisplayL" runat="server" OnItemDataBound="rpDisplay_ItemDataBound">
                        <HeaderTemplate>
                            <ol>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:Image ID="imgMach" runat="server" />
                                <div>
                                <asp:Label ID="lblMachType" runat="server"></asp:Label></div>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ol>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="txtWidth" runat="server" CssClass="text" Width="70%" Text='<%#Eval("Width") %>'></asp:TextBox>
                    <a href='javascript:openParam(<%#Eval("MI_Id") %>,"w", this);'>参数</a>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLineItem" ControlToValidate="txtWidth"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator6" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtWidth"
                                Type="Integer" ValidationGroup="MachLineItem"></asp:CompareValidator>
                    <asp:Repeater ID="rpDisplayW" runat="server" OnItemDataBound="rpDisplay_ItemDataBound">
                        <HeaderTemplate>
                            <ol>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:Image ID="imgMach" runat="server" />
                                <div>
                                <asp:Label ID="lblMachType" runat="server"></asp:Label></div>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ol>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="txtDeep" runat="server" CssClass="text" Width="70%" Text='<%#Eval("Deepth") %>'></asp:TextBox>
                    <a href='javascript:openParam(<%#Eval("MI_Id") %>,"d", this);'>参数</a>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLineItem" ControlToValidate="txtDeep"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator7" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtDeep"
                                Type="Integer" ValidationGroup="MachLineItem"></asp:CompareValidator>
                    <asp:Repeater ID="rpDisplayD" runat="server" OnItemDataBound="rpDisplay_ItemDataBound">
                        <HeaderTemplate>
                            <ol>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:Image ID="imgMach" runat="server" />
                                <div>
                                <asp:Label ID="lblMachType" runat="server"></asp:Label></div>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ol>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="txtQty" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Quantity") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLineItem" ControlToValidate="txtQty"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator8" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtQty"
                                Type="Integer" ValidationGroup="MachLineItem"></asp:CompareValidator>
                </td>
                <td valign="top" align="left">
                    <asp:Label ID="lblSquare" runat="server" CssClass="text" Width="80%" Text='<%#Utility.Round(Eval("Square")) %>'></asp:Label>
                </td>
                <td valign="top">
                    <asp:TextBox ID="txtRemark" runat="server" CssClass="text" Width="95%" Text='<%#Eval("MachIntro") %>' TextMode="MultiLine" Rows="2"></asp:TextBox>
                </td>
                <td align="center" valign="top">
                    <asp:LinkButton ID="btnSave" runat="server" CssClass="button" Text="保存" CommandName="Save" ValidationGroup="MachLineItem"></asp:LinkButton>
                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="button" Text="删除" CommandName="Delete" ValidationGroup="MachLineItem"></asp:LinkButton>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>


</div>
