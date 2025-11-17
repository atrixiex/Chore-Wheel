using ChoreWheel.Backend.Models;

namespace ChoreWheel.Backend.DTOs;

public class ChoreDifficultyDto
{
    public required ChoreDifficulty Value { get; set; }
    public required string Name { get; set; }
}
