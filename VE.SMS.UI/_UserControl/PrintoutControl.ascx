<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintoutControl.ascx.cs"
    Inherits="VE.SMS.UI._UserControl.PrintoutControl" %>
<link rel="stylesheet" media="all" type="text/css" href="../Styles/printout.css" />
<script language="javascript" type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
<script language="javascript" type="text/javascript" src="../Scripts/printout.js"></script>
<script language="javascript" type="text/javascript" src="../Scripts/jquery-ui.min.js"></script>

<script type="text/javascript" language="javascript">
    function printout() {
        $(".printfooter").hide();
        if ($("#ddlBankInfo").length != 0) {
            $("#ddlBankInfo").hide();
        }
        window.print();
        if ($("#ddlBankInfo").length != 0) {
            $("#ddlBankInfo").show();
        }
        $(".printfooter").show();
    }

</script>
<script language="javascript" type="text/javascript">
    function printsetup() {
        // 打印页面设置 
        WebBrowser.execwb(8, 1);
    }
    function printpreview() {
        // 打印页面预览 
        $(".printfooter").hide();
        if ($("#ddlBankInfo").length != 0) {
            $("#ddlBankInfo").hide();
        }
        WebBrowser.execwb(7, 1);
        $(".printfooter").show();
        if ($("#ddlBankInfo").length != 0) {
            $("#ddlBankInfo").show();
        }
    }

    function printit() {
        if (confirm('确定打印吗？')) {
            if ($("#ddlBankInfo").length != 0) {
                $("#ddlBankInfo").hide();
            }
            WebBrowser.execwb(6, 6)
            if ($("#ddlBankInfo").length != 0) {
                $("#ddlBankInfo").show();
            }
        }
    } 
</script>
<div class="printfooter">
<input type="button" class="button" value="打印" onclick="javascript:printout();" style="margin-right: 150px;
    float: right;" />
<input type="button" name="button_print" value="打印Web" class="button" onclick="javascript:printit()"/>
<input type="button" name="button_setup" value="打印页面设置" class="button" onclick="javascript:printsetup();"/>
<input type="button" name="button_show" value="打印预览" class="button" onclick="javascript:printpreview();"/>
</div>