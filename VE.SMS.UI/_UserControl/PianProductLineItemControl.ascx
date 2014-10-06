<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PianProductLineItemControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.PianProductLineItemControl" %>
<%@ Import Namespace="VE.SMS.Common" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<table class="listtable">
            <tbody>
                <tr class="gridheader">
                    <td>
                        ID
                    </td>
                    <td>
                        
                        <asp:LinkButton ID="btnProduct_Name" runat="server" Text="材料名称" CommandName="Product_Name" OnClick="Sort_Click"></asp:LinkButton>
                    </td>
                    <td>
                        
                        <asp:LinkButton ID="btnProduct_Code" runat="server" Text="代码" CommandName="Product_Code" OnClick="Sort_Click"></asp:LinkButton>
                    </td>
                    <td>
                        
                        <asp:LinkButton ID="btnColor" runat="server" Text="颜色" CommandName="Color" OnClick="Sort_Click"></asp:LinkButton>
                    </td>
                    <td>
                        
                        <asp:LinkButton ID="btnPriceM" runat="server" Text="单价(M)" CommandName="PriceM" OnClick="Sort_Click"></asp:LinkButton>
                    </td>
                    <td>
                        
                        <asp:LinkButton ID="btnPriceM2" runat="server" Text="单价(M2)" CommandName="PriceM2" OnClick="Sort_Click"></asp:LinkButton>
                    </td>
                    <td>
                        
                        <asp:LinkButton ID="btnHuangliaoCode" runat="server" Text="荒料号" CommandName="HuangliaoCode" OnClick="Sort_Click"></asp:LinkButton>
                    </td>
                    <td>
                        
                        <asp:LinkButton ID="btnJiaCode" runat="server" Text="架号" CommandName="JiaCode" OnClick="Sort_Click"></asp:LinkButton>
                    </td>
                    <td>
                        
                        <asp:LinkButton ID="btnPianCode" runat="server" Text="片号" CommandName="PianCode" OnClick="Sort_Click"></asp:LinkButton>
                    </td>
                    <td>
                        
                        <asp:LinkButton ID="btnQuantityM2" runat="server" Text="平方数" CommandName="QuantityM2" OnClick="Sort_Click"></asp:LinkButton>
                    </td>
                                        <td>
                        金额
                    </td>
                    <td>
                        
                        <asp:LinkButton ID="btnLocation" runat="server" Text="位置" CommandName="Location"></asp:LinkButton>
                    </td>
                    <%if (ACLUtility.IsAccessible(ACLConsts.ViewProductSupplier))
                      {  %>
                    <td>
                        
                        <asp:LinkButton ID="btnSupplierName" runat="server" Text="供应商" CommandName="SupplierName"></asp:LinkButton>
                    </td>
                    <%} %>
                </tr>
<asp:Repeater ID="rpProductList" runat="server" 
    onitemdatabound="rpProductList_ItemDataBound">
    <ItemTemplate>
        <tr class="gridrow">
            <td><a href='ProductForm.aspx?id=<%#Eval("Product_Id") %>&type=P&viewtype=edit' target="_blank"><%#Container.ItemIndex + 1%></a></td>
            <td>
                <a href='ProductForm.aspx?id=<%#Eval("Product_Id") %>&type=P&viewtype=edit' target="_blank"><%#Eval("Product_Name")%></a>
            </td>
            <td>
                <%#Eval("Product_Code")%>
            </td>
            <td>
                <%#Eval("Color")%>
            </td>
            <td>
                <%#Eval("PriceM")%>
            </td>
            <td>
                <%#Eval("PriceM2")%>
            </td>
            <td>
                <%#Eval("HuangliaoCode")%>
            </td>
            <td>
                <%#Eval("JiaCode")%>
            </td>
            <td>
                <%#Eval("PianCode")%>
            </td>
            <td>
                <%#Eval("QuantityM2")%>
            </td>
                       <td>
                       <%# Utility.Round(Convert.ToDouble(Eval("PriceM2")) * Convert.ToDouble(Eval("QuantityM2"))) %>
                    </td>
            <td>
                <%#Eval("Location")%>
            </td>
                                <%if (ACLUtility.IsAccessible(ACLConsts.ViewProductSupplier))
                                  {  %>
            <td>
                <%#Eval("SupplierName")%>
            </td>
                              <%} %>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr class="gridrowalt">
        <td><a href='ProductForm.aspx?id=<%#Eval("Product_Id") %>&type=P&viewtype=edit' target="_blank"><%#Container.ItemIndex + 1%></a></td>
            <td>
                <a href='ProductForm.aspx?id=<%#Eval("Product_Id") %>&type=P&viewtype=edit' target="_blank"><%#Eval("Product_Name")%></a>
            </td>
            <td>
                <%#Eval("Product_Code")%>
            </td>
            <td>
                <%#Eval("Color")%>
            </td>
            <td>
                <%#Eval("PriceM")%>
            </td>
            <td>
                <%#Eval("PriceM2")%>
            </td>
            <td>
                <%#Eval("HuangliaoCode")%>
            </td>
            <td>
                <%#Eval("JiaCode")%>
            </td>
            <td>
                <%#Eval("PianCode")%>
            </td>
            <td>
                <%#Eval("QuantityM2")%>
            </td>
                       <td>
                        <%# Utility.Round(Convert.ToDouble(Eval("PriceM2")) * Convert.ToDouble(Eval("QuantityM2"))) %>
                    </td>
            <td>
                <%#Eval("Location")%>
            </td>
                                <%if (ACLUtility.IsAccessible(ACLConsts.ViewProductSupplier))
                      {  %>
            <td>
                <%#Eval("SupplierName")%>
            </td>
            <%} %>
        </tr>
    </AlternatingItemTemplate>
    <FooterTemplate>
    <tr><td align="right" colspan="12">
    平方数小计:<asp:Label ID="lblTotalSquare" runat="server"></asp:Label>
    金额小计:<asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
    </td></tr>
        </tbody></table>
    </FooterTemplate>
</asp:Repeater>
</ContentTemplate>
</asp:UpdatePanel>