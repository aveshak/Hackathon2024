using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momentus_DataTransformAndSync.Config.Models
{
    public class DBConfig
    {
        public DBType DBType { get; set; }
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string Table { get; set; }
    }

    public enum DBType
    {
        MySQL,
        SQL,
        DataLake,
        DataWarehouse,
        CosmosDB
    }
}
