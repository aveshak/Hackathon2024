using System;
using System.Collections.Generic;
using System.Linq;

namespace Momentus_DataTransformAndSync.Config.Models
{
    public class ConfigItem
    {
        public string id { get; set; }
        public  List<SyncConfig> SyncConfigs { get; set; }

        public SyncConfig GetSyncConfig(string instanceId)
        {
            return SyncConfigs.Where(x => x.InstanceId.Equals(instanceId, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }
    }
}
