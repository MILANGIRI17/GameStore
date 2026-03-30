using GameStore.Api.Data;
using GameStore.Api.EndPoints;
using GameStore.Api.Models;

var builder = WebApplication.CreateBuilder(args);

//Database
var connectionString = "Data Source=GameStore.db";
builder.Services.AddSqlite<GameStoreContext>(
    connectionString,
    optionsAction: options => options.UseSeeding((context, _) =>
    {
        if (!context.Set<Genre>().Any())
        {
            context.Set<Genre>()
            .AddRange
            (
                new Genre{ Name = "Fighting"},
                new Genre{ Name = "RPG"},
                new Genre{ Name = "Platformer"},
                new Genre{ Name = "Racing"},
                new Genre{ Name = "Sports"}
            );
            context.SaveChanges();
        }
    }));

//Services
builder.Services.AddValidation();

var app = builder.Build();
app.MapGamesEndpoints();
//Migrating database on application start.
app.MigrateDb();
app.Run();