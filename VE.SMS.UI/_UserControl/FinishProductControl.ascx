<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FinishProductControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.FinishProductControl" %>
<div class="generaldiv">
    <fieldset style="height: 90%;">
        <legend>成品信息 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        分类:
                    </td>
                    <td width="35%">
                        <asp:DropDownList ID="ddlCatelog" runat="server" Width="254px"></asp:DropDownList>
                    </td>
                    <td align="right">
                        细类:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSubCatelog" runat="server" Width="254px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        成品代码:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txtCode" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td align="right">
                        成品名称:
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        供应商:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="dropdownlist" Width="254px">
                        </asp:DropDownList>
                    </td>
                    <td width="15%" nowrap="nowrap" align="right">
                        位置:
                    </td>
                    <td width="35%">
                    <asp:DropDownList ID="ddlLocation" runat="server" CssClass="dropdownlist" Width="254px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        长:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLongFinishProduct" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td align="right">
                        宽:
                    </td>
                    <td>
                        <asp:TextBox ID="txtWidthFinishProduct" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        厚:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDeepFinishProduct" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td align="right">
                        单价
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td>
                    </td>
                    <td align="right">
                    </td>
                    <td>
                        <asp:Button ID="btnSearchFinishProduct" runat="server" Text="查询" CssClass="button"
                            float="right" OnClick="btnSearchFinishProduct_Click" />
                            <asp:Button ID="btnCreate" runat="server" Text="创建成品" CssClass="button"
                            float="right" name="createfinishproduct" OnClientClick="javascript:window.open('productform.aspx?type=ep&viewtype=create');return false;"/>
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
</div>
<div class="generaldiv">
    <fieldset style="height: 100%;">
        <legend>成品信息汇总 </legend>
        <div class="generaldiv">
            <asp:Repeater ID="rpProductList" runat="server" 
                onitemdatabound="rpProductList_ItemDataBound" 
                onitemcommand="rpProductList_ItemCommand">
                <HeaderTemplate>
                    <table class="listtable">
                        <tbody>
                            <tr class="gridheader">
                            <td>Id
                            </td>
                                <td>
                                    <asp:LinkButton ID="Name" runat="server" Text="名称" CommandName="Name"></asp:LinkButton>
                                </td>
                                <td>
                                    
                                    <asp:LinkButton ID="Code" runat="server" Text="代码" CommandName="Code"></asp:LinkButton>
                                </td>
                                <td>
                                    
                                    <asp:LinkButton ID="Catelog" runat="server" Text="分类" CommandName="Catelog"></asp:LinkButton>
                                </td>
                                <td>
                                    
                                    <asp:LinkButton ID="SubCatelog" runat="server" Text="细类" CommandName="SubCatelog"></asp:LinkButton>
                                </td>
                                <td>
                                    
                                    <asp:LinkButton ID="Material" runat="server" Text="材料" CommandName="Material"></asp:LinkButton>
                                </td>
                                <td>
                                    
                                    <asp:LinkButton ID="Price" runat="server" Text="单价" CommandName="Price"></asp:LinkButton>
                                </td>
                                 <%if (VE.SMS.Common.ACLUtility.IsAccessible(VE.SMS.Common.ACLConsts.ViewEndProductSupplier))
                                   { %>
                                <td>
                                    
                                    <asp:LinkButton ID="SupplierName" runat="server" Text="供应商" CommandName="SupplierName"></asp:LinkButton>
                                </td>
                                <%} %>
                                <td>
                                    
                                    <asp:LinkButton ID="Qty" runat="server" Text="数量" CommandName="Qty"></asp:LinkButton>
                                </td>
                                <td>
                                    金额
                                </td>
                                <td>
                                    
                                    <asp:LinkButton ID="Location" runat="server" Text="位置" CommandName="Location"></asp:LinkButton>
                                </td>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="gridrow">
                        <td><a href='ProductForm.aspx?id=<%#Eval("EP_ID") %>&type=EP&viewtype=edit'><%#Container.ItemIndex + 1  %></a></td>
                        <td>
                           <a href='ProductForm.aspx?id=<%#Eval("EP_ID") %>&type=EP&viewtype=edit'><%#Eval("Name") %></a>
                        </td>
                        <td>
                            <%#Eval("Code") %>
                        </td>
                        <td>
                            <%#Eval("Catelog") %>
                        </td>
                        <td>
                            <%#Eval("SubCatelog") %>
                        </td>
                        <td>
                            <%#Eval("Material") %>
                        </td>
                        <td>
                            <%#Eval("Price") %>
                        </td>
                         <%if (VE.SMS.Common.ACLUtility.IsAccessible(VE.SMS.Common.ACLConsts.ViewEndProductSupplier))
                      { %>
                        <td>
                            <%#Eval("SupplierName") %>
                        </td>
                        <%} %>
                        <td>
                            <%#Eval("Qty") %>
                        </td>
                        <td>
                            <%# Convert.ToInt32(Eval("Qty")) * Convert.ToDouble(Eval("Price")) %>
                        </td>
                        <td>
                            <%#Eval("Location") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="gridrowalt">
                        <td><a href='ProductForm.aspx?id=<%#Eval("EP_ID") %>&type=EP&viewtype=edit'><%#Container.ItemIndex + 1  %></a></td>
                        <td>
                           <a href='ProductForm.aspx?id=<%#Eval("EP_ID") %>&type=EP&viewtype=edit'><%#Eval("Name") %></a>
                        </td>
                        <td>
                            <%#Eval("Code") %>
                        </td>
                        <td>
                            <%#Eval("Catelog") %>
                        </td>
                        <td>
                            <%#Eval("SubCatelog") %>
                        </td>
                        <td>
                            <%#Eval("Material") %>
                        </td>
                        <td>
                            <%#Eval("Price") %>
                        </td>
                         <%if (VE.SMS.Common.ACLUtility.IsAccessible(VE.SMS.Common.ACLConsts.ViewEndProductSupplier))
                           { %>
                        <td>
                            <%#Eval("SupplierName") %>
                        </td>
                        <%} %>
                        <td>
                            <%#Eval("Qty") %>
                        </td>
                        <td>
                            <%# Convert.ToInt32(Eval("Qty")) * Convert.ToDouble(Eval("Price")) %>
                        </td>
                        <td>
                            <%#Eval("Location") %>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                <tr><td align="right" colspan="11">
    数量小计:<asp:Label ID="lblTotalQuantity" runat="server"></asp:Label>
    金额小计:<asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
    </td></tr>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </fieldset>
</div>
