using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VE.SMS.Common;

namespace VE.SMS.UI._UserControl
{
	public partial class DeliveryEditControl : BaseUserControl
	{
        public delegate string GetAddress();
        public GetAddress OnGetAddress;
        public string DeliveryType { get { return ddlDeliveryType.SelectedValue; } }
        public string DeliveryIntro { get { return txtDeliveryIntro.Text; } set { txtDeliveryIntro.Text = value; } }
        public string DeliveryToAddress { get { return this.txtShippingToAddress.Text; } set { txtShippingToAddress.Text = value; } }

		protected void Page_Load(object sender, EventArgs e)
		{

		}

        public override void BindControl()
        {
            Utility.BindDataToDropdown(ddlDeliveryType, Utility.GetLookupList(SysConst.DeliveryCatelog));

        }

        public void SetDeliveryType(string deliveryType)
        {
            if (!string.IsNullOrEmpty(deliveryType))
            {
                ddlDeliveryType.SelectedValue = deliveryType;
            }
        }

        protected void rbSame_CheckedChanged(object sender, EventArgs e)
        {
            this.txtShippingToAddress.Text = OnGetAddress();
            SetFocus(sender);
        }

        protected void rbOther_CheckedChanged(object sender, EventArgs e)
        {
            this.txtShippingToAddress.Text = string.Empty;
            SetFocus(sender);
        }
	}
}