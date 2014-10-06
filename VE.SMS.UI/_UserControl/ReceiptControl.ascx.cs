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
	public partial class ReceiptControl : BaseUserControl
	{
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public override void BindControl()
        {
            ReceiptDAL dal = new ReceiptDAL();
            Utility.BindDataToRepeater(rpItems, dal.GetReceiptBySource(SourceType, SourceNo));
        }

        protected void rpItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                TextBox txtReceiptDate = e.Item.FindControl("txtReceiptDate") as TextBox;
                TextBox txtReceiptAmount = e.Item.FindControl("txtReceiptAmount") as TextBox;
                TextBox txtReceiptMan = e.Item.FindControl("txtReceiptMan") as TextBox;
                TextBox txtRemark = e.Item.FindControl("txtRemark") as TextBox;
                Receipt receipt = new Receipt()
                {
                    Man = txtReceiptMan.Text,
                    ReceivedAmount = !string.IsNullOrEmpty(txtReceiptAmount.Text) ? double.Parse(txtReceiptAmount.Text) : 0,
                    ReceivedDate = !string.IsNullOrEmpty(txtReceiptDate.Text) ? DateTime.Parse(txtReceiptDate.Text) : DateTime.Now,
                    Remark = txtRemark.Text,
                    SourceNo = SourceNo,
                    SourceType = SourceType
                };
                ReceiptDAL dal = new ReceiptDAL();
                dal.Add(receipt);
                dal.Save();
                BindControl();
                SetFocus(btnFocus);
            }
        }
        private double TotalAmount;

        protected void rpItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var receipt = e.Item.DataItem as Receipt;
                TotalAmount += receipt.ReceivedAmount.HasValue ? receipt.ReceivedAmount.Value : 0;
            }
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblTotalAmount = e.Item.FindControl("lblTotalAmount") as Label;
                lblTotalAmount.Text = TotalAmount.ToString();
            }
        }
	}
}