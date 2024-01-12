using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momentus_DataTransformAndSync.Config.Models
{
    public class SyncConfig
    {
        public string InstanceId { get; set; }
        public DBConfig Source { get; set; }
        public DBConfig Destination { get; set; }

        public List<FieldMapping> FieldMappings { get; set; }
    }
}
