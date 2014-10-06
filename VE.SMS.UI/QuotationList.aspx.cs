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
	public partial class QuotationList : BasePage
	{
        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewQuotationList;
            }
        }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Utility.BindDataToDropdown(ddlQuotationStatus, Utility.GetQuotationStatusList(true));
                Utility.BindDataToDropdown(ddlEnqOrdMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlQuoteMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlCompany, Utility.GetCompanyList(true));
                Utility.BindDataToDropdown(ddlContact, Utility.GetContactList(true));
                Utility.BindDataToRepeater(rpQuotationList, GetQuoteList());
			}
		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{
			Utility.BindDataToRepeater(rpQuotationList, GetQuoteList());
		}

		private List<Quotation> GetQuoteList()
		{
			string quono = txtQuotationNo.Text;
            string quoman = Utility.GetSelectedText(ddlQuoteMan);
            string enqOrdMan = Utility.GetSelectedText(ddlEnqOrdMan);
			string status = Utility.GetSelectedText(ddlQuotationStatus);
			DateTime beginDate = string.IsNullOrEmpty(txtBeginDate.Text) ? DateTime.MinValue : DateTime.Parse(txtBeginDate.Text);
			DateTime endDate = string.IsNullOrEmpty(txtEndDate.Text) ? DateTime.MaxValue : DateTime.Parse(txtEndDate.Text);
            string companyName = Utility.GetSelectedText(ddlCompany);
            string contcat = Utility.GetSelectedText(ddlContact);
			string email = txtEmail.Text;
			string phone = txtPhone.Text;
			string qq = txtQQ.Text;

			QuotationDAL dal = new QuotationDAL();
			var quotes =  dal.SearchQuote(quono,
										quoman,
										enqOrdMan,
										status, 
										beginDate,
										endDate,
										companyName,
										contcat,
										email,
										phone,
										qq);
			return quotes;
		}

        protected void rpQuotationList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType==ListItemType.Item)
            {
                FollowUpTop3UserControl followUpTop3UserControl = e.Item.FindControl("followUpTop3UserControl") as FollowUpTop3UserControl;
                UIUtility.BindUserControl(followUpTop3UserControl, SysConst.SourceTypeQuote, ((Quotation)e.Item.DataItem).Quotation_No);
            }
        }

        protected void rpQuotationList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete" && (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item))
            {
                HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
                new QuotationDAL().Delete(int.Parse(hdId.Value));
                Utility.BindDataToRepeater(rpQuotationList, GetQuoteList());
            }
            else
            {
                SetSorting(e);
                if (!string.IsNullOrWhiteSpace(SortOrder))
                {
                    Utility.BindDataToRepeater(rpQuotationList, GetQuoteList().Sort(string.Format("{0} {1}", e.CommandName, SortOrder)));
                }
            }
        }
	}
}