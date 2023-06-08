using OTTCreator.WebApp.Areas.Identity.Data;
using OTTCreator.WebApp.Data;
using OTTCreator.WebApp.Models;
using OTTCreator.WebApp.Repositories.Interfaces;

namespace OTTCreator.WebApp.Repositories.Realizations;

public class ContentRepository : GenericRepository<ContentItem>, IContentRepository
{
    public ContentRepository(ApplicationIdentityDbContext dbContext) : base(dbContext) { }
}
