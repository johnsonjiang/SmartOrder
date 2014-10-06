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
	public partial class FollowUpControl : BaseUserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			BindControl();
		}

        public string Person { get { return ddlFollowUpPersonAdd.SelectedValue; } }

		public override void BindControl()
		{
			FollowUpDAL dal = new FollowUpDAL();
			Utility.BindDataToRepeater(rpFollowUp, dal.GetFollowUpBySource(SourceType, SourceNo));
            Utility.BindDataToDropdown(ddlFollowUpPersonAdd, Utility.GetUserList2());
            ddlFollowUpPersonAdd.SelectedValue = SMSContext.Current.User.RealName;
		}

		public void AddFollowUp(string followUpNotes)
		{
			FollowUp followUp = new FollowUp()
			{
				FollowUp_Date = DateTime.Now,
				FollowUp_Man = ddlFollowUpPersonAdd.SelectedItem.Text,
				FollowUp_Notes = followUpNotes,
				SourceNo = SourceNo,
				SourceType = SourceType
			};
			FollowUpDAL dal = new FollowUpDAL();
			dal.AddFollowUp(followUp);
			dal.Save();
			BindControl();
		}

        protected void btnCreateFollowUp_Click(object sender, EventArgs e)
        {
            string followUpMan = ddlFollowUpPersonAdd.SelectedItem.Text;
            string followUpNote = txtFollowUpNoteAdd.Text;

            if (!string.IsNullOrEmpty(followUpMan) && !string.IsNullOrEmpty(followUpNote))
            {
                AddFollowUp(followUpNote);
                BindControl();
            }
            this.SetFocus(btnFocus);
        }
	}
}