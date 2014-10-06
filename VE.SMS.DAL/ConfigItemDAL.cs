using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class ConfigItemDAL:BaseDAL
    {
        public List<ConfigItem> GetConfigByGroup(int groupId)
        {
            return Db.ConfigItem.Where(item => item.ConfigGroup_Id == groupId).ToList();
        }

        public List<ConfigItem> GetConfigByGroup(string groupName)
        {
            var group = Db.ConfigGroup.SingleOrDefault(c => c.ConfigGroup_Name == groupName);
            return Db.ConfigItem.Where(item => item.ConfigGroup_Id == group.ConfigGroup_Id).ToList();
        }

        public ConfigItem GetConfigItemById(int configItemId)
        {
            return Db.ConfigItem.SingleOrDefault(c=>c.ConfigItem_Id == configItemId);
        }

        public void AddConfigItem(ConfigItem item)
        {
            Db.ConfigItem.AddObject(item);
        }

        public void UpdateConfigItem(ConfigItem item)
        {
            var dbItem = Db.ConfigItem.Single(i => i.ConfigItem_Id == item.ConfigItem_Id);
            dbItem.ConfigItem_Key = item.ConfigItem_Key;
            dbItem.ConfigItem_Value = item.ConfigItem_Value;
            dbItem.IsDefault = item.IsDefault;
        }

        public void Delete(int id)
        {
            var configItem = GetConfigItemById(id);
            Db.ConfigItem.DeleteObject(configItem);
            Save();
        }
    }
}
