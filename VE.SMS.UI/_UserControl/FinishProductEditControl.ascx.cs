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
	public partial class FinishProductEditControl : BaseUserControl
	{

        public string ViewType { get { return Request.QueryString["viewtype"]; } }
        public int EPId { get { return ViewState["EPId"] == null ? -1 : Convert.ToInt32(ViewState["EPId"]); } set { ViewState["EPId"] = value; } }
        public string CloseAfter { get { return ViewState["CloseAfter"] == null ? string.Empty : ViewState["CloseAfter"].ToString(); } set { ViewState["CloseAfter"] = value; } }

		protected void Page_Load(object sender, EventArgs e)
		{
		}

        public override void BindControl()
        {
            Utility.BindDataToDropdown(ddlCatelog, Utility.GetLookupList("分类"));
            Utility.BindDataToDropdown(ddlSubCatelog, Utility.GetLookupList("细类"));
            Utility.BindDataToDropdown(ddlLocation, Utility.GetLookupList("成品位置"));
            Utility.BindDataToDropdown(ddlSupplier, Utility.GetSupplierNameList());

            if (string.Equals(ViewType, "edit", StringComparison.OrdinalIgnoreCase))
            {
                EndProductDAL dal = new EndProductDAL();
                var ep = dal.GetEndProductById(EPId);
                txtCode.Text = ep.Code;
                txtName.Text = ep.Name;
                ddlCatelog.SelectedValue = ep.Catelog;
                ddlSubCatelog.SelectedValue = ep.SubCatelog;
                txtLong.Text = ep.Long == null ? string.Empty : ep.Long.Value.ToString();
                txtWidth.Text = ep.Width == null ? string.Empty : ep.Width.Value.ToString();
                txtDeep.Text = ep.Deepth == null ? string.Empty : ep.Deepth.Value.ToString();
                txtMaterial.Text = ep.Material;
                txtPrice.Text = ep.Price == null ? string.Empty : ep.Price.Value.ToString();
                txtPriceIn.Text = ep.PurchasePrice == null ? string.Empty : ep.PurchasePrice.Value.ToString();
                txtQty.Text = ep.Qty == null ? string.Empty : ep.Qty.Value.ToString();
                ddlSupplier.SelectedValue = ep.SupplierName;
                ddlLocation.SelectedValue = ep.Location;
                txtRemark.Text = ep.Remark;
                if (!string.IsNullOrEmpty(ep.ImgPth))
                    imgPath.ImageUrl = Page.ResolveUrl(ep.ImgPth); 
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EndProduct ep = null;
            var isExists = new EndProductDAL().Exists(txtCode.Text, EPId);
            if (isExists == true)
            {
                Page.RegisterClientScriptBlock("endproduct", "<script language='javascript'>alert('已经有相同的产品!');</script>");
                return;
            }
            if (string.Equals(ViewType, "edit", StringComparison.OrdinalIgnoreCase))
            {
                EndProductDAL dal = new EndProductDAL();
                ep = dal.GetEndProductById(EPId);
                ep.Code = txtCode.Text;
                ep.Name = txtName.Text;
                ep.Catelog = Utility.GetSelectedText(ddlCatelog);
                ep.SubCatelog = Utility.GetSelectedText(ddlSubCatelog);
                if (!string.IsNullOrEmpty(txtLong.Text))
                    ep.Long = int.Parse(txtLong.Text);
                if (!string.IsNullOrEmpty(txtWidth.Text))
                    ep.Width = int.Parse(txtWidth.Text);
                if (!string.IsNullOrEmpty(txtDeep.Text))
                    ep.Deepth = int.Parse(txtDeep.Text);
                ep.Material = txtMaterial.Text;
                if (!string.IsNullOrEmpty(txtPrice.Text))
                    ep.Price = double.Parse(txtPrice.Text);
                if (!string.IsNullOrEmpty(txtPriceIn.Text))
                    ep.PurchasePrice = double.Parse(txtPriceIn.Text);
                if (!string.IsNullOrEmpty(txtQty.Text))
                    ep.Qty = int.Parse(txtQty.Text);
                ep.SupplierName = Utility.GetSelectedText(ddlSupplier);
                ep.Location = Utility.GetSelectedText(ddlLocation);
                ep.Remark = txtRemark.Text;
                if (!string.IsNullOrEmpty(filePic.FileName))
                {
                    string serverFilePath = string.Empty;
                    Utility.UploadFile(filePic, "EndProductImage", SourceNo, ref serverFilePath);
                    ep.ImgPth = serverFilePath;
                }
                dal.Save();

            }
            else if(string.Equals(ViewType,"create", StringComparison.OrdinalIgnoreCase))
            {
                EndProductDAL dal = new EndProductDAL();
                ep = new EndProduct();
                ep.Code = txtCode.Text;
                ep.Name = txtName.Text;
                ep.Catelog = Utility.GetSelectedText(ddlCatelog);
                ep.SubCatelog = Utility.GetSelectedText(ddlSubCatelog);
                if (!string.IsNullOrEmpty(txtLong.Text))
                    ep.Long = int.Parse(txtLong.Text);
                if (!string.IsNullOrEmpty(txtWidth.Text))
                    ep.Width = int.Parse(txtWidth.Text);
                if (!string.IsNullOrEmpty(txtDeep.Text))
                    ep.Deepth = int.Parse(txtDeep.Text);
                ep.Material = txtMaterial.Text;
                if (!string.IsNullOrEmpty(txtPrice.Text))
                    ep.Price = double.Parse(txtPrice.Text);
                if (!string.IsNullOrEmpty(txtPriceIn.Text))
                    ep.PurchasePrice = double.Parse(txtPriceIn.Text);
                if (!string.IsNullOrEmpty(txtQty.Text))
                    ep.Qty = int.Parse(txtQty.Text);
                ep.SupplierName = Utility.GetSelectedText(ddlSupplier);
                ep.Location = Utility.GetSelectedText(ddlLocation);
                ep.Remark = txtRemark.Text;
                if (!string.IsNullOrEmpty(filePic.FileName))
                {
                    string serverFilePath = string.Empty;
                    Utility.UploadFile(filePic, "EndProductImage", SourceNo, ref serverFilePath);
                    ep.ImgPth = serverFilePath;
                }
                dal.AddEndProduct(ep);
                dal.Save();
            }
            //redirect
            if (string.IsNullOrEmpty(CloseAfter))
            {
                Response.Redirect(string.Format("productform.aspx?type=ep&id={0}&viewtype=edit", ep.EP_Id)); 
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(typeof(FinishProductEditControl), "closecreate", "javascript:closeWindow();");
            }
        }
	}
}