using ChoreWheel.Backend.DTOs;
using ChoreWheel.Backend.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace ChoreWheel.Backend.Mappers;

public static class ChoreMapper
{
    extension(Chore chore)
    {
        public ChoreDto ToDto()
        {
            return new ChoreDto
            {
                Id = chore.Id,
                Title = chore.Title,
                Description = chore.Description,
                Time = chore.Time,
                Difficulty = chore.Difficulty.ToDto(),
                Created = chore.CreationDateTime,
                Modified = chore.CreationDateTime,
                StartOn = chore.StartOn,
                RepetitionInterval = chore.RepetitionInterval,
                OwnedBy = chore.OwnedBy.ToDto(),
                SharedWith = [.. chore.SharedWith.Select<IdentityUser, UserDto>(sharee => sharee.ToDto())]
            };
        }

        public void Update(ChorePatchDto chorePatchDto)
        {
            if (chorePatchDto.Title != null) chore.Title = chorePatchDto.Title;
            if (chorePatchDto.Description != null) chore.Description = chorePatchDto.Description;
            if (chorePatchDto.Time != null) chore.Time = (int)chorePatchDto.Time;
            if (chorePatchDto.Difficulty != null) chore.Difficulty = (ChoreDifficulty)chorePatchDto.Difficulty;
            if (chorePatchDto.RepetitionInterval != null) chore.RepetitionInterval = chorePatchDto.RepetitionInterval;
        }
    }

    extension(ChorePostDto chorePostDto)
    {
        public Chore ToChore(IdentityUser owner)
        {
            return new Chore
            {
                Title = chorePostDto.Title,
                Description = chorePostDto.Description,
                Time = chorePostDto.Time,
                Difficulty = chorePostDto.Difficulty,
                StartOn = chorePostDto.StartOn,
                RepetitionInterval = chorePostDto.RepetitionInterval,
                OwnedBy = owner
            };
        }
    }
}