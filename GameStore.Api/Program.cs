using GameStore.Api.Dtos;

const string GetGameEnpointName = "GetGame";

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new(1, "Street Fighter II", "Fighting", 19.99m, new DateOnly(1992, 7, 15)),
    new(2, "Final Fantasy VII Rebirth", "RPG", 69.99m, new DateOnly(2024, 2, 29)),
    new(3, "Astro Bot", "Platformer", 59.99m, new DateOnly(2024, 9, 6)),
];

//GET /games
app.MapGet("/games", () => games);

//GET /games/1
app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id))
.WithName(GetGameEnpointName);

//POST /games
app.MapPost("/games", (CreateGameDto newGame) =>
{
    GameDto game = new(games.Count + 1, newGame.Name, newGame.Genre,newGame.Price, newGame.ReleaseDate);
    games.Add(game);
    return Results.CreatedAtRoute(GetGameEnpointName, new {id = game.Id}, game);
});

//Update /games/1
app.MapPut("/games/{id}", (int id, UpdateGameDto updateGame) =>
{
    var index = games.FindIndex(g=> g.Id == id);
    games[index]= new GameDto(
        id,
        updateGame.Name,
        updateGame.Genre,
        updateGame.Price,
        updateGame.ReleaseDate
    );
    return Results.NoContent();
});

//Delete /games/1
app.MapDelete("/games/{id}", (int id) =>
{
    var index = games.FindIndex(game=> game.Id == id);
    if(index == -1) return Results.NotFound("Game not found");
    games.RemoveAt(index);
    return Results.NoContent();
});



app.Run();