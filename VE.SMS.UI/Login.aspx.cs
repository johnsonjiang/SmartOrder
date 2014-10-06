using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VE.SMS.Common;

namespace VE.SMS.UI
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Value) && !string.IsNullOrEmpty(txtPwd.Value))
            {
                UserInfo user = null;
                if (!ACLUtility.AuthorizeLoginUser(txtName.Value, txtPwd.Value, ref user))
                {
                    lblMsg.Visible = true;
                }
                else
                {
                    ACLUtility.WriteLoginCookie(user);
                    Response.Redirect("homepage.aspx");
                }
            }
        }
	}
}