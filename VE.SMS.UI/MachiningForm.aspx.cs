using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using VE.SMS.Common;
using VE.SMS.DAL;

namespace VE.SMS.UI
{
	public partial class MachiningForm : BasePage
	{
		public string SourceNo { get { return GetQueryStringValue("sourceno"); } }
		public string SourceType { get { return GetQueryStringValue("sourcetype"); } }
		public string MachNo { get { return GetQueryStringValue("machNo"); } }
		public int MachId { get { return int.Parse(GetQueryStringValue("machId")); } }

        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewMachiningForm;
            }
        }
        protected override string EditName
        {
            get
            {
                return ACLConsts.EditMachiningForm;
            }
        }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Utility.BindDataToDropdown(ddlMachiningStatus, Utility.GetMachiningStatusList());
                Utility.BindDataToDropdown(ddlMachCreateMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlMachTableMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlSalesMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlRefineMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlSurveyMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlMachProcessor, Utility.GetUserList2(true));

				if (!string.IsNullOrWhiteSpace(MachNo))
				{
					MachiningDAL dal = new MachiningDAL();
					var mach = dal.GetMachByNo(MachNo);

					OrderDAL sDAL = new OrderDAL();
					var order = sDAL.GetOrderByNo(SourceNo);
					lnkSource.NavigateUrl = Page.ResolveUrl(string.Format("~/OrderForm.aspx?ordno={0}&ordid={1}&sourceno={2}&sourcetype={3}", order.Order_No, order.Order_Id, order.SourceNo, order.SourceType));
					lnkSource.Text = SourceNo;

					txtCreatedDate.Text = mach.CreatedDate.ToString("yyyy-MM-dd");
					ddlMachCreateMan.SelectedValue= mach.MachCreateMan;
					ddlMachTableMan.SelectedValue= mach.ProcessCreateMan;
					ddlSalesMan.SelectedValue= mach.SalesMan;
					ddlRefineMan.SelectedValue= mach.RefineMan;
					ddlSurveyMan.SelectedValue= mach.SurveyMan;
					ddlMachProcessor.SelectedValue = mach.MachMan;
					txtApplyDate.Text = mach.ApplyDate.HasValue ? mach.ApplyDate.Value.ToString("yyyy-MM-dd") : string.Empty;
					txtExpectedCompletedDate.Text = mach.ExpectedCompleteDate.HasValue ? mach.ExpectedCompleteDate.Value.ToString("yyyy-MM-dd") : string.Empty;
					txtCompletedDate.Text = mach.CompleteDate.HasValue ? mach.CompleteDate.Value.ToString("yyyy-MM-dd") : string.Empty;
					txtExpectedDeliveryDate.Text = mach.ExpectedDeliveryDate.HasValue ? mach.ExpectedDeliveryDate.Value.ToString("yyyy-MM-dd") : string.Empty;
					txtExpectedInstallDate.Text = mach.ExpectedInstallDate.HasValue ? mach.ExpectedInstallDate.Value.ToString("yyyy-MM-dd") : string.Empty;
					txtMachiningSummary.Text = mach.MachIntro;

					//customer info
					this.customerInfoControl.SetValue(
						mach.CustomerCompanyName,
						mach.CustomerContactName,
						mach.CustomerAddress,
						mach.CustomerEmail,
						mach.CustomerQQ,
						mach.CustomerPhone1,
						mach.CustomerPhone2,
						mach.CustomerOthers);
					//history refine
					UIUtility.BindUserControl(cADRefinementControl, SysConst.SourceTypeOrder, SourceNo);
					//customer drawing
					customerDrawingControl.IsCustomerProvideImage = order.IsCustomerProvideImage;
					UIUtility.BindUserControl(customerDrawingControl, SysConst.SourceTypeOrder, order.Order_No);
					//survey
					UIUtility.BindUserControl(surveyControl, SysConst.SourceTypeOrder, SourceNo);
					//purchase
					UIUtility.BindUserControl(PurchaseControl1, SysConst.SourceTypeMaching, mach.Mach_No);
					//machining table
					MachiningLineItem1.IsRefineInstead = mach.IsRefineInstead;
					MachiningLineItem1.RefineNo = mach.RefineNo;
					MachiningLineItem1.RefineIntro = mach.InsteadIntro;
					MachiningLineItem1.OrderNo = order.Order_No;
					MachiningLineItem1.MachId = mach.Mach_Id;
					UIUtility.BindUserControl(MachiningLineItem1, SysConst.SourceTypeMaching, mach.Mach_No);

					//maching summary
					MachiningSummaryControl1.MachId = mach.Mach_Id;
					UIUtility.BindUserControl(MachiningSummaryControl1, SysConst.SourceTypeMaching, mach.Mach_No);
					//status
					ddlMachiningStatus.SelectedValue = mach.Status;
					//followup
					UIUtility.BindUserControl(followUpControl, SysConst.SourceTypeOrder, order.Order_No);
				}

			}
		}
        protected void btnChangeStatus_Click(object sender, EventArgs e)
        {
            MachiningDAL dal = new MachiningDAL();
            var mach = dal.GetMachByNo(MachNo);
            AddFollowUp(followUpControl, mach.Status, Utility.GetSelectedText(ddlMachiningStatus));
            SetFocus(btnChangeStatus);
        }
		protected void btnSave_Click(object sender, EventArgs e)
		{
			MachiningDAL dal = new MachiningDAL();
			var mach = dal.GetMachByNo(MachNo);
			//update ord
            mach.MachCreateMan = Utility.GetSelectedText(ddlMachCreateMan);
            mach.ProcessCreateMan = Utility.GetSelectedText(ddlMachTableMan);
            mach.SalesMan = Utility.GetSelectedText(ddlSalesMan); 
            mach.RefineMan = Utility.GetSelectedText(ddlRefineMan);
            mach.SurveyMan = Utility.GetSelectedText(ddlSurveyMan);
            mach.MachMan = Utility.GetSelectedText(ddlMachProcessor);
			if (!string.IsNullOrEmpty(txtApplyDate.Text))
			{
				mach.ApplyDate = DateTime.Parse(txtApplyDate.Text);
			}

			if (!string.IsNullOrEmpty(txtExpectedCompletedDate.Text))
			{
				mach.ExpectedCompleteDate = DateTime.Parse(txtExpectedCompletedDate.Text); 
			}
			if (!string.IsNullOrEmpty(txtCompletedDate.Text))
			{
				mach.CompleteDate = DateTime.Parse(txtCompletedDate.Text); 
			}
			if (!string.IsNullOrEmpty(txtExpectedDeliveryDate.Text))
			{
				mach.ExpectedDeliveryDate = DateTime.Parse(txtExpectedDeliveryDate.Text); 
			}
			if (!string.IsNullOrEmpty(txtExpectedInstallDate.Text))
			{
				mach.ExpectedInstallDate = DateTime.Parse(txtExpectedInstallDate.Text); 
			}
			mach.MachIntro = txtMachiningSummary.Text;

			mach.CustomerCompanyName = customerInfoControl.CompanyName;
			mach.CustomerContactName = customerInfoControl.ContactName;
			mach.CustomerAddress = customerInfoControl.Address;
			mach.CustomerEmail = customerInfoControl.Email;
			mach.CustomerQQ = customerInfoControl.QQ;
			mach.CustomerPhone1 = customerInfoControl.Phone1;
			mach.CustomerPhone2 = customerInfoControl.Phone2;
			mach.CustomerOthers = customerInfoControl.Other;

			mach.IsRefineInstead = MachiningLineItem1.IsRefineInstead;
			mach.RefineNo = MachiningLineItem1.RefineNo;
			mach.InsteadIntro = MachiningLineItem1.RefineIntro;
            AddFollowUp(followUpControl, mach.Status, Utility.GetSelectedText(ddlMachiningStatus));
			mach.Status = Utility.GetSelectedText(ddlMachiningStatus);
			dal.Save();
			//save new customer
			customerInfoControl.Save();
			this.SetFocus(sender);
		}
	}
}