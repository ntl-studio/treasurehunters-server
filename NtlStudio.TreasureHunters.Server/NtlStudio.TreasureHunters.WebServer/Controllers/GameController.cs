using Microsoft.AspNetCore.Mvc;
using NtlStudio.TreasureHunters.Game;

namespace NtlStudio.TreasureHunters.WebServer.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly ILogger<GameController> _logger;
    
    public GameController(ILogger<GameController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public GameState Get(Guid gameId)
    {
        _logger.LogTrace($"Game {gameId} has been requested");
        // returns hardcoded gamestate yet
        return new GameState(gameId);
    }
}