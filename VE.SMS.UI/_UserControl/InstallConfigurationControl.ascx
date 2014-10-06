<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstallConfigurationControl.ascx.cs" Inherits="VE.SMS.UI._UserControl.InstallConfigurationControl" %>
<div class="generaldiv">
    <asp:Repeater ID="rpMachiningInstall" runat="server" 
        onitemcommand="rpMachiningInstall_ItemCommand">
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
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="InstallLookupAdd" ControlToValidate="txtCodeAdd"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNameAdd" runat="server" CssClass="text" Width="80%" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="InstallLookupAdd" ControlToValidate="txtNameAdd"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPriceMAdd" runat="server" CssClass="text" Width="80%" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="InstallLookupAdd" ControlToValidate="txtPriceMAdd"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceMAdd"
                            Type="Double" ValidationGroup="InstallLookupAdd"></asp:CompareValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPriceM2Add" runat="server" CssClass="text" Width="80%" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="InstallLookupAdd" ControlToValidate="txtPriceM2Add"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceM2Add"
                            Type="Double" ValidationGroup="InstallLookupAdd"></asp:CompareValidator>
                        </td>
                                                <td>
                            <asp:TextBox ID="txtPriceOtherAdd" runat="server" CssClass="text" Width="80%" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="InstallLookupAdd" ControlToValidate="txtPriceOtherAdd"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceOtherAdd"
                            Type="Double" ValidationGroup="InstallLookupAdd"></asp:CompareValidator>
                        </td>
                        
                        <td>
                            <asp:TextBox ID="txtRemarkAdd" runat="server" CssClass="text" Width="80%" />
                        </td>
                        <td>
                            <asp:LinkButton ID="btnAdd" runat="server" Text="新增" CssClass="button" CommandName="Add" ValidationGroup="InstallLookupAdd"/>
                        </td>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="gridrow">
                <td>
                    <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("Install_Id") %>' />
                    <%#Eval("Code") %>
                </td>
                <td>
                    <%#Eval("Name") %>
                </td>
                <td>
                    <asp:TextBox ID="txtPriceM" runat="server"  Text='<%#Eval("PriceM") %>' CssClass="text" Width="80%"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="InstallLookup" ControlToValidate="txtPriceM"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceM"
                            Type="Double" ValidationGroup="InstallLookup"></asp:CompareValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtPriceM2" runat="server" Text='<%#Eval("PriceM2") %>'  CssClass="text" Width="80%"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="InstallLookup" ControlToValidate="txtPriceM2"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceM2"
                            Type="Double" ValidationGroup="InstallLookup"></asp:CompareValidator>
                </td>
                   <td>
                    <asp:TextBox ID="txtPriceOther" runat="server" Text='<%#Eval("PriceOther") %>'  CssClass="text" Width="80%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="InstallLookup" ControlToValidate="txtPriceOther"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceOther"
                            Type="Double" ValidationGroup="InstallLookup"></asp:CompareValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtRemark" runat="server"  Text='<%#Eval("Intro") %>' CssClass="text" Width="80%"></asp:TextBox>
                </td>
                <td>
                    <asp:LinkButton ID="btnSave" runat="server" Text="保存" CssClass="button" CommandName="Save"  ValidationGroup="InstallLookup"/>
                    <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete"  ValidationGroup="InstallLookup"/>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="gridrowalt">
               <td>
                    <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("Install_Id") %>' />
                    <%#Eval("Code") %>
                </td>
                <td>
                    <%#Eval("Name") %>
                </td>
                <td>
                    <asp:TextBox ID="txtPriceM" runat="server"  Text='<%#Eval("PriceM") %>' CssClass="text" Width="80%"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="InstallLookup" ControlToValidate="txtPriceM"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceM"
                            Type="Double" ValidationGroup="InstallLookup"></asp:CompareValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtPriceM2" runat="server" Text='<%#Eval("PriceM2") %>'  CssClass="text" Width="80%"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="InstallLookup" ControlToValidate="txtPriceM2"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceM2"
                            Type="Double" ValidationGroup="InstallLookup"></asp:CompareValidator>
                </td>
                   <td>
                    <asp:TextBox ID="txtPriceOther" runat="server" Text='<%#Eval("PriceOther") %>'  CssClass="text" Width="80%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="InstallLookup" ControlToValidate="txtPriceOther"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPriceOther"
                            Type="Double" ValidationGroup="InstallLookup"></asp:CompareValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtRemark" runat="server"  Text='<%#Eval("Intro") %>' CssClass="text" Width="80%"></asp:TextBox>
                </td>
                <td>
                    <asp:LinkButton ID="btnSave" runat="server" Text="保存" CssClass="button" CommandName="Save"  ValidationGroup="InstallLookup"/>
                    <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete"  ValidationGroup="InstallLookup"/>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
</div>
