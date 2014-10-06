<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerDrawingControl.ascx.cs" Inherits="VE.SMS.UI._UserControl.CustomerDrawingControl" %>

<div class="generaldiv" runat="server" id="divOperate">
    <asp:CheckBox ID="chkProvideDrawing" runat="server" Text="客户提供图纸" 
        AutoPostBack="True" oncheckedchanged="chkProvideDrawing_CheckedChanged" />
    <asp:Panel ID="pnlOA" runat="server">
    <asp:FileUpload ID="fileUploadDrawing" runat="server" CssClass="file_input" />  说明:
    <asp:TextBox ID="txtCustomerDrawingIntro" runat="server" CssClass="text" 
        Style="width: 254px"></asp:TextBox>
    <asp:Button ID="btnUpload" runat="server" Text="上传" CssClass="button" 
        onclick="btnUpload_Click" />
        </asp:Panel>
</div>
<div class="generaldiv" id="pnlOB" runat="server">
    <asp:Repeater ID="rpCustomerDrawing" runat="server" 
        onitemcommand="rpCustomerDrawing_ItemCommand">
        <HeaderTemplate>
                    <table class="listtable">
                <tbody>
                <tr class="gridheader">
            <td>图纸</td>
            <td>说明</td>
            <td>操作</td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr class="gridrow">
            <td><a href='<%#Eval("CustomerDrawing_Path") %>' target="_blank"><%#Eval("CustomerDrawing_Name")%></a>
                <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("CustomerDrawing_Id") %>' />
            </td>
            <td><%#Eval("CustomerDrawing_Intro")%></td>
            <td><asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="删除"></asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
        <tr class="gridrowalt">
            <td><a href='<%#Eval("CustomerDrawing_Path") %>' target="_blank"><%#Eval("CustomerDrawing_Name")%></a>
            <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("CustomerDrawing_Id") %>' />
            </td>
            <td><%#Eval("CustomerDrawing_Intro")%></td>
            <td><asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="删除"></asp:LinkButton></td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
</div>
