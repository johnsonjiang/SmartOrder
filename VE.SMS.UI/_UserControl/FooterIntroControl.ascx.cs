using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using VE.SMS.Common;
using VE.SMS.DAL;

namespace VE.SMS.UI._UserControl
{
	public partial class FooterIntroControl : BaseUserControl
	{

		protected void Page_Load(object sender, EventArgs e)
		{
		}

		public override void BindControl()
		{
			FooterDAL dal = new FooterDAL();
			var result = dal.GetFooterBySource(SourceNo, SourceType);
			Utility.BindDataToRepeater(rpItems, result);
		}

		protected void rpItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Header)
			{
				DropDownList ddlIntro = e.Item.FindControl("ddlIntro") as DropDownList;
                string footerType = string.Empty;
                if (string.Equals(SourceType, SysConst.SourceTypeDelivery, StringComparison.OrdinalIgnoreCase))
                {
                    footerType = "送货安装单页尾";
                }
                else if (string.Equals(SourceType, SysConst.SourceTypeEnquiry, StringComparison.OrdinalIgnoreCase))
                {
                    footerType = "咨询单页尾";
                }
                else if (string.Equals(SourceType, SysConst.SourceTypeQuote, StringComparison.OrdinalIgnoreCase))
                {
                    footerType = "报价单页尾";
                }
                else if (string.Equals(SourceType, SysConst.SourceTypeOrder, StringComparison.OrdinalIgnoreCase))
                {
                    footerType = "订单页尾";
                }
                Utility.BindDataValueToDropdown(ddlIntro, Utility.GetLookupList(footerType));
			}
		}

		protected void rpItems_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			FooterDAL dal = new FooterDAL();
			if (e.CommandName=="Add")
			{
				DropDownList ddlIntro = e.Item.FindControl("ddlIntro") as DropDownList;
				
				Footer footer = new Footer();
				footer.Intro = ddlIntro.SelectedValue;
				footer.SourceType = SourceType;
				footer.SourceNo = SourceNo;
				dal.AddFooter(footer);
				dal.Save();
			}
			if (e.CommandName == "Save")
			{
				HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
				TextBox txtIntro = e.Item.FindControl("txtIntro") as TextBox;

				var item = dal.GetFooterById(int.Parse(hdId.Value));
				item.Intro = txtIntro.Text;
				dal.Save();
				
			}
			if (e.CommandName == "Delete")
			{
                HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
                dal.DeleteFooterItem(int.Parse(hdId.Value));
			}
			BindControl();
			SetFocus(rpItems);
		}
	}
}