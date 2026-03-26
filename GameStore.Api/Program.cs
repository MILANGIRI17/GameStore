using GameStore.Api.EndPoints;

var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.AddValidation();

var app = builder.Build();
app.MapGamesEndpoints();
app.Run();