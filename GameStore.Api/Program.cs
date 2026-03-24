var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//GET /games
app.MapGet("/games", () => {
    return "Hello World!";
  });

app.Run();
