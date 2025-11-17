using ChoreWheel.Backend.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChoreWheel.Backend.DTOs;

public class ChorePatchDto
{
    public string? Title { get; set; }
    [MinLength(20)]
    public string? Description { get; set; }
    [Range(0, int.MaxValue)]
    public int? Time { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter<ChoreDifficulty>))]
    public ChoreDifficulty? Difficulty { get; set; }
    public DateTime? StartOn { get; set; }
    public TimeSpan? RepetitionInterval { get; set; }
}
