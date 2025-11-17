using ChoreWheel.Backend.DTOs;
using ChoreWheel.Backend.Models;
using NuGet.Packaging.Signing;

namespace ChoreWheel.Backend.Mappers;

public static class ChoreDifficultyMapper
{
    extension(ChoreDifficulty choreDifficulty)
    {
        public ChoreDifficultyDto ToDto()
        {
            return new ChoreDifficultyDto
            {
                Value = choreDifficulty,
                Name = choreDifficulty.ToString()
            };
        }
    }
}