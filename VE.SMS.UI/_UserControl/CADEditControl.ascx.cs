using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VE.SMS.UI._UserControl
{
	public partial class CADEditControl : BaseUserControl
	{
        public bool IsCADRefinementNeeded { get { return chkRefinement.Checked; } set { chkRefinement.Checked = value; pnlOA.Visible = chkRefinement.Checked; } }
        public string RefineIntro { get { return txtRefineIntro.Text; } set { txtRefineIntro.Text = value; } }
        public bool IsCustomerCADConfirmationNeeded { get { return chkCADCustomerConfirm.Checked; } set { chkCADCustomerConfirm.Checked = value; } }

		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void chkRefinement_CheckedChanged(object sender, EventArgs e)
        {
            pnlOA.Visible = chkRefinement.Checked;
            SetFocus(sender);
        }
	}
}