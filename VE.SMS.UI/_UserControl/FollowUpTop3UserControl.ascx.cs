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
	public partial class FollowUpTop3UserControl : BaseUserControl
	{
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void BindControl()
        {
            FollowUpDAL dal = new FollowUpDAL();
            Utility.BindDataToRepeater(rpFollowUp, dal.GetTop3FollowUpBySource(SourceType, SourceNo));
        }

	}
}