using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VE.SMS.Common;

namespace VE.SMS.UI._UserControl
{
	public partial class InstallEditControl : BaseUserControl
	{
        public bool IsInstallProvided
        {
            get { return chkInstall.Checked; }
            set
            {
                chkInstall.Checked = value; ddlInstallType.Visible = chkInstall.Checked;
                pnlOA.Visible = chkInstall.Checked;
                pnlOB.Visible = chkInstall.Checked;
            }
        }
        public string InstallType { get { return ddlInstallType.SelectedValue; } }
        public string InstallIntro { get { return txtInstallIntro.Text; } set { txtInstallIntro.Text = value; } }

		protected void Page_Load(object sender, EventArgs e)
		{

		}

        public override void BindControl()
        {
            Utility.BindDataToDropdown(ddlInstallType, Utility.GetLookupList(SysConst.InstallCatelog));
        }

        public void SetInstallType(string installType)
        {
            if (!string.IsNullOrEmpty(installType))
            {
                ddlInstallType.SelectedValue = installType;
            }
        }

        protected void chkInstall_CheckedChanged(object sender, EventArgs e)
        {
            ddlInstallType.Visible = chkInstall.Checked;
            pnlOA.Visible = chkInstall.Checked;
            pnlOB.Visible = chkInstall.Checked;
            SetFocus(sender);
        }
	}
}