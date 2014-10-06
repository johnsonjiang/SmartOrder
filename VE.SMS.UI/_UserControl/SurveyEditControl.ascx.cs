using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VE.SMS.Common;

namespace VE.SMS.UI._UserControl
{
	public partial class SurveyEditControl : BaseUserControl
	{
        public bool IsSurveyNeed { get { return this.chkSurveyOnsite.Checked; } set { this.chkSurveyOnsite.Checked = value; } }
        public string SurveyType { get { return ddlSurveyType.SelectedValue; } }
        public string SurveyIntro { get { return txtSurveyIntro.Text; } set { txtSurveyIntro.Text = value; } }

		protected void Page_Load(object sender, EventArgs e)
		{
            
		}

        public override void BindControl()
        {
            pnlOA.Visible = chkSurveyOnsite.Checked;
            Utility.BindDataToDropdown(ddlSurveyType, Utility.GetLookupList(SysConst.SuveryCatelog));

        }

        public void SetSurveyType(string surveyType)
        {
            if (!string.IsNullOrEmpty(SurveyType))
            {
                ddlSurveyType.SelectedValue = surveyType;
            }
        }

        protected void chkSurveyOnsite_CheckedChanged(object sender, EventArgs e)
        {
            pnlOA.Visible = chkSurveyOnsite.Checked;
            SetFocus(sender);
        }
	}
}