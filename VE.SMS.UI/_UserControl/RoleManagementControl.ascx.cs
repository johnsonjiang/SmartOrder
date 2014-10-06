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
	public partial class RoleManagementControl : BaseUserControl
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Utility.BindDataToRepeater(rpRoleList, GetRoleList());
            }
        }

        private List<Role> GetRoleList()
        {
            RoleDAL dal = new RoleDAL();
            var result = dal.SearchRole(txtRoleName.Text);
            return result;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Utility.BindDataToRepeater(rpRoleList, GetRoleList());
            SetFocus(btnSearch);
            Response.Redirect("AccessControlManagement.aspx?tabno=2");
        }

        protected void rpRoleList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                if (e.Item.ItemType == ListItemType.Header)
                {
                    TextBox txtRoleNameAdd = e.Item.FindControl("txtRoleNameAdd") as TextBox;

                    Role role = new Role()
                    {
                        Role_Name = txtRoleNameAdd.Text,
                        IsActive = true
                    };

                    RoleDAL dal = new RoleDAL();
                    dal.AddRole(role);
                    dal.Save();

                }
            }
            else if (e.CommandName == "Delete")
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hfId = e.Item.FindControl("hfId") as HiddenField;
                    RoleDAL dal = new RoleDAL();
                    dal.DeleteRole(int.Parse(hfId.Value));
                }
            }
            Utility.BindDataToRepeater(rpRoleList, GetRoleList());
            SetFocus(source);
            Response.Redirect("AccessControlManagement.aspx?tabno=2");
        }
	}
}