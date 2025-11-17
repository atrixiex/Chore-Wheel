using ChoreWheel.Backend.Data.Database;
using ChoreWheel.Backend.DTOs;
using ChoreWheel.Backend.Mappers;
using ChoreWheel.Backend.Models;
using ChoreWheel.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChoreWheel.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class UserManagementController(UserManagementService userManagementService) : ControllerBase
{
    private readonly UserManagementService _userManagementService = userManagementService;
    // GET: api/Chores
    [HttpGet("Users")]
    public async Task<ActionResult<List<ChoreDifficultyDto>>> GetUsers()
    {
        return Ok(await _userManagementService.GetUsers());
    }
}
