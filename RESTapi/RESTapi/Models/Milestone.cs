using System.Text.Json.Serialization;

namespace TestRail_Example.Models;

public record Milestone
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("project_id")] public int ProjectId { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("completed_on")] public string? CompletedOn { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("due_on")] public int DueOn { get; set; }
    [JsonPropertyName("is_completed")] public bool IsCompleted { get; set; }
    [JsonPropertyName("is_started")] public bool IsStarted { get; set; }
    [JsonPropertyName("refs")] public string? Refs { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
}
