using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using VE.SMS.DAL;
using VE.SMS.Common;
using VE.SMS.UI._UserControl;

namespace VE.SMS.UI
{
	public partial class EnquiryList : BasePage
	{
		protected override string ViewName
		{
			get
			{
				return ACLConsts.ViewEnquiryList;
			}
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Utility.BindDataToDropdown(ddlEnqStatus, Utility.GetEnquiryStatusList(true));
				Utility.BindDataToDropdown(ddlEnqMan, Utility.GetUserList2(true));
				Utility.BindDataToDropdown(ddlCompany, Utility.GetCompanyList(true));
				Utility.BindDataToDropdown(ddlContact, Utility.GetContactList(true));
				Utility.BindDataToRepeater(rpEnqList, GetEnquiryList());
			}
		}

		protected void rpEnqList_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Enquiry enq = e.Item.DataItem as Enquiry;
				RefineDAL rDal = new RefineDAL();
				SurveyDAL sDal = new SurveyDAL();
				QuotationDAL qDal = new QuotationDAL();

				Repeater rpRefinement = e.Item.FindControl("rpRefinement") as Repeater;
				Utility.BindDataToRepeater(rpRefinement, rDal.GetRefineBySource(SysConst.SourceTypeEnquiry, enq.Enquiry_No));

				Repeater rpSurvey = e.Item.FindControl("rpSurvey") as Repeater;
				Utility.BindDataToRepeater(rpSurvey, sDal.GetSurveyBySource(enq.Enquiry_No,SysConst.SourceTypeEnquiry));

				Repeater rpQuoationa = e.Item.FindControl("rpQuoation") as Repeater;
				Utility.BindDataToRepeater(rpQuoationa, qDal.GetQuotesBySource(SysConst.SourceTypeEnquiry, enq.Enquiry_No));

