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
	public partial class OrderList : BasePage
	{
        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewOrderList;
            }
        }

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                Utility.BindDataToDropdown(ddlOrderStatus, Utility.GetOrderStatusList(true));
                Utility.BindDataToDropdown(ddlOrdMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlCompany, Utility.GetCompanyList(true));
                Utility.BindDataToDropdown(ddlContact, Utility.GetContactList(true));

                Utility.BindDataToRepeater(rpOrderList, GetOrderList());
            }
		}

        public List<Order> GetOrderList()
        {
            OrderDAL dal = new OrderDAL();
            var result = dal.SearchOrder(txtOrderNo.Text,
                                        Utility.GetSelectedText(ddlOrdMan),
                                        Utility.GetSelectedText(ddlOrderStatus),
                                        !string.IsNullOrEmpty(txtBeginDate.Text) ? DateTime.Parse(txtBeginDate.Text) : DateTime.MinValue,
                                        !string.IsNullOrEmpty(txtEndDate.Text) ? DateTime.Parse(txtEndDate.Text) : DateTime.MaxValue,
                                        Utility.GetSelectedText(ddlCompany),
                                        Utility.GetSelectedText(ddlContact),
                                        txtPhone.Text
                                        );
            return result;            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Utility.BindDataToRepeater(rpOrderList, GetOrderList());
        }

        protected void rpOrderList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete" && (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item))
            {
                HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
                new OrderDAL().Delete(int.Parse(hdId.Value));
                Utility.BindDataToRepeater(rpOrderList, GetOrderList());
            }
            else
            {
                SetSorting(e);
                if (!string.IsNullOrWhiteSpace(SortOrder))
                {
                    Utility.BindDataToRepeater(rpOrderList, GetOrderList().Sort(string.Format("{0} {1}", e.CommandName, SortOrder)));
                }
            }
        }

        double totalContract = 0;
        double totalSt = 0;
        double totalRec = 0;
        double totalNeed = 0;

        protected void rpOrderList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Order order = e.Item.DataItem as Order;
                FollowUpTop3UserControl followUp = e.Item.FindControl("followUpTop3UserControl") as FollowUpTop3UserControl;
                UIUtility.BindUserControl(followUp, SysConst.SourceTypeOrder, order.Order_No);

                Label lblContractAmount = e.Item.FindControl("lblContractAmount") as Label;
                Label lblSettlementAmount = e.Item.FindControl("lblSettlementAmount") as Label;
                Label lblReceivedAmount = e.Item.FindControl("lblReceivedAmount") as Label;
                Label lblNeedAmount = e.Item.FindControl("lblNeedAmount") as Label;
                LineItemDAL lineDAL = new LineItemDAL();
                SettlementDAL stDAL = new SettlementDAL();
                ReceiptDAL rDAL = new ReceiptDAL();
                var contractAmount = lineDAL.GetLineItemsBySource(order.Order_Id, SysConst.SourceTypeOrder).Sum(l => l.UnitPrice * l.Quantity);
                var stAmount = stDAL.GetSettlementByOrderNo(order.Order_No).Sum(s => s.TotalAmount);
                var receivedAmount = rDAL.GetReceiptBySource(SysConst.SourceTypeOrder, order.Order_No).Sum(r=>r.ReceivedAmount);
                lblContractAmount.Text = contractAmount.ToString();
                lblSettlementAmount.Text = stAmount.ToString();
                lblReceivedAmount.Text = receivedAmount.ToString();
                var needAmount = stAmount != 0 ? (stAmount - receivedAmount) : (contractAmount - receivedAmount);
                lblNeedAmount.Text = needAmount.ToString();

                totalContract += contractAmount.GetValueOrDefault();
                totalSt += stAmount.GetValueOrDefault();
                totalRec += receivedAmount.GetValueOrDefault();
                totalNeed += needAmount.GetValueOrDefault();
            }

            if (e.Item.ItemType == ListItemType.Footer)
            {
                var lblTotalContract = e.Item.FindControl("lblTotalContract") as Label;
                var lblTotalST = e.Item.FindControl("lblTotalST") as Label;
                var lblTotalRec = e.Item.FindControl("lblTotalRec") as Label;
                var lblTotalNeed = e.Item.FindControl("lblTotalNeed") as Label;

                lblTotalContract.Text = totalContract.ToString();
                lblTotalNeed.Text = totalNeed.ToString();
                lblTotalRec.Text = totalRec.ToString();
                lblTotalST.Text = totalSt.ToString();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            var ordNo = new SeedDAL().GetNoByTableName(SysConst.TableOrder, SysConst.SuffixOrder);
            Order ord = new Order();
            ord.Status = FirstStatusConsts.Order;
            ord.Order_No = ordNo;
            ord.SourceNo = string.Empty;
            ord.SourceType = string.Empty;
            ord.InstallType = string.Empty;
            ord.CreatedDate = DateTime.Now;
            ord.IsActive = true;
            var dal = new OrderDAL();
            dal.AddOrder(ord);
            dal.Save();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "createorder",
                string.Format("<script>window.open('orderform.aspx?ordid={0}&ordno={1}&sourceno={2}&sourcetype={3}')</script>",
                ord.Order_Id,
                ord.Order_No,
                ord.SourceNo,
                ord.SourceType));
            Utility.AddDefault(ord.Order_No, SysConst.SourceTypeOrder, FooterConsts.Order);
        }
	}
}