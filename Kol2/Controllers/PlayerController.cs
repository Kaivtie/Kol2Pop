using Kol2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kol2.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IGetPlayer _palyerMatches;
    
    public PlayerController(IGetPlayer playerMatches)
    {
        _palyerMatches = playerMatches;
    }
    
    [HttpGet("{id}/matches")]
    public async Task<IActionResult> GetPlayerMatches(int id)
    {
        var player = await _palyerMatches.GetPlayerMatchesInfo(id);
        return Ok(player);
    }
}