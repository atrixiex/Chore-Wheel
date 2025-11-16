using ChoreWheel.Backend.Models;

namespace ChoreWheel.Backend.DTOs;

public class ChoreDifficultyDto(ChoreDifficulty choreDifficulty)
{
    public ChoreDifficulty Value { get; } = choreDifficulty;
    public string Name { get; } = choreDifficulty.ToString();
}
