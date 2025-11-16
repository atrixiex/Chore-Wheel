using ChoreWheel.Backend.Data.Database;
using ChoreWheel.Backend.DTOs;
using ChoreWheel.Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChoreWheel.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class GeneralController : ControllerBase
{

    // GET: api/Chores
    [HttpGet("Difficulties")]
    public async Task<ActionResult<List<ChoreDifficulty>>> GetDifficulties()
    {
        return Ok(Enum.GetValues<ChoreDifficulty>().Select<ChoreDifficulty, ChoreDifficultyDto>(choreDifficulty => new ChoreDifficultyDto(choreDifficulty)));
    }
}
