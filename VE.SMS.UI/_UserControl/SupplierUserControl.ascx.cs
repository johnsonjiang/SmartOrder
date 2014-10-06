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
	public partial class SupplierUserControl : BaseUserControl
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
            SupplierDAL dal = new SupplierDAL();
            Utility.BindDataToRepeater(rpSupplier, dal.GetSupplierList());
        }

        protected void rpSupplier_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                if (e.Item.ItemType == ListItemType.Header)
                {
                    TextBox txtSupplierNameAdd = e.Item.FindControl("txtSupplierNameAdd") as TextBox;
                    TextBox txtContactNameAdd = e.Item.FindControl("txtContactNameAdd") as TextBox;
                    TextBox txtPhoneAdd = e.Item.FindControl("txtPhoneAdd") as TextBox;
                    TextBox txtRemarkAdd = e.Item.FindControl("txtRemarkAdd") as TextBox;

                    SupplierDAL dal = new SupplierDAL();
                    Supplier s = new Supplier()
                    {
                        Supplier_Name = txtSupplierNameAdd.Text,
                        Supplier_ContactName = txtContactNameAdd.Text,
                        Supplier_Phone = txtPhoneAdd.Text,
                        Remark = txtRemarkAdd.Text
                    };
                    dal.AddSupplier(s);
                }
            }
            if (e.CommandName == "Delete")
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hfId = e.Item.FindControl("hfId") as HiddenField;
                    SupplierDAL dal = new SupplierDAL();
                    dal.DeleteSupplier(int.Parse(hfId.Value));
                }
            }
            if (e.CommandName == "Save")
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    TextBox txtSupplierName = e.Item.FindControl("txtSupplierName") as TextBox;
                    TextBox txtContactName = e.Item.FindControl("txtContactName") as TextBox;
                    TextBox txtPhone = e.Item.FindControl("txtPhone") as TextBox;
                    TextBox txtRemark = e.Item.FindControl("txtRemark") as TextBox;
                    HiddenField hfId = e.Item.FindControl("hfId") as HiddenField;
                    SupplierDAL dal = new SupplierDAL();
                    var supplier = dal.GetSupplierById(int.Parse(hfId.Value));
                    supplier.Supplier_Name = txtSupplierName.Text;
                    supplier.Supplier_ContactName = txtContactName.Text;
                    supplier.Supplier_Phone = txtPhone.Text;
                    supplier.Remark = txtRemark.Text;
                    dal.Save();
                }
            }
            BindRepeater();
        }
	}
}