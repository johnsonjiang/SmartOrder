using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VE.SMS.DAL;
using VE.SMS.Common;

namespace VE.SMS.UI
{
    public partial class SnapShot : System.Web.UI.Page
    {
        protected string MachNo { get { return Request.QueryString["machno"]; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int machId = int.Parse(Request.QueryString["machId"]);
                MachItemDAL dal = new MachItemDAL();
                var machItems = dal.GetMachItemsByMachId(machId);
                Utility.BindDataToRepeater(rpItemExport, machItems);
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
                    var longResult = longMachList.Split('|').Where(r => !string.IsNullOrEmpty(r));
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

        protected void rpDisplay_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var item = e.Item.DataItem as MachLookUp;
                Image imgMach = e.Item.FindControl("imgMach") as Image;
                imgMach.ImageUrl = Page.ResolveUrl(string.Format("~/_Files/MachTypeImage/{0}", item.MachIdentity));
                string machType = item.Name;
                Label lblMachType = e.Item.FindControl("lblMachType") as Label;
                lblMachType.Text = machType;
            }
        }
    }
}