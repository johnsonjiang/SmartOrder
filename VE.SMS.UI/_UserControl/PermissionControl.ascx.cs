using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using VE.SMS.Common;
using VE.SMS.DAL;

namespace VE.SMS.UI._UserControl
{
	public partial class PermissionControl : BaseUserControl
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Utility.BindDataToDropdown(ddlRoleName, Utility.GetRoleList(true));
                Utility.BindDataToDropdown(ddlPermission, Utility.GetPermissionList(true));
                BindRepeater();
            }
        }

        private void BindRepeater()
        {
            UserDAL dal = new UserDAL();
            var result = dal.GetRolePermission(string.IsNullOrEmpty(ddlRoleName.SelectedValue) ? -1 : int.Parse(ddlRoleName.SelectedValue),
                                               string.IsNullOrEmpty(ddlPermission.SelectedValue) ? -1 : int.Parse(ddlPermission.SelectedValue));
            Utility.BindDataToRepeater(rpPermissionList, result);

        }

        protected void rpPermissionList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                if (e.Item.ItemType == ListItemType.Header)
                {
                    DropDownList ddlRoleNameAdd = e.Item.FindControl("ddlRoleNameAdd") as DropDownList;
                    DropDownList ddlPermissionAdd = e.Item.FindControl("ddlPermissionAdd") as DropDownList;
                    UserDAL dal = new UserDAL();
                    dal.AddPermission(int.Parse(ddlRoleNameAdd.SelectedValue), int.Parse(ddlPermissionAdd.SelectedValue));
                }
            }
            if (e.CommandName == "Delete")
            {
                HiddenField hfId = e.Item.FindControl("hfId") as HiddenField;
                UserDAL dal = new UserDAL();
                dal.DeletePermission(int.Parse(hfId.Value));
            }
            BindRepeater();
            Response.Redirect("AccessControlManagement.aspx?tabno=4");
        }

        protected void rpPermissionList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                DropDownList ddlRoleNameAdd = e.Item.FindControl("ddlRoleNameAdd") as DropDownList;
                DropDownList ddlPermissionAdd = e.Item.FindControl("ddlPermissionAdd") as DropDownList;
                Utility.BindDataToDropdown(ddlRoleNameAdd, Utility.GetRoleList());
                Utility.BindDataToDropdown(ddlPermissionAdd, Utility.GetPermissionList());
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindRepeater();
            Response.Redirect("AccessControlManagement.aspx?tabno=4");
        }

	}
}