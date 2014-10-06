using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using VE.SMS.Common;

namespace VE.SMS.UI.Printout
{
	public partial class DeliveryPrintout : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            BindControl();
        }

        public void BindControl()
        {
            ArrayList arr = new ArrayList();
            arr.Add(1);
            arr.Add(1);
            arr.Add(1);
            arr.Add(1);
            Utility.BindDataToRepeater(rpItems, arr);
        }
	}
}