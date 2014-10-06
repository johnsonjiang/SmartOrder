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
	public partial class EnquiryPrintout : BasePage
	{
        protected string EnqNo { get { return GetQueryStringValue("enqno"); } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            EnquiryDAL dal = new EnquiryDAL();
            var enq = dal.GetEnquiryByNo(EnqNo);
            lblDate.Text = enq.CreatedDate.ToString("yyyy-MM-dd");
            lblContactName.Text = enq.CustomerContactName;
            if (!string.IsNullOrEmpty(enq.CustomerPhone1) && !string.IsNullOrEmpty(enq.CustomerPhone2))
            {
                lblPhone.Text = enq.CustomerPhone1 + "/" + enq.CustomerPhone2;
            }
            else
            {
                lblPhone.Text = enq.CustomerPhone1 + enq.CustomerPhone2;
            }
            lblEmail.Text = enq.CustomerEmail;
            lblQQ.Text = enq.CustomerQQ;
            lblAddress.Text = enq.CustomerAddress;
            lblIsCustomerProvideImage.Text = enq.IsCustomerProvideImage ? YesNoConsts.Yes : YesNoConsts.No;
            lblSampleToCustomer.Text = enq.IsSampleProvidedToCustomer ? YesNoConsts.Yes : YesNoConsts.No;
            if (enq.IsSampleProvidedToCustomer)
            {
                lblTextSampleCode.Visible = true;
                lblSampleToCustomer.Visible = true;
                lblSampleCode.Visible = true;
                SampleProvidDAL sdal = new SampleProvidDAL();
                var samples = sdal.GetSampleBySource(SysConst.SourceTypeEnquiry, EnqNo);
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
            lblSurveyNeeded.Text = enq.IsSurveyNeeded ? YesNoConsts.Yes : YesNoConsts.No;
            if (enq.IsSurveyNeeded)
            {
                lblSurveyType.Text = enq.SurveyType;
            }
            lblProvideRefine.Text = enq.IsCADRefinementNeeded ? YesNoConsts.Yes : YesNoConsts.No;
            lblProvideDelivery.Text = enq.DeliveryType;
            lblDeliveryType.Text = enq.DeliveryType;
            lblDeliveryAddress.Text = enq.DeliveryToAddress;
            lblProvideInstall.Text = enq.IsInstallProvided ? YesNoConsts.Yes : YesNoConsts.No;
            lblInstallType.Text = enq.InstallType;

            //item
            LineItemDAL lDAL = new LineItemDAL();
            var items = lDAL.GetLineItemsBySource(enq.Enquiry_Id, SysConst.SourceTypeEnquiry);
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