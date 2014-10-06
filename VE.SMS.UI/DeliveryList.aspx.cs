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
	public partial class DeliveryList : BasePage
	{
        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewDeliveryList;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Utility.BindDataToDropdown(ddlDeliveryStatus, Utility.GetDeliveryStatusList(true));
                Utility.BindDataToRepeater(rpDeliveryList, GetDeliveryList());
                Utility.BindDataToDropdown(ddlDeliveryDriverMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlCompany, Utility.GetCompanyList(true));
                Utility.BindDataToDropdown(ddlContact, Utility.GetContactList(true));
                Utility.BindDataToDropdown(ddlInstallMan, Utility.GetUserList2(true));
            }
        }

        private List<Delivery> GetDeliveryList()
        {
            DeliveryDAL dal = new DeliveryDAL();
            var result = dal.SearchDelivery(txtDeliveryNo.Text,
                                            Utility.GetSelectedText(ddlCompany),
                                            Utility.GetSelectedText(ddlContact),
                                            txtPhone.Text,
                                            !string.IsNullOrEmpty(txtBeginDate.Text) ? DateTime.Parse(txtBeginDate.Text) : DateTime.MinValue,
                                            !string.IsNullOrEmpty(txtEndDate.Text) ? DateTime.Parse(txtEndDate.Text) : DateTime.MaxValue,
                                            Utility.GetSelectedText(ddlDeliveryDriverMan),
                                            Utility.GetSelectedText(ddlInstallMan),
                                            Utility.GetSelectedText(ddlDeliveryStatus),
                                            txtOrderNo.Text);
            return result;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Utility.BindDataToRepeater(rpDeliveryList, GetDeliveryList());
        }

        protected void rpDeliveryList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete" && (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item))
            {
                HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
                new DeliveryDAL().Delete(int.Parse(hdId.Value));
                Utility.BindDataToRepeater(rpDeliveryList, GetDeliveryList());
            }
            else
            {
                SetSorting(e);
                if (!string.IsNullOrWhiteSpace(SortOrder))
                {
                    Utility.BindDataToRepeater(rpDeliveryList, GetDeliveryList().Sort(string.Format("{0} {1}", e.CommandName, SortOrder)));
                }
            }
        }

        protected void rpDeliveryList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                FollowUpTop3UserControl followUp = e.Item.FindControl("followUpTop3UserControl") as FollowUpTop3UserControl;
                UIUtility.BindUserControl(followUp, SysConst.SourceTypeDelivery, ((Delivery)e.Item.DataItem).Delivery_No);
            }
        }
	}
}