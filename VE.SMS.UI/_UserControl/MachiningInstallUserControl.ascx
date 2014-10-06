<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MachiningInstallUserControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.MachiningInstallUserControl" %>
<div class="generaldiv">
    <asp:Repeater ID="rpMachiningInstall" runat="server" 
        OnItemCommand="rpMachiningInstall_ItemCommand" EnableViewState="False">
        <HeaderTemplate>
            <table class="listtable">
                <tbody>
                    <tr class="gridheader">
                        <td width="15%">
                            代码
                        </td>
                        <td width="15%">
                            名称
                        </td>
                        <td width="10%">
                            单价(M)
                        </td>
                        <td width="10%">
                            单价(M2)
                        </td>
                        <td width="10%">
                            单价(其他)
                        </td>
                        <td>
                            加工标识
                        </td>
                        <td width="20%">
                            说明
                        </td>
                        <td width="10%">
                            操作
                        </td>
                    </tr>
                    <tr class="gridrowadd">
                        <td>
                            <asp:TextBox ID="txtCodeAdd" runat="server" CssClass="text" Width="80%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rq" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLookupAdd" ControlToValidate="txtCodeAdd"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNameAdd" runat="server" CssClass="text" Width="80%" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLookupAdd" ControlToValidate="txtNameAdd"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPriceMAdd" runat="server" CssClass="text" Width="80%" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLookupAdd" ControlToValidate="txtPriceMAdd"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceMAdd"
                            Type="Double" ValidationGroup="MachLookupAdd"></asp:CompareValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPriceM2Add" runat="server" CssClass="text" Width="80%" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLookupAdd" ControlToValidate="txtPriceM2Add"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceM2Add"
                            Type="Double" ValidationGroup="MachLookupAdd"></asp:CompareValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPriceOtherAdd" runat="server" CssClass="text" Width="80%" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLookupAdd" ControlToValidate="txtPriceOtherAdd"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceOtherAdd"
                            Type="Double" ValidationGroup="MachLookupAdd"></asp:CompareValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMachIdentityAdd" runat="server" CssClass="text" Width="80%" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLookupAdd" ControlToValidate="txtMachIdentityAdd"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemarkAdd" runat="server" CssClass="text" Width="80%" />
                        </td>
                        <td>
                            <asp:LinkButton ID="btnAdd" runat="server" Text="新增" CssClass="button" CommandName="Add" ValidationGroup="MachLookupAdd" />
                        </td>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="gridrow">
                <td>
                    <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Mach_Id") %>' />
                    <%#Eval("Code") %>
                </td>
                <td>
                    <%#Eval("Name") %>
                </td>
                <td>
                    <asp:TextBox ID="txtPriceM" runat="server" CssClass="text" Width="80%" Text='<%#Eval("PriceM") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLookup" ControlToValidate="txtPriceM"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceM"
                            Type="Double" ValidationGroup="MachLookup"></asp:CompareValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtPriceM2" runat="server" CssClass="text" Width="80%" Text='<%#Eval("PriceM2") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLookup" ControlToValidate="txtPriceM2"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceM2"
                            Type="Double" ValidationGroup="MachLookup"></asp:CompareValidator>
                </td>
                                <td>
                    <asp:TextBox ID="txtPriceOther" runat="server" CssClass="text" Width="80%" Text='<%#Eval("PriceOther") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLookup" ControlToValidate="txtPriceOther"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceOther"
                            Type="Double" ValidationGroup="MachLookup"></asp:CompareValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtMachIdentity" runat="server" CssClass="text" Width="80%" Text='<%#Eval("MachIdentity") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLookup" ControlToValidate="txtMachIdentity"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtRemark" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Intro") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:LinkButton ID="btnSave" runat="server" Text="保存" CssClass="button" CommandName="Save" ValidationGroup="MachLookup" />
                    <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" ValidationGroup="MachLookup" />
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="gridrowalt">
                <td>
                    <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Mach_Id") %>' />
                    <%#Eval("Code") %>
                </td>
                <td>
                    <%#Eval("Name") %>
                </td>
                <td>
                    <asp:TextBox ID="txtPriceM" runat="server" CssClass="text" Width="80%" Text='<%#Eval("PriceM") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLookup" ControlToValidate="txtPriceM"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceM"
                            Type="Double" ValidationGroup="MachLookup"></asp:CompareValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtPriceM2" runat="server" CssClass="text" Width="80%" Text='<%#Eval("PriceM2") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLookup" ControlToValidate="txtPriceM2"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceM2"
                            Type="Double" ValidationGroup="MachLookup"></asp:CompareValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtPriceOther" runat="server" CssClass="text" Width="80%" Text='<%#Eval("PriceOther") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLookup" ControlToValidate="txtPriceOther"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceOther"
                            Type="Double" ValidationGroup="MachLookup"></asp:CompareValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtMachIdentity" runat="server" CssClass="text" Width="80%" Text='<%#Eval("MachIdentity") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="MachLookup" ControlToValidate="txtMachIdentity"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtRemark" runat="server" CssClass="text" Width="80%" Text='<%#Eval("Intro") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:LinkButton ID="btnSave" runat="server" Text="保存" CssClass="button" CommandName="Save" ValidationGroup="MachLookup" />
                    <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" ValidationGroup="MachLookup" />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
</div>
