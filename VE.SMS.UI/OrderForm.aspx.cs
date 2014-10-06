using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using VE.SMS.Common;
using VE.SMS.DAL;

namespace VE.SMS.UI
{
	public partial class OrderForm : BasePage
	{
		public string OrdNo{get{return GetQueryStringValue("ordno");}}
		public int OrdId { get { return int.Parse(GetQueryStringValue("ordid")); } }

		protected override string ViewName
		{
			get
			{
				return ACLConsts.ViewOrderForm;
			}
		}
		protected override string EditName
		{
			get
			{
				return ACLConsts.EditOrderForm;
			}
		}

		private string GetAddress()
		{
			return customerInfoControl.Address;
		}

		protected override void OnInit(EventArgs e)
		{
			this.DeliveryEditControl1.OnGetAddress = this.GetAddress;
            this.quotationControl.OnQuotationCreated += new EventHandler(quotationControl_OnQuotationCreated);
			base.OnInit(e);
		}

        void quotationControl_OnQuotationCreated(object sender, EventArgs e)
        {
            this.ddlOrderStatus.SelectedValue = sender.ToString();
        }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				//dropdown
				Utility.BindDataToDropdown(ddlOrderStatus, Utility.GetOrderStatusList());
				Utility.BindDataToDropdown(ddlOrdMan, Utility.GetUserList2(true));

