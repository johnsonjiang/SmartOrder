using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using VE.SMS.Common;
using VE.SMS.DAL;
using VE.SMS.UI._UserControl;

namespace VE.SMS.UI
{
	public partial class SurveyList : BasePage
	{
        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewSurveyList;
            }
        }

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Utility.BindDataToDropdown(ddlSurveyStatus, Utility.GetSurveyStatusList(true));
                Utility.BindDataToDropdown(ddlEnqOrdMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlSurveyMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlCompany, Utility.GetCompanyList(true));
                Utility.BindDataToDropdown(ddlContact, Utility.GetContactList(true));

				BindControl();
			}
		}

		public void BindControl()
		{
			var result = GetSurveyList();
			Utility.BindDataToRepeater(rpSurveyList, result);
		}

		private List<Survey> GetSurveyList()
		{
			SurveyDAL dal = new SurveyDAL();
			var result = dal.SearchSurvey(txtSurveyNo.Text,
											Utility.GetSelectedText(ddlSurveyMan),
											Utility.GetSelectedText(ddlEnqOrdMan),
											Utility.GetSelectedText(ddlSurveyStatus),
											!string.IsNullOrEmpty(txtBeginDate.Text) ? DateTime.Parse(txtBeginDate.Text) : DateTime.MinValue,
											!string.IsNullOrEmpty(txtEndDate.Text) ? DateTime.Parse(txtEndDate.Text) : DateTime.MaxValue,
											Utility.GetSelectedText(ddlCompany),
											Utility.GetSelectedText(ddlContact),
											txtEmail.Text,
											txtPhone.Text,
											txtQQ.Text);
			return result;
		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{
			BindControl();
		}

		protected void rpSurveyList_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
            if (e.CommandName == "Delete" && (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item))
            {
                HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
                new SurveyDAL().Delete(int.Parse(hdId.Value));
                Utility.BindDataToRepeater(rpSurveyList, GetSurveyList());
            }
            else
            {
                SetSorting(e);
                if (!string.IsNullOrWhiteSpace(SortOrder))
                {
                    Utility.BindDataToRepeater(rpSurveyList, GetSurveyList().Sort(string.Format("{0} {1}", e.CommandName, SortOrder)));
                }
            }
		}

		protected void rpSurveyList_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				FollowUpTop3UserControl followUp = e.Item.FindControl("followUpTop3UserControl") as FollowUpTop3UserControl;
				UIUtility.BindUserControl(followUp, SysConst.SourceTypeSurvey, ((Survey)e.Item.DataItem).Survey_No);
			}
		}


	}
}