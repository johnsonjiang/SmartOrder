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
    public partial class ProductList : BasePage
    {
        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewProductList;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Utility.BindDataToDropdown(ddlSupplierProduct, Utility.GetSupplierNameList(true));
                Utility.BindDataToDropdown(ddlColor, Utility.GetColorList(true));
                Utility.BindDataToDropdown(ddlLocation, Utility.GetLookupList("材料位置", true));
                Utility.BindDataToDropdown(ddlTexure, Utility.GetLookupList("纹理", true));
                ProductDAL dal = new ProductDAL();
                var products = dal.GetAllProducts();
                products.Insert(0, new Product() { Product_Code = string.Empty, Product_Name = string.Empty });
                ddlProductCode.DataSource = products;
                ddlProductCode.DataTextField = "Product_Code";
                ddlProductCode.DataValueField = "Product_Code";
                ddlProductCode.DataBind();

                ddlProductName.DataSource = products;
                ddlProductName.DataTextField = "Product_Name";
                ddlProductName.DataValueField = "Product_Name";
                ddlProductName.DataBind();
                SeachProduct();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SeachProduct();
        }

        private void SeachProduct()
        {
            //pian
            pianProductLineItemControl1.SetValue(Utility.GetSelectedText(ddlProductCode),
                Utility.GetSelectedText(ddlProductName),
                txtHuangliaoCode.Text,
                txtJiaCode.Text,
                txtPianCode.Text,
                Utility.GetSelectedText(ddlLocation),
                Utility.GetSelectedText(ddlColor),
                Utility.GetSelectedText(ddlTexure),
                Utility.GetSelectedText(ddlSupplierProduct),
                !string.IsNullOrEmpty(txtLong.Text) ? int.Parse(txtLong.Text) : -1,
                !string.IsNullOrEmpty(txtWidth.Text) ? int.Parse(txtWidth.Text) : -1,
                !string.IsNullOrEmpty(txtDeep.Text) ? int.Parse(txtDeep.Text) : -1,
                !string.IsNullOrEmpty(txtPriceM.Text) ? double.Parse(txtPriceM.Text) : -1,
                !string.IsNullOrEmpty(txtPriceM2.Text) ? double.Parse(txtPriceM2.Text) : -1);
            pianProductLineItemControl1.BindControl();
            //jia
            jiaProductLineItemControl1.SetValue(Utility.GetSelectedText(ddlProductCode),
                Utility.GetSelectedText(ddlProductName),
            txtHuangliaoCode.Text,
            txtJiaCode.Text,
            txtPianCode.Text,
            Utility.GetSelectedText(ddlLocation),
            Utility.GetSelectedText(ddlColor),
            Utility.GetSelectedText(ddlTexure),
            Utility.GetSelectedText(ddlSupplierProduct),
            !string.IsNullOrEmpty(txtLong.Text) ? int.Parse(txtLong.Text) : -1,
            !string.IsNullOrEmpty(txtWidth.Text) ? int.Parse(txtWidth.Text) : -1,
            !string.IsNullOrEmpty(txtDeep.Text) ? int.Parse(txtDeep.Text) : -1,
            !string.IsNullOrEmpty(txtPriceM.Text) ? double.Parse(txtPriceM.Text) : -1,
            !string.IsNullOrEmpty(txtPriceM2.Text) ? double.Parse(txtPriceM2.Text) : -1);
            jiaProductLineItemControl1.BindControl();
            //huangliao
            huangliaoProductLineItemControl1.SetValue(Utility.GetSelectedText(ddlProductCode),
                Utility.GetSelectedText(ddlProductName),
                txtHuangliaoCode.Text,
                txtJiaCode.Text,
                txtPianCode.Text,
                Utility.GetSelectedText(ddlLocation),
                Utility.GetSelectedText(ddlColor),
                Utility.GetSelectedText(ddlTexure),
                Utility.GetSelectedText(ddlSupplierProduct),
                !string.IsNullOrEmpty(txtLong.Text) ? int.Parse(txtLong.Text) : -1,
                !string.IsNullOrEmpty(txtWidth.Text) ? int.Parse(txtWidth.Text) : -1,
                !string.IsNullOrEmpty(txtDeep.Text) ? int.Parse(txtDeep.Text) : -1,
                !string.IsNullOrEmpty(txtPriceM.Text) ? double.Parse(txtPriceM.Text) : -1,
                !string.IsNullOrEmpty(txtPriceM2.Text) ? double.Parse(txtPriceM2.Text) : -1);
            huangliaoProductLineItemControl1.BindControl();
            //material
            caiLiaoProductLineItemControl1.SetValue(Utility.GetSelectedText(ddlProductCode),
                Utility.GetSelectedText(ddlProductName),
                txtHuangliaoCode.Text,
                txtJiaCode.Text,
                txtPianCode.Text,
                Utility.GetSelectedText(ddlLocation),
                Utility.GetSelectedText(ddlColor),
                Utility.GetSelectedText(ddlTexure),
                Utility.GetSelectedText(ddlSupplierProduct),
                !string.IsNullOrEmpty(txtLong.Text) ? int.Parse(txtLong.Text) : -1,
                !string.IsNullOrEmpty(txtWidth.Text) ? int.Parse(txtWidth.Text) : -1,
                !string.IsNullOrEmpty(txtDeep.Text) ? int.Parse(txtDeep.Text) : -1,
                !string.IsNullOrEmpty(txtPriceM.Text) ? double.Parse(txtPriceM.Text) : -1,
                !string.IsNullOrEmpty(txtPriceM2.Text) ? double.Parse(txtPriceM2.Text) : -1);
            caiLiaoProductLineItemControl1.BindControl();
        }
    }
}