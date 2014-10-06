using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class MonitorDAL : BaseDAL
    {
        public void SaveMonitor(int value)
        {
            Monitor monitor = GetMonitor();
            if (monitor != null)
            {
                monitor.MonitorV = value;
            }
            else
            {
                Db.Monitor.AddObject(new Monitor() { MonitorV = value });
            }
            Save();
        }

        public Monitor GetMonitor()
        {
            return Db.Monitor.FirstOrDefault();
        }
    }
}
