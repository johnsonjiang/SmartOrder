<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EnquiryImageControl.ascx.cs" Inherits="VE.SMS.UI._UserControl.EnquiryImageControl" %>

<div>
    <asp:FileUpload ID="fileUploadEnqImg" runat="server" CssClass="file_input" />
    <asp:Button ID="btnUpload" runat="server" Text="上传" CssClass="button" 
        onclick="btnUpload_Click" />
</div>
<div style="width:100%;">
    <asp:Image ID="imgEnq" runat="server" Width="100%" AlternateText="咨询单图片" />
</div>
