using Microsoft.AspNetCore.Mvc;
using NtlStudio.TreasureHunters.Game;

namespace NtlStudio.TreasureHunters.WebServer.Controllers;

[ApiController]
[Route("[controller]")]
public class GamesController : ControllerBase
{
    private readonly ILogger<GamesController> _logger;
    
    public GamesController(ILogger<GamesController> logger)
    {
        _logger = logger;
    }
    
    [HttpPost]
    [Route("[action]")]
    public IActionResult Create()
    {
        var game = new GameState(Guid.NewGuid());
        _logger.LogInformation($"A new game {game.Id} has been created.");
        return CreatedAtAction(nameof(Get), new {Id = game.Id}, game);
    }

    [HttpGet]
    [Route("{Id}")]
    public GameState Get(Guid id)
    {
        _logger.LogInformation($"Game {id} has been requested.");
        // returns hardcoded gamestate yet
        return new GameState(id);
    }
}