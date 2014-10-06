<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="AccessControlManagement.aspx.cs" Inherits="VE.SMS.UI.AccessControlManagement" %>

<%@ Register Src="_UserControl/UserManagementControl.ascx" TagName="UserManagementControl"
    TagPrefix="uc1" %>
<%@ Register Src="_UserControl/UserRoleMangementControl.ascx" TagName="UserRoleMangementControl"
    TagPrefix="uc1" %>
<%@ Register Src="_UserControl/PermissionControl.ascx" TagName="PermissionControl"
    TagPrefix="uc1" %>
<%@ Register src="_UserControl/RoleManagementControl.ascx" tagname="RoleManagementControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" media="all" type="text/css" href="Styles/tabs.css" />
    <link rel="stylesheet" media="all" type="text/css" href="Styles/style.css" />
    <script src="Scripts/tabs.js" language="javascript" type="text/javascript"></script>
        <script src="Scripts/jquery-1.4.1.min.js"></script>
    <script language="javascript">
        function getQueryStringByName(name) {
            var result = location.search.match(new RegExp("[\?\&]" + name + "=([^\&]+)", "i"));
            if (result == null || result.length < 1) {
                return "";
            }
            return result[1];
        }
        $(document).ready(function () {
            var queryValue = getQueryStringByName("tabno");
            if (queryValue != "") {
                var tabNo = parseInt(queryValue);
                switchTab(tabNo, 4);
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="box" class="generaldiv" style="width: 1002px">
        <ul id="tab">
            <li class="on" id="tab_1" onclick="switchTab(1,4)">用户管理</li>
            <li id="tab_2" onclick="switchTab(2,4)">角色管理</li>
            <li id="tab_3" onclick="switchTab(3,4)">用户角色管理</li>
            <li id="tab_4" onclick="switchTab(4,4)">权限管理</li>
        </ul>
        <ul id="tab_con">
            <li id="tab_con_1">
                <uc1:UserManagementControl ID="userManagementControl" runat="server" />
            </li>
            <li id="tab_con_2">
                <uc1:rolemanagementcontrol ID="roleManagementControl" runat="server" />
            </li>
            <li id="tab_con_3">
                <uc1:userrolemangementcontrol ID="userRoleMangementControl" runat="server" />
            </li>
            <li id="tab_con_4">
            <uc1:PermissionControl ID="PermissionControl1" runat="server" /></li>
        </ul>
    </div>
</asp:Content>
