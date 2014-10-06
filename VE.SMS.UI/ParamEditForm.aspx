<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParamEditForm.aspx.cs"
    Inherits="VE.SMS.UI.ParamEditForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑加工参数</title>
    <link rel="stylesheet" media="all" type="text/css" href="Styles/menu_style.css" />
    <link rel="stylesheet" rev="stylesheet" href="Styles/style.css" type="text/css" media="all" />
    <link rel="stylesheet" media="all" type="text/css" href="Styles/jquery-ui.css" />
    <script type="text/javascript" language="javascript">
        function closeWindow() {
            returnValue = "Ok";
            window.close();

        }
    </script>
    <base target="_self"/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divParamSelect">
        <asp:Repeater ID="rpParams" runat="server" OnItemDataBound="rpParams_ItemDataBound">
            <HeaderTemplate>
                <table>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="gridrow">
                    <td>
                        <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Mach_Id") %>' />
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="cbParam" runat="server" Text='<%#Eval("Name") %>' />
                    </td>
                    <td align="left">
                        <asp:Image ID="imgPath" runat="server" ImageUrl='<%#Page.ResolveUrl(string.Format("~/_Files/MachTypeImage/{0}",Eval("MachIdentity").ToString())) %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="gridrowalt">
                    <td>
                        <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Mach_Id") %>' />
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="cbParam" runat="server" Text='<%#Eval("Name") %>' />
                    </td>
                    <td align="left">
                        <asp:Image ID="imgPath" runat="server" ImageUrl='<%#Page.ResolveUrl(string.Format("~/_Files/MachTypeImage/{0}",Eval("MachIdentity").ToString())) %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <div class="generaldiv">
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="保存" 
                onclick="btnSave_Click"></asp:Button>
            <input type="button" value="取消" onclick="javascript:window.close();" class="button" />
        </div>
    </div>
    </form>
</body>
</html>
