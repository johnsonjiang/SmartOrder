using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VE.SMS.Common;

namespace VE.SMS.UI
{
	public partial class AccessControlManagement : BasePage
	{
        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewAccessControlManagement;
            }
        }

        protected override string EditName
        {
            get
            {
                return ACLConsts.EditAccessControlManagement;
            }
        }
		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}