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
	public partial class MachiningInstallUserControl : BaseUserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			BindControl();
		}

		public void BindControl()
		{
			MachLookupDAL dal = new MachLookupDAL();
			Utility.BindDataToRepeater(rpMachiningInstall,dal.GetAllMach());
		}

        protected void rpMachiningInstall_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            MachLookupDAL dal = new MachLookupDAL();
            if (e.CommandName == "Add")
            {
                var txtCodeAdd = e.Item.FindControl("txtCodeAdd") as TextBox;
                var txtNameAdd = e.Item.FindControl("txtNameAdd") as TextBox;
                var txtPriceMAdd = e.Item.FindControl("txtPriceMAdd") as TextBox;
                var txtPriceM2Add = e.Item.FindControl("txtPriceM2Add") as TextBox;
                var txtPriceOtherAdd = e.Item.FindControl("txtPriceOtherAdd") as TextBox;
                var txtMachIdentityAdd = e.Item.FindControl("txtMachIdentityAdd") as TextBox;
                var txtRemarkAdd = e.Item.FindControl("txtRemarkAdd") as TextBox;

                var machLookup = new MachLookUp();
                machLookup.Code = txtCodeAdd.Text;
                machLookup.IdentityImgPath = string.Empty;
                machLookup.Intro = txtRemarkAdd.Text;
                machLookup.IsActive = true;
                machLookup.MachIdentity = txtMachIdentityAdd.Text;
                machLookup.Name = txtNameAdd.Text;
                machLookup.PriceM = double.Parse(txtPriceMAdd.Text);
                machLookup.PriceM2 = double.Parse(txtPriceM2Add.Text);
                machLookup.PriceOther = double.Parse(txtPriceOtherAdd.Text);

                dal.AddMachLookup(machLookup);
                dal.Save();
            }
            else if (e.CommandName == "Save")
            {
                var hdId = e.Item.FindControl("hdId") as HiddenField;
                var machLookup = dal.GetMachLookupById(int.Parse(hdId.Value));
                machLookup.PriceM = double.Parse((e.Item.FindControl("txtPriceM") as TextBox).Text);
                machLookup.PriceM2 = double.Parse((e.Item.FindControl("txtPriceM2") as TextBox).Text);
                machLookup.PriceOther = double.Parse((e.Item.FindControl("txtPriceOther") as TextBox).Text);
                machLookup.MachIdentity = (e.Item.FindControl("txtMachIdentity") as TextBox).Text;
                machLookup.Intro = (e.Item.FindControl("txtRemark") as TextBox).Text;
                dal.Save();
            }
            else if (e.CommandName == "Delete")
            {
                var hdId = e.Item.FindControl("hdId") as HiddenField;
                dal.DeleteMachLookup(int.Parse(hdId.Value));
            }
            BindControl();
        }
	}
}