using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VE.SMS.DAL;
using VE.SMS.Common;

namespace VE.SMS.UI._UserControl
{
	public partial class SurveyControl : BaseUserControl
	{
        public override bool Editable
        {
            get { return divOperate.Visible; }
            set { divOperate.Visible = value; }
        }
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        class SurveyComparer : IEqualityComparer<Survey>
        {
            public bool Equals(Survey x, Survey y)
            {
                return x.Survey_Id == y.Survey_Id;
            }

            public int GetHashCode(Survey obj)
            {
                return base.GetHashCode();
            }
        }
        public override void BindControl()
        {
            SurveyDAL dal = new SurveyDAL();
            var result = dal.GetSurveyBySource(SourceNo, SourceType);

            string enqNo = string.Empty;
            List<Survey> surveys2 = new List<Survey>();
            Order ord = new Order();
            if (string.Equals(SourceType, SysConst.SourceTypeEnquiry, StringComparison.OrdinalIgnoreCase))
            {
                ord = new OrderDAL().GetOrderByEnq(SourceNo);
                if (ord != null)
                {
                    surveys2 = dal.GetSurveyBySource(ord.Order_No, SysConst.SourceTypeOrder);
                }
            }
            else if (string.Equals(SourceType, SysConst.SourceTypeOrder, StringComparison.OrdinalIgnoreCase))
            {
                ord = new OrderDAL().GetOrderByNo(SourceNo);
                if (!string.IsNullOrEmpty(ord.EnqNo))
                {
                    var enq = new EnquiryDAL().GetEnquiryByNo(ord.EnqNo);
                    surveys2 = dal.GetSurveyByEnq(enq.Enquiry_No);
                }
            }
            result.AddRange(surveys2);
            result = result.Distinct(new SurveyComparer()).OrderBy(s=>s.Survey_No).ToList();
            Utility.BindDataToRepeater(rpSurveyList, result);
        }

        protected void btnCreateSurvey_Click(object sender, EventArgs e)
        {
            //get no
            SeedDAL sdal = new SeedDAL();
            string no = sdal.GetNoByTableName(SysConst.TableSurvey, SysConst.SuffixSuvey);
            //get enqordman
            string enqOrdMan = string.Empty;
            string companyName = string.Empty;
            string contact = string.Empty;
            string address = string.Empty;
            string email = string.Empty;
            string qq = string.Empty;
            string phone1 = string.Empty;
            string phone2 = string.Empty;
            string other = string.Empty;
            string surveyIntro = string.Empty;
            string enqNo = string.Empty;

            List<LineItem> items = new List<LineItem>();
            int sourceId = -1;
            if (string.Equals(SourceType, SysConst.SourceTypeEnquiry, StringComparison.OrdinalIgnoreCase))
            {
                EnquiryDAL enqDAL = new EnquiryDAL();
                var enq = enqDAL.GetEnquiryByNo(SourceNo);
                enqOrdMan = enq.EnqMan;
                companyName = enq.CustomerCompanyName;
                contact = enq.CustomerContactName;
                address = enq.CustomerAddress;
                email = enq.CustomerEmail;
                qq = enq.CustomerQQ;
                phone1 = enq.CustomerPhone1;
                phone2 = enq.CustomerPhone2;
                other = enq.CustomerOthers;
                surveyIntro = enq.SurveyIntro;
                enqNo = SourceNo;
                sourceId = enq.Enquiry_Id;
                //update enq status
                enq.Status = "申请测量";
                enqDAL.Save();
            }
            if (string.Equals(SourceType, SysConst.SourceTypeSalesOrder, StringComparison.OrdinalIgnoreCase))
            {
                OrderDAL soDAL = new OrderDAL();
                var so = soDAL.GetOrderByNo(SourceNo);
                enqOrdMan = so.OrderMan;
                companyName = so.CustomerCompanyName;
                contact = so.CustomerContactName;
                address = so.CustomerAddress;
                email = so.CustomerEmail;
                qq = so.CustomerQQ;
                phone1 = so.CustomerPhone1;
                phone2 = so.CustomerPhone2;
                other = so.CustomerOthers;
                surveyIntro = so.SurveyIntro;
                enqNo = so.EnqNo;
                sourceId = so.Order_Id;
                //update ord status
                so.Status = "申请测量";
                soDAL.Save();
            }
            //new refine
            SurveyDAL dal = new SurveyDAL();
            Survey survey = new Survey()
            {
                Survey_No = no,
                Status = FirstStatusConsts.Survey,
                EnqOrdMan = enqOrdMan,
                SourceType = SourceType,
                SourceNo = SourceNo,
                CreatedDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                CreatedBy = SMSContext.Current.User.UserName,
                CustomerCompanyName = companyName,
                CustomerContactName = contact,
                CustomerAddress = address,
                CustomerEmail = email,
                CustomerQQ = qq,
                CustomerPhone1 = phone1,
                CustomerPhone2 = phone2,
                CustomerOthers = other,
                SurveyIntro = surveyIntro,
                EnqNo = enqNo
            };
            dal.AddSurvey(survey);
            dal.Save();

            LineItemDAL lDAL = new LineItemDAL();
            items = lDAL.GetLineItemsBySource(sourceId, SourceType);
            foreach (var item in items)
            {
                LineItem target = new LineItem() 
                { 
                    Intro = item.Intro,
                    Name = item.Name,
                    OriginNo = item.OriginNo,
                    Project = item.Project,
                    Quantity = item.Quantity,
                    Remark = item.Remark,
                    SourceId = survey.Survey_Id,
                    SourceType = SysConst.SourceTypeSurvey,
                    Spec = item.Spec,
                    Unit = item.Unit,
                    UnitPrice = item.UnitPrice
                };
                lDAL.AddLineItem(target);
            }
            lDAL.Save();
            int svid = survey.Survey_Id;
            string svno = survey.Survey_No;
            string url = Page.ResolveUrl(string.Format("~/SurveyForm.aspx?svid={0}&svno={1}&sourcetype={2}&sourceno={3}", svid, svno, SourceType, SourceNo));
            string script = string.Format("<script>window.open('{0}')</script>", url);
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "createsuvey", script);
            BindControl();
            SetFocus(btnCreateSurvey);
        }

        protected void rpSurveyList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Survey survey = e.Item.DataItem as Survey;
                if (!string.IsNullOrEmpty(survey.SurveyImageName) && !string.IsNullOrEmpty(survey.SurveyImagePath))
                {
                    HyperLink lnkLatestFile = e.Item.FindControl("lnkLatestFile") as HyperLink;
                    lnkLatestFile.Text = survey.SurveyImageName;
                    lnkLatestFile.NavigateUrl = Page.ResolveUrl(survey.SurveyImagePath);
                }
            }
        }
	}
}