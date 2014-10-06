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
	public partial class FinishProductControl : BaseUserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                Utility.BindDataToDropdown(ddlCatelog, Utility.GetLookupList("分类", true));
                Utility.BindDataToDropdown(ddlSubCatelog, Utility.GetLookupList("细类",true));

                Utility.BindDataToDropdown(ddlSupplier, Utility.GetSupplierNameList(true));
                Utility.BindDataToDropdown(ddlLocation, Utility.GetLookupList("成品位置", true));
                BindControl();
            }
		}

        public override void BindControl()
        {
            var result = GetEndProductList();
            Utility.BindDataToRepeater(rpProductList, result);
        }

        private List<EndProduct> GetEndProductList()
        {
            EndProductDAL dal = new EndProductDAL();
            var result = dal.SearchEndProduct(Utility.GetSelectedText(ddlCatelog),
                Utility.GetSelectedText(ddlSubCatelog),
                txtCode.Text,
                txtName.Text,
                Utility.GetSelectedText(ddlSupplier),
                Utility.GetSelectedText(ddlLocation),
                !string.IsNullOrEmpty(txtLongFinishProduct.Text) ? int.Parse(txtLongFinishProduct.Text) : -1,
                !string.IsNullOrEmpty(txtWidthFinishProduct.Text) ? int.Parse(txtWidthFinishProduct.Text) : -1,
                !string.IsNullOrEmpty(txtDeepFinishProduct.Text) ? int.Parse(txtDeepFinishProduct.Text) : -1,
                !string.IsNullOrEmpty(txtPrice.Text) ? double.Parse(txtPrice.Text) : -1);
            return result;
        }

        protected void btnSearchFinishProduct_Click(object sender, EventArgs e)
        {
            BindControl();
            SetFocus(sender);
        }

        protected void rpProductList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                EndProductDAL dal = new EndProductDAL();
                var result = dal.SearchEndProduct(Utility.GetSelectedText(ddlCatelog),
                    Utility.GetSelectedText(ddlSubCatelog),
                    txtCode.Text,
                    txtName.Text,
                    Utility.GetSelectedText(ddlSupplier),
                    Utility.GetSelectedText(ddlLocation),
                    !string.IsNullOrEmpty(txtLongFinishProduct.Text) ? int.Parse(txtLongFinishProduct.Text) : -1,
                    !string.IsNullOrEmpty(txtWidthFinishProduct.Text) ? int.Parse(txtWidthFinishProduct.Text) : -1,
                    !string.IsNullOrEmpty(txtDeepFinishProduct.Text) ? int.Parse(txtDeepFinishProduct.Text) : -1,
                    !string.IsNullOrEmpty(txtPrice.Text) ? double.Parse(txtPrice.Text) : -1);
                double qty = result.Sum(r => r.Qty).Value;
                double amount = result.Sum(r => r.Qty * r.Price).Value;
                var lblTotalQuantity = e.Item.FindControl("lblTotalQuantity") as Label;
                var lblTotalAmount = e.Item.FindControl("lblTotalAmount") as Label;
                lblTotalQuantity.Text = Utility.Round(qty).ToString();
                lblTotalAmount.Text = Utility.Round(amount).ToString();
            }
        }

        protected void rpProductList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            SetSorting(e);
            if (!string.IsNullOrWhiteSpace(SortOrder))
            {
                Utility.BindDataToRepeater(rpProductList, GetEndProductList().Sort(string.Format("{0} {1}", e.CommandName, SortOrder)));
            }
        }
	}
}