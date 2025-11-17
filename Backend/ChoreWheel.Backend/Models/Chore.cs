using ChoreWheel.Backend.Data.Database;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChoreWheel.Backend.Models;

public class Chore : AuditedEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Title { get; set; }
    [MinLength(20)]
    public string? Description { get; set; }
    [Range(0, int.MaxValue)]
    public int Time { get; set; } = 5;
    public ChoreDifficulty Difficulty { get; set; } = ChoreDifficulty.Tiny;
    public DateTimeOffset StartOn { get; set; } = DateTime.Now;
    public TimeSpan? RepetitionInterval { get; set; }
    public required IdentityUser OwnedBy { get; set; }
    public ICollection<IdentityUser> SharedWith { get; set; } = [];
}
