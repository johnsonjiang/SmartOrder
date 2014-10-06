<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SampleControl.ascx.cs" Inherits="VE.SMS.UI._UserControl.SampleControl" %>
 <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td nowrap="nowrap" align="right">
                    </td>
                    <td>
                        <asp:CheckBox ID="chkToCustomer" runat="server" Text="提供样品给客户" 
                            oncheckedchanged="chkToCustomer_CheckedChanged" AutoPostBack="True" />
                        <asp:panel ID="pnlOA" runat="server" Visible="false">
                        <asp:DropDownList ID="ddlProduct" runat="server" CssClass="dropdownlist">
                        </asp:DropDownList>
                        </asp:panel>
                    </td>
                    <td align="right">
                    <asp:Panel ID="pnlOG" runat="server" Visible="false">
                        说明:</asp:Panel>
                    </td>
                    <td>
                        <asp:panel ID="pnlOB" runat="server" Visible="false">
                        <asp:TextBox ID="txtToCustomer" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        <asp:Button ID="btnAddToCustomer" runat="server" Text="添加" CssClass="button" 
                            onclick="btnAddToCustomer_Click" />
                            </asp:panel>

                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" align="left" colspan="4">
                        <div class="generaldiv" runat="server" id="pnlOC" Visible="false">
                            <asp:Repeater ID="rpSampleToCustomer" runat="server">
                                <HeaderTemplate>
                                    <table class="listtable">
                                        <tbody>
                                            <tr class="gridheader">
                                                <td>
                                                    样品
                                                </td>
                                                <td>
                                                    说明
                                                </td>
                                            </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="gridrow">
                                        <td>
                                            <%#Eval("SampleName") %>
                                        </td>
                                        <td>
                                            <%#Eval("SampleIntro") %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="gridrowalt">
                                        <td>
                                            <%#Eval("SampleName") %>
                                        </td>
                                        <td>
                                            <%#Eval("SampleIntro") %>
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
            </tbody>
        </table>
        <table style="width: 100%;" border="0" cellspacing="1" cellpadding="2">
            <tbody>
                <tr>
                    <td nowrap="nowrap" align="right">
                    </td>
                    <td>
                        
                        <asp:CheckBox ID="chkSampleFromCustomer" runat="server" Text="客人提供样品" 
                            oncheckedchanged="chkSampleFromCustomer_CheckedChanged" 
                            AutoPostBack="True" />
                        <asp:panel ID="pnlOD" runat="server" Visible="false">
                        <asp:DropDownList ID="ddlProductFrom" runat="server" CssClass="dropdownlist">
                        </asp:DropDownList>
                        </asp:panel>
                    </td>
                    <td align="right">
                       <asp:Panel ID="pnlOH" runat="server" Visible="false">说明:</asp:Panel>
                    </td>
                    <td>
                    <asp:panel ID="pnlOE" runat="server" Visible="false">
                        <asp:TextBox ID="txtSampleFromCustomerIntro" runat="server" CssClass="text" Style="width: 254px"></asp:TextBox>
                        <asp:Button ID="btnAddSampleFromCustomer" runat="server" Text="添加" 
                            CssClass="button" onclick="btnAddSampleFromCustomer_Click" />
                            </asp:panel>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" align="left" colspan="4">
                        <div class="generaldiv" runat="server" id="pnlOF" Visible="false">
                            <asp:Repeater ID="rpSampleFromCustomer" runat="server">
                                <HeaderTemplate>
                                    <table class="listtable">
                                        <tbody>
                                            <tr class="gridheader">
                                                <td>
                                                    样品
                                                </td>
                                                <td>
                                                    说明
                                                </td>
                                            </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="gridrow">
                                        <td>
                                            <%#Eval("SampleName") %>
                                        </td>
                                        <td>
                                            <%#Eval("SampleIntro") %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="gridrowalt">
                                        <td>
                                            <%#Eval("SampleName") %>
                                        </td>
                                        <td>
                                            <%#Eval("SampleIntro") %>
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
            </tbody>
        </table>