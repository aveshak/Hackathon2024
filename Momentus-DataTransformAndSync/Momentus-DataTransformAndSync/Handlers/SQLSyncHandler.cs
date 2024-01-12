using Microsoft.Data.SqlClient;
using Momentus_DataTransformAndSync.Config.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momentus_DataTransformAndSync.Handlers
{
    public class SQLSyncHandler
    {
        protected readonly SyncConfig _syncConfig;
        protected readonly DataTransformer _transformer;

        public SQLSyncHandler(SyncConfig syncConfig, DataTransformer transformer)
        {
            _syncConfig = syncConfig;
            _transformer = transformer;
        }

        public void Execute(bool skipUpdate)
        {
            Dictionary<string, object> outputData = _transformer.ApplyTransformation();
            
            //string selectQuery, insertQuery, updateQuery;

            using (SqlConnection sqlConnection = new SqlConnection(_syncConfig.Destination.ConnectionString))
            {
                sqlConnection.Open();

                SqlCommand cmd = sqlConnection.CreateCommand();

                var whereClause = string.Join(" AND ", _syncConfig.FieldMappings.Where(x => x.PrimaryKey).Select(f => $"{f.Output}=@{f.Output}").ToArray());

                cmd.CommandText = $"SELECT COUNT(1) FROM [{_syncConfig.Destination.Table}] WHERE {whereClause}";
                cmd.CommandType = CommandType.Text;

                _syncConfig.FieldMappings.Where(x => x.PrimaryKey).ToList().ForEach(x =>
                    {
                        var dataType =
                            (x.DataType.Equals("int", StringComparison.OrdinalIgnoreCase) ? SqlDbType.Int :
                            (x.DataType.Equals("integer", StringComparison.OrdinalIgnoreCase) ? SqlDbType.Int :
                            (x.DataType.Equals("varchar", StringComparison.OrdinalIgnoreCase) ? SqlDbType.VarChar :
                            (x.DataType.Equals("nvarchar", StringComparison.OrdinalIgnoreCase) ? SqlDbType.NVarChar :
                            (x.DataType.Equals("char", StringComparison.OrdinalIgnoreCase) ? SqlDbType.Char :
                            (x.DataType.Equals("numeric", StringComparison.OrdinalIgnoreCase) ? SqlDbType.Decimal :
                            (x.DataType.Equals("datetime", StringComparison.OrdinalIgnoreCase) ? SqlDbType.DateTime :
                            SqlDbType.VarChar)))))));

                        cmd.Parameters.Add($"@{x.Output}", dataType).Value = outputData[x.Output];
                    }
                );

                int recCount = (int)cmd.ExecuteScalar();

                if (recCount == 0)
                {
                    var query = //$"SET IDENTITY_INSERT [{_syncConfig.Destination.Table}] ON; " +
                        $"INSERT INTO [{_syncConfig.Destination.Table}] (" +
                        string.Join(",", _syncConfig.FieldMappings.Select(x => $"[{x.Output}]").ToArray()) + ") VALUES (" +
                        string.Join(",", _syncConfig.FieldMappings.Select(x => $"@{x.Output}").ToArray()) + ");";
                    //+ $"SET IDENTITY_INSERT [{_syncConfig.Destination.Table}] OFF;";

                    cmd.CommandText = query;
                    cmd.Parameters.Clear();

                    _syncConfig.FieldMappings.ToList().ForEach(x =>
                    {
                        try
                        {
                            var dataType =
                                (x.DataType.Equals("int", StringComparison.OrdinalIgnoreCase) ? SqlDbType.Int :
                                (x.DataType.Equals("integer", StringComparison.OrdinalIgnoreCase) ? SqlDbType.Int :
                                (x.DataType.Equals("varchar", StringComparison.OrdinalIgnoreCase) ? SqlDbType.VarChar :
                                (x.DataType.Equals("nvarchar", StringComparison.OrdinalIgnoreCase) ? SqlDbType.NVarChar :
                                (x.DataType.Equals("char", StringComparison.OrdinalIgnoreCase) ? SqlDbType.Char :
                                (x.DataType.Equals("numeric", StringComparison.OrdinalIgnoreCase) ? SqlDbType.Decimal :
                                (x.DataType.Equals("datetime", StringComparison.OrdinalIgnoreCase) ? SqlDbType.DateTime :
                                SqlDbType.VarChar)))))));

                            cmd.Parameters.Add($"@{x.Output}", dataType).Value =
                                (outputData[x.Output] != null && !string.IsNullOrEmpty(outputData[x.Output].ToString())) ? (
                                (dataType == SqlDbType.Int ? int.Parse(outputData[x.Output].ToString()) :
                                (dataType == SqlDbType.BigInt ? long.Parse(outputData[x.Output].ToString()) :
                                (dataType == SqlDbType.Decimal ? decimal.Parse(outputData[x.Output].ToString()) :
                                (dataType == SqlDbType.DateTime ? DateTime.Parse(outputData[x.Output].ToString()) :
                                (dataType == SqlDbType.Bit ? bool.Parse(outputData[x.Output].ToString()) :
                                outputData[x.Output].ToString())))))) : DBNull.Value;
                        }
                        catch (Exception ex1)
                        {
                        }
                    });
                }
                else if (skipUpdate == false)
                {
                    var query = $"UPDATE [{_syncConfig.Destination.Table}] SET " +
                        string.Join(",", _syncConfig.FieldMappings.Where(f => f.PrimaryKey == false).Select(x => $"[{x.Output}] = @{x.Output}").ToArray()) +
                        $" WHERE {whereClause}";

                    cmd.CommandText = query;

                    cmd.Parameters.Clear();

                    _syncConfig.FieldMappings.ToList().ForEach(x =>
                    {
                        try
                        {
                            var dataType =
                                (x.DataType.Equals("int", StringComparison.OrdinalIgnoreCase) ? SqlDbType.Int :
                                (x.DataType.Equals("integer", StringComparison.OrdinalIgnoreCase) ? SqlDbType.Int :
                                (x.DataType.Equals("varchar", StringComparison.OrdinalIgnoreCase) ? SqlDbType.VarChar :
                                (x.DataType.Equals("nvarchar", StringComparison.OrdinalIgnoreCase) ? SqlDbType.NVarChar :
                                (x.DataType.Equals("char", StringComparison.OrdinalIgnoreCase) ? SqlDbType.Char :
                                (x.DataType.Equals("numeric", StringComparison.OrdinalIgnoreCase) ? SqlDbType.Decimal :
                                (x.DataType.Equals("datetime", StringComparison.OrdinalIgnoreCase) ? SqlDbType.DateTime :
                                SqlDbType.VarChar)))))));

                            cmd.Parameters.Add($"@{x.Output}", dataType).Value =
                                    (outputData[x.Output] != null && !string.IsNullOrEmpty(outputData[x.Output].ToString())) ? (
                                    (dataType == SqlDbType.Int ? int.Parse(outputData[x.Output].ToString()) :
                                    (dataType == SqlDbType.BigInt ? long.Parse(outputData[x.Output].ToString()) :
                                    (dataType == SqlDbType.Decimal ? decimal.Parse(outputData[x.Output].ToString()) :
                                    (dataType == SqlDbType.DateTime ? DateTime.Parse(outputData[x.Output].ToString()) :
                                    (dataType == SqlDbType.Bit ? bool.Parse(outputData[x.Output].ToString()) :
                                    outputData[x.Output].ToString())))))) : DBNull.Value;
                        }
                        catch (Exception ex1)
                        {
                        }
                    });
                }

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
    }
}
