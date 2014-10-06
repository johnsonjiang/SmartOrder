<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MachiningSummaryControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.MachiningSummaryControl" %>
<div class="generaldiv">
    <asp:Repeater ID="rpItems" runat="server" onitemcommand="rpItems_ItemCommand" 
        onitemdatabound="rpItems_ItemDataBound">
        <HeaderTemplate>
            <table class="listtable">
                <tbody>
                    <tr class="gridheader">
                        <td width="10%">
                            序号
                        </td>
                        <td width="10%">
                            加工说明
                        </td>
                        <td width="10%" align="center">
                            加工名称
                        </td>
                        <td width="10%" align="center">
                            单位
                        </td>
                        <td width="10%" align="center">
                            数量
                        </td>
                        <td width="20%" align="center">
                            标识
                        </td>
                        <td width="20%" align="center">
                            备注
                        </td>
                        <td width="10%" align="center">
                            操作
                        </td>
                    </tr>
                    <tr class="gridrowadd">
                        <td>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMachIntroAdd" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlMachNameAdd" runat="server" Width="90%"></asp:DropDownList>
                        </td>
                        <td align="center">
                            <asp:dropdownlist ID="ddlMachUnitAdd" runat="server" CssClass="text" Width="90%"></asp:dropdownlist>
                        </td>
                        <td  align="center">
                            <asp:TextBox ID="txtQtyAdd" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                        </td>
                        <td align="center">
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtRemarkAdd" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                        </td>
                        <td align="center">
                            <asp:LinkButton ID="btnAdd" runat="server" CssClass="button" Text="新增" CommandName="Add"></asp:LinkButton>
                        </td>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="gridrow">
                <td>
                    <%#Container.ItemIndex + 1 %>
                </td>
                <td>
                    <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Id") %>' />
                            <asp:TextBox ID="txtMachIntro" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlMachName" runat="server" Width="90%"></asp:DropDownList>
                        </td>
                        <td align="center">
                            <asp:dropdownlist ID="ddlMachUnit" runat="server" CssClass="text" Width="90%"></asp:dropdownlist>
                        </td>
                        <td  align="center">
                            <asp:TextBox ID="txtQty" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                        </td>
                        <td align="center">
                            <asp:Image ID="imgPath" runat="server" />
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtRemark" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                        </td>
                <td align="center">
                    <asp:LinkButton ID="btnSave" runat="server" CssClass="button" Text="保存" CommandName="Save"></asp:LinkButton>
                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="button" Text="删除" CommandName="Delete"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="gridrowalt">
                <td>
                    <%#Container.ItemIndex + 1 %>
                </td>
                <td>
                    <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Id") %>' />
                            <asp:TextBox ID="txtMachIntro" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlMachName" runat="server" Width="90%"></asp:DropDownList>
                        </td>
                        <td align="center">
                            <asp:dropdownlist ID="ddlMachUnit" runat="server" CssClass="text" Width="90%"></asp:dropdownlist>
                        </td>
                        <td  align="center">
                            <asp:TextBox ID="txtQty" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                        </td>
                        <td align="center">
                            <asp:Image ID="imgPath" runat="server" />
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtRemark" runat="server" CssClass="text" Width="90%"></asp:TextBox>
                        </td>
                <td align="center">
                    <asp:LinkButton ID="btnSave" runat="server" CssClass="button" Text="保存" CommandName="Save"></asp:LinkButton>
                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="button" Text="删除" CommandName="Delete"></asp:LinkButton>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:LinkButton ID="btnLoc" runat="server"></asp:LinkButton>
</div>
