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
	public partial class SettlementControl : BaseUserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public override void BindControl()
		{
            SettlementDAL dal = new SettlementDAL();
            var sts = dal.GetSettlementByOrderNo(SourceNo);
            Utility.BindDataToRepeater(rpItems, sts);
		}

		protected void btnSettlement_Click(object sender, EventArgs e)
		{
            //get no
            SeedDAL sdal = new SeedDAL();
            string no = sdal.GetNoByTableName(SysConst.TableSettlement, SysConst.SuffixSettlement);

            string companyName = string.Empty;
            string contact = string.Empty;
            string address = string.Empty;
            string email = string.Empty;
            string qq = string.Empty;
            string phone1 = string.Empty;
            string phone2 = string.Empty;
            string other = string.Empty;
            
            OrderDAL soDAL = new OrderDAL();
            var so = soDAL.GetOrderByNo(SourceNo);

            companyName = so.CustomerCompanyName;
            contact = so.CustomerContactName;
            address = so.CustomerAddress;
            email = so.CustomerEmail;
            qq = so.CustomerQQ;
            phone1 = so.CustomerPhone1;
            phone2 = so.CustomerPhone2;
            other = so.CustomerOthers;
            
            //new refine
            SettlementDAL dal = new SettlementDAL();
            Settlement st = new Settlement()
            {
                St_No = no,
                Status = FirstStatusConsts.Settlement,
                SourceType = SourceType,
                SourceNo = SourceNo,
                CreatedDate = DateTime.Now,
                CustomerCompanyName = companyName,
                CustomerContactName = contact,
                CustomerAddress = address,
                CustomerEmail = email,
                CustomerQQ = qq,
                CustomerPhone1 = phone1,
                CustomerPhone2 = phone2,
                CustomerOthers = other
            };
            dal.AddSettlement(st);
            dal.Save();

            int stid = st.St_Id;
            string stno = st.St_No;
            string url = Page.ResolveUrl(string.Format("~/SettlementForm.aspx?stid={0}&stno={1}&sourcetype={2}&sourceno={3}", stid, stno, SysConst.SourceTypeOrder, SourceNo));
            string script = string.Format("<script>window.open('{0}')</script>", url);
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "createsettle", script);
            BindControl();
            SetFocus(btnSettlement);
		}

        private double TotalAmount;
        private double FirstAmount;
        private double ReceivedAmount;
        private double EndAmount;
        protected void rpItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Settlement settle = e.Item.DataItem as Settlement;
                TotalAmount += settle.TotalAmount.HasValue ? settle.TotalAmount.Value : 0;
                FirstAmount += settle.FirstAmount.HasValue ? settle.FirstAmount.Value : 0;
                ReceivedAmount += settle.AmountReceived.HasValue ? settle.AmountReceived.Value:0;
                EndAmount += (settle.TotalAmount.HasValue ? settle.TotalAmount.Value : 0) - (settle.AmountReceived.HasValue ? settle.AmountReceived.Value:0);
            }
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblTotalAmount = e.Item.FindControl("lblTotalAmount") as Label;
                Label lblFirstAmount = e.Item.FindControl("lblFirstAmount") as Label;
                Label lblReceivedAmount = e.Item.FindControl("lblReceivedAmount") as Label;
                Label lblEnd = e.Item.FindControl("lblEnd") as Label;
                lblTotalAmount.Text = TotalAmount.ToString();
                lblFirstAmount.Text = FirstAmount.ToString();
                lblReceivedAmount.Text = ReceivedAmount.ToString();
                lblEnd.Text = EndAmount.ToString();
            }
        }
	}
}