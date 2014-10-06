using System;
using System.Collections;
using VE.SMS.Common;
using VE.SMS.DAL;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace VE.SMS.UI._UserControl
{
    public partial class HuangliaoProductLineItemControl : BaseUserControl
    {
        private string Code { get { return ViewState["Code"].ToString(); } set { ViewState["Code"] = value; } }
        private string ProductName { get { return ViewState["Name"].ToString(); } set { ViewState["Name"] = value; } }
        private string HuangCode { get { return ViewState["HuangCode"].ToString(); } set { ViewState["HuangCode"] = value; } }
        private string JiaCode { get { return ViewState["JiaCode"].ToString(); } set { ViewState["JiaCode"] = value; } }
        private string PianCode { get { return ViewState["PianCode"].ToString(); } set { ViewState["PianCode"] = value; } }
        private string Location { get { return ViewState["Location"].ToString(); } set { ViewState["Location"] = value; } }
        private string Color { get { return ViewState["Color"].ToString(); } set { ViewState["Color"] = value; } }
        private string Texure { get { return ViewState["Texure"].ToString(); } set { ViewState["Texure"] = value; } }
        private string Supplier { get { return ViewState["Supplier"].ToString(); } set { ViewState["Supplier"] = value; } }
        private int Long { get { return Convert.ToInt32(ViewState["Long"]); } set { ViewState["Long"] = value; } }
        private int Width { get { return Convert.ToInt32(ViewState["Width"]); } set { ViewState["Width"] = value; } }
        private int Deep { get { return Convert.ToInt32(ViewState["Deep"]); } set { ViewState["Deep"] = value; } }
        private string Alias { get { return ViewState["Alias"].ToString(); } set { ViewState["Alias"] = value; } }
        private double PriceM { get { return Convert.ToInt32(ViewState["PriceM"]); } set { ViewState["PriceM"] = value; } }
        private double PriceM2 { get { return Convert.ToInt32(ViewState["PriceM2"]); } set { ViewState["PriceM2"] = value; } }

        public void SetValue(string code,
                            string name,
                            string huangCode,
                            string jiaCode,
                            string pianCode,
                            string location,
                            string color,
                            string texure,
                            string supplier,
                            int pLong,
                            int pWidth,
                            int pDeep,
                            double priceM,
                            double priceM2)
        {
            Code = code;
            ProductName = name;
            HuangCode = huangCode;
            JiaCode = jiaCode;
            PianCode = pianCode;
            Location = location;
            Color = color;
            Texure = texure;
            Supplier = supplier;
            Long = pLong;
            Width = pWidth;
            Deep = pDeep;
            PriceM = priceM;
            PriceM2 = priceM2;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void BindControl()
        {
            var products = GetProductList();
            Utility.BindDataToRepeater(rpProductList, products);
        }

        private List<Proce_GetProductByHuang_Result> GetProductList()
        {
            ProductDAL dal = new ProductDAL();
            var products = dal.GetProductSummaryByHuang(Code,
                                            Name,
                                            HuangCode,
                                            JiaCode,
                                            PianCode,
                                            Location,
                                            Color,
                                            Texure,
                                            Supplier,
                                            Long,
                                            Width,
                                            Deep,
                                            PriceM,
                                            PriceM2
                                           );
            return products;
        }

        protected void rpProductList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                ProductDAL dal = new ProductDAL();
                var products = dal.GetProductSummaryByHuang(Code,
                                                Name,
                                                HuangCode,
                                                JiaCode,
                                                PianCode,
                                                Location,
                                                Color,
                                                Texure,
                                                Supplier,
                                                Long,
                                                Width,
                                                Deep,
                                                PriceM,
                                                PriceM2
                                               );
                var qty = products.Sum(q => q.QuantityM2).Value;
                var amount = products.Sum(a => a.PriceM2 * a.QuantityM2).Value;
                var lblTotalSquare = e.Item.FindControl("lblTotalSquare") as Label;
                var lblTotalAmount = e.Item.FindControl("lblTotalAmount") as Label;
                lblTotalSquare.Text = Utility.Round(qty).ToString();
                lblTotalAmount.Text = Utility.Round(amount).ToString();
            }
        }

        protected void Sort_Click(object sender, EventArgs e)
        {
            SetSorting(sender);
            if (!string.IsNullOrWhiteSpace(SortOrder))
            {
                Utility.BindDataToRepeater(rpProductList, GetProductList().Sort(string.Format("{0} {1}", (sender as LinkButton).CommandName, SortOrder)));
            }
        }
    }
}