using Microsoft.EntityFrameworkCore;
using OTTCreator.API.Models;

var APIKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("APIKey").Value;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication();
builder.Services.AddDbContext<ApplicationIdentityDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

async Task<User> GetUser(ApplicationIdentityDbContext db, string code)
{
    var codesAndUsersIds = db.Users.Select(x => new { Codes = x.CodesAndUse, Id = x.Id }).ToList();
    var userCodesAndId = codesAndUsersIds.Where(x => x.Codes.Keys.Contains(Guid.Parse(code))).ToList();
    var user = await db.Users.FirstOrDefaultAsync(x => x.Id == userCodesAndId.FirstOrDefault().Id);
    return user;
}

app.MapPut("activate/{apikey}/{code}", async (string apikey, string code, ApplicationIdentityDbContext db) =>
{
    if (apikey == APIKey)
    {
        var user = await GetUser(db, code);
        if (user != null)
        {
            if (user.CodesAndUse[Guid.Parse(code)] != true)
            {
                user.CodesAndUse[Guid.Parse(code)] = true;
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Results.Ok();
            }
            return Results.Forbid();
        }
        return Results.Unauthorized();
    }
    return Results.Unauthorized();
});

app.MapGet("contentitems/{apikey}/{code}", async (string apikey, string code, ApplicationIdentityDbContext db) =>
{
    if (apikey == APIKey)
    {
        var user = await GetUser(db, code);
        if (user != null)
            return await db.ContentItems.ToListAsync();
    }
    return null;
});

app.MapGet("types/{apikey}/{code}", async (string apikey, string code, ApplicationIdentityDbContext db) =>
{
    if (apikey == APIKey)
    {
        var user = await GetUser(db, code);
        if (user != null)
            return await db.ContentItems.Select(c => c.Type).Distinct().ToListAsync();
    }
    return null;
});

app.MapGet("{type}/categories/{apikey}/{code}", async (string type, string apikey, string code, ApplicationIdentityDbContext db) =>
{
    if (apikey == APIKey)
    {
        var user = await GetUser(db, code);
        if (user != null)
            return await db.ContentItems.Where(c => c.Type == type).Select(c => c.Category).Distinct().ToListAsync();
    }
    return null;
});

app.MapGet("{type}/{category}/contentitems/{apikey}/{code}", async (string type, string category, string apikey, string code, ApplicationIdentityDbContext db) =>
{
    if (apikey == APIKey)
    {
        var user = await GetUser(db, code);
        if (user != null)
            return await db.ContentItems.Where(c => c.Type == type && c.Category == category).ToListAsync();
    }
    return null;
});

app.MapGet("{type}/contentitems/favorites/{apikey}/{code}", async (string type, string apikey, string code, ApplicationIdentityDbContext db) =>
{
    if (apikey == APIKey)
    {
        var user = await GetUser(db, code);
        if (user != null)
            return await db.ContentItems.Where(c => c.Type == type && user.FavoriteContentItemsIDs.Contains(c.ID)).ToListAsync();
    }
    return null;
});

app.MapGet("{type}/contentitems/recommended/{apikey}/{code}", async (string type, string apikey, string code, ApplicationIdentityDbContext db) =>
{
    if (apikey == APIKey)
    {
        var user = await GetUser(db, code);
        if (user != null)
            return await db.ContentItems.Where(c => c.Type == type && user.RecommendedContentItemsIDs.Contains(c.ID)).ToListAsync();
    }
    return null;
});

app.MapGet("contentitems/{id}/{apikey}/{code}", async (int id, string apikey, string code, ApplicationIdentityDbContext db) =>
{
    if (apikey == APIKey)
    {
        var user = await GetUser(db, code);
        if (user != null)
        {
            var contentItem = await db.ContentItems.FindAsync(id);
            if (contentItem != null)
                return Results.Ok(contentItem);
        }
    }
    return Results.NotFound();
});

app.MapPut("contentitems/{id}/favorite/{apikey}/{code}", async (int id, string apikey, string code, ApplicationIdentityDbContext db) =>
{
    if (apikey == APIKey)
    {
        var contentItem = await db.ContentItems.FindAsync(id);
        if (contentItem is null) return Results.NotFound();
        var user = await GetUser(db, code);
        if (user != null)
        {
            if (user.FavoriteContentItemsIDs.Contains(id))
                user.FavoriteContentItemsIDs.Remove(id);
            else
                user.FavoriteContentItemsIDs.Add(id);
            db.Entry(user).State = EntityState.Modified;
            await db.SaveChangesAsync();

        }
        return Results.NoContent();
    }
    return Results.Unauthorized();
});

app.Run();
