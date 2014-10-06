using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using VE.SMS.Common;
using VE.SMS.DAL;
using System.Data;
using System.Text;
using System.Threading;
using DanSilverlight.Web.MyLib;
using System.IO;

namespace VE.SMS.UI._UserControl
{
	public partial class MachiningLineItem : BaseUserControl
	{
		public bool IsRefineInstead { get { return chkRefine.Checked; } set { chkRefine.Checked = value; } }
		public string RefineNo { get { return ViewState["RefineNo"] == null ? string.Empty : ViewState["RefineNo"].ToString(); } set { ViewState["RefineNo"] = value; } }
		public string RefineIntro { get { return ViewState["RefineIntro"] == null ? string.Empty : ViewState["RefineIntro"].ToString(); } set { ViewState["RefineIntro"] = value; } }
		public string OrderNo { get { return ViewState["OrderNo"] == null ? string.Empty : ViewState["OrderNo"].ToString(); } set { ViewState["OrderNo"] = value; } }
		public int MachId { get { return ViewState["MachId"] == null ? 0 : Convert.ToInt32(ViewState["MachId"]); } set { ViewState["MachId"] = value; } }

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public override void BindControl()
		{
			if (IsRefineInstead)
			{
				ddlRefineList.Visible = true;
				txtRefineIntro.Visible = true;
				//btnSave.Visible = true;

				RefineDAL refDAL = new RefineDAL();
				var refineList = refDAL.GetRefineBySource(SysConst.SourceTypeOrder, OrderNo);
				var result = (from r in refineList
							  select new NameValueItem()
							  {
								  Name = r.Refine_No,
								  Value = r.Refine_No
							  }).ToList();
				Utility.BindDataToDropdown(ddlRefineList, result);
				if (!string.IsNullOrEmpty(RefineNo))
				{
					ddlRefineList.SelectedValue = RefineNo; 
				}
				txtRefineIntro.Text = RefineIntro;
			}
			MachItemDAL dal = new MachItemDAL();
			var machItems = dal.GetMachItemsByMachId(MachId);
			Utility.BindDataToRepeater(rpItems, machItems);
		}
		protected void chkRefine_CheckedChanged(object sender, EventArgs e)
		{
			ddlRefineList.Visible = chkRefine.Checked;
			txtRefineIntro.Visible = chkRefine.Checked;
			SetFocus(chkRefine);
		}

		protected void rpItems_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			MachItemDAL dal = new MachItemDAL();
			if (e.CommandName == "Add")
			{
				MachItem item = new MachItem();
				TextBox txtIntroAdd = e.Item.FindControl("txtIntroAdd") as TextBox;
				TextBox txtProductAdd = e.Item.FindControl("txtProductAdd") as TextBox;
				TextBox txtCodeAdd = e.Item.FindControl("txtCodeAdd") as TextBox;
				TextBox txtLongAdd = e.Item.FindControl("txtLongAdd") as TextBox;
				TextBox txtWidthAdd = e.Item.FindControl("txtWidthAdd") as TextBox;
				TextBox txtDeepAdd = e.Item.FindControl("txtDeepAdd") as TextBox;
				TextBox txtQtyAdd = e.Item.FindControl("txtQtyAdd") as TextBox;
				TextBox txtRemarkAdd = e.Item.FindControl("txtRemarkAdd") as TextBox;

                int longValue = !string.IsNullOrEmpty(txtLongAdd.Text) ? int.Parse(txtLongAdd.Text) : 0;
                int width = !string.IsNullOrEmpty(txtWidthAdd.Text) ? int.Parse(txtWidthAdd.Text) : 0;
                int deepth = !string.IsNullOrEmpty(txtDeepAdd.Text) ? int.Parse(txtDeepAdd.Text) : 0;
                int qty = !string.IsNullOrEmpty(txtQtyAdd.Text) ? int.Parse(txtQtyAdd.Text) : 0;

				item.Mach_Id = MachId;
				item.Intro = txtIntroAdd.Text;
				item.Product_Code = txtProductAdd.Text;
				item.Code = txtCodeAdd.Text;
                item.Long = longValue;
                item.Width = width;
                item.Deepth = deepth;
                item.Quantity = qty;
                item.Square = ((double)(longValue * width * qty)) / (1000 * 1000);
				item.MachIntro = txtRemarkAdd.Text;

				dal.AddMachItem(item);
				dal.Save();
			}
			if (e.CommandName == "Save")
			{
				HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
				var item = dal.GetMachItemById(int.Parse(hdId.Value));
				TextBox txtIntro = e.Item.FindControl("txtIntro") as TextBox;
				TextBox txtProduct = e.Item.FindControl("txtProduct") as TextBox;
				TextBox txtCode = e.Item.FindControl("txtCode") as TextBox;
				TextBox txtLong = e.Item.FindControl("txtLong") as TextBox;
				TextBox txtWidth = e.Item.FindControl("txtWidth") as TextBox;
				TextBox txtDeep = e.Item.FindControl("txtDeep") as TextBox;
				TextBox txtQty = e.Item.FindControl("txtQty") as TextBox;
				TextBox txtRemark = e.Item.FindControl("txtRemark") as TextBox;

                int longValue = !string.IsNullOrEmpty(txtLong.Text) ? int.Parse(txtLong.Text) : 0;
                int width = !string.IsNullOrEmpty(txtWidth.Text) ? int.Parse(txtWidth.Text) : 0;
                int deepth = !string.IsNullOrEmpty(txtDeep.Text) ? int.Parse(txtDeep.Text) : 0;
                int qty = !string.IsNullOrEmpty(txtQty.Text) ? int.Parse(txtQty.Text) : 0;

				item.Mach_Id = MachId;
				item.Intro = txtIntro.Text;
				item.Product_Code = txtProduct.Text;
				item.Code = txtCode.Text;
                item.Long = longValue;
                item.Width = width;
                item.Deepth = deepth;
				item.Quantity = qty;
                item.Square = ((double)(longValue * width * qty)) / (1000 * 1000);
				item.MachIntro = txtRemark.Text;
				dal.Save();
			}
			if (e.CommandName == "Delete")
			{
				HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
				dal.DeleteMachItem(int.Parse(hdId.Value));
			}

