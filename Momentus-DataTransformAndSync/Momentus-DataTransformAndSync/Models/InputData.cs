using Momentus_DataTransformAndSync.Config.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Momentus_DataTransformAndSync.Models
{
    public class InputData
    {
        public Dictionary<string, string> Data { get; set; }

        protected readonly dynamic _inputData;
        protected readonly SyncConfig _syncConfig;

        public InputData(string inputData, SyncConfig syncConfig)
        {
            _inputData = JsonConvert.DeserializeObject<dynamic>(inputData);
        }

        public void ParseData()
        {
            Data = new Dictionary<string, string>();
            JObject sourceObj = _inputData as JObject;
            if (sourceObj != null)
            {
                foreach (JProperty childToken in sourceObj.Children())
                {
                    if (childToken.Value.GetType() == typeof(JValue))
                    {
                        string data = ((JProperty)childToken).Value.Value<string>();
                        Data.Add(childToken.Name.ToUpper().Trim(), data);
                    }
                    else if (childToken.Value.GetType() == typeof(JObject))
                    {
                        throw new NotImplementedException("Handling Object in input is not implemented");
                    }
                    else if (childToken.Value.GetType() == typeof(JArray))
                    {
                        throw new NotImplementedException("Handling Array in input is not implemented");
                    }
                }
            }
        }
    }
}
