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
	public partial class SampleControl : BaseUserControl
	{
		public bool IsSampleProvidedToCustomer { get { return this.chkToCustomer.Checked; } }
		public bool IsSampleFromCustomer { get { return this.chkSampleFromCustomer.Checked; } }

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public void SetValue(bool sampleTo, bool sampleFrom)
		{
			this.chkSampleFromCustomer.Checked = sampleFrom;
			this.chkToCustomer.Checked = sampleTo;
            SetFromCustomerVisible();
            SetToCustomerVisible();
		}

		public override void BindControl()
		{
            SampleDAL sampleDAL = new SampleDAL();
            var samples = sampleDAL.GetAllSamples();
            List<NameValueItem> sampleList = new List<NameValueItem>();
            foreach (var item in samples)
	        {
		        sampleList.Add(new NameValueItem(){Name=item.SampleCode + "/" + item.MaterialName, Value=item.SampleCode});
	        }
            Utility.BindDataToDropdown(ddlProductFrom, sampleList);
            Utility.BindDataToDropdown(ddlProduct, sampleList);

			SampleProvidDAL dal = new SampleProvidDAL();
			var list = dal.GetSampleBySource(SourceType, SourceNo);
			this.rpSampleFromCustomer.DataSource = list.Where(l => l.SampleDirection == SysConst.SampleDirectionFrom);
			this.rpSampleFromCustomer.DataBind();
			this.rpSampleToCustomer.DataSource = list.Where(l => l.SampleDirection == SysConst.SampleDirectionTo);
			this.rpSampleToCustomer.DataBind();
		}

		protected void btnAddToCustomer_Click(object sender, EventArgs e)
		{
			SampleProvid sample = new SampleProvid() 
			{ 
				CreatedAt = DateTime.Now,
				CreatedBy = SMSContext.Current.User.UserName,
				SampleDirection = SysConst.SampleDirectionTo,
				SampleIntro = txtToCustomer.Text,
				SampleName = ddlProduct.SelectedItem.Text,
				SourceNo = SourceNo,
				SourceType = SourceType
			};
			SampleProvidDAL dal = new SampleProvidDAL();
			dal.AddSample(sample);
			dal.Save();
            BindControl();
            SetFocus(sender);
		}

        protected void btnAddSampleFromCustomer_Click(object sender, EventArgs e)
        {
            SampleProvid sample = new SampleProvid()
            {
                CreatedAt = DateTime.Now,
                CreatedBy = SMSContext.Current.User.UserName,
                SampleDirection = SysConst.SampleDirectionFrom,
                SampleIntro = txtSampleFromCustomerIntro.Text,
                SampleName = ddlProductFrom.SelectedItem.Text,
                SourceNo = SourceNo,
                SourceType = SourceType
            };
            SampleProvidDAL dal = new SampleProvidDAL();
            dal.AddSample(sample);
            dal.Save();
            BindControl();
            SetFocus(sender);
        }

        protected void chkToCustomer_CheckedChanged(object sender, EventArgs e)
        {
            SetToCustomerVisible();
            SetFocus(sender);
        }

        private void SetToCustomerVisible()
        {
            pnlOA.Visible = chkToCustomer.Checked;
            pnlOB.Visible = chkToCustomer.Checked;
            pnlOC.Visible = chkToCustomer.Checked;
            pnlOG.Visible = chkToCustomer.Checked;
        }

        protected void chkSampleFromCustomer_CheckedChanged(object sender, EventArgs e)
        {
            SetFromCustomerVisible();
            SetFocus(sender);
        }

        private void SetFromCustomerVisible()
        {
            pnlOD.Visible = chkSampleFromCustomer.Checked;
            pnlOE.Visible = chkSampleFromCustomer.Checked;
            pnlOF.Visible = chkSampleFromCustomer.Checked;
            pnlOH.Visible = chkSampleFromCustomer.Checked;
        }
	}
}