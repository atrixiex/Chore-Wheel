using ChoreWheel.Backend.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ChoreWheel.Backend.DTOs;

public class ChoreDto
{
    [Key]
    public required int Id { get; set; }
    [Required]
    public required string Title { get; set; }
    [MinLength(20)]
    public string? Description { get; set; }
    [Range(0, int.MaxValue)]
    public required int Time { get; set; }
    public required ChoreDifficultyDto Difficulty { get; set; }
    public required DateTimeOffset Created { get; set; }
    public required DateTimeOffset Modified { get; set; }
    public required DateTimeOffset StartOn { get; set; }
    public required TimeSpan? RepetitionInterval { get; set; }
    public required UserDto OwnedBy { get; set; }
    public required ICollection<UserDto> SharedWith { get; set; }
}
