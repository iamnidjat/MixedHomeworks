using Newtonsoft.Json;

public class Item
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; } = null!;

    [JsonProperty("description")]
    public string Description { get; set; } = null!;

    [JsonProperty("deadline")]
    public DateTime Deadline { get; set; }
}