			BindControl();
			SetFocus(btnExport);

		}

		protected void rpDisplay_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
                MachLookUp item = e.Item.DataItem as MachLookUp;
				Image imgMach = e.Item.FindControl("imgMach") as Image;
				imgMach.ImageUrl = Page.ResolveUrl(string.Format("~/_Files/MachTypeImage/{0}", item.MachIdentity));
                string machType = item.Name;
                Label lblMachType = e.Item.FindControl("lblMachType") as Label;
                lblMachType.Text = machType;
			}
		}

		protected void rpItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Repeater rpDisplayL = e.Item.FindControl("rpDisplayL") as Repeater;
				Repeater rpDisplayW = e.Item.FindControl("rpDisplayW") as Repeater;
				Repeater rpDisplayD = e.Item.FindControl("rpDisplayD") as Repeater;

				MachItem machItem = e.Item.DataItem as MachItem;
				string longMachList = machItem.LongMachList;
				string widthMachList = machItem.WidthMachList;
				string deepthMachList = machItem.DeepthMachList;
				var machLookupList = Utility.GetMachLookupList();
				if (!string.IsNullOrEmpty(longMachList))
				{
					var longResult = longMachList.Split('|').Where(r=>!string.IsNullOrEmpty(r));
					var result = from c in machLookupList
								 join r in longResult
								 on c.Mach_Id equals int.Parse(r)
								 select c;
					Utility.BindDataToRepeater(rpDisplayL, result);
				}
				if (!string.IsNullOrEmpty(widthMachList))
				{
					var widthResult = widthMachList.Split('|').Where(r => !string.IsNullOrEmpty(r));
					var result = from c in machLookupList
								 join r in widthResult
                                 on c.Mach_Id equals int.Parse(r)
								 select c;
					Utility.BindDataToRepeater(rpDisplayW, result);
				}
				if (!string.IsNullOrEmpty(deepthMachList))
				{
					var deepResult = deepthMachList.Split('|').Where(r => !string.IsNullOrEmpty(r));
					var result = from c in machLookupList
								 join r in deepResult
                                 on c.Mach_Id equals int.Parse(r)
								 select c;
					Utility.BindDataToRepeater(rpDisplayD, result);
				}
			}
		}

		protected void btnExport_Click(object sender, EventArgs e)
		{
            string url = Request.Url.AbsoluteUri.Replace("MachiningForm", "snapshot");
            Thread NewTh = new Thread(new ParameterizedThreadStart(ExportImg));
            NewTh.SetApartmentState(ApartmentState.STA);
            NewTh.Start(url);
            while (NewTh.ThreadState == ThreadState.Running)
            {

            }
            MachiningDAL dal = new MachiningDAL();
            var mach = dal.GetMachById(MachId);

            string fileName = string.Format("{0}.jpg",mach.Mach_No);
            string filePath = Server.MapPath(string.Format("~/ImgLib/{0}", fileName));

            FileStream fs = new FileStream(filePath, FileMode.Open);        
            byte[] bytes = new byte[(int)fs.Length];        
            fs.Read(bytes, 0, bytes.Length);        
            fs.Close();        
            Response.ContentType = "application/octet-stream";        
            //通知浏览器下载文件而不是打开        
            Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));        
            Response.BinaryWrite(bytes);        
            Response.Flush();        
            Response.End();
		}

        void ExportImg(object url)
        {
            WebPageSnapshot wps = new WebPageSnapshot();
            
            wps.Url = url.ToString();
            try
            {
                MachiningDAL dal = new MachiningDAL();
                var mach = dal.GetMachById(MachId);
                string fileName = string.Format("{0}.jpg",mach.Mach_No);
                wps.TakeSnapshot().Save(Server.MapPath("~/ImgLib/") + "\\" + fileName);
            }
            catch (Exception ex)
            {

            }
            wps.Dispose();
        }

	}
}