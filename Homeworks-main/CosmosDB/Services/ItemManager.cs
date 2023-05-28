using Microsoft.Azure.Cosmos;


public class ItemManager
{
    private readonly CosmosClient _client;

    public ItemManager(CosmosClient client)
    {
        _client = client;
    }
}