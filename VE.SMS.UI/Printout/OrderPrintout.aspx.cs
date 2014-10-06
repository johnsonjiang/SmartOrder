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
	public partial class OrderPrintout : BasePage
	{
        protected string OrdNo { get { return GetQueryStringValue("ordno"); } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            OrderDAL dal = new OrderDAL();
            var ord = dal.GetOrderByNo(OrdNo);
            lblDate.Text = ord.CreatedDate.ToString("yyyy-MM-dd");
            lblContactName.Text = ord.CustomerContactName;
            if (!string.IsNullOrEmpty(ord.CustomerPhone1) && !string.IsNullOrEmpty(ord.CustomerPhone2))
            {
                lblPhone.Text = ord.CustomerPhone1 + "/" + ord.CustomerPhone2;
            }
            else
            {
                lblPhone.Text = ord.CustomerPhone1 + ord.CustomerPhone2;
            }
            lblEmail.Text = ord.CustomerEmail;
            lblQQ.Text = ord.CustomerQQ;
            lblAddress.Text = ord.CustomerAddress;
            lblIsCustomerProvideImage.Text = ord.IsCustomerProvideImage ? YesNoConsts.Yes : YesNoConsts.No;
            lblSampleToCustomer.Text = ord.IsSampleProvidedToCustomer ? YesNoConsts.Yes : YesNoConsts.No;
            if (ord.IsSampleProvidedToCustomer)
            {
                lblTextSampleCode.Visible = true;
                lblSampleToCustomer.Visible = true;
                lblSampleCode.Visible = true;
                SampleProvidDAL sdal = new SampleProvidDAL();
                var samples = sdal.GetSampleBySource(SysConst.SourceTypeOrder, OrdNo);
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
            lblSurveyNeeded.Text = ord.IsSurveyNeeded ? YesNoConsts.Yes : YesNoConsts.No;
            if (ord.IsSurveyNeeded)
            {
                lblSurveyType.Text = ord.SurveyType;
            }
            lblProvideRefine.Text = ord.IsCADRefinementNeeded ? YesNoConsts.Yes : YesNoConsts.No;
            lblProvideDelivery.Text = ord.DeliveryType;
            lblDeliveryType.Text = ord.DeliveryType;
            lblDeliveryAddress.Text = ord.DeliveryToAddress;
            lblProvideInstall.Text = ord.IsInstallProvided ? YesNoConsts.Yes : YesNoConsts.No;
            lblInstallType.Text = ord.InstallType;

            //item
            LineItemDAL lDAL = new LineItemDAL();
            var items = lDAL.GetLineItemsBySource(ord.Order_Id, SysConst.SourceTypeOrder);
            Utility.BindDataToRepeater(rpItems, items);
            //bankinfo
            Utility.BindDataToDropdown(ddlBankInfo, Utility.GetLookupList("账户列表"));
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

        protected void ddlBankInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBankInfo();
        }

        private void SetBankInfo()
        {
            var bankInfo = Utility.GetLookupList(ddlBankInfo.SelectedValue);
            lblBankName.Text = bankInfo.FirstOrDefault(b => b.ConfigItem_Key == "银行").ConfigItem_Value;
            lblName.Text = bankInfo.FirstOrDefault(b => b.ConfigItem_Key == "户名").ConfigItem_Value;
            lblAccount.Text = bankInfo.FirstOrDefault(b => b.ConfigItem_Key == "账号").ConfigItem_Value;
        }
	}
}