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
    
	public partial class LineItemsControl : BaseUserControl
	{
        public bool IsPriceColumnVisible
        {
            get
            {
                return ViewState["IsPriceColumnVisible"] == null ? true : Convert.ToBoolean(ViewState["IsPriceColumnVisible"]);
            }
            set
            {
                ViewState["IsPriceColumnVisible"] = value;
            }

        }

        public bool IsFooterVisible
        {
            get
            {
                return ViewState["IsFooterVisible"] == null ? true : Convert.ToBoolean(ViewState["IsFooterVisible"]);
            }
            set
            {
                ViewState["IsFooterVisible"] = value;
            }

        }

        public bool IsSpecColumnVisible
        {
            get
            {
                return ViewState["IsSpecColumnVisible"] == null ? true : Convert.ToBoolean(ViewState["IsSpecColumnVisible"]);
            }
            set
            {
                ViewState["IsSpecColumnVisible"] = value;
            }

        }
        public double TotalMaterialAmount ;//{ get { return ViewState["TotalMaterialAmount"] == null ? 0 : Convert.ToDouble(ViewState["TotalMaterialAmount"]); } set { ViewState["TotalMaterialAmount"] = value; } }
        public double TotalMachAmount ;//{ get { return ViewState["TotalMachAmount"] == null ? 0 : Convert.ToDouble(ViewState["TotalMachAmount"]); } set { ViewState["TotalMachAmount"] = value; } }
        public double TotalInstallAmount ;//{ get { return ViewState["TotalInstallAmount"] == null ? 0 : Convert.ToDouble(ViewState["TotalInstallAmount"]); } set { ViewState["TotalInstallAmount"] = value; } }
        public double TotalEndProductAmount;
		protected void Page_Load(object sender, EventArgs e)
		{

		}
        class PriceInfo
	    {
            public double PriceM { get; set; }
            public double PriceM2 { get; set; }
            public double PriceOther { get; set; }
	    }

        private PriceInfo GetPriceInfoByProduct(string project, int id)
        {
            PriceInfo price = new PriceInfo();

            if (string.Equals(project, "加工", StringComparison.OrdinalIgnoreCase))
            {
                MachLookupDAL dal = new MachLookupDAL();
                var mach = dal.GetMachLookupById(id);
                price.PriceM = mach.PriceM.Value;
                price.PriceM2 = mach.PriceM2.Value;
                price.PriceOther = mach.PriceOther.Value;
            }
            else if (string.Equals(project, "安装", StringComparison.OrdinalIgnoreCase))
            {
                InstallLookupDAL dal = new InstallLookupDAL();
                var install = dal.GetLookupById(id);
                price.PriceM = install.PriceM.Value;
                price.PriceM2 = install.PriceM2.Value;
                price.PriceOther = install.PriceOther.Value;
            }
            else if (string.Equals(project, "材料", StringComparison.OrdinalIgnoreCase))
            {
                ProductDAL dal = new ProductDAL();
                var product = dal.GetProductById(id);
                price.PriceM = product.PriceM.Value;
                price.PriceM2 = product.PriceM2.Value;
                price.PriceOther = product.PriceOther.Value;
                
            }
            else if (string.Equals(project, "成品", StringComparison.OrdinalIgnoreCase))
            {
                EndProductDAL dal = new EndProductDAL();
                var endProduct = dal.GetEndProductById(id);
                price.PriceM = endProduct.Price.Value;
                price.PriceM2 = endProduct.Price.Value;
                price.PriceOther = endProduct.Price.Value;
            }
            return price;
        }

        private List<NameValueItem> GetProductByProject(string project)
        {
            List<NameValueItem> result = new List<NameValueItem>();

            if (string.Equals(project, "加工", StringComparison.OrdinalIgnoreCase))
            {
                MachLookupDAL dal = new MachLookupDAL();
                var machs = dal.GetAllMach();
                foreach (var item in machs)
                {
                    result.Add(new NameValueItem() { Name = item.Name, Value = item.Mach_Id.ToString()});
                }
            }
            else if (string.Equals(project, "安装", StringComparison.OrdinalIgnoreCase))
            {
                InstallLookupDAL dal = new InstallLookupDAL();
                var installs = dal.GetAllLookup();
                foreach (var item in installs)
                {
                    result.Add(new NameValueItem() { Name = item.Name, Value = item.Install_Id.ToString() });
                }
            }
            else if (string.Equals(project, "材料", StringComparison.OrdinalIgnoreCase))
            {
                ProductDAL dal = new ProductDAL();
                var products = dal.GetAllProducts();
                foreach (var item in products)
                {
                    result.Add(new NameValueItem() { Name = item.Product_Name + "/" + item.Product_Code, Value = item.Product_Id.ToString()});
                }
            }
            else if (string.Equals(project, "成品", StringComparison.OrdinalIgnoreCase))
            {
                EndProductDAL dal = new EndProductDAL();
                var endProducts = dal.GetAllEndProductList();
                foreach (var item in endProducts)
                {
                    result.Add(new NameValueItem() { Name = item.Name + "/" + item.Code, Value = item.EP_Id.ToString() });
                }
            }

            return result;
        }

		public override void BindControl()
		{
            Utility.BindDataToDropdown(ddlProjectAdd, Utility.GetProjectList());

            string projectType = Utility.GetSelectedText(ddlProjectAdd);
            var products = GetProductByProject(projectType);
            Utility.BindDataToDropdown(ddlProductNameAdd, products);
            Utility.BindDataToDropdown(ddlUnitAdd, Utility.GetUnitTypeList());
			LineItemDAL dal = new LineItemDAL();
			var result = dal.GetLineItemsBySource(SourceId, SourceType);
			Utility.BindDataToRepeater(rpItems, result);
		}

		protected void rpItems_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			LineItemDAL dal = new LineItemDAL();
			
			if (e.CommandName == "Save")
			{
				HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
				TextBox txtIntro = e.Item.FindControl("txtIntro") as TextBox;
                TextBox txtProductName = e.Item.FindControl("txtProductName") as TextBox;
				TextBox txtSpec = e.Item.FindControl("txtSpec") as TextBox;
                TextBox txtUnit = e.Item.FindControl("txtUnit") as TextBox;
				TextBox txtPrice = e.Item.FindControl("txtPrice") as TextBox;
				TextBox txtQty = e.Item.FindControl("txtQty") as TextBox;
				TextBox txtRemark = e.Item.FindControl("txtRemark") as TextBox;
				var lineItem = dal.GetLineItemById(int.Parse(hdId.Value));

				lineItem.Intro = txtIntro.Text;
                lineItem.Name = txtProductName.Text;
				lineItem.Spec = txtSpec.Text;
                lineItem.Unit = txtUnit.Text;
				lineItem.UnitPrice = !string.IsNullOrEmpty(txtPrice.Text) ? double.Parse(txtPrice.Text) : 0;
				lineItem.Quantity = !string.IsNullOrEmpty(txtQty.Text) ? double.Parse(txtQty.Text) : 0;
				lineItem.Remark = txtRemark.Text;
				dal.Save();
			}
			if (e.CommandName == "Delete")
			{
				HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
				dal.DeleteItem(int.Parse(hdId.Value));
			}
			BindControl();
            if (UpdateAmount != null)
            {
                UpdateAmount(SourceType, SourceId);
            }
			SetFocus(source);
		}
        public delegate void UpdateAmountDelegate(string sourceType, int sourceId);
        public UpdateAmountDelegate UpdateAmount;
        protected void ddlProductNameAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUnitPriceAdd.Text = string.Empty;
            PriceInfo price = GetPriceInfoByProduct(Utility.GetSelectedText(ddlProjectAdd), int.Parse(ddlProductNameAdd.SelectedValue));
            if (string.Equals(Utility.GetSelectedText(ddlUnitAdd), "M", StringComparison.OrdinalIgnoreCase))
            {
                txtUnitPriceAdd.Text = price.PriceM.ToString();
            }
            else if (string.Equals(Utility.GetSelectedText(ddlUnitAdd), "M2", StringComparison.OrdinalIgnoreCase))
            {
                txtUnitPriceAdd.Text = price.PriceM2.ToString();
            }
            else
            {
                txtUnitPriceAdd.Text = price.PriceOther.ToString();
            }
            SetFocus(btnFocus);
        }

        protected void ddlProjectAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUnitPriceAdd.Text = string.Empty;
            Utility.BindDataToDropdown(ddlProductNameAdd, GetProductByProject(Utility.GetSelectedText(ddlProjectAdd)));
            var price = GetPriceInfoByProduct(Utility.GetSelectedText(ddlProjectAdd), int.Parse(Utility.GetSelectedValue(ddlProductNameAdd)));
            if (string.Equals(Utility.GetSelectedText(ddlUnitAdd), "M", StringComparison.OrdinalIgnoreCase))
            {
                txtUnitPriceAdd.Text = price.PriceM.ToString();
            }
            else if (string.Equals(Utility.GetSelectedText(ddlUnitAdd), "M2", StringComparison.OrdinalIgnoreCase))
            {
                txtUnitPriceAdd.Text = price.PriceM2.ToString();
            }
            else
            {
                txtUnitPriceAdd.Text = price.PriceOther.ToString();
            }
            SetFocus(btnFocus);
        }

		protected void rpItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Header)
			{
				DropDownList ddlProjectAdd = e.Item.FindControl("ddlProjectAdd") as DropDownList;
				DropDownList ddlUnitAdd = e.Item.FindControl("ddlUnitAdd") as DropDownList;
				Utility.BindDataToDropdown(ddlProjectAdd, Utility.GetProjectList());
				Utility.BindDataToDropdown(ddlUnitAdd, Utility.GetUnitTypeList());
			}
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
                LineItem lineItem = e.Item.DataItem as LineItem;
                if (lineItem != null)
                {
                    if (lineItem.Project == "加工")
                    {
                        TotalMachAmount += lineItem.UnitPrice.Value * lineItem.Quantity.Value;
                    }
                    if (lineItem.Project == "安装")
                    {
                        TotalInstallAmount += lineItem.UnitPrice.Value * lineItem.Quantity.Value;
                    }
                    if (lineItem.Project == "材料")
                    {
                        TotalMaterialAmount += lineItem.UnitPrice.Value * lineItem.Quantity.Value;
                    }
                    if (lineItem.Project == "成品")
                    {
                        TotalEndProductAmount += lineItem.UnitPrice.Value * lineItem.Quantity.Value;
                    }
                }
                Label lblDelNo = e.Item.FindControl("lblDelNo") as Label;
                lblDelNo.Text = lineItem.OriginNo;
			}
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblMaterialAmount = e.Item.FindControl("lblMaterialAmount") as Label;
                Label lblMachAmount = e.Item.FindControl("lblMachAmount") as Label;
                Label lblInstallAmount = e.Item.FindControl("lblInstallAmount") as Label;
                Label lblEndProductAmount = e.Item.FindControl("lblEndProductAmount") as Label;
                Label lblTotalAmount = e.Item.FindControl("lblTotalAmount") as Label;

                lblMachAmount.Text = TotalMachAmount.ToString();
                lblMaterialAmount.Text = TotalMaterialAmount.ToString();
                lblInstallAmount.Text = TotalInstallAmount.ToString();
                lblEndProductAmount.Text = TotalEndProductAmount.ToString();
                lblTotalAmount.Text = (TotalMachAmount + TotalMaterialAmount + TotalInstallAmount + TotalEndProductAmount).ToString();
            }
		}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            LineItemDAL dal = new LineItemDAL();
            string name = string.Empty;
            //if (string.Equals(Utility.GetSelectedText(ddlProjectAdd), "材料", StringComparison.OrdinalIgnoreCase) || string.Equals(Utility.GetSelectedText(ddlProjectAdd), "成品", StringComparison.OrdinalIgnoreCase))
            //{
                name = Utility.GetSelectedText(ddlProductNameAdd);
            //}
            LineItem item = new LineItem()
            {
                Intro = txtIntroAdd.Text,
                Name = name,
                Project = Utility.GetSelectedText(ddlProjectAdd),
                Quantity = !string.IsNullOrEmpty(txtQtyAdd.Text) ? double.Parse(txtQtyAdd.Text) : 0,
                Remark = txtRemarkAdd.Text,
                SourceId = SourceId,
                SourceType = SourceType,
                Spec = txtSpecAdd.Text,
                Unit = Utility.GetSelectedText(ddlUnitAdd),
                UnitPrice = !string.IsNullOrEmpty(txtUnitPriceAdd.Text) ? double.Parse(txtUnitPriceAdd.Text) : 0
            };

            dal.AddLineItem(item);
            dal.Save();
            BindControl();
            SetFocus(btnFocus);    
        }
	}
}