<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaiLiaoProductLineItemControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.CaiLiaoProductLineItemControl" %>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table class="listtable">
            <tbody>
                <tr class="gridheader">
                    <td>
                        <asp:LinkButton ID="Product_Name" runat="server" Text="材料名称" OnClick="Sort_Click"
                            CommandName="Product_Name"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnProduct_Code" runat="server" Text="代码" OnClick="Sort_Click"
                            CommandName="Product_Code"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnColor" runat="server" Text="颜色" OnClick="Sort_Click" CommandName="Color"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnPriceM" runat="server" Text="单价(M)" OnClick="Sort_Click" CommandName="PriceM"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnPriceM2" runat="server" Text="单价(M2)" OnClick="Sort_Click"
                            CommandName="PriceM2"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnQuantityM2" runat="server" Text="平方数" OnClick="Sort_Click"
                            CommandName="QuantityM2"></asp:LinkButton>
                    </td>
                    <td>
                        金额
                    </td>
                    <td>
                        <asp:LinkButton ID="btnLocation" runat="server" Text="位置" OnClick="Sort_Click" CommandName="Location"></asp:LinkButton>
                    </td>
                    <%if (VE.SMS.Common.ACLUtility.IsAccessible(VE.SMS.Common.ACLConsts.ViewProductSupplier))
                      {  %>
                    <td>
                        <asp:LinkButton ID="btnSupplierName" runat="server" Text="供应商" OnClick="Sort_Click"
                            CommandName="SupplierName"></asp:LinkButton>
                    </td>
                    <%} %>
                </tr>
<asp:Repeater ID="rpProductList" runat="server" 
    onitemdatabound="rpProductList_ItemDataBound">
  
    <ItemTemplate>
        <tr class="gridrow">
            <td>
                <%#Eval("Product_Name")%>
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
                <%#VE.SMS.Common.Utility.Round(Eval("QuantityM2"))%>
            </td>
            <td>
                <%# VE.SMS.Common.Utility.Round(Convert.ToDouble(Eval("PriceM2")) * Convert.ToDouble(Eval("QuantityM2"))) %>
            </td>
            <td>
                <%#Eval("Location")%>
            </td>
            <%if (VE.SMS.Common.ACLUtility.IsAccessible(VE.SMS.Common.ACLConsts.ViewProductSupplier))
              {  %>
            <td>
                <%#Eval("SupplierName")%>
            </td>
            <%} %>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr class="gridrowalt">
            <td>
                <%#Eval("Product_Name")%>
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
                <%#VE.SMS.Common.Utility.Round(Eval("QuantityM2"))%>
            </td>
            <td>
                <%# VE.SMS.Common.Utility.Round(Convert.ToDouble(Eval("PriceM2")) * Convert.ToDouble(Eval("QuantityM2"))) %>
            </td>
            <td>
                <%#Eval("Location")%>
            </td>
            <%if (VE.SMS.Common.ACLUtility.IsAccessible(VE.SMS.Common.ACLConsts.ViewProductSupplier))
              {  %>
            <td>
                <%#Eval("SupplierName")%>
            </td>
            <%} %>
        </tr>
    </AlternatingItemTemplate>
    <FooterTemplate>
        <tr><td align="right" colspan="11">
    平方数小计:<asp:Label ID="lblTotalSquare" runat="server"></asp:Label>
    金额小计:<asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
    </td></tr>
        </tbody></table>
    </FooterTemplate>
</asp:Repeater>
</ContentTemplate>
</asp:UpdatePanel>