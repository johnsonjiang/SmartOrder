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
	public partial class CustomerUserControl : BaseUserControl
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater();
            }
        }

        public void BindRepeater()
        {
            CustomerDAL dal = new CustomerDAL();
            Utility.BindDataToRepeater(rpCustomer, dal.GetAllCustomer());
        }

        protected void rpCustomer_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                if (e.Item.ItemType == ListItemType.Header)
                {
                    TextBox txtCustomerCompanyNameAdd = e.Item.FindControl("txtCustomerCompanyNameAdd") as TextBox;
                    TextBox txtContactNameAdd = e.Item.FindControl("txtContactNameAdd") as TextBox;
                    TextBox txtAddressAdd = e.Item.FindControl("txtAddressAdd") as TextBox;
                    TextBox txtEmailAdd = e.Item.FindControl("txtEmailAdd") as TextBox;
                    TextBox txtPhone1Add = e.Item.FindControl("txtPhone1Add") as TextBox;
                    TextBox txtPhone2Add = e.Item.FindControl("txtPhone2Add") as TextBox;
                    TextBox txtQQAdd = e.Item.FindControl("txtQQAdd") as TextBox;
                    TextBox txtOthersAdd = e.Item.FindControl("txtOthersAdd") as TextBox;

                    CustomerDAL dal = new CustomerDAL();
                    Customer customer = new Customer()
                    {
                        CustomerCompanyName = txtCustomerCompanyNameAdd.Text,
                        ContactName = txtContactNameAdd.Text,
                        Address = txtAddressAdd.Text,
                        Email = txtEmailAdd.Text,
                        Phone1 = txtPhone1Add.Text,
                        Phone2 = txtPhone2Add.Text,
                        QQ = txtQQAdd.Text,
                        CustomerOthers = txtOthersAdd.Text
                    };
                    dal.AddCustomer(customer);
                    dal.Save();
                }
            }
            if (e.CommandName == "Delete")
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hfId = e.Item.FindControl("hfId") as HiddenField;
                    CustomerDAL dal = new CustomerDAL();
                    dal.DeleteCustomer(int.Parse(hfId.Value));
                }
            }
            if (e.CommandName == "Save")
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    TextBox txtCustomerCompanyName = e.Item.FindControl("txtCustomerCompanyName") as TextBox;
                    TextBox txtContactName = e.Item.FindControl("txtContactName") as TextBox;
                    TextBox txtAddress = e.Item.FindControl("txtAddress") as TextBox;
                    TextBox txtEmail = e.Item.FindControl("txtEmail") as TextBox;
                    TextBox txtPhone1 = e.Item.FindControl("txtPhone1") as TextBox;
                    TextBox txtPhone2 = e.Item.FindControl("txtPhone2") as TextBox;
                    TextBox txtQQ = e.Item.FindControl("txtQQ") as TextBox;
                    TextBox txtOthers = e.Item.FindControl("txtOthers") as TextBox;

                    HiddenField hfId = e.Item.FindControl("hfId") as HiddenField;
                    CustomerDAL dal = new CustomerDAL();
                    var customer = dal.GetCustomerById(int.Parse(hfId.Value));
                    customer.CustomerCompanyName = txtCustomerCompanyName.Text;
                    customer.ContactName = txtContactName.Text;
                    customer.Address = txtAddress.Text;
                    customer.Email = txtEmail.Text;
                    customer.Phone1 = txtPhone1.Text;
                    customer.Phone2 = txtPhone2.Text;
                    customer.QQ = txtQQ.Text;
                    customer.CustomerOthers = txtOthers.Text;
                    dal.Save();
                }
            }
            BindRepeater();
            SetFocus(source);
        }
	}
}