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
	public partial class MachiningControl : BaseUserControl
	{

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public override void BindControl()
        {
            MachiningDAL dal = new MachiningDAL();
            var machs = dal.GetMachBySource(SourceType, SourceNo);
            Utility.BindDataToRepeater(rpMachining, machs);
        }
        protected void btnCreateMachining_Click(object sender, EventArgs e)
        {
            //get no
            SeedDAL sdal = new SeedDAL();
            string no = sdal.GetNoByTableName(SysConst.TableMachining, SysConst.SuffixMachining);

            Machining mach = new Machining();
            mach.Mach_No = no;
            mach.SourceNo = SourceNo;
            mach.SourceType = SourceType;
            mach.CreatedDate = DateTime.Now;
            mach.Status = FirstStatusConsts.Mach;

            OrderDAL soDAL = new OrderDAL();
            var so = soDAL.GetOrderByNo(SourceNo);
            so.Status = "申请生产";
            soDAL.Save();

            mach.CustomerCompanyName = so.CustomerCompanyName;
            mach.CustomerContactName = so.CustomerContactName;
            mach.CustomerAddress= so.CustomerAddress;
            mach.CustomerEmail= so.CustomerEmail;
            mach.CustomerQQ = so.CustomerQQ;
            mach.CustomerPhone1 = so.CustomerPhone1;
            mach.CustomerPhone2 = so.CustomerPhone2;
            mach.CustomerOthers = so.CustomerOthers;

            MachiningDAL dal = new MachiningDAL();
            dal.AddMachining(mach);
            dal.Save();

            int machId = mach.Mach_Id;
            string machNo = mach.Mach_No;
            string url = Page.ResolveUrl(string.Format("~/MachiningForm.aspx?machid={0}&machno={1}&sourcetype={2}&sourceno={3}", machId, machNo, SourceType, SourceNo));
            string script = string.Format("<script>window.open('{0}')</script>", url);
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "createmach", script);
            BindControl();
            SetFocus(btnCreateMachining);
        }
	}
}