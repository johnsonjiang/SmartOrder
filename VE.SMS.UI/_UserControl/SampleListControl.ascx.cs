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
	public partial class SampleListControl : BaseUserControl
	{

        class SampleComparer : IEqualityComparer<Sample>
        {

            public bool Equals(Sample x, Sample y)
            {
                return string.Equals(x.MaterialCode ,y.MaterialCode);
            }

            public int GetHashCode(Sample obj)
            {
                return base.GetHashCode();
            }
        }
        class SampleNameComparer : IEqualityComparer<Sample>
        {

            public bool Equals(Sample x, Sample y)
            {
                return string.Equals(x.MaterialName, y.MaterialName);
            }

            public int GetHashCode(Sample obj)
            {
                return base.GetHashCode();
            }
        }
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                Utility.BindDataToDropdown(ddlSupplier, Utility.GetSupplierNameList(true));
                Utility.BindDataToDropdown(ddlColor, Utility.GetColorList(true));
                Utility.BindDataToDropdown(ddlLocation, Utility.GetLookupList("样品位置", true));
                Utility.BindDataToDropdown(ddlTexure, Utility.GetLookupList("纹理", true));
                var dal = new SampleDAL();
                var samples = dal.GetAllSamples();
                var productCodes = samples.Distinct(new SampleComparer()).ToList();
                productCodes.Insert(0, new Sample() { MaterialCode = string.Empty, MaterialName = string.Empty });
                ddlProductCode.DataSource = productCodes;
                ddlProductCode.DataTextField = "MaterialCode";
                ddlProductCode.DataValueField = "MaterialCode";
                ddlProductCode.DataBind();

                var productNames = samples.Distinct(new SampleNameComparer()).ToList();
                productNames.Insert(0, new Sample() { MaterialName = string.Empty, MaterialCode = string.Empty });
                ddlProductName.DataSource = productNames;
                ddlProductName.DataTextField = "MaterialName";
                ddlProductName.DataValueField = "MaterialName";
                ddlProductName.DataBind();

                samples.Insert(0, new Sample() { SampleCode = string.Empty });
                ddlSampleCode.DataSource = samples;
                ddlSampleCode.DataTextField = "SampleCode";
                ddlSampleCode.DataValueField = "SampleCode";
                ddlSampleCode.DataBind();

                BindControl();
            }
		}

        public override void BindControl()
        {
            var result = GetSampleList();
            Utility.BindDataToRepeater(rpProductList, result);
        }

        private List<Sample> GetSampleList()
        {
            SampleDAL dal = new SampleDAL();
            var result = dal.SearchSample(Utility.GetSelectedText(ddlProductCode),
                                            Utility.GetSelectedText(ddlProductName),
                                            Utility.GetSelectedText(ddlSampleCode),
                                            Utility.GetSelectedText(ddlSupplier),
                                            !string.IsNullOrEmpty(txtPriceMSample.Text) ? double.Parse(txtPriceMSample.Text) : -1,
                                            !string.IsNullOrEmpty(txtPriceM2Sample.Text) ? double.Parse(txtPriceM2Sample.Text) : -1,
                                            Utility.GetSelectedText(ddlColor),
                                            Utility.GetSelectedText(ddlTexure),
                                            txtAliasSample.Text,
                                            Utility.GetSelectedText(ddlLocation));
            return result;
        }

        protected void btnSearchSample_Click(object sender, EventArgs e)
        {
            BindControl();
            SetFocus(btnSearchSample);
        }

        protected void rpProductList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            SetSorting(e);
            if (!string.IsNullOrWhiteSpace(SortOrder))
            {
                Utility.BindDataToRepeater(rpProductList, GetSampleList().Sort(string.Format("{0} {1}", e.CommandName, SortOrder)));
            }
        }
	}
}