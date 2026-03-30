using GameStore.Api.Data;
using GameStore.Api.EndPoints;

var builder = WebApplication.CreateBuilder(args);

//Database
var connectionString = "Data Source=GameStore.db";
builder.Services.AddSqlite<GameStoreContext>(connectionString);

//Services
builder.Services.AddValidation();

var app = builder.Build();
app.MapGamesEndpoints();
//Migrating database on application start.
app.MigrateDb();
app.Run();