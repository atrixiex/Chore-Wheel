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

    [HttpGet("Users")]
    public async Task<ActionResult<List<ChoreDifficultyDto>>> GetUsers([FromQuery]bool includeActivated = false)
    {
        return Ok(await _userManagementService.GetUsers(includeActivated));
    }

    [HttpGet("Users/{id}/activate")]
    public async Task<ActionResult> ActivateUser(string id)
    {
        return await _userManagementService.ActivateUser(id);
    }

    [HttpGet("Users/{id}/disable")]
    public async Task<ActionResult> DisableUser(string id)
    {
        return await _userManagementService.DisableUser(id);
    }
}