				if (!string.IsNullOrWhiteSpace(OrdNo))
				{
					OrderDAL dal = new OrderDAL();
					var ord = dal.GetOrderById(OrdId);
					txtOrdNo.Text = ord.Order_No;
					//link
					if (string.Equals(SourceType, SysConst.SourceTypeEnquiry, StringComparison.OrdinalIgnoreCase))
					{
						lnkSource.NavigateUrl = Page.ResolveUrl(string.Format("~/enquiryform.aspx?enqno={0}", SourceNo));
					}
					else if(string.Equals(SourceType, SysConst.SourceTypeQuote, StringComparison.OrdinalIgnoreCase))
					{
						QuotationDAL qDAL = new QuotationDAL();
						var quote = qDAL.GetQuoteByNo(SourceNo);
						lnkSource.NavigateUrl = Page.ResolveUrl(string.Format("~/quotationform.aspx?quono={0}&quoid={1}&sourceno={2}&sourcetype={3}", quote.Quotation_No,quote.Quotation_Id,quote.SourceNo,quote.SourceType));
					}

					if (!string.IsNullOrEmpty(SourceNo))
					{
						this.lnkSource.Text = SourceNo; 
					}
					this.txtCreatedDate.Text = ord.CreatedDate.ToString("yyyy-MM-dd");
					ddlOrdMan.SelectedValue = ord.OrderMan;
					this.txtOrderSummary.Text = ord.OrderIntro;
					//customer info
					this.customerInfoControl.SetValue(
						ord.CustomerCompanyName,
						ord.CustomerContactName,
						ord.CustomerAddress,
						ord.CustomerEmail,
						ord.CustomerQQ,
						ord.CustomerPhone1,
						ord.CustomerPhone2,
						ord.CustomerOthers);
					//lineitem
					UIUtility.BindUserControl(lineItemsControl, SysConst.SourceTypeOrder, ord.Order_Id);
					//sample
					this.SampleControl1.SetValue(ord.IsSampleProvidedToCustomer, ord.IsCustomerProvideSample);
					UIUtility.BindUserControl(SampleControl1, SysConst.SourceTypeOrder, ord.Order_No);
					//customer drawing
					customerDrawingControl.IsCustomerProvideImage = ord.IsCustomerProvideImage;
					UIUtility.BindUserControl(customerDrawingControl, SysConst.SourceTypeOrder, ord.Order_No);
					//survey
                    SurveyEditControl1.IsSurveyNeed = ord.IsSurveyNeeded;
                    SurveyEditControl1.SurveyIntro = ord.SurveyIntro;
                    UIUtility.BindUserControl(SurveyEditControl1, SysConst.SourceTypeOrder, ord.Order_No);
                    SurveyEditControl1.SetSurveyType(ord.SurveyType);
					//cad
					CADEditControl1.IsCADRefinementNeeded = ord.IsCADRefinementNeeded;
					CADEditControl1.RefineIntro = ord.CADRefinementIntro;
					CADEditControl1.IsCustomerCADConfirmationNeeded = ord.IsCADNeedCustomerConfirmation;
					UIUtility.BindUserControl(CADEditControl1, SysConst.SourceTypeOrder, ord.Order_No);
					//delivery
					DeliveryEditControl1.DeliveryIntro = ord.DeliveryIntro;
					DeliveryEditControl1.DeliveryToAddress = ord.DeliveryToAddress;
					UIUtility.BindUserControl(DeliveryEditControl1, SysConst.SourceTypeOrder, ord.Order_No);
                    DeliveryEditControl1.SetDeliveryType(ord.DeliveryType);
                    
					//install
					InstallEditControl1.IsInstallProvided = ord.IsInstallProvided;
					InstallEditControl1.InstallIntro = ord.InstallIntro;
					UIUtility.BindUserControl(InstallEditControl1, SysConst.SourceTypeOrder, ord.Order_No);
                    InstallEditControl1.SetInstallType(ord.InstallType);
					//history quote
					UIUtility.BindUserControl(quotationControl, SysConst.SourceTypeOrder, ord.Order_No);
					//survey
					UIUtility.BindUserControl(surveyControl, SysConst.SourceTypeOrder, ord.Order_No);
					//refine
					UIUtility.BindUserControl(cADRefinementControl, SysConst.SourceTypeOrder, ord.Order_No);
					//machining
					UIUtility.BindUserControl(MachiningControl1, SysConst.SourceTypeOrder, ord.Order_No);
					//purchase
					UIUtility.BindUserControl(PurchaseControl1, SysConst.SourceTypeOrder, ord.Order_No);
					//delivery
					UIUtility.BindUserControl(DeliveryControl1, SysConst.SourceTypeOrder, ord.Order_No);
					//settlement
					UIUtility.BindUserControl(SettlementControl1, SysConst.SourceTypeOrder, ord.Order_No);
					//receivable
					UIUtility.BindUserControl(ReceiptControl1, SysConst.SourceTypeOrder, ord.Order_No);
					//introduction
					UIUtility.BindUserControl(FooterIntroControl1, SysConst.SourceTypeOrder, ord.Order_No);
					//status
					ddlOrderStatus.SelectedValue = ord.Status;
					//followup
					UIUtility.BindUserControl(followUpControl, SysConst.SourceTypeOrder, ord.Order_No);

				}
			}
		}

		protected void btnUpdateOrdNo_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtOrdNo.Text))
			{
				OrderDAL dal = new OrderDAL();
				Order ord = dal.GetOrderById(OrdId);
				var dbOrd = dal.GetOrderByNo(txtOrdNo.Text);
				if (dbOrd != null && dbOrd.Order_Id != OrdId)
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "updateno", "<script>alert('已经有相同订单号!');</script>");
				}
				else
				{
					ord.Order_No = txtOrdNo.Text;
					dal.Save();
				}
			}
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			OrderDAL dal = new OrderDAL();
			var ord = dal.GetOrderById(OrdId);
			//update ord
			ord.OrderMan = Utility.GetSelectedText(ddlOrdMan);
			ord.OrderIntro = txtOrderSummary.Text;

			ord.CustomerCompanyName = customerInfoControl.CompanyName;
			ord.CustomerContactName = customerInfoControl.ContactName;
			ord.CustomerAddress = customerInfoControl.Address;
			ord.CustomerEmail = customerInfoControl.Email;
			ord.CustomerQQ = customerInfoControl.QQ;
			ord.CustomerPhone1 = customerInfoControl.Phone1;
			ord.CustomerPhone2 = customerInfoControl.Phone2;
			ord.CustomerOthers = customerInfoControl.Other;
			ord.IsSampleProvidedToCustomer = SampleControl1.IsSampleProvidedToCustomer;
			ord.IsCustomerProvideSample = SampleControl1.IsSampleFromCustomer;
			ord.IsCustomerProvideImage = customerDrawingControl.IsCustomerProvideImage;
			ord.IsSurveyNeeded = SurveyEditControl1.IsSurveyNeed;
			if (SurveyEditControl1.IsSurveyNeed)
			{
				ord.SurveyType = SurveyEditControl1.SurveyType;
				ord.SurveyIntro = SurveyEditControl1.SurveyIntro;
			}
			ord.IsCADRefinementNeeded = CADEditControl1.IsCADRefinementNeeded;
			if (CADEditControl1.IsCADRefinementNeeded)
			{
				ord.CADRefinementIntro = CADEditControl1.RefineIntro;
				ord.IsCADNeedCustomerConfirmation = CADEditControl1.IsCustomerCADConfirmationNeeded;
			}
			ord.DeliveryType = DeliveryEditControl1.DeliveryType;
			ord.DeliveryIntro = DeliveryEditControl1.DeliveryIntro;
			ord.DeliveryToAddress = DeliveryEditControl1.DeliveryToAddress;

			ord.IsInstallProvided = InstallEditControl1.IsInstallProvided;
			if (InstallEditControl1.IsInstallProvided)
			{
				ord.InstallType = InstallEditControl1.InstallType;
				ord.InstallIntro = InstallEditControl1.InstallIntro;
			}
			AddFollowUp(followUpControl, ord.Status, Utility.GetSelectedText(ddlOrderStatus));
			ord.Status = Utility.GetSelectedText(ddlOrderStatus);
			dal.Save();

			//save new customer
			customerInfoControl.Save();
			this.SetFocus(sender);
		}

		protected void btnChangeStatus_Click(object sender, EventArgs e)
		{
			OrderDAL dal = new OrderDAL();
			var ord = dal.GetOrderByNo(OrdNo);
			AddFollowUp(followUpControl, ord.Status, Utility.GetSelectedText(ddlOrderStatus));
			ord.Status = Utility.GetSelectedText(ddlOrderStatus);
			dal.Save();
			SetFocus(btnChangeStatus);
		}

        protected void btnSaveFormalOrder_Click(object sender, EventArgs e)
        {
            OrderDAL dal = new OrderDAL();
            var ord = dal.GetOrderByNo(OrdNo);
            //update ord
            string orderStatus = "新订单";
            ord.Status = orderStatus;
            ddlOrderStatus.SelectedValue = orderStatus;
            dal.Save();
            SetFocus(btnSaveFormalOrder);
        }
	}
}