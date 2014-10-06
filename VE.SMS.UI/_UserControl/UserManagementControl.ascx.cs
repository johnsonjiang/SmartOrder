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
	public partial class UserManagementControl : System.Web.UI.UserControl
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Utility.BindDataToRepeater(rpUserList, GetUserList());
            }
        }

        private List<User> GetUserList()
        {
            UserDAL dal = new UserDAL();
            var result = dal.SearchUser(txtUserName.Text, txtRealName.Text);
            return result;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Utility.BindDataToRepeater(rpUserList, GetUserList());
            Response.Redirect("AccessControlManagement.aspx?tabno=1");
        }

        protected void rpUserList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                if (e.Item.ItemType == ListItemType.Header)
                {
                    TextBox txtUserNameAdd = e.Item.FindControl("txtUserNameAdd") as TextBox;
                    TextBox txtRealNameAdd = e.Item.FindControl("txtRealNameAdd") as TextBox;
                    TextBox txtPasswordAdd = e.Item.FindControl("txtPasswordAdd") as TextBox;
                    TextBox txtPhone1Add = e.Item.FindControl("txtPhone1Add") as TextBox;
                    TextBox txtPhone2Add = e.Item.FindControl("txtPhone2Add") as TextBox;
                    TextBox txtDepartmentAdd = e.Item.FindControl("txtDepartmentAdd") as TextBox;

                    User user = new User() 
                    { 
                        UserName = txtUserNameAdd.Text,
                        RealName = txtRealNameAdd.Text,
                        Password = txtPasswordAdd.Text,
                        Phone1 = txtPhone1Add.Text,
                        Phone2 = txtPhone2Add.Text,
                        Department = txtDepartmentAdd.Text,
                        IsActive = true
                    };

                    UserDAL dal = new UserDAL();
                    dal.AddUser(user);
                    dal.Save();
                    
                }
            }
            else if (e.CommandName == "Save")
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hfId = e.Item.FindControl("hfId") as HiddenField;
                    UserDAL dal = new UserDAL();
                    var user = dal.GetUserById(int.Parse(hfId.Value));
                    TextBox txtRealName = e.Item.FindControl("txtRealName") as TextBox;
                    TextBox txtPwd = e.Item.FindControl("txtPwd") as TextBox;
                    TextBox txtPhone1 = e.Item.FindControl("txtPhone1") as TextBox;
                    TextBox txtPhone2 = e.Item.FindControl("txtPhone2") as TextBox;
                    TextBox txtDepartment = e.Item.FindControl("txtDepartment") as TextBox;

                    user.RealName = txtRealName.Text;
                    user.Password = txtPwd.Text;
                    user.Phone1 = txtPhone1.Text;
                    user.Phone2 = txtPhone2.Text;
                    user.Department = txtDepartment.Text;
                    dal.Save();
                }
            }
            else if (e.CommandName == "Delete")
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hfId = e.Item.FindControl("hfId") as HiddenField;
                    UserDAL dal = new UserDAL();
                    var user = dal.GetUserById(int.Parse(hfId.Value));
                    user.IsActive = false;
                    dal.Save();
                }
            }
            Utility.BindDataToRepeater(rpUserList, GetUserList());
            Response.Redirect("AccessControlManagement.aspx?tabno=1");
        }
	}
}