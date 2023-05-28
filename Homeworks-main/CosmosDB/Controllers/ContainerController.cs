using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace CosmosDB.Controllers
{
        [ApiController]
        [Route("api/v1/container")]
        public class ContainerContoller : ControllerBase
        {
            private readonly CosmosClient _client;

            public ContainerContoller(CosmosClient client)
            {
                _client = client;
            }

            [HttpPost]
            public async Task CreateContainer(ContainerOptions options)
            {
                var db = await _client.CreateDatabaseAsync(options.DatabaseName, ThroughputProperties.CreateManualThroughput(options.Throughput));

                await db.Database.CreateContainerAsync(options.ContainerName, options.PartitionKey);
            }
        }
}
