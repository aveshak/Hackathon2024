using Momentus_DataTransformAndSync.Config.Models;
using Momentus_DataTransformAndSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momentus_DataTransformAndSync.Handlers
{
    public class DataTransformer
    {
        protected readonly SyncConfig _syncConfig;
        protected readonly InputData _inputData;

        public DataTransformer(SyncConfig syncConfig, InputData inputData)
        {
            _syncConfig = syncConfig;
            _inputData = inputData;
        }

        public Dictionary<string, object> ApplyTransformation()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            _inputData.ParseData();

            foreach (var fieldMapping in _syncConfig.FieldMappings)
            {
                if (!_inputData.Data.ContainsKey(fieldMapping.Input.ToUpper().Trim()))
                    _inputData.Data.Add(fieldMapping.Input.ToUpper().Trim(), "");
                try
                {
                    switch (fieldMapping.Process.ToUpper())
                    {
                        case "":
                        case "COPY":
                            result.Add(fieldMapping.Output, _inputData.Data[fieldMapping.Input.ToUpper().Trim()]);
                            break;
                        case "DATETIME":
                            if (fieldMapping.Params.InputDateField != null && fieldMapping.Params.InputTimeField != null)
                            {
                                DateTime date = DateTime.Now;
                                DateTime time = DateTime.Now;

                                if (DateTime.TryParse(_inputData.Data[fieldMapping.Params.InputDateField.ToString().ToUpper().Trim()], out date) &&
                                    DateTime.TryParse(_inputData.Data[fieldMapping.Params.InputTimeField.ToString().ToUpper().Trim()], out time)
                                    )
                                {
                                    DateTime dateTime = date.Date.Add(new TimeSpan(time.Hour, time.Minute, time.Second));
                                    result.Add(fieldMapping.Output, dateTime);
                                }
                                else
                                    throw new InvalidCastException($"Failed to parse {fieldMapping.Params.InputDateField.ToString()} or {fieldMapping.Params.InputTimeField.ToString()}");
                            }
                            else
                                throw new MissingFieldException("InputDateField or InputTimeField parameter not provided correctly");
                            break;
                        case "CONCAT":
                            if (fieldMapping.Params.InputFields != null && fieldMapping.Params.Separator != null)
                            {
                                List<string> concatData = new List<string>();

                                foreach (string field in fieldMapping.Params.InputFields)
                                {
                                    concatData.Add(_inputData.Data[field.ToUpper()]);
                                }

                                result.Add(fieldMapping.Output, string.Join(fieldMapping.Params.Separator, concatData));
                            }
                            else
                                throw new MissingFieldException("InputFields and Separator not provided");
                            break;
                        case "FIXED":
                            if (fieldMapping.Params.Value != null)
                            {
                                result.Add(fieldMapping.Output, fieldMapping.Params.Value.ToString());
                            }
                            else
                                throw new MissingFieldException("Params\\Value not provided");
                            break;
                        case "RANDOM":

                            result.Add(fieldMapping.Output, DateTime.Now.Ticks / int.MaxValue);

                            break;
                        default:
                            throw new NotImplementedException($"Process '{fieldMapping.Process}' is not yet implemented");
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return result;
        }
    }
}
