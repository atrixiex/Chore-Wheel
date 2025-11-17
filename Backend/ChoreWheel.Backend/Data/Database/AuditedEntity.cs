using System.Text.Json.Serialization;

namespace ChoreWheel.Backend.Data.Database;

public class AuditedEntity
{
    [JsonPropertyName("Created")]
    public DateTimeOffset CreationDateTime { get; set; }
    [JsonPropertyName("Modified")]
    public DateTimeOffset LastModificationDateTime { get; set; }
}
