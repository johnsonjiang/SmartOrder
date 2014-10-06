using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VE.SMS.DAL;
using VE.SMS.Common;

namespace VE.SMS.UI._UserControl
{
	public partial class SampleProductEditControl : BaseUserControl
	{
        public string ViewType { get { return Request.QueryString["viewtype"]; } }
        public int SampleId { get { return ViewState["SampleId"] == null ? -1 : Convert.ToInt32(ViewState["SampleId"]); } set { ViewState["SampleId"] = value; } }
        public string CloseAfter { get { return ViewState["CloseAfter"] == null ? string.Empty : ViewState["CloseAfter"].ToString(); } set { ViewState["CloseAfter"] = value; } }

		protected void Page_Load(object sender, EventArgs e)
		{

		}

        class ProductComparer : IEqualityComparer<Product>
        {

            public bool Equals(Product x, Product y)
            {
                return x.Product_Code == y.Product_Code;
            }

            public int GetHashCode(Product obj)
            {
                return base.GetHashCode();
            }
        }
        public override void BindControl()
        {
            Utility.BindDataToDropdown(ddlColor, Utility.GetColorList());
            Utility.BindDataToDropdown(ddlLocation, Utility.GetLookupList("样品位置"));
            Utility.BindDataToDropdown(ddlSupplier, Utility.GetSupplierNameList());
            Utility.BindDataToDropdown(ddlTexure, Utility.GetLookupList("纹理"));
            ProductDAL pDAL = new ProductDAL();
            var result = from p in pDAL.GetAllProducts()
                         orderby p.Product_Name
                         select new NameValueItem() 
                         { 
                            Name = p.Product_Name + "/" + p.Product_Code,
                            Value = p.Product_Code
                         };
            Utility.BindDataToDropdown(ddlProductCodeAndName, result.Distinct());
            if (string.Equals(ViewType, "edit", StringComparison.OrdinalIgnoreCase))
            {
                SampleDAL dal = new SampleDAL();
                var sample = dal.GetSampleById(SampleId);
                ddlProductCodeAndName.SelectedValue = sample.MaterialCode;
                txtSampleCode.Text = sample.SampleCode;
                ddlTexure.SelectedValue = sample.SampleTexure;
                txtLong.Text = sample.SampleLong.HasValue ? sample.SampleLong.Value.ToString() : string.Empty;
                txtWidth.Text = sample.SampleWidth.HasValue ? sample.SampleWidth.Value.ToString() : string.Empty;
                txtDeepth.Text = sample.SampleDeep.HasValue ? sample.SampleDeep.Value.ToString() : string.Empty;
                ddlColor.SelectedValue = sample.SampleColor;
                ddlLocation.SelectedValue = sample.SampleLocation;
                txtSquare.Text = sample.SampleSquare.HasValue ? sample.SampleSquare.Value.ToString() : string.Empty;
                ddlSupplier.SelectedValue = sample.Supplier;
                txtPriceInM2.Text = sample.PurchasePrice.HasValue ? sample.PurchasePrice.Value.ToString() : string.Empty;
                txtPriceM.Text = sample.PriceM.HasValue ? sample.PriceM.Value.ToString() : string.Empty;
                txtPriceM2.Text = sample.PriceM2.HasValue ? sample.PriceM2.Value.ToString() : string.Empty;
                txtAlias1.Text = sample.Alias1;
                txtAlias2.Text = sample.Alias2;
                txtIntro.Text = sample.SampleIntro;
                imgPath.ImageUrl = !string.IsNullOrEmpty(sample.ImgPath) ? Page.ResolveUrl(sample.ImgPath) : string.Empty; 
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Sample sample = null;
            var dbProduct = new SampleDAL().GetSampleByCode(ddlProductCodeAndName.SelectedValue);
            if (dbProduct != null)
            {
                Page.RegisterClientScriptBlock("sample", "<script language='javascript'>alert('已经有相同的产品!');</script>");
                return;
            }
            if (string.Equals(ViewType, "edit", StringComparison.OrdinalIgnoreCase))
            {
                SampleDAL dal = new SampleDAL();
                sample = dal.GetSampleById(SampleId);
                sample.MaterialCode = ddlProductCodeAndName.SelectedValue;
                sample.MaterialName = Utility.GetSelectedText(ddlProductCodeAndName);
                sample.SampleCode = txtSampleCode.Text;
                sample.SampleTexure = Utility.GetSelectedText(ddlTexure);
                sample.SampleLong = !string.IsNullOrEmpty(txtLong.Text) ? int.Parse(txtLong.Text) : new Nullable<int>();
                sample.SampleWidth = !string.IsNullOrEmpty(txtWidth.Text) ? int.Parse(txtWidth.Text) : new Nullable<int>();
                sample.SampleDeep = !string.IsNullOrEmpty(txtDeepth.Text) ? int.Parse(txtDeepth.Text) : new Nullable<int>();
                sample.SampleColor = Utility.GetSelectedText(ddlColor);
                sample.SampleLocation = Utility.GetSelectedText(ddlLocation);
                sample.SampleSquare = !string.IsNullOrEmpty(txtSquare.Text) ? double.Parse(txtSquare.Text) : new Nullable<double>();
                sample.Supplier = Utility.GetSelectedText(ddlSupplier);
                sample.PurchasePrice = !string.IsNullOrEmpty(txtPriceInM2.Text) ? double.Parse(txtPriceInM2.Text) : new Nullable<double>();
                sample.PriceM = !string.IsNullOrEmpty(txtPriceM.Text) ? double.Parse(txtPriceM.Text) : new Nullable<double>();
                sample.PriceM2 = !string.IsNullOrEmpty(txtPriceM2.Text) ? double.Parse(txtPriceM2.Text) : new Nullable<double>();
                sample.Alias1 = txtAlias1.Text;
                sample.Alias2 = txtAlias2.Text;
                sample.SampleIntro = txtIntro.Text;
                if (!string.IsNullOrEmpty(filePic.FileName))
                {
                    string serverFilePath = string.Empty;
                    Utility.UploadFile(filePic, "SampleImage", SourceNo, ref serverFilePath);
                    sample.ImgPath = serverFilePath;
                }
                dal.Save(); 
            }
            else if (string.Equals(ViewType,"create", StringComparison.OrdinalIgnoreCase))
            {
                SampleDAL dal = new SampleDAL();
                sample = new Sample();
                sample.MaterialCode = ddlProductCodeAndName.SelectedValue;
                sample.MaterialName = Utility.GetSelectedText(ddlProductCodeAndName);
                sample.SampleCode = txtSampleCode.Text;
                sample.SampleTexure = Utility.GetSelectedText(ddlTexure);
                sample.SampleLong = !string.IsNullOrEmpty(txtLong.Text) ? int.Parse(txtLong.Text) : new Nullable<int>();
                sample.SampleWidth = !string.IsNullOrEmpty(txtWidth.Text) ? int.Parse(txtWidth.Text) : new Nullable<int>();
                sample.SampleDeep = !string.IsNullOrEmpty(txtDeepth.Text) ? int.Parse(txtDeepth.Text) : new Nullable<int>();
                sample.SampleColor = Utility.GetSelectedText(ddlColor);
                sample.SampleLocation = Utility.GetSelectedText(ddlLocation);
                sample.SampleSquare = !string.IsNullOrEmpty(txtSquare.Text) ? double.Parse(txtSquare.Text) : new Nullable<double>();
                sample.Supplier = Utility.GetSelectedText(ddlSupplier);
                sample.PurchasePrice = !string.IsNullOrEmpty(txtPriceInM2.Text) ? double.Parse(txtPriceInM2.Text) : new Nullable<double>();
                sample.PriceM = !string.IsNullOrEmpty(txtPriceM.Text) ? double.Parse(txtPriceM.Text) : new Nullable<double>();
                sample.PriceM2 = !string.IsNullOrEmpty(txtPriceM2.Text) ? double.Parse(txtPriceM2.Text) : new Nullable<double>();
                sample.Alias1 = txtAlias1.Text;
                sample.Alias2 = txtAlias2.Text;
                sample.SampleIntro = txtIntro.Text;
                if (!string.IsNullOrEmpty(filePic.FileName))
                {
                    string serverFilePath = string.Empty;
                    Utility.UploadFile(filePic, "SampleImage", SourceNo, ref serverFilePath);
                    sample.ImgPath = serverFilePath;
                }
                dal.AddSample(sample);
                dal.Save(); 
            }
            if (string.IsNullOrEmpty(CloseAfter))
            {
                Response.Redirect(string.Format("productform.aspx?type=s&id={0}&viewtype=edit", sample.Sample_Id)); 
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(typeof(FinishProductEditControl), "closecreate", "javascript:closeWindow();");
            }
        }
	}
}