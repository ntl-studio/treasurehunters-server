using Azure;
using Azure.Data.Tables;
using NtlStudio.TreasureHunters.Game.Extensions;

namespace NtlStudio.TreasureHunters.Game;

public class GameRepository
{
    private readonly TableClient _tableClient;
    
    public GameRepository(string connectionString)
    {
        TableServiceClient tableServiceClient = new TableServiceClient(connectionString);
        _tableClient = tableServiceClient.GetTableClient(tableName: "GameState");
        _tableClient.CreateIfNotExists();
    }

    public GameState GetById(Guid gameId)
    {
        var tableEntity = _tableClient.GetEntity<TableEntity>("GameState", gameId.ToString("n"));
        return tableEntity.Value.ToGameState();
    }
    
    public GameState Create(GameState game)
    {
        _tableClient.AddEntity(game.ToTableEntity());
        return game;
    }
    
    public GameState Update(GameState game)
    {
        _tableClient.UpdateEntity(game.ToTableEntity(), ETag.All, TableUpdateMode.Replace);
        return game;
    }
}