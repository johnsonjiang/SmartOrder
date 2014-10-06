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
	public partial class RefineList : BasePage
	{
        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewRefineList;
            }
        }
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                Utility.BindDataToDropdown(ddlRefineStatus, Utility.GetRefineStatusList(true));
                Utility.BindDataToDropdown(ddlRefMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlEnqOrderResponder, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlCompany, Utility.GetCompanyList(true));
                Utility.BindDataToDropdown(ddlContact, Utility.GetContactList(true));
                BindControl();
            }
		}

        private void BindControl()
        {
            var result = GetRefineList();
            Utility.BindDataToRepeater(rpRefineList, result);

        }

        private List<Refine> GetRefineList()
        {
            string refNo = txtRefineNo.Text;
            string refMan = Utility.GetSelectedText(ddlRefMan);
            string enqOrdMan = Utility.GetSelectedText(ddlEnqOrderResponder);
            string status = Utility.GetSelectedText(ddlRefineStatus);
            DateTime beginDate = !string.IsNullOrEmpty(txtBeginDate.Text) ? DateTime.Parse(txtBeginDate.Text) : DateTime.MinValue;
            DateTime endDate = !string.IsNullOrEmpty(txtEndDate.Text) ? DateTime.Parse(txtEndDate.Text) : DateTime.MaxValue;
            string companyName = Utility.GetSelectedText(ddlCompany);
            string contact = Utility.GetSelectedText(ddlContact);
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string qq = txtQQ.Text;

            RefineDAL dal = new RefineDAL();
            var result = dal.SearchRefine(refNo,
                                        refMan,
                                        enqOrdMan,
                                        status,
                                        beginDate,
                                        endDate,
                                        companyName,
                                        contact,
                                        email,
                                        phone,
                                        qq);
            return result;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControl();
        }

        protected void rpRefineList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete" && (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item))
            {
                HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
                new RefineDAL().Delete(int.Parse(hdId.Value));
                BindControl();
            }
            else
	        {
	            SetSorting(e);
                if (!string.IsNullOrWhiteSpace(SortOrder))
                {
                    Utility.BindDataToRepeater(rpRefineList, GetRefineList().Sort(string.Format("{0} {1}", e.CommandName, SortOrder)));
                } 
	        }
        }

        protected void rpRefineList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                FollowUpTop3UserControl followUp = e.Item.FindControl("followUpTop3UserControl") as FollowUpTop3UserControl;
                UIUtility.BindUserControl(followUp, SysConst.SourceTypeRefine, ((Refine)e.Item.DataItem).Refine_No);
            }
        }

	}
}