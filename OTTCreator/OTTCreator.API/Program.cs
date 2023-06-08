using Microsoft.EntityFrameworkCore;
using OTTCreator.WebAPI.Models;

var WebAPIKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("WebAPIKey").Value;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationIdentityDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

async Task<User> GetUserAsync(ApplicationIdentityDbContext db, string code)
{
    var codesAndUsersIds = db.Users.Select(x => new { Codes = x.CodesAndUse, Id = x.Id }).ToList();
    var userCodesAndId = codesAndUsersIds.Where(x => x.Codes.Keys.Contains(Guid.Parse(code))).ToList();
    var user = await db.Users.FirstOrDefaultAsync(x => x.Id == userCodesAndId.FirstOrDefault().Id);
    return user;
}

app.MapPut("activate/{activateOrDeactivate}/{WebAPIkey}/{code}", async (bool activateOrDeactivate, string WebAPIkey, string code, ApplicationIdentityDbContext db) =>
{
    if (WebAPIkey == WebAPIKey)
    {
        var user = await GetUserAsync(db, code);
        if (user != null)
        {
            if ((user.CodesAndUse[Guid.Parse(code)] != activateOrDeactivate))
            {
                user.CodesAndUse[Guid.Parse(code)] = activateOrDeactivate;
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

app.MapGet("contentitems/{WebAPIkey}/{code}", async (string WebAPIkey, string code, ApplicationIdentityDbContext db) =>
{
    if (WebAPIkey == WebAPIKey)
    {
        var user = await GetUserAsync(db, code);
        if (user != null && user.IsAllowed)
            return await db.ContentItems.ToListAsync();
    }
    return null;
});

app.MapGet("types/{WebAPIkey}/{code}", async (string WebAPIkey, string code, ApplicationIdentityDbContext db) =>
{
    if (WebAPIkey == WebAPIKey)
    {
        var user = await GetUserAsync(db, code);
        if (user != null && user.IsAllowed)
        {
            return Enumerable.Reverse(await db.ContentItems.Select(c => c.Type).Distinct().AsQueryable().ToListAsync());
        }       
    }
    return null;
});

app.MapGet("{type}/categories/{WebAPIkey}/{code}", async (string type, string WebAPIkey, string code, ApplicationIdentityDbContext db) =>
{
    if (WebAPIkey == WebAPIKey)
    {
        var user = await GetUserAsync(db, code);
        if (user != null && user.IsAllowed)
            return await db.ContentItems.Where(c => c.Type == type).Select(c => c.Category).Distinct().ToListAsync();
    }
    return null;
});

app.MapGet("{type}/{category}/contentitems/{WebAPIkey}/{code}", async (string type, string category, string WebAPIkey, string code, ApplicationIdentityDbContext db) =>
{
    if (WebAPIkey == WebAPIKey )
    {
        var user = await GetUserAsync(db, code);
        if (user != null && user.IsAllowed)
            return await db.ContentItems.Where(c => c.Type == type && c.Category == category).ToListAsync();
    }
    return null;
});

app.MapGet("{type}/contentitems/favorites/{WebAPIkey}/{code}", async (string type, string WebAPIkey, string code, ApplicationIdentityDbContext db) =>
{
    if (WebAPIkey == WebAPIKey)
    {
        var user = await GetUserAsync(db, code);
        if (user != null && user.IsAllowed)
            return await db.ContentItems.Where(c => c.Type == type && user.FavoriteContentItemsIDs.Contains(c.ID)).ToListAsync();
    }
    return null;
});

app.MapGet("contentitems/{id}/{WebAPIkey}/{code}", async (int id, string WebAPIkey, string code, ApplicationIdentityDbContext db) =>
{
    if (WebAPIkey == WebAPIKey)
    {
        var user = await GetUserAsync(db, code);
        if (user != null && user.IsAllowed)
        {
            var contentItem = await db.ContentItems.FindAsync(id);
            if (contentItem != null)
                return Results.Ok(contentItem);
        }
    }
    return Results.NotFound();
});

app.MapPut("contentitems/{id}/favorite/{WebAPIkey}/{code}", async (int id, string WebAPIkey, string code, ApplicationIdentityDbContext db) =>
{
    if (WebAPIkey == WebAPIKey)
    {
        var contentItem = await db.ContentItems.FindAsync(id);
        if (contentItem is null) return Results.NotFound();
        var user = await GetUserAsync(db, code);
        if (user != null && user.IsAllowed)
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
