<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterIntroControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.FooterIntroControl" %>
<div class="generaldiv">
    <asp:Repeater ID="rpItems" runat="server" onitemcommand="rpItems_ItemCommand" 
        onitemdatabound="rpItems_ItemDataBound">
        <HeaderTemplate>
            <table class="listtable">
                <tbody>
                    <tr class="gridheader">
                        <td>
                            序号
                        </td>
                        <td>
                            说明
                        </td>
                        <td>
                            操作
                        </td>
                    </tr>
                    <tr class="gridrowadd">
                        <td>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlIntro" runat="server" CssClass="dropdownlist" Width="90%">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:LinkButton ID="btnCreateFollowUp" runat="server" Text="新增" CssClass="button"
                                CommandName="Add" />
                        </td>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="gridrow">
                <td>
                    <%#Container.ItemIndex + 1%>
                    <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Id") %>' />
                </td>
                <td>
                   <asp:TextBox ID="txtIntro" runat="server" Text='<%#Eval("Intro") %>' Width="90%" CssClass="text" ValidationGroup="Footer"></asp:TextBox>
                   <asp:RequiredFieldValidator
                            ID="rqEnqMan" runat="server" ErrorMessage="*" ForeColor="Red"  ValidationGroup="Footer" ControlToValidate="txtIntro" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:LinkButton ID="btnSave" runat="server" Text="保存" CssClass="button" CommandName="Save" ValidationGroup="Footer"/>
                    <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" />
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="gridrowalt">
                                <td>
                    <%#Container.ItemIndex + 1%>
                    <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Id") %>' />
                </td>
                <td>
                   <asp:TextBox ID="txtIntro" runat="server" Text='<%#Eval("Intro") %>' Width="90%" CssClass="text" ValidationGroup="Footer"></asp:TextBox>
                   <asp:RequiredFieldValidator
                            ID="rqEnqMan" runat="server" ErrorMessage="*" ForeColor="Red"  ValidationGroup="Footer" ControlToValidate="txtIntro" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:LinkButton ID="btnSave" runat="server" Text="保存" CssClass="button" CommandName="Save" ValidationGroup="Footer"/>
                    <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CssClass="button" CommandName="Delete" />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
</div>
