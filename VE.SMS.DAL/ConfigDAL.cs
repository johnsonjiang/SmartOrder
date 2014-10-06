using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class ConfigDAL : BaseDAL
    {
        public void AddConfigGroup(ConfigGroup group)
        {
            Db.ConfigGroup.AddObject(group);
        }

        public List<ConfigGroup> GetAllConfigGroup()
        {
            return Db.ConfigGroup.ToList();
        }

        public List<ConfigItem> GetConfigByGroup(int groupId)
        {
            return Db.ConfigItem.Where(item => item.ConfigGroup_Id == groupId).ToList();
        }

        public List<ConfigItem> GetConfigByGroup(string groupName)
        {
            return Db.ConfigItem.Where(item => item.ConfigItem_Key == groupName).ToList();
        }

        public void UpdateConfigItem(ConfigItem item)
        {
            var dbItem = Db.ConfigItem.Single(i => i.ConfigItem_Id == item.ConfigItem_Id);
            dbItem.ConfigItem_Key = item.ConfigItem_Key;
            dbItem.ConfigItem_Value = item.ConfigItem_Value;
        }
    }
}
