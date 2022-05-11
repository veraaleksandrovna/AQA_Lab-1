using System.Text.Json.Serialization;
using RESTapi.ApiTesting;
using TestRail_Example.Models;

namespace RESTapi.Models;

public record Milestones
{
    [JsonPropertyName("offset")] public int Offset { get; set; }
    [JsonPropertyName("limit")] public int Limit { get; set; }
    [JsonPropertyName("size")] public int Size { get; set; }
    [JsonPropertyName("_links")] public Links? Links { get; set; }
    [JsonPropertyName("milestones")] public Milestone[]? MilestonesList { get; set; }
}
