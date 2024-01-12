using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Momentus_DataTransformAndSync.Config.Handler;
using Momentus_DataTransformAndSync.Models;
using Momentus_DataTransformAndSync.Handlers;

namespace Momentus_DataTransformAndSync
{
    public static class DataTransformAndSyncService
    {
        [FunctionName("DataTransformAndSync")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log,
            ExecutionContext context)
        {
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                if (string.IsNullOrEmpty(req.Query["tenant_id"]))
                    return new BadRequestObjectResult("tenant_id parameter required in Query string");

                if (string.IsNullOrEmpty(req.Query["instance_id"]))
                    return new BadRequestObjectResult("instance_id parameter required in Query string");

                string tenant_id = req.Query["tenant_id"];
                string instance_id = req.Query["instance_id"];
                bool skipUpdate = (!string.IsNullOrEmpty(req.Query["skipUpdate"]) ? bool.Parse(req.Query["skipUpdate"]) : false);

                log.LogInformation($"Tenant ID: {tenant_id}");
                log.LogInformation($"Instance ID: {instance_id}");

                var config = new ConfigurationBuilder()
                    .SetBasePath(context.FunctionAppDirectory)
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                if (config.GetValue<string>("ConfigsConnection") == null)
                    return new BadRequestObjectResult("Config not found: EliteConfigsConnection");

                if (config.GetValue<string>("DatabaseId") == null)
                    return new BadRequestObjectResult("Config not found: DatabaseId");

                if (config.GetValue<string>("ContainerId") == null)
                    return new BadRequestObjectResult("Config not found: ContainerId");

                var tenantConfig = await TenantConfigHandler.GetTenantConfiguration(config.GetValue<string>("ConfigsConnection"),
                    config.GetValue<string>("DatabaseId"), config.GetValue<string>("ContainerId"), tenant_id);

                var syncConfig = tenantConfig.GetSyncConfig(instance_id);

                if (tenantConfig == null)
                    return new BadRequestObjectResult("Tenant configuration not found");

                InputData inputData = new InputData(requestBody, syncConfig);

                DataTransformer dataTransformer = new DataTransformer(syncConfig, inputData);
                SQLSyncHandler sqlSyncHandler = new SQLSyncHandler(syncConfig, dataTransformer);

                sqlSyncHandler.Execute(skipUpdate);

                return new OkObjectResult("OK");
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString());
                return new BadRequestObjectResult(ex.ToString());
            }
        }
    }
}
