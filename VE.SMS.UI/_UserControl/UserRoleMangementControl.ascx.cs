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
	public partial class UserRoleMangementControl : BaseUserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                Utility.BindDataToDropdown(ddlUserName, Utility.GetUserList(true));
                Utility.BindDataToDropdown(ddlRole, Utility.GetRoleList(true));
                Utility.BindDataToRepeater(rpUserRoleList, GetUserRoleList());
            }
		}

        private List<UserRoleItem> GetUserRoleList()
        {
            UserDAL dal = new UserDAL();
            var result = dal.GetUserRoleList(string.IsNullOrEmpty(ddlUserName.SelectedValue) ? -1 : int.Parse(ddlUserName.SelectedValue), 
                                             string.IsNullOrEmpty(ddlRole.SelectedValue) ? -1 : int.Parse(ddlRole.SelectedValue));
            return result;
        }
		protected void btnSearch_Click(object sender, EventArgs e)
		{
            Utility.BindDataToRepeater(rpUserRoleList, GetUserRoleList());
            Response.Redirect("AccessControlManagement.aspx?tabno=3");
		}

        protected void rpUserRoleList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                if (e.Item.ItemType == ListItemType.Header)
                {
                    DropDownList ddlUserNameAdd = e.Item.FindControl("ddlUserNameAdd") as DropDownList;
                    DropDownList ddlRoleAdd = e.Item.FindControl("ddlRoleAdd") as DropDownList;
                    UserDAL dal = new UserDAL();
                    dal.AddUserRole(int.Parse(ddlUserNameAdd.SelectedValue), int.Parse(ddlRoleAdd.SelectedValue));
                    Utility.BindDataToRepeater(rpUserRoleList, GetUserRoleList());
                }
            }
            if (e.CommandName == "Delete")
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hfUrId = e.Item.FindControl("hfUrId") as HiddenField;
                    UserDAL dal = new UserDAL();
                    dal.DeleteUserRole(int.Parse(hfUrId.Value));
                    Utility.BindDataToRepeater(rpUserRoleList, GetUserRoleList());
                }
            }
            Response.Redirect("AccessControlManagement.aspx?tabno=3");
        }

        protected void rpUserRoleList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                DropDownList ddlUserNameAdd = e.Item.FindControl("ddlUserNameAdd") as DropDownList;
                DropDownList ddlRoleAdd = e.Item.FindControl("ddlRoleAdd") as DropDownList;
                Utility.BindDataToDropdown(ddlUserNameAdd, Utility.GetUserList());
                Utility.BindDataToDropdown(ddlRoleAdd, Utility.GetRoleList());
            }
        }
	}
}