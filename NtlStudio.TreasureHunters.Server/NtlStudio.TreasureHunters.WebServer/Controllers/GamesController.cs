using Microsoft.AspNetCore.Mvc;
using NtlStudio.TreasureHunters.Game;

namespace NtlStudio.TreasureHunters.WebServer.Controllers;

[ApiController]
[Route("[controller]")]
public class GamesController : ControllerBase
{
    private readonly ILogger<GamesController> _logger;
    private readonly IConfiguration _configuration;
    
    public GamesController(ILogger<GamesController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }
    
    [HttpPost]
    [Route("[action]")]
    public IActionResult Create()
    {
        var repository = new GameRepository(_configuration.GetConnectionString("CosmosConnectionString"));
        var game  = repository.Create(new GameState(Guid.NewGuid()));
        _logger.LogInformation($"A new game {game.Id} has been created.");
        return CreatedAtAction(nameof(Get), new {Id = game.Id}, game);
    }

    [HttpGet]
    [Route("{id}")]
    public GameState Get(Guid id)
    {
        _logger.LogInformation($"Game {id} has been requested.");
        var repository = new GameRepository(_configuration.GetConnectionString("CosmosConnectionString"));
        return repository.GetById(id);
    }
    
    [HttpPut]
    [Route("{id}/[action]/{name}")]
    public User AddUser(Guid id, string name)
    {
        var repository = new GameRepository(_configuration.GetConnectionString("CosmosConnectionString"));
        var gameState = repository.GetById(id);
        var user = gameState.RegisterUser(name);
        repository.Update(gameState);
        _logger.LogInformation($"User {name} has been registered to game {id}.");
        // returns hardcoded user yet
        return user;
    }

    [HttpPut]
    [Route("{id}/[action]")]
    public GameState Start(Guid id)
    {
        var repository = new GameRepository(_configuration.GetConnectionString("CosmosConnectionString"));
        var gameState = repository.GetById(id);
        if (!gameState.Start())
            throw new InvalidOperationException("Something went wrong while starting the game.");
        repository.Update(gameState);
        return gameState;
    }
}