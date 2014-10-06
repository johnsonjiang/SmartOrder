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
	public partial class CustomerDrawingControl : BaseUserControl
	{
        public bool IsCustomerProvideImage 
        { 
            get 
            { return chkProvideDrawing.Checked; } 
            set 
            { 
                chkProvideDrawing.Checked = value; 
                this.pnlOA.Visible = chkProvideDrawing.Checked;
                this.pnlOB.Visible = chkProvideDrawing.Checked;
            } 
        }
		public bool Editable
		{
			get
			{
				return divOperate.Visible;
			}
			set
			{
				divOperate.Visible = value;
			}
		}
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public override void BindControl()
		{
			CustomerDrawingDAL dal = new CustomerDrawingDAL();
			Utility.BindDataToRepeater(rpCustomerDrawing, dal.GetCustomerDrawingBySource(SourceType, SourceNo));
		}

		protected void btnUpload_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(fileUploadDrawing.FileName))
			{
				string serverFilePath = string.Empty;
				Utility.UploadFile(fileUploadDrawing, "CustomerDrawing", SourceNo, ref serverFilePath);

				CustomerDrawing item = new CustomerDrawing() 
				{ 
					CreatedAt = DateTime.Now,
					CreatedBy = SMSContext.Current.User.UserName,
					CustomerDrawing_Intro = txtCustomerDrawingIntro.Text,
					CustomerDrawing_Name = Utility.GetFileName(fileUploadDrawing),
					CustomerDrawing_Path = serverFilePath,
					SourceNo = SourceNo,
					SourceType = SourceType,
				};

				CustomerDrawingDAL dal = new CustomerDrawingDAL();
				dal.AddCustomerDrawing(item);
				dal.Save();
				BindControl();
			}
            SetFocus(sender);
		}

        protected void chkProvideDrawing_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlOA.Visible = chkProvideDrawing.Checked;
            this.pnlOB.Visible = chkProvideDrawing.Checked;
            SetFocus(sender);
        }

        protected void rpCustomerDrawing_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                var hdId = e.Item.FindControl("hdId") as HiddenField;
                new CustomerDrawingDAL().DeleteCustomerDrawing(int.Parse(hdId.Value));
                BindControl();
            }
        }
	}
}