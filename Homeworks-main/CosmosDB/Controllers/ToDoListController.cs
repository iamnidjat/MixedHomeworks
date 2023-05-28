using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace CosmosDB.Controllers
{
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly CosmosClient _client;
        private readonly Database _database;
        private readonly Container _container;

        public ToDoListController(CosmosClient client)
        {
            _client = client;
            _database = _client.GetDatabase("mydb");
            _container = _database.GetContainer("mycont");
        }

        [HttpGet("api/v1/getall")]
        public async Task<List<Item>> GetAll()
        {
            var queryDefinition = new QueryDefinition("SELECT * FROM c");
            var iterator = _container.GetItemQueryIterator<Item>(queryDefinition);
            var result = new List<Item>();

            while (iterator.HasMoreResults)
            {
                var products = await iterator.ReadNextAsync();

                result.AddRange(products);
            }

            return result;

        }

        [HttpGet("api/v1/get/{id}")]
        public async Task<Item?> GetProduct(string? id)
        {
            var queryDefinition = new QueryDefinition("SELECT * FROM c WHERE c.id = @id").WithParameter("@id", id);
            var iterator = _container.GetItemQueryIterator<Item>(queryDefinition);

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();

                return response.SingleOrDefault();
            }

            return null;
        }

        [HttpPost("api/v1/create")]
        public async Task<Item?> CreateProduct(Item? product)
        {
            if (product == null)
            {
                return null;
            }

            product.Id = Guid.NewGuid().ToString();

            var createdItem = await _container.CreateItemAsync(product, new PartitionKey(product.Id));

            return createdItem;
        }

        [HttpDelete("api/v1/remove/{id}")]
        public async Task DeleteProduct(string? id)
        {
            await _container.DeleteItemAsync<Item>(id, new PartitionKey(id));
        }

        [HttpPatch("api/v1/update")]
        public async Task UpdateProduct(Item? product)
        {
            if (product == null)
            {
                return;
            }

            await _container.ReplaceItemAsync<Item>(product, product.Id, new PartitionKey(product.Id));
        }
    }
}
