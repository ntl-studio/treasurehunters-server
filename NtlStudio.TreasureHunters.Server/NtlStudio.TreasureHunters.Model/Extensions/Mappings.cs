using Azure.Data.Tables;
using Newtonsoft.Json;

namespace NtlStudio.TreasureHunters.Game.Extensions;

public static class Mappings
{
    public static ITableEntity ToTableEntity(this GameState gameState)
    {
        var result = new TableEntity("GameState", gameState.Id.ToString("n"))
        {
            { 
                "GameField", JsonConvert.SerializeObject(gameState.GameField, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                    }
                ) 
            },
            {
                "Players", JsonConvert.SerializeObject(gameState.Players, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                    }
                )
            },
            {
                "IsRunning", gameState.IsRunning
            }
        };
        return result;
    }
    
    public static GameState ToGameState(this TableEntity entity)
    {
        var players = JsonConvert.DeserializeObject<User[]>((string)entity["Players"]);
        var gameField = JsonConvert.DeserializeObject<FieldCell[,]>((string)entity["GameField"]); 
        var transformedGameField = new FieldCell[gameField!.GetLength(1), gameField.GetLength(0)];
        for (var x = 0; x < gameField.GetLength(1); x++)
        {
            for (var y = 0; y < gameField.GetLength(0); y++)
            {
                transformedGameField[x, y] = gameField[y, x];
            }
        }
        var isRunning = entity.GetBoolean("IsRunning");
        return new GameState(Guid.Parse(entity.RowKey), isRunning.HasValue && isRunning.Value, players, 
            new GameField(transformedGameField));
    }
}