using Microsoft.Azure.Cosmos;
using Momentus_DataTransformAndSync.Config.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Momentus_DataTransformAndSync.Config.Handler
{
    public abstract class TenantConfigHandler
    {
        static ObjectCache tokenCache = MemoryCache.Default;

        public static async Task<ConfigItem> GetTenantConfiguration(string connectionString, string databaseId, string containerId, string tenantId)
        {
            CacheItem tokenContents = tokenCache.GetCacheItem(tenantId);
            // Branch when cache doesn’t exist. This would mean we need to regenerate it.
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.Priority = CacheItemPriority.Default;

            if (tokenContents != null)
            {
                var configItem = JsonConvert.DeserializeObject<ConfigItem>(tokenContents.Value.ToString());
                return configItem;
            }
            else
            {
                CosmosClient cosmosClient = new CosmosClient(connectionString);
                Container container = cosmosClient.GetContainer(databaseId, containerId);

                var parameterizedQuery = new QueryDefinition(
                    query: "SELECT * FROM configs p WHERE p.id = @tenantid"
                ).WithParameter("@tenantid", tenantId);

                var items = container.GetItemQueryIterator<ConfigItem>(queryDefinition: parameterizedQuery);

                while (items.HasMoreResults)
                {
                    FeedResponse<ConfigItem> response = await items.ReadNextAsync();

                    if (response != null && response.Count > 0)
                    {
                        var configItem = response.First();

                        // Setting expiration timing for the cache
                        policy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(24);
                        tokenContents = new CacheItem(tenantId, JsonConvert.SerializeObject(configItem));
                        tokenCache.Set(tokenContents, policy);

                        return configItem;
                    }
                }
            }

            return null;
        }
    }



}
