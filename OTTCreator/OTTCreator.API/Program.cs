using Microsoft.EntityFrameworkCore;
using OTTCreator.API;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("contentitems", async (ApplicationDbContext db) =>
    await db.ContentItems.ToListAsync());

app.MapGet("types", async (ApplicationDbContext db) =>
    await db.ContentItems.Select(c => c.Type).Distinct().ToListAsync());

app.MapGet("{type}/categories/", async (string type, ApplicationDbContext db) =>
    await db.ContentItems.Where(c => c.Type == type).Select(c => c.Category).Distinct().ToListAsync());

app.MapGet("{type}/{category}/contentitems", async (string type, string category, ApplicationDbContext db) =>
    await db.ContentItems.Where(c => c.Type == type && c.Category == category).ToListAsync());

app.MapGet("types/favorites", async (ApplicationDbContext db) =>
    await db.ContentItems.Where(c => c.IsFavorite).Select(c => c.Type).ToListAsync());

app.MapGet("types/recommended", async (ApplicationDbContext db) =>
    await db.ContentItems.Where(c => c.IsRecommended).Select(c => c.Type).ToListAsync());

app.MapGet("{type}/contentitems/favorites", async (string type, ApplicationDbContext db) =>
    await db.ContentItems.Where(c => c.Type == type && c.IsFavorite == true).ToListAsync());

app.MapGet("{type}/contentitems/recommended", async (string type, ApplicationDbContext db) =>
    await db.ContentItems.Where(c => c.Type == type && c.IsRecommended == true).ToListAsync());

app.MapGet("contentitems/{id}", async (int id, ApplicationDbContext db) =>
    await db.ContentItems.FindAsync(id)
        is ContentItem contentItem
            ? Results.Ok(contentItem)
            : Results.NotFound());

app.MapPut("contentitems/{id}/favorite", async (int id, ApplicationDbContext db) =>
{
    var contentItem = await db.ContentItems.FindAsync(id);
    if (contentItem is null) return Results.NotFound();
    contentItem.IsFavorite = !contentItem.IsFavorite;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
