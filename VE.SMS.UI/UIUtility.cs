using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VE.SMS.UI._UserControl;

namespace VE.SMS.UI
{
	public static class UIUtility
	{
		public static void BindUserControl(BaseUserControl control, string sourceType, string sourceNo)
		{
			control.SourceNo = sourceNo;
			control.SourceType = sourceType;
			control.BindControl();
		}

		public static void BindUserControl(BaseUserControl control, string sourceType, int sourceId)
		{
			control.SourceId = sourceId;
			control.SourceType = sourceType;
			control.BindControl();
		}
	}
}