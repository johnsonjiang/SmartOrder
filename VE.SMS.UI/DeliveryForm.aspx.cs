using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VE.SMS.Common;
using VE.SMS.DAL;
using System.Text;

namespace VE.SMS.UI
{
	public partial class DeliveryForm : BasePage
	{
        public string SourceNo { get { return GetQueryStringValue("sourceno"); } }
        public string SourceType { get { return GetQueryStringValue("sourcetype"); } }
        public string DeliveryNo { get { return GetQueryStringValue("dlno"); } }
        public int DeliveryId { get { return int.Parse(GetQueryStringValue("dlid")); } }

        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewDeliveryForm;
            }
        }
        protected override string EditName
        {
            get
            {
                return ACLConsts.EditDeliveryForm;
            }
        }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                Utility.BindDataToDropdown(ddlDeliveryStatus, Utility.GetDeliveryStatusList());
                Utility.BindDataToDropdown(ddlDeliveryMethod, Utility.GetLookupList(SysConst.DeliveryCatelog));
                Utility.BindDataToDropdown(ddlInstallType, Utility.GetLookupList(SysConst.InstallCatelog));
                Utility.BindDataToDropdown(ddlDelCreateMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlSalesMan, Utility.GetUserList2(true));

                if (!string.IsNullOrEmpty(DeliveryNo))
                {
                    DeliveryDAL dDAL = new DeliveryDAL();
                    var del = dDAL.GetDeliveryByNo(DeliveryNo);
                    OrderDAL soDAL = new OrderDAL();
                    var ord = soDAL.GetOrderByNo(SourceNo);
                    MachiningDAL mDAL = new MachiningDAL();
                    var machList = mDAL.GetMachBySource(SysConst.SourceTypeOrder, SourceNo);
                    foreach (var item in machList)
                    {
                        cblMach.Items.Add(new ListItem() { Text = item.Mach_No, Value = item.Mach_Id.ToString() });
                    }
                    //basic
                    txtCreatedDate.Text = del.CreatedDate.ToString("yyyy-MM-dd");
                    ddlSalesMan.SelectedValue= del.OrderMan;
                    ddlDelCreateMan.SelectedValue = del.DeliveryCreateMan;
                    lnkOrder.Text = SourceNo;
                    lnkOrder.NavigateUrl = Page.ResolveUrl(string.Format("~/OrderForm.aspx?ordid={0}&ordno={1}&sourcetype={2}&sourceno={3}",
                        ord.Order_Id,
                        ord.Order_No,
                        ord.SourceType,
                        ord.SourceNo));
                    if (!string.IsNullOrEmpty(del.MachList))
                    {
                        foreach (ListItem item in cblMach.Items)
                        {
                            if (del.MachList.Contains(item.Text))
                            {
                                item.Selected = true;
                            }
                        } 
                    }
                    //customer
                    this.customerInfoControl.SetValue(
                                                    del.CustomerCompanyName,
                                                    del.CustomerContactName,
                                                    del.CustomerAddress,
                                                    del.CustomerEmail,
                                                    del.CustomerQQ,
                                                    del.CustomerPhone1,
                                                    del.CustomerPhone2,
                                                    del.CustomerOthers);
                    //delivery type
                    this.ddlDeliveryMethod.SelectedValue = del.DeliveryType;
                    this.txtDelIntro.Text = del.DeliveryIntro;
                    this.txtDeliveryDriverMan.Text = del.DeliveryDriverMan;
                    this.txtDelPhone.Text = del.DriverPhone;
                    this.txtCarType.Text = del.CarType;
                    this.txtDeliveryToAddress.Text = del.DeliveryToAddress;
                    this.txtExpectDeliveryDate.Text = del.ExpectedDeliveryDate.HasValue ? del.ExpectedDeliveryDate.Value.ToString("yyyy-MM-dd") : string.Empty;
                    this.txtRealDelDate.Text = del.RealDeliveryDate.HasValue ? del.RealDeliveryDate.Value.ToString("yyyy-MM-dd") : string.Empty;
                    //install
                    this.chkProvideInstall.Checked = del.IsInstallProvided;
                    this.ddlInstallType.SelectedValue = del.InstallType;
                    this.txtInstallIntro.Text = del.InstallIntro;
                    this.txtInstallMan.Text = del.InstallMan;
                    this.txtInstallPhone.Text = del.InstallPhone;
                    this.txtInstallDate.Text = del.InstallDate.HasValue ? del.InstallDate.Value.ToString("yyyy-MM-dd"):string.Empty;
                    this.chkInsteadSettlement.Checked = del.InsteadOfSettlement;
                    //delivery content
                    lineItemControl.SourceId = del.Delivery_Id;
                    UIUtility.BindUserControl(lineItemControl, SysConst.SourceTypeDelivery, del.Delivery_No);
                    //settlement info
                    if (chkInsteadSettlement.Checked)
                    {
                        SettlementDAL dal = new SettlementDAL();
                        SetAmount(SysConst.SourceTypeDelivery, del.Delivery_Id);

                        txtTotalAmount.Text = del.TotalAmount.ToString();
                        txtReceivedFirst.Text = del.FirstAmount.ToString();
                        txtReceived.Text = del.ReceivedAmount.ToString();
                        txtBalanceIntro.Text = del.ReceivableIntro;
                        lblEndBalance.Text = ((del.TotalAmount.HasValue ? del.TotalAmount.Value : 0) - (del.ReceivedAmount.HasValue ? del.ReceivedAmount.Value : 0)).ToString();
                        var accumulateAmount = dal.GetSettlementByOrderNo(SourceNo).Where(s => s.CreatedDate <= del.CreatedDate).Sum(settle => settle.TotalAmount);
                        var receivableTotal = new ReceiptDAL().GetReceiptBySource(SysConst.SourceTypeOrder, del.Order_No).Where(r => r.ReceivedDate <= del.CreatedDate).Sum(re => re.ReceivedAmount);
                        lblAccumulateAmount.Text = accumulateAmount.ToString();
                        lblReceivableTotal.Text = receivableTotal.ToString();
                    }
                    //intro
                    UIUtility.BindUserControl(FooterIntroControl1, SysConst.SourceTypeDelivery, del.Delivery_No);
                    this.ddlDeliveryStatus.SelectedValue = del.Status;
                    //followup
                    UIUtility.BindUserControl(followUpControl, SysConst.SourceTypeDelivery, del.Delivery_No);
                }
			}
		}

        protected void btnSaveAmount_OnClick(object sender, EventArgs e)
        {
            DeliveryDAL dal = new DeliveryDAL();
            var delivery = dal.GetDeliveryByNo(DeliveryNo);
            if (!string.IsNullOrEmpty(txtTotalAmount.Text))
            {
                delivery.TotalAmount = double.Parse(txtTotalAmount.Text);
            }
            if (!string.IsNullOrEmpty(txtReceivedFirst.Text))
            {
                delivery.FirstAmount = double.Parse(txtReceivedFirst.Text);
            }
            if (!string.IsNullOrEmpty(txtReceived.Text))
            {
                delivery.ReceivedAmount = double.Parse(txtReceived.Text);
            }
            delivery.ReceivableIntro = txtBalanceIntro.Text;
            lblEndBalance.Text = ((delivery.TotalAmount.HasValue ? delivery.TotalAmount.Value : 0) - (delivery.ReceivedAmount.HasValue ? delivery.ReceivedAmount.Value : 0)).ToString();
            dal.Save();
            SetFocus(btnSaveAmount);
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

        protected void btnImport_Click(object sender, EventArgs e)
        {
            DeliveryDAL dal = new DeliveryDAL();
            LineItemDAL lDal = new LineItemDAL();
            MachSummaryDAL mDAL = new MachSummaryDAL();
            MachLookupDAL mlDAL = new MachLookupDAL();

            var delivery = dal.GetDeliveryByNo(DeliveryNo);
            StringBuilder sb = new StringBuilder(256);
            List<MachSummary> machSummaryList = new List<MachSummary>();

            foreach (ListItem item in cblMach.Items)
            {
                if (item.Selected)
                {
                    sb.Append(item.Text).Append("|");
                    machSummaryList.AddRange(mDAL.GetSummaryByMachId(int.Parse(item.Value)));
                }
            }
            delivery.MachList = sb.ToString();
            dal.Save();

            
            var lineItems = lDal.GetLineItemsBySource(this.DeliveryId, SysConst.SourceTypeDelivery);
            foreach (var item in lineItems)
            {
                lDal.DeleteItem(item.LineItem_Id);
            }

            foreach (var item in machSummaryList)
	        {
                var machLook = mlDAL.GetMachLookupByName(item.MachName);
                var lineItem = new LineItem();
                lineItem.Intro = item.MachIntro;
                lineItem.Name = "加工";
                lineItem.Project = item.MachName;
                lineItem.Quantity = item.Qty;
                lineItem.Remark = item.Remark;
                lineItem.SourceId = DeliveryId;
                lineItem.SourceType = SysConst.SourceTypeDelivery;
                lineItem.Spec = string.Empty;
                lineItem.Unit = item.Unit;
                if (string.Equals(item.Unit, "米"))
                {
                    lineItem.UnitPrice = machLook.PriceM;
                }
                else if (string.Equals(item.Unit, "平方米"))
                {
                    lineItem.UnitPrice = machLook.PriceM2;
                }
                else
                {
                    lineItem.UnitPrice = machLook.PriceOther;
                }
                lDal.AddLineItem(lineItem);
	        }

            lDal.Save();

            UIUtility.BindUserControl(lineItemControl, SysConst.SourceTypeDelivery, DeliveryId);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DeliveryDAL dal = new DeliveryDAL();
            var delivery = dal.GetDeliveryByNo(DeliveryNo);
            //update delivery
            delivery.OrderMan = Utility.GetSelectedText(ddlSalesMan);
            delivery.DeliveryCreateMan = Utility.GetSelectedText(ddlDelCreateMan);
            StringBuilder sb = new StringBuilder(256);
            //save 

            delivery.CustomerCompanyName = customerInfoControl.CompanyName;
            delivery.CustomerContactName = customerInfoControl.ContactName;
            delivery.CustomerAddress = customerInfoControl.Address;
            delivery.CustomerEmail = customerInfoControl.Email;
            delivery.CustomerQQ = customerInfoControl.QQ;
            delivery.CustomerPhone1 = customerInfoControl.Phone1;
            delivery.CustomerPhone2 = customerInfoControl.Phone2;
            delivery.CustomerOthers = customerInfoControl.Other;

            //delivery
            delivery.DeliveryType = Utility.GetSelectedText(ddlDeliveryMethod);
            delivery.DeliveryIntro = txtDelIntro.Text;
            delivery.DeliveryDriverMan = txtDeliveryDriverMan.Text;
            delivery.DriverPhone = txtDelPhone.Text;
            delivery.CarType = txtCarType.Text;
            delivery.DeliveryToAddress = txtDeliveryToAddress.Text;
            if(!string.IsNullOrEmpty(txtExpectDeliveryDate.Text))
            {
                delivery.ExpectedDeliveryDate =  DateTime.Parse(txtExpectDeliveryDate.Text);
            }
            if (!string.IsNullOrEmpty(txtRealDelDate.Text))
            {
                delivery.RealDeliveryDate = DateTime.Parse(txtRealDelDate.Text);
            }
            //settlement info
            if (chkInsteadSettlement.Checked)
            {
                delivery.TotalAmount = double.Parse(txtTotalAmount.Text);
                delivery.FirstAmount = double.Parse(txtReceivedFirst.Text);
                delivery.ReceivedAmount = double.Parse(txtReceived.Text);
                delivery.ReceivableIntro = txtBalanceIntro.Text;
            }

            //install
            delivery.IsInstallProvided = chkProvideInstall.Checked;
            delivery.InstallType = Utility.GetSelectedText(ddlInstallType);
            delivery.InstallIntro = txtInstallIntro.Text;
            delivery.InstallMan = txtInstallMan.Text;
            delivery.InstallPhone = txtInstallPhone.Text;
            if (!string.IsNullOrEmpty(txtInstallDate.Text))
            {
                delivery.InstallDate = DateTime.Parse(txtInstallDate.Text);    
            }
            delivery.InsteadOfSettlement = chkInsteadSettlement.Checked;
            AddFollowUp(followUpControl, delivery.Status, Utility.GetSelectedText(ddlDeliveryStatus));
            delivery.Status = Utility.GetSelectedText(ddlDeliveryStatus);
            dal.Save();
            //save new customer
            customerInfoControl.Save();
            this.SetFocus(sender);
        }

        protected void btnChangeStatus_Click(object sender, EventArgs e)
        {
            DeliveryDAL dal = new DeliveryDAL();
            var delivery = dal.GetDeliveryByNo(DeliveryNo);
            AddFollowUp(followUpControl, delivery.Status, Utility.GetSelectedText(ddlDeliveryStatus));
            delivery.Status = Utility.GetSelectedText(ddlDeliveryStatus);
            dal.Save();
            SetFocus(btnChangeStatus);
        }


	}
}