				FollowUpTop3UserControl followUp = e.Item.FindControl("followUpTop3UserControl") as FollowUpTop3UserControl;
				UIUtility.BindUserControl(followUp, SysConst.SourceTypeEnquiry, ((Enquiry)e.Item.DataItem).Enquiry_No);
			}
		}

		protected void btnCreate_Click(object sender, EventArgs e)
		{
			SeedDAL sdal = new SeedDAL();
			string no = sdal.GetNoByTableName(SysConst.TableNameEnquiry, SysConst.SuffixEnquiry);
			Enquiry item = new Enquiry()
			{
				Enquiry_No = no,
				Status = FirstStatusConsts.Enquiry,
				CreatedAt = DateTime.Now,
				CreatedDate = DateTime.Now,
				CreatedBy = SMSContext.Current.User.UserName
			};
			EnquiryDAL dal = new EnquiryDAL();
			dal.AddEnquiry(item);
			dal.Save();
			int enqId = item.Enquiry_Id;
			string enqNo = item.Enquiry_No;
			Utility.AddDefault(item.Enquiry_No, SysConst.SourceTypeEnquiry, FooterConsts.Enquiry);
			string script = string.Format("<script>window.open('enquiryform.aspx?enqid={0}&enqno={1}')</script>", enqId, enqNo);
			ClientScript.RegisterClientScriptBlock(this.GetType(), "createenq", script);
		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{
			Utility.BindDataToRepeater(rpEnqList ,GetEnquiryList());
		}

		private List<Enquiry> GetEnquiryList()
		{
			string enqNo = txtEnqNo.Text;
			string companyName = Utility.GetSelectedText(ddlCompany);
			string contactName = Utility.GetSelectedText(ddlContact);
			string phone = txtPhone.Text;
			DateTime beginDate = string.IsNullOrWhiteSpace(txtBeginDate.Text) ? DateTime.MinValue : DateTime.Parse(txtBeginDate.Text);
			DateTime endDate = string.IsNullOrWhiteSpace(txtEndDate.Text) ? DateTime.MaxValue : DateTime.Parse(txtEndDate.Text);
			string status = string.Empty;
			if (ddlEnqStatus.SelectedItem != null)
			{
				status = ddlEnqStatus.SelectedItem.Text;
			}
			string enqMan = Utility.GetSelectedText(ddlEnqMan);
			EnquiryDAL dal = new EnquiryDAL();
			var enqList = dal.SearchEnquiry(
											enqNo,
											companyName,
											contactName,
											phone,
											beginDate,
											endDate,
											string.Empty,
											status,
											enqMan);
			return enqList;
		}

		protected void rpEnqList_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			if (e.CommandName == "GenerateOrder" &&(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item))
			{
				HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
				Enquiry enq = new EnquiryDAL().GetEnquiryById(int.Parse(hdId.Value));

				OrderDAL dal = new OrderDAL();
				var order = dal.GetOrderByEnq(enq.Enquiry_No);
				if (order != null)
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "generateorder",
					string.Format("<script>window.open('OrderForm.aspx?ordid={0}&ordno={1}&sourcetype=E&sourceno={2}')</script>", order.Order_Id, order.Order_No, enq.Enquiry_No));
					return;
				}


				SeedDAL sdal = new SeedDAL();
				LineItemDAL lDAL = new LineItemDAL();
				var no = sdal.GetNoByTableName(SysConst.TableOrder, SysConst.SuffixOrder);
				var enqItems = lDAL.GetLineItemsBySource(enq.Enquiry_Id, SysConst.SourceTypeEnquiry);
				
				Order ord = new Order();
				ord.SourceType = SysConst.SourceTypeEnquiry;
				ord.SourceNo = enq.Enquiry_No;
				ord.Order_No = no;
				ord.Status = FirstStatusConsts.Order;
				ord.CreatedDate = DateTime.Now;
				ord.CustomerAddress = enq.CustomerAddress;
				ord.CustomerCompanyName = enq.CustomerCompanyName;
				ord.CustomerContactName = enq.CustomerContactName;
				ord.CustomerEmail = enq.CustomerEmail;
				ord.CustomerOthers = enq.CustomerOthers;
				ord.CustomerPhone1 = enq.CustomerPhone1;
				ord.CustomerPhone2 = enq.CustomerPhone2;
				ord.CustomerQQ = enq.CustomerQQ;

				ord.IsSampleProvidedToCustomer = enq.IsSampleProvidedToCustomer;
				ord.IsCustomerProvideSample = enq.IsCustomerProvideSample;
				ord.IsCustomerProvideImage  = enq.IsCustomerProvideImage;
				ord.IsSurveyNeeded = enq.IsSurveyNeeded;
				ord.SurveyType = enq.SurveyType;
				ord.SurveyIntro = enq.SurveyIntro;
				ord.IsCADRefinementNeeded = enq.IsCADRefinementNeeded;
				ord.CADRefinementIntro = enq.CADRefinementIntro;
				ord.IsCADNeedCustomerConfirmation = enq.IsCADNeedCustomerConfirmation;
				ord.DeliveryType = enq.DeliveryType;
				ord.DeliveryIntro = enq.DeliveryIntro;
				ord.DeliveryToAddress = enq.DeliveryToAddress;
				ord.IsInstallProvided = enq.IsInstallProvided;
                ord.InstallType = string.IsNullOrEmpty(enq.InstallType) ? string.Empty : enq.InstallType; 
                
				ord.InstallIntro = enq.InstallIntro;
				ord.EnqNo = enq.Enquiry_No;
                ord.IsActive = true;
				dal.AddOrder(ord);
				dal.Save();
				//intro
				//intro
				Utility.AddDefault(ord.Order_No, SysConst.SourceTypeOrder, FooterConsts.Order);
				//item
				foreach (var item in enqItems)
				{
					LineItem newItem = new LineItem()
					{
						Intro = item.Intro,
						Name  = item.Name,
						Project = item.Project,
						Quantity = item.Quantity,
						Remark = item.Remark,
						SourceId = ord.Order_Id,
						SourceType = SysConst.SourceTypeOrder,
						Spec = item.Spec,
						Unit = item.Unit,
						UnitPrice = item.UnitPrice
					};
					lDAL.AddLineItem(newItem);
				}
				lDAL.Save();
				ClientScript.RegisterClientScriptBlock(this.GetType(), "generateorder", 
					string.Format("<script>window.open('OrderForm.aspx?ordid={0}&ordno={1}&sourcetype=E&sourceno={2}')</script>",ord.Order_Id,ord.Order_No,enq.Enquiry_No));
			}
			else if (e.CommandName == "Delete" && (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item))
			{
				HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
				new EnquiryDAL().Delete(int.Parse(hdId.Value));
                Utility.BindDataToRepeater(rpEnqList, GetEnquiryList());
			}
			else
			{
				SetSorting(e);
				if (!string.IsNullOrWhiteSpace(SortOrder))
				{
					Utility.BindDataToRepeater(rpEnqList, GetEnquiryList().Sort(string.Format("{0} {1}", e.CommandName, SortOrder)));
				} 
			}

		}
	}
}