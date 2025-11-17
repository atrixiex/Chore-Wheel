using ChoreWheel.Backend.Data.Database;
using ChoreWheel.Backend.DTOs;
using ChoreWheel.Backend.Mappers;
using ChoreWheel.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChoreWheel.Backend.Services;

public class ChoreService(ApplicationDbContext context, UserContextService userContext)
{
    private readonly ApplicationDbContext _dbContext = context;
    private readonly UserContextService _userContext = userContext;

    public async Task<List<ChoreDto>> GetChoresAsync()
    {
        return await _dbContext.Chore.Select(chore => chore.ToDto()).ToListAsync();
    }

    public async Task<ChoreDto?> GetChoreAsync(int id)
    {
        return (await _dbContext.Chore.FindAsync(id))?.ToDto();
    }

    public async Task<ActionResult<ChoreDto>> UpdateChoreAsync(int id, ChorePatchDto chorePatchDto)
    {
        if(_userContext.CurrentUser == null)
        {
            return new BadRequestResult();
        }

        var chore = await _dbContext.Chore.FindAsync(id);
        if (chore == null)
        {
            return new NotFoundResult();
        }
        if(chore.OwnedBy != _userContext.CurrentUser)
        {
            return new ForbidResult("You must be the owner of a chore to update!");
        }
        chore.Update(chorePatchDto);

        _dbContext.Entry(chore).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return chore.ToDto();
    }

    public async Task<ActionResult<ChoreDto>> CreateChoreAsync(ChorePostDto chorePostDto)
    {
        if (_userContext.CurrentUser == null)
        {
            return new BadRequestResult();
        }
        var chore = chorePostDto.ToChore(_userContext.CurrentUser);
        _dbContext.Chore.Add(chore);
        await _dbContext.SaveChangesAsync();

        return new CreatedAtActionResult("GetChore", "ChoresController", new { id = chore.Id }, chore.ToDto());
    }

    public async Task<IActionResult> DeleteChoreAsync(int id)
    {
        if (_userContext.CurrentUser == null)
        {
            return new BadRequestResult();
        }
        var chore = await _dbContext.Chore.FindAsync(id);
        if (chore == null)
        {
            return new NotFoundResult();
        }
        if (chore.OwnedBy != _userContext.CurrentUser)
        {
            return new ForbidResult("You must be the owner of a chore to update!");
        }
        _dbContext.Chore.Remove(chore);
        await _dbContext.SaveChangesAsync();

        return new NoContentResult();
    }
}
