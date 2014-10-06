<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="ProductForm.aspx.cs" Inherits="VE.SMS.UI.ProductForm" %>

<%@ Register src="_UserControl/FinishProductEditControl.ascx" tagname="FinishProductEditControl" tagprefix="uc2" %>
<%@ Register src="_UserControl/ProductInfoControl.ascx" tagname="ProductInfoControl" tagprefix="uc3" %>
<%@ Register src="_UserControl/SampleProductEditControl.ascx" tagname="SampleProductEditControl" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <script type="text/javascript" language="javascript">
            function closeWindow() {
                returnValue = "Ok";
                window.close();
            }
    </script>
    <uc3:ProductInfoControl ID="ProductInfoControl1" runat="server" Visible="false" />
    <uc4:SampleProductEditControl ID="SampleProductEditControl1" runat="server" Visible="false"/>
    <uc2:FinishProductEditControl ID="FinishProductEditControl1" runat="server" Visible="false"/>
    <input type="button" style="display:none" onclick="javascript:closeWindow();" id="btnClose"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterConter" runat="server">
</asp:Content>
