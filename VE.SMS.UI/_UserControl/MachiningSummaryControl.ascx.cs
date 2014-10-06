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
	public partial class MachiningSummaryControl : BaseUserControl
	{
		public int MachId { get { return ViewState["MachId"] == null ? 0 : Convert.ToInt32(ViewState["MachId"]); } set { ViewState["MachId"] = value; } }
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public override void BindControl()
		{
			MachSummaryDAL dal = new MachSummaryDAL();
			var result = dal.GetSummaryByMachId(MachId);
			Utility.BindDataToRepeater(rpItems, result);
		}

		protected void rpItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Header)
			{
				DropDownList ddlMachNameAdd = e.Item.FindControl("ddlMachNameAdd") as DropDownList;
				DropDownList ddlMachUnitAdd = e.Item.FindControl("ddlMachUnitAdd") as DropDownList;
				Utility.BindDataToDropdown(ddlMachNameAdd, Utility.GetMachTypeList());
				Utility.BindDataToDropdown(ddlMachUnitAdd, Utility.GetUnitTypeList());
			}
			if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				MachSummary summary = e.Item.DataItem as MachSummary;
				DropDownList ddlMachName = e.Item.FindControl("ddlMachName") as DropDownList;
				DropDownList ddlMachUnit = e.Item.FindControl("ddlMachUnit") as DropDownList;
				Utility.BindDataToDropdown(ddlMachName, Utility.GetMachTypeList());
				Utility.BindDataToDropdown(ddlMachUnit, Utility.GetUnitTypeList());

				TextBox txtMachIntro = e.Item.FindControl("txtMachIntro") as TextBox;
				TextBox txtQty = e.Item.FindControl("txtQty") as TextBox;
				TextBox txtRemark = e.Item.FindControl("txtRemark") as TextBox;
				Image imgPath = e.Item.FindControl("imgPath") as Image;

				ddlMachName.Items.FindByText(summary.MachName).Selected = true;
				ddlMachUnit.SelectedValue = summary.Unit;
				txtMachIntro.Text = summary.MachIntro;
				txtQty.Text = summary.Qty.HasValue ? summary.Qty.Value.ToString() : "0";
				txtRemark.Text = summary.Remark;
				imgPath.ImageUrl = Page.ResolveUrl(string.Format("~/_Files/MachTypeImage/{0}", summary.ImagePath));
			}
		}

		protected void rpItems_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			MachSummaryDAL dal = new MachSummaryDAL();
			MachLookupDAL lDAL = new MachLookupDAL();
			if (e.CommandName == "Add")
			{
				TextBox txtMachIntroAdd = e.Item.FindControl("txtMachIntroAdd") as TextBox;
				DropDownList ddlMachNameAdd = e.Item.FindControl("ddlMachNameAdd") as DropDownList;
				DropDownList ddlMachUnitAdd = e.Item.FindControl("ddlMachUnitAdd") as DropDownList;
				TextBox txtQtyAdd = e.Item.FindControl("txtQtyAdd") as TextBox;
				TextBox txtRemarkAdd = e.Item.FindControl("txtRemarkAdd") as TextBox;


				MachSummary summary = new MachSummary();
				summary.MachId = MachId;
				summary.MachIntro = txtMachIntroAdd.Text;
				summary.MachName = Utility.GetSelectedText(ddlMachNameAdd);
				summary.Unit = Utility.GetSelectedText(ddlMachUnitAdd);
				summary.Qty = !string.IsNullOrEmpty(txtQtyAdd.Text) ? int.Parse(txtQtyAdd.Text) : 0;
				summary.Remark = txtRemarkAdd.Text;
				summary.ImagePath = lDAL.GetMachLookupById(int.Parse(Utility.GetSelectedValue(ddlMachNameAdd))).MachIdentity;
				dal.AddMachSummary(summary);
				dal.Save();
			}
			else if (e.CommandName == "Save")
			{
				HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
				MachSummary summary = dal.GetSummaryById(int.Parse(hdId.Value));

				TextBox txtMachIntro = e.Item.FindControl("txtMachIntro") as TextBox;
				DropDownList ddlMachName = e.Item.FindControl("ddlMachName") as DropDownList;
				DropDownList ddlMachUnit = e.Item.FindControl("ddlMachUnit") as DropDownList;
				TextBox txtQty = e.Item.FindControl("txtQty") as TextBox;
				TextBox txtRemark = e.Item.FindControl("txtRemark") as TextBox;

				summary.MachIntro = txtMachIntro.Text;
				summary.MachName = Utility.GetSelectedText(ddlMachName);
				summary.Unit = Utility.GetSelectedText(ddlMachUnit);
				summary.Qty = !string.IsNullOrEmpty(txtQty.Text) ? int.Parse(txtQty.Text) : 0;
				summary.Remark = txtRemark.Text;
				summary.ImagePath = lDAL.GetMachLookupById(int.Parse(Utility.GetSelectedValue(ddlMachName))).MachIdentity;

				dal.Save();
			}
			else if (e.CommandName == "Delete")
			{
				HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
				dal.DeleteSummary(int.Parse(hdId.Value));
			}

			BindControl();
			SetFocus(btnLoc);
		}
	}
}