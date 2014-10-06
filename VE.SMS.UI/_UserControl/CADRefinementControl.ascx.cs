using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using VE.SMS.DAL;
using VE.SMS.Common;

namespace VE.SMS.UI._UserControl
{
	public partial class CADRefinementControl : BaseUserControl
	{
		public override bool Editable
		{
			get { return this.btnCreateCADRefinement.Visible; }
			set { this.btnCreateCADRefinement.Visible = value; }
		}
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		class RefineComparer : IEqualityComparer<Refine>
		{
			public bool Equals(Refine x, Refine y)
			{
				return x.Refine_Id == y.Refine_Id;
			}

			public int GetHashCode(Refine obj)
			{
				return base.GetHashCode();
			}
		}
		public override void BindControl()
		{
			RefineDAL dal = new RefineDAL();
			var result = dal.GetRefineBySource(SourceType, SourceNo);

            string enqNo = string.Empty;
            List<Refine> refines2 = new List<Refine>();
            Order ord = new Order();
            if (string.Equals(SourceType, SysConst.SourceTypeEnquiry, StringComparison.OrdinalIgnoreCase))
            {
                ord = new OrderDAL().GetOrderByEnq(SourceNo);
                if (ord != null)
                {
                    refines2 = dal.GetRefineBySource(SysConst.SourceTypeOrder,ord.Order_No);
                }
            }
            else if (string.Equals(SourceType, SysConst.SourceTypeOrder, StringComparison.OrdinalIgnoreCase))
            {
                ord = new OrderDAL().GetOrderByNo(SourceNo);
                if (!string.IsNullOrEmpty(ord.EnqNo))
                {
                    var enq = new EnquiryDAL().GetEnquiryByNo(ord.EnqNo);
                    refines2 = dal.GetRefineByEnq(enq.Enquiry_No);
                }
            }
			result.AddRange(refines2);
			result = result.Distinct(new RefineComparer()).OrderBy(r=>r.Refine_No).ToList();
			Utility.BindDataToRepeater(rpRefinement, result);
		}

		protected void btnCreateCADRefinement_Click(object sender, EventArgs e)
		{
			//get no
			SeedDAL sdal = new SeedDAL();
			string no = sdal.GetNoByTableName(SysConst.TableRefine, SysConst.SuffixRefine);
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
			string enqNo = string.Empty;

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
				enqNo = SourceNo;
                //update enq status
                enq.Status = "申请CAD细化";
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
				enqNo = so.EnqNo;
                //update enq status
                so.Status = "申请CAD细化";
                soDAL.Save();
			}
			//new refine
			RefineDAL dal = new RefineDAL();
			Refine refine = new Refine()
			{
				Refine_No = no,
				Status = FirstStatusConsts.Refine,
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
				EnqNo = enqNo
			};
			dal.AddRefine(refine);
			dal.Save();

			int refid = refine.Refine_Id;
			string refno = refine.Refine_No;
			string url = Page.ResolveUrl(string.Format("~/RefineForm.aspx?refid={0}&refno={1}&sourcetype={2}&sourceno={3}", refid, refno, SourceType, SourceNo));
			string script = string.Format("<script>window.open('{0}')</script>", url);
			Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "createrefine", script);
			BindControl();
			SetFocus(btnCreateCADRefinement);
		}

		protected void rpRefinement_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Refine refine = e.Item.DataItem as Refine;
				RefineItemDAL dal = new RefineItemDAL();
				var refineItem = dal.GetRefineItemByRefineId(refine.Refine_Id).OrderByDescending(i => i.RefineItemDate).FirstOrDefault();
				if (refineItem != null)
				{
					HyperLink lnkLatestFile = e.Item.FindControl("lnkLatestFile") as HyperLink;
					lnkLatestFile.Text = refineItem.RefineFileName;
					lnkLatestFile.NavigateUrl = Page.ResolveUrl(refineItem.RefineFilePath); 
				}
			}
		}
	}
}