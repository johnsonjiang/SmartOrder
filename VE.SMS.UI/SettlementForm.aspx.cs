using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using VE.SMS.Common;
using VE.SMS.DAL;
using System.Text;

namespace VE.SMS.UI
{
	public partial class SettlementForm : BasePage
	{
        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewSettlementForm;
            }
        }
        protected override string EditName
        {
            get
            {
                return ACLConsts.EditSettlementForm;
            }
        }
		protected string SourceType { get { return "O"; } }
		protected string SourceNo { get { return GetQueryStringValue(SysConst.KeySourceNo); } }
		protected int StId { get { return int.Parse(GetQueryStringValue("stid")); } }
		protected string StNo { get { return GetQueryStringValue("stno"); } }
		protected override void OnInit(EventArgs e)
		{
			LineItemsControl1.UpdateAmount = SetAmount;
			base.OnInit(e);
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Utility.BindDataToDropdown(ddlSettlementStatus, Utility.GetSettlementStatusList());
                Utility.BindDataToDropdown(ddlSettlementMan, Utility.GetUserList2(true));
				DeliveryDAL dlDAL = new DeliveryDAL();
				var deliverys = dlDAL.GetDeliveryByOrderNo(SourceNo);
				if (deliverys != null)
				{
					foreach (var item in deliverys)
					{
						cblDeliveryList.Items.Add(new ListItem() { Text = item.Delivery_No, Value = item.Delivery_Id.ToString() });
					} 
				}
				//link
				OrderDAL sDAL = new OrderDAL();
				var order = sDAL.GetOrderByNo(SourceNo);
				lnkOrderId.Text = order.Order_No;
				lnkOrderId.NavigateUrl = string.Format("orderform.aspx?ordid={0}&ordno={1}&sourcetype={2}&sourceno={3}",order.Order_Id,order.Order_No,order.SourceType,order.SourceNo);
				SettlementDAL dal = new SettlementDAL();
				var st = dal.GetSettlementByNo(StNo);
				txtCreatedDate.Text = st.CreatedDate.ToString("yyyy-MM-dd");
				txtDeliveryDate.Text = st.DeliveryDate.HasValue ? st.DeliveryDate.Value.ToString("yyyy-MM-dd") : string.Empty;
			 	ddlSettlementMan.SelectedValue = st.StMan;
				if (!string.IsNullOrEmpty(st.DeliveryList))
				{
					foreach (ListItem item in cblDeliveryList.Items)
					{
						if (st.DeliveryList.Contains(item.Text))
						{
							item.Selected = true;
						}
					} 
				}
				//customer
				this.customerInfoControl.SetValue(st.CustomerCompanyName,
													st.CustomerContactName,
													st.CustomerAddress,
													st.CustomerEmail,
													st.CustomerQQ,
													st.CustomerPhone1,
													st.CustomerPhone2,
													st.CustomerOthers);
				//lineitem
				LineItemsControl1.IsPriceColumnVisible = true;
				LineItemsControl1.IsSpecColumnVisible = false;
				LineItemsControl1.IsFooterVisible = false;
				LineItemsControl1.SourceId = st.St_Id;
				UIUtility.BindUserControl(LineItemsControl1, SysConst.SourceTypeSettlement, st.St_No);
				//amount
				SetAmount(SysConst.SourceTypeSettlement, st.St_Id);

				txtTotalAmount.Text = st.TotalAmount.ToString();
				txtReceivedFirst.Text = st.FirstAmount.ToString();
				txtReceived.Text = st.AmountReceived.ToString();
				txtBalanceIntro.Text = st.ReceivableIntro;
				lblEndBalance.Text = ((st.TotalAmount.HasValue ? st.TotalAmount.Value : 0) - (st.AmountReceived.HasValue ? st.AmountReceived.Value:0)).ToString();
				var accumulateAmount = dal.GetSettlementByOrderNo(SourceNo).Where(s => s.CreatedDate <= st.CreatedDate).Sum(settle => settle.TotalAmount);
				var receivableTotal = new ReceiptDAL().GetReceiptBySource(SysConst.SourceTypeOrder, st.SourceNo).Where(r=>r.ReceivedDate <= st.CreatedDate).Sum(re=>re.ReceivedAmount);
				lblAccumulateAmount.Text = accumulateAmount.ToString();
				lblReceivableTotal.Text = receivableTotal.ToString();
				//status
				ddlSettlementStatus.SelectedValue = st.Status;
				//followup
				UIUtility.BindUserControl(followUpControl, SysConst.SourceTypeSettlement, st.SourceNo);

			}
		}

		private void SetAmount(string sourceType, int sourceId)
		{
			double materialAmount = 0;
			double installAmount = 0;
			double machAmount = 0;
			LineItemDAL lDAL = new LineItemDAL();
			var lines = lDAL.GetLineItemsBySource(sourceId, sourceType);
			foreach (var item in lines)
			{
				if (item.Project == "材料")
				{
					materialAmount += item.UnitPrice.Value * item.Quantity.Value;
				}
				if (item.Project == "加工")
				{
					machAmount += item.UnitPrice.Value * item.Quantity.Value;
				}
				if (item.Project == "安装")
				{
					installAmount += item.UnitPrice.Value * item.Quantity.Value;
				}
			}
			lblMaterialAmount.Text = materialAmount.ToString();
			lblMachAmount.Text = machAmount.ToString();
			lblInstallAmount.Text = installAmount.ToString();
		}

		protected void btnSaveAmount_Click(object sender, EventArgs e)
		{
			SettlementDAL dal = new SettlementDAL();
			var st = dal.GetSettlementByNo(StNo);
			if (!string.IsNullOrEmpty(txtTotalAmount.Text))
			{
				st.TotalAmount = double.Parse(txtTotalAmount.Text);
			}
			if (!string.IsNullOrEmpty(txtReceivedFirst.Text))
			{
				st.FirstAmount = double.Parse(txtReceivedFirst.Text);
			}
			if (!string.IsNullOrEmpty(txtReceived.Text))
			{
				st.AmountReceived = double.Parse(txtReceived.Text);
			}
			st.ReceivableIntro = txtBalanceIntro.Text;
			lblEndBalance.Text = ((st.TotalAmount.HasValue ? st.TotalAmount.Value : 0) - (st.AmountReceived.HasValue ? st.AmountReceived.Value : 0)).ToString();
			dal.Save();
		}

		protected void btnChangeStatus_Click(object sender, EventArgs e)
		{
			SettlementDAL dal = new SettlementDAL();
			var st = dal.GetSettlementByNo(StNo);
			AddFollowUp(followUpControl, st.Status, Utility.GetSelectedText(ddlSettlementStatus));
			SetFocus(btnChangeStatus);
		}

        protected void btnImport_Click(object sender, EventArgs e)
        {
            SettlementDAL dal = new SettlementDAL();
            LineItemDAL lDal = new LineItemDAL();

            var settlement = dal.GetSettlementById(StId);
            StringBuilder sb = new StringBuilder(256);
            List<LineItem> lineItems = new List<LineItem>();
            foreach (ListItem item in cblDeliveryList.Items)
            {
                if (item.Selected)
                {
                    sb.Append(item.Text).Append("|");
                    lineItems.AddRange(lDal.GetLineItemsBySource(int.Parse(item.Value), SysConst.SourceTypeDelivery));
                }
            }
            settlement.DeliveryList = sb.ToString();

            dal.Save();


            var dbItems = lDal.GetLineItemsBySource(this.StId, SysConst.SourceTypeSettlement);
            foreach (var item in dbItems)
            {
                lDal.DeleteItem(item.LineItem_Id);
            }

            foreach (var item in lineItems)
            {
                LineItem li = new LineItem()
                {
                    Intro = item.Intro,
                    Name = item.Name,
                    OriginNo = item.OriginNo,
                    Project = item.Project,
                    Quantity = item.Quantity,
                    Remark = item.Remark,
                    SourceId = this.StId,
                    SourceType = SysConst.SourceTypeSettlement,
                    Spec = item.Spec,
                    Unit = item.Unit,
                    UnitPrice = item.UnitPrice
                };
                lDal.AddLineItem(li);
                
            }
            lDal.Save();

            UIUtility.BindUserControl(LineItemsControl1, SysConst.SourceTypeSettlement, StId);
        }

		protected void btnSave_Click(object sender, EventArgs e)
		{
			SettlementDAL dal = new SettlementDAL();
			var st = dal.GetSettlementByNo(StNo);

			if (!string.IsNullOrEmpty(txtDeliveryDate.Text))
			{
				st.DeliveryDate = DateTime.Parse(txtDeliveryDate.Text);
			}
			//update st
            st.StMan = Utility.GetSelectedText(ddlSettlementMan);

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < cblDeliveryList.Items.Count; i++)
			{
				if (cblDeliveryList.Items[i].Selected)
				{
					sb.Append(cblDeliveryList.Items[i].Text).Append("|");
				}
			}
			st.DeliveryList = sb.ToString();
			st.StLocation = txtSettleLocation.Text;

			st.CustomerCompanyName = customerInfoControl.CompanyName;
			st.CustomerContactName = customerInfoControl.ContactName;
			st.CustomerAddress = customerInfoControl.Address;
			st.CustomerEmail = customerInfoControl.Email;
			st.CustomerQQ = customerInfoControl.QQ;
			st.CustomerPhone1 = customerInfoControl.Phone1;
			st.CustomerPhone2 = customerInfoControl.Phone2;
			st.CustomerOthers = customerInfoControl.Other;
			//settlement
			if (!string.IsNullOrEmpty(txtTotalAmount.Text))
			{
				st.TotalAmount = double.Parse(txtTotalAmount.Text);
			}
			if (!string.IsNullOrEmpty(txtReceivedFirst.Text))
			{
				st.FirstAmount = double.Parse(txtReceivedFirst.Text);
			}
			if (!string.IsNullOrEmpty(txtReceived.Text))
			{
				st.AmountReceived = double.Parse(txtReceived.Text);
			}
			st.ReceivableIntro = txtBalanceIntro.Text;
			AddFollowUp(followUpControl, st.Status, Utility.GetSelectedText(ddlSettlementStatus));
			st.Status = Utility.GetSelectedText(ddlSettlementStatus);
			
			dal.Save();
			//save new customer
			customerInfoControl.Save();
			this.SetFocus(sender);
		}

        protected void cblDeliveryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<LineItem> items = new List<LineItem>();
            LineItemDAL dal = new LineItemDAL();
            foreach (ListItem listItem in cblDeliveryList.Items)
            {
                if (listItem.Selected)
                {
                    var del = new DeliveryDAL().GetDeliveryByNo(listItem.Text);
                    var delItems = dal.GetLineItemsBySource(del.Delivery_Id, SysConst.SourceTypeDelivery);
                    foreach (var delItem in delItems)
                    {
                        items.Add(new LineItem() 
                        { 
                            Intro = delItem.Intro,
                            Name = delItem.Name,
                            OriginNo = listItem.Text,
                            Project = delItem.Project,
                            Quantity = delItem.Quantity,
                            Remark = delItem.Remark,
                            SourceId = StId,
                            SourceType = SysConst.SourceTypeSettlement,
                            Spec = delItem.Spec,
                            Unit = delItem.Unit,
                            UnitPrice = delItem.UnitPrice
                        });
                    }
                }
                else
                {
                    var lineItemsOfSt = dal.GetLineItemsBySource(StId, SysConst.SourceTypeSettlement);
                    foreach (var item in lineItemsOfSt)
                    {
                        if (item.OriginNo == listItem.Text)
                        {
                            dal.DeleteItem(item.LineItem_Id);
                        }
                    }
                }
            }
            foreach (var item in items)
            {
                dal.AddLineItem(item);
            }
            dal.Save();

            //save list
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < cblDeliveryList.Items.Count; i++)
            {
                if (cblDeliveryList.Items[i].Selected)
                {
                    sb.Append(cblDeliveryList.Items[i].Text).Append("|");
                }
            }
            var stDAL = new SettlementDAL();
            var st = stDAL.GetSettlementByNo(StNo);
            st.DeliveryList = sb.ToString();
            stDAL.Save();

            UIUtility.BindUserControl(LineItemsControl1, SysConst.SourceTypeSettlement, StId);
            
        }
	}
}