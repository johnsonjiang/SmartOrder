using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VE.SMS.Common;

namespace VE.SMS.UI
{
	public partial class ProductForm : BasePage
	{
        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewProductForm;
            }
        }
        protected override string EditName
        {
            get
            {
                return ACLConsts.EditProductForm;
            }
        }
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                int id = !string.IsNullOrEmpty(Request.QueryString["id"]) ? int.Parse(GetQueryStringValue("id")) : -1;
                string type = GetQueryStringValue("type");
                string closeafter = !string.IsNullOrEmpty(Request.QueryString["closeafter"]) ? Request.QueryString["closeafter"] : string.Empty;

                if (string.Equals(type,"EP", StringComparison.OrdinalIgnoreCase))
                {
                    FinishProductEditControl1.Visible = true;
                    FinishProductEditControl1.EPId = id;
                    FinishProductEditControl1.CloseAfter = closeafter;
                    FinishProductEditControl1.BindControl();
                }
                if (string.Equals(type, "S", StringComparison.OrdinalIgnoreCase))
                {
                    SampleProductEditControl1.Visible = true;
                    SampleProductEditControl1.SampleId = id;
                    SampleProductEditControl1.CloseAfter = closeafter;
                    SampleProductEditControl1.BindControl();
                }
                if (string.Equals(type, "P", StringComparison.OrdinalIgnoreCase))
                {
                    ProductInfoControl1.Visible = true;
                    ProductInfoControl1.ProductId = id;
                    ProductInfoControl1.CloseAfter = closeafter;
                    ProductInfoControl1.BindControl();
                }
            }
		}
	}
}