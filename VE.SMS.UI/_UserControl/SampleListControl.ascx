<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SampleListControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.SampleListControl" %>
<div class="generaldiv">
    <fieldset style="height: 100%;">
        <legend>样品信息 </legend>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                            材料代码:
                        </td>
                        <td width="35%">
                            <asp:DropDownList ID="ddlProductCode" runat="server" Width="254px"></asp:DropDownList>
                            
                        </td>
                        <td align="right">
                            材料名称:
                        </td>
                        <td>
                        <asp:DropDownList ID="ddlProductName" runat="server" Width="254px"></asp:DropDownList>
                            
                        </td>
                </tr>
                <tr>
                    <td align="right">
                        样品号:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSampleCode" runat="server" Width="254px"></asp:DropDownList>
                    </td>
                    <td align="right">
                        供应商:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="dropdownlist" Width="254px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        单价(M):
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txtPriceMSample" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td align="right">
                        单价(M2):
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceM2Sample" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                            颜色:
                        </td>
                        <td>
                        <asp:DropDownList ID="ddlColor" runat="server" Width="254px"></asp:DropDownList>
                        </td>
                        <td align="right">
                            纹理:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTexure" runat="server" Width="254px"></asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td width="15%" nowrap="nowrap" align="right">
                        别称:
                    </td>
                    <td width="35%">
                        <asp:TextBox ID="txtAliasSample" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                    </td>
                    <td align="right">
                        位置:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLocation" runat="server" Width="254px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnSearchSample" runat="server" Text="查询" CssClass="button" float="right"
                            OnClick="btnSearchSample_Click" />
                            <asp:Button ID="btnCreate" runat="server" Text="创建样品" CssClass="button" 
                            float="right"  name="cresatesample" OnClientClick="javascript:window.open('productform.aspx?type=s&viewtype=create');return false;"
                             />
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
</div>
<div class="generaldiv">
    <fieldset style="height: 100%;">
        <legend>样品信息汇总 </legend>
        <div class="generaldiv">
            <asp:Repeater ID="rpProductList" runat="server" 
                onitemcommand="rpProductList_ItemCommand">
                <HeaderTemplate>
                    <table class="listtable">
                        <tbody>
                            <tr class="gridheader">
                            <td>
                            <asp:LinkButton ID="Sample_Id" runat="server" Text="Id" CommandName="Sample_Id"></asp:LinkButton>
                            </td>
                                                            <td>
                                    
                                    <asp:LinkButton ID="SampleCode" runat="server" Text="样品号" CommandName="SampleCode"></asp:LinkButton>
                                </td>
                                <td>
                                    
                                    <asp:LinkButton ID="MaterialName" runat="server" Text="材料名称" CommandName="MaterialName"></asp:LinkButton>
                                </td>
                                <td>
                                    
                                    <asp:LinkButton ID="MaterialCode" runat="server" Text="代码" CommandName="MaterialCode"></asp:LinkButton>
                                </td>

                                <td>
                                    规格
                                </td>
                                <td>
                                    
                                    <asp:LinkButton ID="SampleColor" runat="server" Text="颜色" CommandName="SampleColor"></asp:LinkButton>
                                </td>
                                <td>
                                    
                                    <asp:LinkButton ID="PriceM" runat="server" Text="单价(M)" CommandName="PriceM"></asp:LinkButton>
                                </td>
                                <td>
                                    
                                    <asp:LinkButton ID="PriceM2" runat="server" Text="单价(M2)" CommandName="PriceM2"></asp:LinkButton>
                                </td>
                                <%if (VE.SMS.Common.ACLUtility.IsAccessible(VE.SMS.Common.ACLConsts.ViewSampleProductSupplier))
                                  {  %>
                                <td>
                                    
                                    <asp:LinkButton ID="Supplier" runat="server" Text="供应商" CommandName="Supplier"></asp:LinkButton>
                                </td>
                                <%} %>
                                <td>
                                    
                                    <asp:LinkButton ID="SampleLocation" runat="server" Text="位置" CommandName="SampleLocation"></asp:LinkButton>
                                </td>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="gridrow">
                    <td><a href='ProductForm.aspx?id=<%#Eval("Sample_Id") %>&type=S&viewtype=edit'>
                                <%#Container.ItemIndex + 1%></a></td>
                                            <td>
                            <a href='ProductForm.aspx?id=<%#Eval("Sample_Id") %>&type=S&viewtype=edit'>
                                <%#Eval("SampleCode")%></a>
                        </td>
                        <td>
                            <%#Eval("MaterialName")%>
                        </td>
                        <td>
                            <%#Eval("MaterialCode")%>
                        </td>

                        <td>
                            <%#Eval("SampleLong")%>*<%#Eval("SampleWidth")%>*<%#Eval("SampleDeep")%></td>
                        <td>
                            <%#Eval("SampleColor")%>
                        </td>
                        <td>
                            <%#Eval("PriceM")%>
                        </td>
                        <td>
                            <%#Eval("PriceM2")%>
                        </td>
                        <%if (VE.SMS.Common.ACLUtility.IsAccessible(VE.SMS.Common.ACLConsts.ViewSampleProductSupplier))
                          {  %>
                        <td>
                            <%#Eval("Supplier")%>
                        </td>
                        <%} %>
                        <td>
                            <%#Eval("SampleLocation")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="gridrowalt">
                    <td><a href='ProductForm.aspx?id=<%#Eval("Sample_Id") %>&type=S&viewtype=edit'>
                                <%#Container.ItemIndex + 1%></a></td>
                                            <td>
                            <a href='ProductForm.aspx?id=<%#Eval("Sample_Id") %>&type=S&viewtype=edit'>
                                <%#Eval("SampleCode")%></a>
                        </td>
                        <td>
                            <%#Eval("MaterialName")%>
                        </td>
                        <td>
                            <%#Eval("MaterialCode")%>
                        </td>

                        <td>
                            <%#Eval("SampleLong")%>*<%#Eval("SampleWidth")%>*<%#Eval("SampleDeep")%></td>
                        <td>
                            <%#Eval("SampleColor")%>
                        </td>
                        <td>
                            <%#Eval("PriceM")%>
                        </td>
                        <td>
                            <%#Eval("PriceM2")%>
                        </td>
                        <%if (VE.SMS.Common.ACLUtility.IsAccessible(VE.SMS.Common.ACLConsts.ViewSampleProductSupplier))
                          {  %>
                        <td>
                            <%#Eval("Supplier")%>
                        </td>
                        <%} %>
                        <td>
                            <%#Eval("SampleLocation")%>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </fieldset>
</div>
