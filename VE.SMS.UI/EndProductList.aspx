<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true" CodeBehind="EndProductList.aspx.cs" Inherits="VE.SMS.UI.EndProductList" %>
<%@ Register Src="_UserControl/FinishProductControl.ascx" TagName="FinishProductControl"
    TagPrefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <uc6:FinishProductControl ID="FinishProductControl1" runat="server"></uc6:FinishProductControl>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterConter" runat="server">
</asp:Content>
