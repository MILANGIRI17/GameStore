using GameStore.Api.Data;
using GameStore.Api.EndPoints;

var builder = WebApplication.CreateBuilder(args);

//Database
builder.AddGameStoreDb();

//Services
builder.Services.AddValidation();

var app = builder.Build();
app.MapGamesEndpoints();
app.MapGenresEndpoints();
//Migrating database on application start.
app.MigrateDb();
app.Run();