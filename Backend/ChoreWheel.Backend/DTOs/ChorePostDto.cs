using ChoreWheel.Backend.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChoreWheel.Backend.DTOs;

public class ChorePostDto
{
    [Required]
    public required string Title { get; set; }
    [MinLength(20)]
    public string? Description { get; set; }
    [Range(0, int.MaxValue)]
    public required int Time { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter<ChoreDifficulty>))]
    public required ChoreDifficulty Difficulty { get; set; }
    public required DateTimeOffset StartOn { get; set; }
    public required TimeSpan? RepetitionInterval { get; set; }
}
