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

namespace VE.SMS.UI.Printout
{
	public partial class QuotationPrintout : BasePage
	{
		protected string QuoNo { get { return GetQueryStringValue("quono"); } }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BindData();
			}
		}

		private void BindData()
		{
			QuotationDAL dal = new QuotationDAL();
			var quote = dal.GetQuoteByNo(QuoNo);
			lblDate.Text = quote.CreatedDate.ToString("yyyy-MM-dd");
			lblContactName.Text = quote.CustomerContactName;
			if (!string.IsNullOrEmpty(quote.CustomerPhone1) && !string.IsNullOrEmpty(quote.CustomerPhone2))
			{
				lblPhone.Text = quote.CustomerPhone1 + "/" + quote.CustomerPhone2;
			}
			else
			{
				lblPhone.Text = quote.CustomerPhone1 + quote.CustomerPhone2;
			}
			lblEmail.Text = quote.CustomerEmail;
			lblQQ.Text = quote.CustomerQQ;
			lblAddress.Text = quote.CustomerAddress;
			lblIsCustomerProvideImage.Text = quote.IsCustomerProvideImage ? YesNoConsts.Yes : YesNoConsts.No;
			lblSampleToCustomer.Text = quote.IsSampleProvidedToCustomer ? YesNoConsts.Yes : YesNoConsts.No;
			if (quote.IsSampleProvidedToCustomer)
			{
				lblTextSampleCode.Visible = true;
				lblSampleToCustomer.Visible = true;
				lblSampleCode.Visible = true;
				SampleProvidDAL sdal = new SampleProvidDAL();
				var samples = sdal.GetSampleBySource(SysConst.SourceTypeQuote, QuoNo);
				StringBuilder sb = new StringBuilder();
				foreach (var item in samples)
				{
					sb.Append(item.SampleName).Append(",");
				}
				if (sb.Length > 0)
				{
					sb.Remove(sb.Length - 1, 1);
				}
				lblSampleCode.Text = sb.ToString();
			}
			lblSurveyNeeded.Text = quote.IsSurveyNeeded ? YesNoConsts.Yes : YesNoConsts.No;
			if (quote.IsSurveyNeeded)
			{
				lblSurveyType.Text = quote.SurveyType;
			}
			lblProvideRefine.Text = quote.IsCADRefinementNeeded ? YesNoConsts.Yes : YesNoConsts.No;
			lblProvideDelivery.Text = quote.DeliveryType;
			lblDeliveryType.Text = quote.DeliveryType;
			lblDeliveryAddress.Text = quote.DeliveryToAddress;
			lblProvideInstall.Text = quote.IsInstallProvided ? YesNoConsts.Yes : YesNoConsts.No;
			lblInstallType.Text = quote.InstallType;

			//item
			LineItemDAL lDAL = new LineItemDAL();
			var items = lDAL.GetLineItemsBySource(quote.Quotation_Id, SysConst.SourceTypeQuote);
			Utility.BindDataToRepeater(rpItems, items);
            //bankinfo
            Utility.BindDataToDropdown(ddlBankInfo, Utility.GetLookupList("账户列表"));
            SetBankInfo();
		}
        private void SetBankInfo()
        {
            var bankInfo = Utility.GetLookupList(ddlBankInfo.SelectedValue);
            lblBankName.Text = bankInfo.FirstOrDefault(b => b.ConfigItem_Key == "银行").ConfigItem_Value;
            lblName.Text = bankInfo.FirstOrDefault(b => b.ConfigItem_Key == "户名").ConfigItem_Value;
            lblAccount.Text = bankInfo.FirstOrDefault(b => b.ConfigItem_Key == "账号").ConfigItem_Value;
        }
        protected void ddlBankInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBankInfo();
        }
        private double TotalAmount;
        protected void rpItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                LineItem lineItem = e.Item.DataItem as LineItem;
                TotalAmount += lineItem.UnitPrice.Value * lineItem.Quantity.Value;
            }
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblTotalAmount = e.Item.FindControl("lblTotalAmount") as Label;
                lblTotalAmount.Text = TotalAmount.ToString();
            }
        }
	}
}