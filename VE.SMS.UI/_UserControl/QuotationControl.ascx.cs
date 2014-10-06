using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using VE.SMS.DAL;
using VE.SMS.Common;

namespace VE.SMS.UI._UserControl
{
	public partial class QuotationControl : BaseUserControl
	{
		public override bool Editable
		{
			get
			{
				return this.btnCreateQuotation.Visible;
			}
			set
			{
				btnCreateQuotation.Visible = value;
			}
		}
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        class QuotationComparer : IEqualityComparer<Quotation>
        {

            public bool Equals(Quotation x, Quotation y)
            {
                return x.Quotation_Id == y.Quotation_Id;
            }

            public int GetHashCode(Quotation obj)
            {
                return base.GetHashCode();
            }
        }
		public override void BindControl()
		{
			QuotationDAL dal = new QuotationDAL();
			var quotes = dal.GetQuotesBySource(SourceType, SourceNo);
            List<Quotation> quotes2 = new List<Quotation>();
            string enqNo = string.Empty;
            Order ord = new Order();
            if (string.Equals(SourceType, SysConst.SourceTypeEnquiry, StringComparison.OrdinalIgnoreCase))
            {
                ord = new OrderDAL().GetOrderByEnq(SourceNo);
                if (ord != null)
                {
                    quotes2 = dal.GetQuotesBySource(SysConst.SourceTypeOrder, ord.Order_No);
                }
            }
            else if (string.Equals(SourceType, SysConst.SourceTypeOrder, StringComparison.OrdinalIgnoreCase))
            {
                ord = new OrderDAL().GetOrderByNo(SourceNo);
                if (!string.IsNullOrEmpty(ord.EnqNo))
                {
                    var enq = new EnquiryDAL().GetEnquiryByNo(ord.EnqNo);
                    quotes2 = dal.GetQuoteByEnq(enq.Enquiry_No);
                }
            }
            quotes.AddRange(quotes2);
            var result = quotes.Distinct(new QuotationComparer()).OrderBy(q=>q.Quotation_No);

            Utility.BindDataToRepeater(rpQuotation, result);
		}
        public event EventHandler OnQuotationCreated;
		protected void btnCreateQuotation_Click(object sender, EventArgs e)
		{
			//get no
			SeedDAL sdal = new SeedDAL();
			string no = sdal.GetNoByTableName(SysConst.TableNameQuotation, SysConst.SuffixQuotation);
			//get enqordman
			string enqOrdMan = string.Empty;
			string companyName = string.Empty;
			string contact = string.Empty;
			string address = string.Empty;
			string email = string.Empty;
			string qq = string.Empty;
			string phone1 = string.Empty;
			string phone2 = string.Empty;
			string other = string.Empty;
			bool isSampleToCustomer = false;
			bool isSampleFromCustomer = false;
			bool isCustomerProvideImg = false;
			bool isSurveyNeed = false;
			string surveyType = string.Empty;
			string surveyIntro = string.Empty;
			bool isCADRefineNeeded = false;
			string refineIntro = string.Empty;
			bool isCustomerConfirmNeeded = false;
			string deliveryType = string.Empty;
			string deliveryIntro = string.Empty;
			string deliveryAdd = string.Empty;
			bool isInstallProvided = false;
			string installType = string.Empty;
			string insallIntro = string.Empty;
            string enqNo = string.Empty;
            List<LineItem> items = new List<LineItem>();
            int sourceId = -1;

            if (string.Equals(SourceType, SysConst.SourceTypeSalesOrder, StringComparison.OrdinalIgnoreCase))
            {
                OrderDAL soDAL = new OrderDAL();
                var so = soDAL.GetOrderByNo(SourceNo);
                so.Status = "申请报价";
                soDAL.Save();
                OnQuotationCreated(so.Status, EventArgs.Empty);
                enqOrdMan = so.OrderMan;
                companyName = so.CustomerCompanyName;
                contact = so.CustomerContactName;
                address = so.CustomerAddress;
                email = so.CustomerEmail;
                qq = so.CustomerQQ;
                phone1 = so.CustomerPhone1;
                phone2 = so.CustomerPhone2;
                other = so.CustomerOthers;
                isSampleToCustomer = so.IsSampleProvidedToCustomer;
                isSampleFromCustomer = so.IsCustomerProvideSample;
                isCustomerProvideImg = so.IsCustomerProvideImage;
                isSurveyNeed = so.IsSurveyNeeded;
                surveyType = so.SurveyType;
                surveyIntro = so.SurveyIntro;
                isCADRefineNeeded = so.IsCADRefinementNeeded;
                refineIntro = so.CADRefinementIntro;
                isCustomerConfirmNeeded = so.IsCADNeedCustomerConfirmation;
                deliveryType = so.DeliveryType;
                deliveryIntro = so.DeliveryIntro;
                deliveryAdd = so.DeliveryToAddress;
                isInstallProvided = so.IsInstallProvided;
                installType = string.IsNullOrEmpty(so.InstallType) ?string.Empty : so.InstallType;
                insallIntro = so.InstallIntro;
                enqNo = so.EnqNo;
                sourceId = so.Order_Id;

            }
			else if (string.Equals(SourceType, SysConst.SourceTypeEnquiry, StringComparison.OrdinalIgnoreCase))
			{
				EnquiryDAL enqDAL = new EnquiryDAL();
				var enq = enqDAL.GetEnquiryByNo(SourceNo);
				enqOrdMan = enq.EnqMan;
				companyName = enq.CustomerCompanyName;
				contact = enq.CustomerContactName;
				address = enq.CustomerAddress;
				email = enq.CustomerEmail;
				qq = enq.CustomerQQ;
				phone1 = enq.CustomerPhone1;
				phone2 = enq.CustomerPhone2;
				other = enq.CustomerOthers;
				isSampleToCustomer = enq.IsSampleProvidedToCustomer;
				isSampleFromCustomer = enq.IsCustomerProvideSample;
				isCustomerProvideImg = enq.IsCustomerProvideImage;
				isSurveyNeed = enq.IsSurveyNeeded;
				surveyType = enq.SurveyType;
				surveyIntro = enq.SurveyIntro;
				isCADRefineNeeded = enq.IsCADRefinementNeeded;
				refineIntro = enq.CADRefinementIntro;
				isCustomerConfirmNeeded = enq.IsCADNeedCustomerConfirmation;
				deliveryType = enq.DeliveryType;
				deliveryIntro = enq.DeliveryIntro;
				deliveryAdd = enq.DeliveryToAddress;
				isInstallProvided = enq.IsInstallProvided;
				installType = string.IsNullOrEmpty(enq.InstallType) ? string.Empty : enq.InstallType;
				insallIntro = enq.InstallIntro;
                enqNo = SourceNo;
                sourceId = enq.Enquiry_Id;
                //update enq status
                enq.Status = "申请报价";
                enqDAL.Save();
			}
			
			//new quote
			QuotationDAL dal = new QuotationDAL();
			Quotation quote = new Quotation()
			{
				Quotation_No = no,
				Status = FirstStatusConsts.Quotation,
				EnqOrdMan = enqOrdMan,
				SourceType = SourceType,
				SourceNo = SourceNo,
				CreatedDate = DateTime.Now,
				CreatedAt = DateTime.Now,
				CreatedBy = SMSContext.Current.User.UserName,
				CustomerCompanyName = companyName,
				CustomerContactName = contact,
				CustomerAddress = address,
				CustomerEmail = email,
				CustomerQQ = qq,
				CustomerPhone1 = phone1,
				CustomerPhone2 = phone2,
				CustomerOthers = other,
				IsSampleProvidedToCustomer = isSampleToCustomer,
				IsCustomerProvideSample = isSampleFromCustomer,
				IsCustomerProvideImage = isCustomerProvideImg,
				IsSurveyNeeded = isSurveyNeed,
				SurveyType = surveyType,
				SurveyIntro = surveyIntro,
				IsCADRefinementNeeded = isCADRefineNeeded,
				CADRefinementIntro = refineIntro,
				IsCADNeedCustomerConfirmation = isCustomerConfirmNeeded,
				DeliveryType = deliveryType,
				DeliveryIntro = deliveryIntro,
				DeliveryToAddress = deliveryAdd,
				IsInstallProvided = isInstallProvided,
				InstallType = installType,
				InstallIntro = insallIntro,
                EnqNo = enqNo
			};
			dal.AddQuote(quote);
			dal.Save();

            LineItemDAL lDAL = new LineItemDAL();
            items = lDAL.GetLineItemsBySource(sourceId, SourceType);
            foreach (var item in items)
            {
                LineItem target = new LineItem()
                {
                    Intro = item.Intro,
                    Name = item.Name,
                    OriginNo = item.OriginNo,
                    Project = item.Project,
                    Quantity = item.Quantity,
                    Remark = item.Remark,
                    SourceId = quote.Quotation_Id,
                    SourceType = SysConst.SourceTypeQuote,
                    Spec = item.Spec,
                    Unit = item.Unit,
                    UnitPrice = item.UnitPrice
                };
                lDAL.AddLineItem(target);
            }
            lDAL.Save();

			int quoId = quote.Quotation_Id;
			string quoNo = quote.Quotation_No;
			Utility.AddDefault(quote.Quotation_No, SysConst.SourceTypeQuote, FooterConsts.Quotation);
			string url = Page.ResolveUrl(string.Format("~/QuotationForm.aspx?quoid={0}&quono={1}&sourcetype={2}&sourceno={3}", quoId, quoNo, SourceType, SourceNo));
			string script = string.Format("<script>window.open('{0}')</script>", url);
			Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "createquote", script);
			BindControl();
			SetFocus(btnCreateQuotation);
		}
	}
}