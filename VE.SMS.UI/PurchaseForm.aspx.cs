using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VE.SMS.Common;
using System.Collections;
using VE.SMS.DAL;

namespace VE.SMS.UI
{
	public partial class PurchaseForm : BasePage
	{
        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewPurchaseForm;
            }
        }
        protected override string EditName
        {
            get
            {
                return ACLConsts.EditPurchaseForm;
            }
        }
		public string PONo { get { return GetQueryStringValue("pono"); } }
		public int POId { get { return int.Parse(GetQueryStringValue("poid")); } }

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Utility.BindDataToDropdown(ddlPurchaseStatus, Utility.GetPurchaseStatusList());
                Utility.BindDataToDropdown(ddlApplyPurchaseMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlApproveMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlMachMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlMachTableMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlPurchaseMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlSalesMan, Utility.GetUserList2(true));
				PurchaseOrderDAL dal = new PurchaseOrderDAL();
				var po = dal.GetPOByNo(PONo);
				txtPurchaseId.Text = po.Purchase_No;
				txtPurchaseCreatedDate.Text = po.CreatedDate.ToString("yyyy-MM-dd");
				txtApplyPurchaseDate.Text = po.ApplyPurchaseDate.HasValue ? po.ApplyPurchaseDate.Value.ToString("yyyy-MM-dd") : string.Empty;
				txtExpectedCompleteDate.Text = po.ExpectedCompleteDate.HasValue ? po.ExpectedCompleteDate.Value.ToString("yyyy-MM-dd") : string.Empty;
			    ddlSalesMan.SelectedValue = po.EnqOrdMan;
				ddlMachMan.SelectedValue= po.MachiningCreateMan;
                ddlPurchaseMan.SelectedValue = po.PurchaseMan;
                ddlApplyPurchaseMan.SelectedValue = po.PurchaseApplyMan;
                ddlApproveMan.SelectedValue = po.ApproveMan;
                ddlMachTableMan.SelectedValue = po.MachTableCreateMan;
				txtPurchaseSummary.Text = po.PurchaseIntro;
				//purchase content
                BindControl();
				//status
				ddlPurchaseStatus.SelectedValue = po.Status;
				//followup
				UIUtility.BindUserControl(followUpControl, SysConst.SourceTypePurchase, PONo);
			}
		}

		private void BindControl()
		{
            POItemDAL dal = new POItemDAL();
            var poItems = dal.GetPOItemByPOId(POId);
            Utility.BindDataToRepeater(rpItems, poItems);
		}

        protected void rpItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            POItemDAL dal = new POItemDAL();
            if (e.Item.ItemType == ListItemType.Header)
            {
                if (e.CommandName == "Add")
                {
                    TextBox txtIntroAdd = e.Item.FindControl("txtIntroAdd") as TextBox;
                    TextBox txtProductAdd = e.Item.FindControl("txtProductAdd") as TextBox;
                    TextBox txtCodeAdd = e.Item.FindControl("txtCodeAdd") as TextBox;
                    TextBox txtLongAdd = e.Item.FindControl("txtLongAdd") as TextBox;
                    TextBox txtWidthAdd = e.Item.FindControl("txtWidthAdd") as TextBox;
                    TextBox txtDeepAdd = e.Item.FindControl("txtDeepAdd") as TextBox;
                    TextBox txtQtyAdd = e.Item.FindControl("txtQtyAdd") as TextBox;
                    TextBox txtSquareAdd = e.Item.FindControl("txtSquareAdd") as TextBox;

                    PurchaseOrderItem item = new PurchaseOrderItem();
                    item.PO_Id = POId;
                    item.Intro = txtIntroAdd.Text;
                    item.Product_Code = txtProductAdd.Text;
                    item.Code = txtCodeAdd.Text;
                    item.Long = !string.IsNullOrEmpty(txtLongAdd.Text) ? int.Parse(txtLongAdd.Text) : 0;
                    item.Width = !string.IsNullOrEmpty(txtWidthAdd.Text) ? int.Parse(txtWidthAdd.Text) : 0;
                    item.Deepth = !string.IsNullOrEmpty(txtDeepAdd.Text) ? int.Parse(txtDeepAdd.Text) : 0;
                    item.Quantity = !string.IsNullOrEmpty(txtQtyAdd.Text) ? int.Parse(txtQtyAdd.Text) : 0;
                    item.Square = !string.IsNullOrEmpty(txtSquareAdd.Text) ? double.Parse(txtSquareAdd.Text) : 0;

                    dal.AddPOItem(item);
                    dal.Save();
                }
            }
            if (e.CommandName == "Save")
            {
                HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
                var item = dal.GetPOItemById(int.Parse(hdId.Value));
                TextBox txtIntro = e.Item.FindControl("txtIntro") as TextBox;
                TextBox txtProduct = e.Item.FindControl("txtProduct") as TextBox;
                TextBox txtCode = e.Item.FindControl("txtCode") as TextBox;
                TextBox txtLong = e.Item.FindControl("txtLong") as TextBox;
                TextBox txtWidth = e.Item.FindControl("txtWidth") as TextBox;
                TextBox txtDeep = e.Item.FindControl("txtDeep") as TextBox;
                TextBox txtQty = e.Item.FindControl("txtQty") as TextBox;
                TextBox txtSquare = e.Item.FindControl("txtSquare") as TextBox;
                TextBox txtRemark = e.Item.FindControl("txtRemark") as TextBox;

                item.Intro = txtIntro.Text;
                item.Product_Code = txtProduct.Text;
                item.Code = txtCode.Text;
                item.Long = !string.IsNullOrEmpty(txtLong.Text) ? int.Parse(txtLong.Text) : 0;
                item.Width = !string.IsNullOrEmpty(txtWidth.Text) ? int.Parse(txtWidth.Text) : 0;
                item.Deepth = !string.IsNullOrEmpty(txtDeep.Text) ? int.Parse(txtDeep.Text) : 0;
                item.Quantity = !string.IsNullOrEmpty(txtQty.Text) ? int.Parse(txtQty.Text) : 0;
                item.Square = !string.IsNullOrEmpty(txtSquare.Text) ? double.Parse(txtSquare.Text) : 0;
                dal.Save();
            }
            if (e.CommandName == "Delete")
            {
                HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
                dal.DeletePOItem(int.Parse(hdId.Value));
            }
            BindControl();
            SetFocus(source);
        }

        private Dictionary<string, double> PurchaseMap = new Dictionary<string,double>();

        protected void rpItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                PurchaseOrderItem lineItem = e.Item.DataItem as PurchaseOrderItem;
                if (lineItem != null)
                {
                    if (PurchaseMap.ContainsKey(lineItem.Product_Code))
                    {
                        PurchaseMap[lineItem.Product_Code] += lineItem.Long * lineItem.Width * lineItem.Quantity.Value;
                    }
                    else
                    {
                        PurchaseMap.Add(lineItem.Product_Code, lineItem.Long * lineItem.Width * lineItem.Quantity.Value);
                    }
                }
            }
            if (e.Item.ItemType == ListItemType.Footer)
            {
                foreach (var item in PurchaseMap)
                {
                    e.Item.Controls.Add(new Label() { Text = string.Format("{0} : {1}  ", item.Key, item.Value), CssClass="footerlabel"});
                }
            }
        }

		protected void btnSave_Click(object sender, EventArgs e)
		{
			PurchaseOrderDAL dal = new PurchaseOrderDAL();
			var po = dal.GetPOByNo(PONo);
			if (!string.IsNullOrEmpty(txtApplyPurchaseDate.Text))
			{
				po.ApplyPurchaseDate = DateTime.Parse(txtApplyPurchaseDate.Text);
			}
			if (!string.IsNullOrEmpty(txtExpectedCompleteDate.Text))
			{
				po.ExpectedCompleteDate = DateTime.Parse(txtExpectedCompleteDate.Text);
			}
            po.EnqOrdMan = Utility.GetSelectedText(ddlSalesMan);
            po.MachiningCreateMan = Utility.GetSelectedText(ddlSalesMan); 
            po.PurchaseMan = Utility.GetSelectedText(ddlPurchaseMan); 
            po.PurchaseApplyMan = Utility.GetSelectedText(ddlApplyPurchaseMan); 
            po.ApproveMan = Utility.GetSelectedText(ddlApproveMan); 
            po.MachTableCreateMan = Utility.GetSelectedText(ddlMachTableMan);
			po.PurchaseIntro = txtPurchaseSummary.Text;
            AddFollowUp(followUpControl, po.Status, Utility.GetSelectedText(ddlPurchaseStatus));
			po.Status = Utility.GetSelectedText(ddlPurchaseStatus);
			dal.Save();
			SetFocus(sender);
		}

		protected void btnChangeStatus_Click(object sender, EventArgs e)
		{
			PurchaseOrderDAL dal = new PurchaseOrderDAL();
			var po = dal.GetPOByNo(PONo);
            AddFollowUp(followUpControl, po.Status, Utility.GetSelectedText(ddlPurchaseStatus));
			po.Status = Utility.GetSelectedText(ddlPurchaseStatus);
			dal.Save();
			SetFocus(sender);
		}
	}
}