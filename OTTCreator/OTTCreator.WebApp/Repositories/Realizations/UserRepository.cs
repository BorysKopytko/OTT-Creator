using OTTCreator.WebApp.Areas.Identity.Data;
using OTTCreator.WebApp.Data;
using OTTCreator.WebApp.Repositories.Interfaces;

namespace OTTCreator.WebApp.Repositories.Realizations;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationIdentityDbContext dbContext) : base(dbContext) { }
}
