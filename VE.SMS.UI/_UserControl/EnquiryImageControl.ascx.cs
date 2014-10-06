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
    public partial class EnquiryImageControl : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public int EnquiryId
        {
            get
            {
                return ViewState["EnquiryId"] == null ? -1 : Convert.ToInt32(ViewState["EnquiryId"]);
            }
            set
            {
                ViewState["EnquiryId"] = value;
            }
        }
        public string ImagePath
        {
            get
            {
                return ViewState["ImagePath"] == null ? string.Empty : ViewState["ImagePath"].ToString();
            }
            set
            {
                ViewState["ImagePath"] = value;
            }
        }
        public override void BindControl()
        {
            imgEnq.ImageUrl = Page.ResolveUrl(string.Format("~/{0}", ImagePath));
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string serverFilePath = string.Empty;
            Utility.UploadFile(fileUploadEnqImg, "EnquiryImage", SourceNo, ref serverFilePath);
            ImagePath = serverFilePath;

            EnquiryDAL dal = new EnquiryDAL();
            var enq = dal.GetEnquiryById(EnquiryId);
            enq.EnquiryImgPath = serverFilePath;
            dal.Save();
            BindControl();
        }
    }
}