using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VE.SMS.Common;
using VE.SMS.DAL;

namespace VE.SMS.UI._UserControl
{
	public partial class ProductInfoControl : BaseUserControl
	{
        public int ProductId { get { return ViewState["ProductId"] == null ? -1 : Convert.ToInt32(ViewState["ProductId"]); } set { ViewState["ProductId"] = value; } }
        public string ViewType { get { return Request.QueryString["viewtype"]; } }
        public string CloseAfter { get { return ViewState["CloseAfter"] == null ? string.Empty : ViewState["CloseAfter"].ToString(); } set { ViewState["CloseAfter"] = value; } }

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {

            }
		}

        public override void BindControl()
        {
            Utility.BindDataToDropdown(ddlColor, Utility.GetColorList());
            Utility.BindDataToDropdown(ddlLocation, Utility.GetLookupList("材料位置"));
            Utility.BindDataToDropdown(ddlSupplier, Utility.GetSupplierNameList());
            Utility.BindDataToDropdown(ddlTexure, Utility.GetLookupList("纹理"));
            if (string.Equals(ViewType, "edit", StringComparison.OrdinalIgnoreCase))
            {

                ProductDAL dal = new ProductDAL();
                
                var product = dal.GetProductById(ProductId);
                txtProductCode.Text = product.Product_Code;
                txtProductName.Text = product.Product_Name;
                txtHuangliaoCode.Text = product.HuangliaoCode;
                ddlTexure.SelectedValue = product.Texure;
                txtJiaCode.Text = product.JiaCode;
                txtPianCode.Text = product.PianCode;
                txtLong.Text = product.Long.HasValue ? product.Long.Value.ToString() : string.Empty;
                txtWidth.Text = product.Width.HasValue ? product.Width.Value.ToString() : string.Empty;
                txtDeepth.Text = product.Deep.HasValue ? product.Deep.Value.ToString() : string.Empty;
                ddlColor.SelectedValue = product.Color;
                ddlLocation.SelectedValue = product.Location;
                lblSquare.Text = (((product.Long.HasValue ? product.Long.Value : 0) * (product.Width.HasValue ? product.Width.Value : 0))/(1000*1000)).ToString();
                ddlSupplier.SelectedValue= product.SupplierName;
                txtPriceInM2.Text = product.PurchasePrice.HasValue ? product.PurchasePrice.Value.ToString() : string.Empty;
                txtPriceM.Text = product.PriceM.HasValue ? product.PriceM.Value.ToString() : string.Empty;
                txtPriceM2.Text = product.PriceM2.HasValue ? product.PriceM2.Value.ToString() : string.Empty;
                txtPriceOther.Text = product.PriceOther.HasValue ? product.PriceOther.Value.ToString() : string.Empty;
                txtAlias1.Text = product.Alias1;
                txtAlias2.Text = product.Alias2;
                txtIntro.Text = product.Intro;
                imgPath.ImageUrl = !string.IsNullOrEmpty(product.ImgPath) ? Page.ResolveUrl(product.ImgPath) : string.Empty; 
            }
        }

