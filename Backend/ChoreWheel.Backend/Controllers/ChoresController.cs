using ChoreWheel.Backend.DTOs;
using ChoreWheel.Backend.Mappers;
using ChoreWheel.Backend.Models;
using ChoreWheel.Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChoreWheel.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChoresController(ChoreService choreService) : ControllerBase
{
    private readonly ChoreService _choreService = choreService;

    [HttpGet("Difficulties")]
    public async Task<ActionResult<List<ChoreDifficultyDto>>> GetDifficulties()
    {
        return Ok(Enum.GetValues<ChoreDifficulty>().Select<ChoreDifficulty, ChoreDifficultyDto>(choreDifficulty => choreDifficulty.ToDto()));
    }

    // GET: api/Chores
    [HttpGet]
    public async Task<ActionResult<List<ChoreDto>>> GetChores()
    {
        return Ok(await _choreService.GetChoresAsync());
    }

    // GET: api/Chores/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ChoreDto>> GetChore(int id)
    {
        var chore = await _choreService.GetChoreAsync(id);

        if (chore == null)
        {
            return NotFound();
        }

        return Ok(chore);
    }

    // PATCH: api/Chores/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPatch("{id}")]
    public async Task<ActionResult<ChoreDto>> PatchChore(int id, ChorePatchDto chorePatchDto)
    {
        return await _choreService.UpdateChoreAsync(id, chorePatchDto);
    }

    // POST: api/Chores
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ChoreDto>> PostChore(ChorePostDto chorePostDto)
    {
        return await _choreService.CreateChoreAsync(chorePostDto);
    }

    // DELETE: api/Chores/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteChore(int id)
    {
        return await _choreService.DeleteChoreAsync(id);
    }
}
