<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CADFileListControl.ascx.cs" Inherits="VE.SMS.UI._UserControl.CADFileListControl" %>

<div class="generaldiv" runat="server" id="divOperate">
    <asp:FileUpload ID="fileUploadDrawing" runat="server"  class="file_input" />
    说明:<asp:TextBox ID="txtIntro" runat="server" CssClass="text" Width="200px"></asp:TextBox>
    <asp:Button ID="btnUpload" runat="server" Text="上传" CssClass="button" 
        onclick="btnUpload_Click" />
        
</div>
<div class="generaldiv">
    <asp:Repeater ID="rpCADFile" runat="server">
        <HeaderTemplate>
                    <table class="listtable">
                <tbody>
                <tr class="gridheader">
            <td>细化文件</td>
            <td>时间</td>
            <td>说明</td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr class="gridrow">
            <td><a href='<%#Eval("RefineFilePath") %>' target="_blank"><%#Eval("RefineFileName")%></a></td>
            <td><%#Eval("RefineItemDate")%></td>
            <td><%#Eval("Intro") %></td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
        <tr class="gridrowalt">
            <td><a href='<%#Eval("RefineFilePath") %>' target="_blank"><%#Eval("RefineFileName")%></a></td>
            <td><%#Eval("RefineItemDate")%></td>
            <td><%#Eval("Intro") %></td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
</div>
