using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.Common
{
    public class StatusEngine
    {
        class StatusInfo
        {
            public string Status { get; set; }
            public string List { get; set; }
        }
        public static List<string> GetRefineStatus(bool includeMach, bool isApproved, bool customerConfirmed)
        {
            Dictionary<string, StatusInfo> StatusMap = new Dictionary<string, StatusInfo>();
            StatusMap.Add("A", new StatusInfo() { Status = "待细化", List = "0,1,2,4,3,5,6,7" });
            StatusMap.Add("B", new StatusInfo() { Status = "作图中", List = "0,1,2,4,3,5,6,7" });
            StatusMap.Add("C", new StatusInfo() { Status = "细化完成", List = "0,1" });
            StatusMap.Add("D", new StatusInfo() { Status = "细化完成+", List = "4,5" });
            StatusMap.Add("E", new StatusInfo() { Status = "细化完成待审", List = "2,3" });
            StatusMap.Add("F", new StatusInfo() { Status = "未知", List = "6,7" });
            StatusMap.Add("G", new StatusInfo() { Status = "待确认", List = "1,3,5,7" });
            StatusMap.Add("H", new StatusInfo() { Status = "要求修改", List = "1,3,5,7" });
            StatusMap.Add("I", new StatusInfo() { Status = "已确认", List = "1,3,5,7" });
            StatusMap.Add("J", new StatusInfo() { Status = "审核中", List = "2,3,6,7" });
            StatusMap.Add("K", new StatusInfo() { Status = "审核修改", List = "2,3,6,7" });
            StatusMap.Add("L", new StatusInfo() { Status = "审核通过", List = "2,3,6,7" });

            int num = 0;
            num = Convert.ToInt32(includeMach) << 2 | Convert.ToInt32(isApproved) << 1 | Convert.ToInt32(customerConfirmed) << 0;

            var result = from s in StatusMap
                         where s.Value.List.Contains(num.ToString())
                         select s.Value.Status;
            return result.ToList();
        }
    }
}
