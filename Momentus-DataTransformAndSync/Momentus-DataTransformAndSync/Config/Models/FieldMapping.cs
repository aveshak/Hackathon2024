using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momentus_DataTransformAndSync.Config.Models
{
    public class FieldMapping
    {
        protected string _process;
        private bool _primaryKey = false;

        public FieldMapping()
        {
            if (_process == null)
                _process = "Copy";
        }
        public string Input { get; set; }
        public string Output { get; set; }
        public string Process
        {
            get => string.IsNullOrEmpty(_process) ? "Copy" : _process;
            set => _process = value;
        }
        public string DataType { get; set; }
        public string Size { get; set; }
        public dynamic Params { get; set; }
        public bool PrimaryKey { get => _primaryKey; set => _primaryKey = value; }
    }
}
