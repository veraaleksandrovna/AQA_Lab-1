using System.Text.Json.Serialization;

namespace RESTapi.ApiTesting;

public record Links
{
    [JsonPropertyName("next")] public string Next { get; set; }
    [JsonPropertyName("prev")] public string Prev { get; set; }
    
}