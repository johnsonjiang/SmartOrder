using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VE.SMS.Common;
using System.Collections;
using VE.SMS.DAL;

namespace VE.SMS.UI
{
	public partial class QuotationForm : BasePage
	{
		protected override string ViewName
		{
			get
			{
				return ACLConsts.ViewQuotationForm;
			}
		}
        protected override string EditName
        {
            get
            {
                return ACLConsts.EditQuotationForm;
            }
        }
		protected string SourceType { get { return GetQueryStringValue(SysConst.KeySourceType).ToUpper(); } }
		protected string SourceNo { get { return GetQueryStringValue(SysConst.KeySourceNo); } }
		protected int QuoteId { get { return int.Parse(GetQueryStringValue("quoid")); } }
		protected string QuoteNo { get { return GetQueryStringValue("quono"); } }

		protected override void OnInit(EventArgs e)
		{
			this.DeliveryEditControl1.OnGetAddress = this.GetAddess;
			base.OnInit(e);
		}

		protected string GetAddess()
		{
			return customerInfoControl.Address;
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{

				if (!string.IsNullOrEmpty(SourceType) && !string.IsNullOrEmpty(SourceNo))
				{
					Utility.BindDataToDropdown(ddlEnqOrdMan, Utility.GetUserList2(true));
					Utility.BindDataToDropdown(ddlQuoteMan, Utility.GetUserList2(true));
					//link
					if (string.Equals(SourceType, SysConst.SourceTypeEnquiry, StringComparison.OrdinalIgnoreCase))
					{
						EnquiryDAL eDAL = new EnquiryDAL();
						var enq = eDAL.GetEnquiryByNo(SourceNo);
						lnkSource.NavigateUrl = Page.ResolveUrl(string.Format("~/enquiryform.aspx?enqno={0}&enqid={1}", SourceNo, enq.Enquiry_Id));
					}
					else
					{
						OrderDAL sDAL = new OrderDAL();
						var ord = sDAL.GetOrderByNo(SourceNo);
						lnkSource.NavigateUrl = Page.ResolveUrl(string.Format("~/orderform.aspx?ordno={0}&ordid={1}&sourcetype={2}&sourceno={3}", SourceNo,ord.Order_Id,ord.SourceType,ord.SourceNo));
					}
					lnkSource.Text = SourceNo;

					QuotationDAL dal = new QuotationDAL();
					var quote = dal.GetQuoteByNo(QuoteNo);
					//basic
					txtCreatedDate.Text = quote.CreatedDate.ToString("yyyy-MM-dd");

					ddlEnqOrdMan.SelectedValue = quote.EnqOrdMan;
					ddlQuoteMan.SelectedValue = quote.QuotationMan;
					txtQuoteIntro.Text = quote.QuotationIntro;

					//customer info
					this.customerInfoControl.SetValue(
						quote.CustomerCompanyName,
						quote.CustomerContactName,
						quote.CustomerAddress,
						quote.CustomerEmail,
						quote.CustomerQQ,
						quote.CustomerPhone1,
						quote.CustomerPhone2,
						quote.CustomerOthers);
					//lineitem
					UIUtility.BindUserControl(lineItemsControl, SysConst.SourceTypeQuote, quote.Quotation_Id);
					//sample
					this.SampleControl1.SetValue(quote.IsSampleProvidedToCustomer, quote.IsCustomerProvideSample);
					UIUtility.BindUserControl(SampleControl1, SysConst.SourceTypeQuote, quote.Quotation_No);
					//customer drawing
					customerDrawingControl.IsCustomerProvideImage = quote.IsCustomerProvideImage;
					UIUtility.BindUserControl(customerDrawingControl, SysConst.SourceTypeQuote, quote.Quotation_No);
					//survey
                    SurveyEditControl1.IsSurveyNeed = quote.IsSurveyNeeded;
                    SurveyEditControl1.SurveyIntro = quote.SurveyIntro;
                    UIUtility.BindUserControl(SurveyEditControl1, SysConst.SourceTypeQuote, quote.Quotation_No);
                    SurveyEditControl1.SetSurveyType(quote.SurveyType);
					//cad
					CADEditControl1.IsCADRefinementNeeded = quote.IsCADRefinementNeeded;
					CADEditControl1.RefineIntro = quote.CADRefinementIntro;
					CADEditControl1.IsCustomerCADConfirmationNeeded = quote.IsCADNeedCustomerConfirmation;
					UIUtility.BindUserControl(CADEditControl1, SysConst.SourceTypeQuote, quote.Quotation_No);
					//delivery
					DeliveryEditControl1.DeliveryIntro = quote.DeliveryIntro;
					DeliveryEditControl1.DeliveryToAddress = quote.DeliveryToAddress;
					UIUtility.BindUserControl(DeliveryEditControl1, SysConst.SourceTypeQuote, quote.Quotation_No);
                    DeliveryEditControl1.SetDeliveryType(quote.DeliveryType);
					//install
					InstallEditControl1.IsInstallProvided = quote.IsInstallProvided;
					InstallEditControl1.InstallIntro = quote.InstallIntro;
					UIUtility.BindUserControl(InstallEditControl1, SysConst.SourceTypeQuote, quote.Quotation_No);
                    InstallEditControl1.SetInstallType(quote.InstallType);
					//quotation
					UIUtility.BindUserControl(quotationControl, SourceType, SourceNo);
                    //survey
                    UIUtility.BindUserControl(surveyControl, SourceType, SourceNo);
                    //customer provide drawing
                    UIUtility.BindUserControl(customerDrawingControl1, SourceType, SourceNo);
					//refine
					UIUtility.BindUserControl(cADRefinementControl, SourceType, SourceNo);
					//intro
					UIUtility.BindUserControl(FooterIntroControl1, SysConst.SourceTypeQuote, quote.Quotation_No);
					//followup
					UIUtility.BindUserControl(followUpControl, SysConst.SourceTypeQuote, quote.Quotation_No);

					//status dropdown
					Utility.BindDataToDropdown(this.ddlQuotationStatus, Utility.GetQuotationStatusList());
					ddlQuotationStatus.SelectedValue = quote.Status;
					if (string.Equals(quote.Status, "报价完成", StringComparison.OrdinalIgnoreCase)
						|| string.Equals(quote.Status, "待确认", StringComparison.OrdinalIgnoreCase)
						|| string.Equals(quote.Status, "确认", StringComparison.OrdinalIgnoreCase)
						|| string.Equals(quote.Status, "不确认", StringComparison.OrdinalIgnoreCase)
						)
					{
						SetControlsStatus(false);
						ddlQuotationStatus.Enabled = true;
						btnChangeStatus.Enabled = true;
						btnPrint.Disabled = false;
						btnCopy.Enabled = true;
					}

                    if (quote.Status!="编辑中")
                    {
                        SetControlsStatus(false);
                        SetControlEnabled(btnChangeStatus, true);
                        SetControlEnabled(ddlQuotationStatus, true);
                    }
				}
			}
		}
		protected void btnChangeStatus_Click(object sender, EventArgs e)
		{
			string quono = GetQueryStringValue("quono");
			QuotationDAL dal = new QuotationDAL();
			var quote = dal.GetQuoteByNo(quono);
			AddFollowUp(followUpControl, quote.Status, Utility.GetSelectedText(ddlQuotationStatus));
			quote.Status = Utility.GetSelectedText(ddlQuotationStatus);
			dal.Save();
			if (string.Equals(quote.Status, "报价完成", StringComparison.OrdinalIgnoreCase)
				|| string.Equals(quote.Status, "待确认", StringComparison.OrdinalIgnoreCase)
				|| string.Equals(quote.Status, "确认", StringComparison.OrdinalIgnoreCase)
				|| string.Equals(quote.Status, "不确认", StringComparison.OrdinalIgnoreCase)
				)
			{
				SetControlsStatus(false);
				ddlQuotationStatus.Enabled = true;
				btnChangeStatus.Enabled = true;
				btnPrint.Disabled = false;
				btnCopy.Enabled = true;
			}
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			string quono = GetQueryStringValue("quono");
			QuotationDAL dal = new QuotationDAL();
			var quote = dal.GetQuoteByNo(quono);
			if (!string.IsNullOrEmpty(txtCreatedDate.Text))
			{
				quote.CreatedDate = DateTime.Parse(txtCreatedDate.Text);
			}
			quote.EnqOrdMan = Utility.GetSelectedText(ddlEnqOrdMan);
			quote.QuotationMan = Utility.GetSelectedText(ddlQuoteMan);
			quote.QuotationIntro = txtQuoteIntro.Text;
			quote.CustomerCompanyName = customerInfoControl.CompanyName;
			quote.CustomerContactName = customerInfoControl.ContactName;
			quote.CustomerAddress = customerInfoControl.Address;
			quote.CustomerEmail = customerInfoControl.Email;
			quote.CustomerQQ = customerInfoControl.QQ;
			quote.CustomerPhone1 = customerInfoControl.Phone1;
			quote.CustomerPhone2 = customerInfoControl.Phone2;
			quote.CustomerOthers = customerInfoControl.Other;
			quote.IsSampleProvidedToCustomer = SampleControl1.IsSampleProvidedToCustomer;
			quote.IsCustomerProvideSample = SampleControl1.IsSampleFromCustomer;
			quote.IsCustomerProvideImage = customerDrawingControl.IsCustomerProvideImage;
			quote.IsSurveyNeeded = SurveyEditControl1.IsSurveyNeed;
			if (SurveyEditControl1.IsSurveyNeed)
			{
				quote.SurveyType = SurveyEditControl1.SurveyType;
				quote.SurveyIntro = SurveyEditControl1.SurveyIntro;
			}
			quote.IsCADRefinementNeeded = CADEditControl1.IsCADRefinementNeeded;
			if (CADEditControl1.IsCADRefinementNeeded)
			{
				quote.CADRefinementIntro = CADEditControl1.RefineIntro;
				quote.IsCADNeedCustomerConfirmation = CADEditControl1.IsCustomerCADConfirmationNeeded;
			}
			quote.DeliveryType = DeliveryEditControl1.DeliveryType;
			quote.DeliveryIntro = DeliveryEditControl1.DeliveryIntro;
			quote.DeliveryToAddress = DeliveryEditControl1.DeliveryToAddress;

			quote.IsInstallProvided = InstallEditControl1.IsInstallProvided;
			if (InstallEditControl1.IsInstallProvided)
			{
				quote.InstallType = InstallEditControl1.InstallType;
				quote.InstallIntro = InstallEditControl1.InstallIntro;
			}
			AddFollowUp(followUpControl, quote.Status, Utility.GetSelectedText(ddlQuotationStatus));
			quote.Status = ddlQuotationStatus.SelectedItem.Text;
			dal.Save();
			//save new customer
			customerInfoControl.Save();
			this.SetFocus(btnSave);
			if (string.Equals(quote.Status, "报价完成", StringComparison.OrdinalIgnoreCase)
				|| string.Equals(quote.Status, "待确认", StringComparison.OrdinalIgnoreCase)
				|| string.Equals(quote.Status, "确认", StringComparison.OrdinalIgnoreCase)
				|| string.Equals(quote.Status, "不确认", StringComparison.OrdinalIgnoreCase)
				)
			{
				SetControlsStatus(false);
                SetControlEnabled(ddlQuotationStatus, true);
                SetControlEnabled(btnChangeStatus, true);
                SetControlEnabled(btnCopy, true);
			}
		}

