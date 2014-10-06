<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true" CodeBehind="SampleList.aspx.cs" Inherits="VE.SMS.UI.SampleList" %>
<%@ Register src="_UserControl/SampleListControl.ascx" tagname="SampleListControl" tagprefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<uc7:SampleListControl ID="SampleListControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterConter" runat="server">
</asp:Content>
