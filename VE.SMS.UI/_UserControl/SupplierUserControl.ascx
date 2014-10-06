<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SupplierUserControl.ascx.cs" Inherits="VE.SMS.UI._UserControl.SupplierUserControl" %>
<div class="generaldiv">
    <asp:Repeater ID="rpSupplier" runat="server" 
        onitemcommand="rpSupplier_ItemCommand">
        <HeaderTemplate>
            <table class="listtable">
                <tbody>
                    <tr class="gridheader">
                        <td>
                            供应商名称
                        </td>
                        <td>
                            供应商联系人
                        </td>
                        <td>
                            联系电话
                        </td>
                        <td>
                            备注
                        </td>
                        <td>
                            操作
                        </td>
                    </tr>
                    <tr class="gridrowadd">
                        <td>
                            <asp:TextBox ID="txtSupplierNameAdd" runat="server" CssClass="text" Width="95%"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactNameAdd" runat="server" CssClass="text" Width="95%"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhoneAdd" runat="server" CssClass="text" Width="95%" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemarkAdd" runat="server" CssClass="text" Width="95%" />
                        </td>
                        <td>
                            <asp:LinkButton ID="btnAdd" runat="server" Text="新增" CssClass="button" CommandName="Add" />
                        </td>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="gridrow">
                <td>
                    <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("Supplier_Id") %>' />
                    <asp:TextBox ID="txtSupplierName" runat="server" Text='<%#Eval("Supplier_Name") %>' CssClass="text"
                        Width="95%"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtContactName" runat="server" Text='<%#Eval("Supplier_ContactName") %>' CssClass="text"
                        Width="95%"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" Text='<%#Eval("Supplier_Phone") %>' CssClass="text" Width="95%"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtRemark" runat="server" Text='<%#Eval("Remark") %>' CssClass="text"
                        Width="95%"></asp:TextBox>
                </td>
                <td>
                    <asp:LinkButton ID="btnSave" runat="server" Text="保存" CssClass="button" CommandName="Save" />
                    <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" />
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="gridrowalt">
                      <td>
                    <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("Supplier_Id") %>' />
                    <asp:TextBox ID="txtSupplierName" runat="server" Text='<%#Eval("Supplier_Name") %>' CssClass="text"
                        Width="95%"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtContactName" runat="server" Text='<%#Eval("Supplier_ContactName") %>' CssClass="text"
                        Width="95%"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" Text='<%#Eval("Supplier_Phone") %>' CssClass="text" Width="95%"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtRemark" runat="server" Text='<%#Eval("Remark") %>' CssClass="text"
                        Width="95%"></asp:TextBox>
                </td>
                <td>
                    <asp:LinkButton ID="btnSave" runat="server" Text="保存" CssClass="button" CommandName="Save" />
                    <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
</div>
