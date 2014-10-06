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
	public partial class InstallConfigurationControl : BaseUserControl
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater();
            }
        }

        private void BindRepeater()
        {
            InstallLookupDAL dal = new InstallLookupDAL();
            Utility.BindDataToRepeater(rpMachiningInstall, dal.GetAllLookup());
        }

        protected void rpMachiningInstall_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            InstallLookupDAL dal = new InstallLookupDAL();
            if (e.CommandName == "Add")
            {
                if (e.Item.ItemType == ListItemType.Header)
                {
                    TextBox txtCodeAdd = e.Item.FindControl("txtCodeAdd") as TextBox;
                    TextBox txtNameAdd = e.Item.FindControl("txtNameAdd") as TextBox;
                    TextBox txtPriceMAdd = e.Item.FindControl("txtPriceMAdd") as TextBox;
                    TextBox txtPriceM2Add = e.Item.FindControl("txtPriceM2Add") as TextBox;
                    TextBox txtPriceOtherAdd = e.Item.FindControl("txtPriceOtherAdd") as TextBox;
                    TextBox txtRemarkAdd = e.Item.FindControl("txtRemarkAdd") as TextBox;

                    InstallLookup lookup = new InstallLookup()
                    {
                        Code = txtCodeAdd.Text,
                        Name = txtNameAdd.Text,
                        PriceM = double.Parse(txtPriceMAdd.Text),
                        PriceM2 = double.Parse(txtPriceM2Add.Text),
                        PriceOther = double.Parse(txtPriceOtherAdd.Text),
                        Intro = txtRemarkAdd.Text,
                        IsActive = true
                    };
                    dal.Add(lookup);
                    dal.Save();
                }
            }
            if (e.CommandName == "Delete")
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hfId = e.Item.FindControl("hfId") as HiddenField;
                    dal.Delete(int.Parse(hfId.Value));
                }
            }
            if (e.CommandName == "Save")
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    TextBox txtPriceM = e.Item.FindControl("txtPriceM") as TextBox;
                    TextBox txtPriceM2 = e.Item.FindControl("txtPriceM2") as TextBox;
                    TextBox txtPriceOther = e.Item.FindControl("txtPriceOther") as TextBox;
                    TextBox txtRemark = e.Item.FindControl("txtRemark") as TextBox;
                    HiddenField hfId = e.Item.FindControl("hfId") as HiddenField;
                    var lookup = dal.GetLookupById(int.Parse(hfId.Value));
                    lookup.PriceM = double.Parse(txtPriceM.Text);
                    lookup.PriceM2 = double.Parse(txtPriceM2.Text);
                    lookup.PriceOther = double.Parse(txtPriceOther.Text);
                    lookup.Intro = txtRemark.Text;
                    dal.Save();
                }
            }
            BindRepeater();
        }
	}
}