		protected void btnGenerateFormalQuoation_Click(object sender, EventArgs e)
		{
            string quono = GetQueryStringValue("quono");
            QuotationDAL dal = new QuotationDAL();
            var quote = dal.GetQuoteByNo(quono);
            quote.Status = "报价完成";
            SetControlsStatus(false);
            SetControlEnabled(btnChangeStatus, true);
            
		}
		protected void btnCopy_Click(object sender, EventArgs e)
		{
            string quono = GetQueryStringValue("quono");
            QuotationDAL dal = new QuotationDAL();
            var sourceQuote = dal.GetQuoteByNo(quono);

            Quotation targetQuote = new Quotation();
            SeedDAL sdal = new SeedDAL();
            var quoteNo = sdal.GetNoByTableName(SysConst.TableNameQuotation, SysConst.SuffixQuotation);

            targetQuote.Quotation_No = quoteNo;
            targetQuote.SourceNo = sourceQuote.SourceNo;
            targetQuote.SourceType = sourceQuote.SourceType;
            targetQuote.CADRefinementIntro = sourceQuote.CADRefinementIntro;
            targetQuote.CreatedDate = sourceQuote.CreatedDate;
            targetQuote.CustomerAddress = sourceQuote.CustomerAddress;
            targetQuote.CustomerCompanyName = sourceQuote.CustomerCompanyName;
            targetQuote.CustomerContactName = sourceQuote.CustomerContactName;
            targetQuote.CustomerEmail = sourceQuote.CustomerEmail;
            targetQuote.CustomerOthers = sourceQuote.CustomerOthers;
            targetQuote.CustomerPhone1 = sourceQuote.CustomerPhone1;
            targetQuote.CustomerPhone2 = sourceQuote.CustomerPhone2;
            targetQuote.CustomerQQ = sourceQuote.CustomerQQ;
            targetQuote.DeliveryIntro = sourceQuote.DeliveryIntro;
            targetQuote.DeliveryToAddress = sourceQuote.DeliveryToAddress;
            targetQuote.DeliveryType = sourceQuote.DeliveryType;
            targetQuote.InstallIntro = sourceQuote.InstallIntro;
            targetQuote.InstallType = sourceQuote.InstallType;
            targetQuote.IsCADNeedCustomerConfirmation = sourceQuote.IsCADNeedCustomerConfirmation;
            targetQuote.IsCADRefinementNeeded = sourceQuote.IsCADRefinementNeeded;
            targetQuote.IsCustomerProvideImage = sourceQuote.IsCustomerProvideImage;
            targetQuote.IsCustomerProvideSample = sourceQuote.IsCustomerProvideSample;
            targetQuote.IsInstallProvided = sourceQuote.IsInstallProvided;
            targetQuote.IsSampleProvidedToCustomer = sourceQuote.IsSampleProvidedToCustomer;
            targetQuote.IsSurveyNeeded = sourceQuote.IsSurveyNeeded;
            targetQuote.QuotationIntro = sourceQuote.QuotationIntro;
            targetQuote.QuotationMan= sourceQuote.QuotationMan;
            targetQuote.Status = FirstStatusConsts.Order;
            targetQuote.SurveyIntro = sourceQuote.SurveyIntro;
            targetQuote.SurveyType = sourceQuote.SurveyType;

            dal.AddQuote(targetQuote);
            dal.Save();

            LineItemDAL lDal = new LineItemDAL();
            var items = lDal.GetLineItemsBySource(sourceQuote.Quotation_Id, SysConst.SourceTypeQuote);

            foreach (var item in items)
            {
                var targetQuoteItem = new LineItem()
                {
                    Intro = item.Intro,
                    Name = item.Name,
                    Project = item.Project,
                    Quantity = item.Quantity,
                    Remark = item.Remark,
                    SourceId = targetQuote.Quotation_Id,
                    SourceType = SysConst.SourceTypeQuote,
                    Spec = item.Spec,
                    Unit = item.Unit,
                    UnitPrice = item.UnitPrice
                };

                lDal.AddLineItem(targetQuoteItem);
            }
            lDal.Save();

            //intro
            Utility.AddDefault(targetQuote.Quotation_No, SysConst.SourceTypeQuote, FooterConsts.Quotation);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "copyquote",
            string.Format("<script>window.open('quotationform.aspx?quoid={0}&quono={1}&sourceno={2}&sourcetype={3}')</script>",
            targetQuote.Quotation_Id,
            targetQuote.Quotation_No,
            targetQuote.SourceNo,
            targetQuote.SourceType));
		}

		protected void btnGenerateOrder_Click(object sender, EventArgs e)
		{
            var quote = new QuotationDAL().GetQuoteByNo( GetQueryStringValue("quono"));
            if (string.Equals(quote.SourceType, SysConst.SourceTypeOrder, StringComparison.OrdinalIgnoreCase))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "createorder",
                "<script>alert('来源为订单的报价单不能再次生成订单');</script>"
                );
                return;
            }

            string enqNo = quote.SourceNo;
            Order ord = new OrderDAL().GetOrderByEnq(enqNo);
            if (ord == null)
            {
                ord = Utility.GenerateOrder(quote);
            }
            ClientScript.RegisterClientScriptBlock(this.GetType(), "createorder", 
                string.Format("<script>window.open('orderform.aspx?ordid={0}&ordno={1}&sourceno={2}&sourcetype=Q')</script>",
                ord.Order_Id,
                ord.Order_No,
                ord.SourceNo));
		}
	}
}