<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SettlementPrintout.aspx.cs"
    Inherits="VE.SMS.UI.Printout.SettlementPrintout" %>

<%@ Register Src="../_UserControl/PrintoutControl.ascx" TagName="PrintoutControl"
    TagPrefix="uc1" %>

<%@ Register src="SettlementPrintoutControl.ascx" tagname="SettlementPrintoutControl" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" media="all" type="text/css" href="../Styles/menu_style.css" />
    <link rel="stylesheet" rev="stylesheet" href="../Styles/style.css" type="text/css"
        media="all" />
    <link rel="stylesheet" media="all" type="text/css" href="../Styles/jquery-ui.css" />
    <script language="javascript" type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <script language="javascript" type="text/javascript" src="../Scripts/jquery-ui.min.js"></script>
</head>
<body>
    <%--<OBJECT id=wb height=0 width=0 classid=CLSID:8856F961-340A-11D0-A96B-00C04FD705A2 name=wb></OBJECT>--%>
    <form id="form1" runat="server">
    <div class="generaldiv">
    </div>
    <div class="printsection>
    <uc2:SettlementPrintoutControl ID="SettlementPrintoutControl1" runat="server" />
    </div>
    <uc1:PrintoutControl ID="PrintoutControl1" runat="server" />
    </form>
</body>
</html>
