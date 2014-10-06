using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VE.SMS.DAL;

namespace VE.SMS.UI._UserControl
{
	public partial class CustomerInfoControl : BaseUserControl
	{
        public string CompanyName
        {
            get { return this.txtCustomerCompanyName.Text; }
            set { this.txtCustomerCompanyName.Text = value; }
        }
        public string ContactName
        {
            get { return this.txtContactName.Text; }
            set { this.txtContactName.Text = value; }
        }
        public string Address
        {
            get { return this.txtCustomerAddress.Text; }
            set { this.txtCustomerAddress.Text = value; }
        }
        public string Email
        {
            get { return this.txtEmail.Text; }
            set { this.txtEmail.Text = value; }
        }
        public string QQ
        {
            get { return this.txtQQ.Text; }
            set { this.txtQQ.Text = value; }
        }
        public string Phone1
        {
            get { return this.txtPhone1.Text; }
            set { this.txtPhone1.Text = value; }
        }
        public string Phone2
        {
            get { return this.txtPhone2.Text; }
            set { this.txtPhone2.Text = value; }
        }
        public string Other
        {
            get { return this.txtOther.Text; }
            set { this.txtOther.Text = value; }
        }


        public void SetValue(string company, string contact, string add, string email, string qq, string phone1, string phone2, string other)
        {
            this.txtContactName.Text = contact;
            this.txtCustomerAddress.Text = add;
            this.txtCustomerCompanyName.Text = company;
            this.txtEmail.Text = email;
            this.txtOther.Text = other;
            this.txtPhone1.Text = phone1;
            this.txtPhone2.Text = phone2;
            this.txtQQ.Text = qq;
        }
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContactName.Text)
                || (string.IsNullOrWhiteSpace(txtQQ.Text) && string.IsNullOrWhiteSpace(txtEmail.Text) && string.IsNullOrWhiteSpace(txtPhone1.Text) && string.IsNullOrWhiteSpace(txtPhone2.Text)))
            {
                return;
            }
            CustomerDAL dal = new CustomerDAL();
            var customers = dal.GetAllCustomer();
            var customer = from c in customers
                           where
                            (
                            c.ContactName == ContactName
                            )
                            &&
                            (c.Email == Email
                            ||
                            string.IsNullOrEmpty(Email)
                            )
                            &&
                            (c.QQ == QQ
                            ||
                            string.IsNullOrEmpty(QQ)
                            )
                            &&
                            (c.Phone1 == Phone1
                            ||
                            string.IsNullOrEmpty(Phone1)
                            )
                            &&
                            (c.Phone2 == Phone2
                            ||
                            string.IsNullOrEmpty(Phone2)
                            )
                           select  c;
            if (customer != null && customer.Count() > 0)
            {
                var cust = customer.ToList()[0];
                CompanyName = cust.CustomerCompanyName;
                ContactName = cust.ContactName;
                Address = cust.Address;
                Email = cust.Email;
                QQ = cust.QQ;
                Phone1 = cust.Phone1;
                Phone2 = cust.Phone2;
                Other = cust.CustomerOthers;
            }
        }

        public void Save()
        {
            if (string.IsNullOrWhiteSpace(txtContactName.Text)
                ||(string.IsNullOrWhiteSpace(txtQQ.Text) && string.IsNullOrWhiteSpace(txtEmail.Text) && string.IsNullOrWhiteSpace(txtPhone1.Text) && string.IsNullOrWhiteSpace(txtPhone2.Text)))
            {
                return;
            }
            CustomerDAL dal = new CustomerDAL();
            var customers = dal.GetAllCustomer();
            var customer = from c in customers
                           where
                            (
                            c.ContactName == ContactName
                            )
                            &&
                            (c.Email == Email
                            ||
                            string.IsNullOrEmpty(Email)
                            )
                            &&
                            (c.QQ == QQ
                            ||
                            string.IsNullOrEmpty(QQ)
                            )
                            &&
                            (c.Phone1 == Phone1
                            ||
                            string.IsNullOrEmpty(Phone1)
                            )
                            &&
                            (c.Phone2 == Phone2
                            ||
                            string.IsNullOrEmpty(Phone2)
                            )
                           select c;
            if (customer != null && customer.Count() > 0)
            {
                return;
            }
            Customer cust = new Customer() 
            { 
                Address = Address,
                ContactName = ContactName,
                CustomerCompanyName = CompanyName,
                CustomerOthers = Other,
                Email = Email,
                Phone1 = Phone1,
                Phone2 = Phone2,
                QQ = QQ
            };
            dal.AddCustomer(cust);
            dal.Save();
        }
	}
}