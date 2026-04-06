using GameStore.Api.Data;
using GameStore.Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.EndPoints;

public static class GenreEndpoints
{
    public static void MapGenreEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/genres");

        //Get /generes
        group.MapGet("/", async (GameStoreContext dbContext) => await dbContext.Genres.Select(genre => new GenreDto(genre.Id, genre.Name)).AsNoTracking().ToListAsync());
    }
}