        protected void btnCopyNew_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Product product = null;
            int id = -1;
            int.TryParse(Request.QueryString["id"], out id);
            bool isExists = new ProductDAL().Exists(txtProductCode.Text,
                txtHuangliaoCode.Text,
                txtJiaCode.Text,
                txtPianCode.Text,
                id
                );
            if (isExists)
            {
                Page.RegisterClientScriptBlock("product", "<script language='javascript'>alert('已经有相同的产品!');</script>");
                return;
            }
            if (string.Equals(ViewType, "edit", StringComparison.OrdinalIgnoreCase))
            {
                ProductDAL dal = new ProductDAL();

                product = dal.GetProductById(ProductId);
                product.Product_Code = txtProductCode.Text;
                product.Product_Name = txtProductName.Text;
                product.HuangliaoCode = txtHuangliaoCode.Text;
                product.JiaCode = txtJiaCode.Text;
                product.PianCode = txtPianCode.Text;
                product.SampleCodes = txtSampleList.Text;
                product.Texure = Utility.GetSelectedText(ddlTexure);
                product.Long = !string.IsNullOrEmpty(txtLong.Text) ? int.Parse(txtLong.Text) : new Nullable<int>();
                product.Width = !string.IsNullOrEmpty(txtWidth.Text) ? int.Parse(txtWidth.Text) : new Nullable<int>();
                product.Deep = !string.IsNullOrEmpty(txtDeepth.Text) ? int.Parse(txtDeepth.Text) : new Nullable<int>();
                product.Color = Utility.GetSelectedText(ddlColor);
                product.Location = Utility.GetSelectedText(ddlLocation);
                product.QuantityM2 = !string.IsNullOrEmpty(lblSquare.Text) ? float.Parse(lblSquare.Text) : new Nullable<float>();
                product.SupplierName = Utility.GetSelectedText(ddlSupplier);
                product.PurchasePrice = !string.IsNullOrEmpty(txtPriceInM2.Text) ? double.Parse(txtPriceInM2.Text) : new Nullable<double>();
                product.PriceM = !string.IsNullOrEmpty(txtPriceM.Text) ? float.Parse(txtPriceM.Text) : new Nullable<float>();
                product.PriceM2 = !string.IsNullOrEmpty(txtPriceM2.Text) ? float.Parse(txtPriceM2.Text) : new Nullable<float>();
                product.PriceOther = !string.IsNullOrEmpty(txtPriceOther.Text) ? float.Parse(txtPriceOther.Text) : new Nullable<float>();
                product.Alias1 = txtAlias1.Text;
                product.Alias2 = txtAlias2.Text;
                product.Intro = txtIntro.Text;
                if (!string.IsNullOrEmpty(filePic.FileName))
                {
                    string serverFilePath = string.Empty;
                    Utility.UploadFile(filePic, "ProductImage", SourceNo, ref serverFilePath);
                    product.ImgPath = serverFilePath;
                }
                dal.Save(); 
            }
            else if (string.Equals(ViewType, "create", StringComparison.OrdinalIgnoreCase))
            {
                ProductDAL dal = new ProductDAL();
                product = new Product();
                product.Product_Code = txtProductCode.Text;
                product.Product_Name = txtProductName.Text;
                product.HuangliaoCode = txtHuangliaoCode.Text;
                product.JiaCode = txtJiaCode.Text;
                product.PianCode = txtPianCode.Text;
                product.SampleCodes = txtSampleList.Text;
                product.Texure = Utility.GetSelectedText(ddlTexure);
                product.Long = !string.IsNullOrEmpty(txtLong.Text) ? int.Parse(txtLong.Text) : new Nullable<int>();
                product.Width = !string.IsNullOrEmpty(txtWidth.Text) ? int.Parse(txtWidth.Text) : new Nullable<int>();
                product.Deep = !string.IsNullOrEmpty(txtDeepth.Text) ? int.Parse(txtDeepth.Text) : new Nullable<int>();
                product.Color = Utility.GetSelectedText(ddlColor);
                product.Location = Utility.GetSelectedText(ddlLocation);
                product.QuantityM2 = !string.IsNullOrEmpty(lblSquare.Text) ? float.Parse(lblSquare.Text) : new Nullable<float>();
                product.SupplierName = Utility.GetSelectedText(ddlSupplier);
                product.PurchasePrice = !string.IsNullOrEmpty(txtPriceInM2.Text) ? double.Parse(txtPriceInM2.Text) : new Nullable<double>();
                product.PriceM = !string.IsNullOrEmpty(txtPriceM.Text) ? float.Parse(txtPriceM.Text) : new Nullable<float>();
                product.PriceM2 = !string.IsNullOrEmpty(txtPriceM2.Text) ? float.Parse(txtPriceM2.Text) : new Nullable<float>();
                product.PriceOther = !string.IsNullOrEmpty(txtPriceOther.Text) ? float.Parse(txtPriceOther.Text) : new Nullable<float>();
                product.Alias1 = txtAlias1.Text;
                product.Alias2 = txtAlias2.Text;
                product.Intro = txtIntro.Text;
                if (!string.IsNullOrEmpty(filePic.FileName))
                {
                    string serverFilePath = string.Empty;
                    Utility.UploadFile(filePic, "ProductImage", SourceNo, ref serverFilePath);
                    product.ImgPath = serverFilePath;
                }
                dal.AddProduct(product);
                dal.Save(); 
            }
            if (string.IsNullOrEmpty(CloseAfter))
            {
                Response.Redirect(string.Format("productform.aspx?type=p&id={0}&viewtype=edit", product.Product_Id));
            }
            else
            {

                Page.RegisterStartupScript("closepopup", "<script language='javascript'>document.getElementById('btnClose').click();</script>");
            }
        }
	}
}