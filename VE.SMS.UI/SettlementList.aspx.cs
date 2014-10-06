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
	public partial class SettlementList : BasePage
	{
        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewSettlementList;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Utility.BindDataToDropdown(ddlSettlementStatus, Utility.GetSettlementStatusList(true));
                Utility.BindDataToDropdown(ddlSettlementMan, Utility.GetUserList2(true));
                Utility.BindDataToRepeater(rpSettlementList, GetSettlementList());
            }
        }

        public List<Settlement> GetSettlementList()
        {
            SettlementDAL dal = new SettlementDAL();
            var result = dal.SearchSettlement(txtSettlementId.Text,
                                            Utility.GetSelectedText(ddlSettlementMan),
                                            !string.IsNullOrEmpty(txtBeginDate.Text) ? DateTime.Parse(txtBeginDate.Text) : DateTime.MinValue,
                                            !string.IsNullOrEmpty(txtEndDate.Text) ? DateTime.Parse(txtEndDate.Text) : DateTime.MaxValue,
                                            txtOrderId.Text,
                                            Utility.GetSelectedText(ddlSettlementStatus));
            return result;
        }

        double Total;
        double TotalNeed;
        double TotalRec;
        double TotalEnd;

        protected void rpSettlementList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Settlement st = e.Item.DataItem as Settlement;
                Repeater rpDelList = e.Item.FindControl("rpDelList") as Repeater;
                DeliveryDAL dlDAL = new DeliveryDAL();
                var deliverys = dlDAL.GetDeliveryByOrderNo(st.SourceNo);

                Utility.BindDataToRepeater(rpDelList, deliverys);
                FollowUpTop3UserControl followUp = e.Item.FindControl("followUpTop3UserControl") as FollowUpTop3UserControl;
                UIUtility.BindUserControl(followUp, SysConst.SourceTypeSettlement, st.St_No);

                Total += st.TotalAmount.GetValueOrDefault();
                TotalNeed += st.FirstAmount.GetValueOrDefault();
                TotalRec += st.AmountReceived.GetValueOrDefault();
                TotalEnd += st.TotalAmount.GetValueOrDefault() - st.AmountReceived.GetValueOrDefault();
            }
            if (e.Item.ItemType == ListItemType.Footer)
            {
                var lblTotal = e.Item.FindControl("lblTotal") as Label;
                var lblNeed = e.Item.FindControl("lblNeed") as Label;
                var lblRec = e.Item.FindControl("lblRec") as Label;
                var lblEnd = e.Item.FindControl("lblEnd") as Label;
                lblTotal.Text = Total.ToString();
                lblNeed.Text = TotalNeed.ToString();
                lblRec.Text = TotalRec.ToString();
                lblEnd.Text = TotalEnd.ToString();
            }
        }

        protected void rpSettlementList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete" && (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item))
            {
                HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
                new SettlementDAL().Delete(int.Parse(hdId.Value));
                Utility.BindDataToRepeater(rpSettlementList, GetSettlementList());
            }
            SetSorting(e);
            if (!string.IsNullOrWhiteSpace(SortOrder))
            {
                Utility.BindDataToRepeater(rpSettlementList, GetSettlementList().Sort(string.Format("{0} {1}", e.CommandName, SortOrder)));
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Utility.BindDataToRepeater(rpSettlementList, GetSettlementList());
        }
	}
}