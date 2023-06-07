using OTTCreator.WebApp.Data;
using OTTCreator.WebApp.Repositories.Interfaces;

namespace OTTCreator.WebApp.Repositories.Realizations;

public class RepositoryWrapper : IRepositoryWrapper
{
    private ApplicationIdentityDbContext _dbContext;

    private IUserRepository _userRepository;

    public IUserRepository UserRepository
    {
        get
        {
            if (_userRepository == null)
            {
                _userRepository = new UserRepository(_dbContext);
            }
            return _userRepository;
        }
    }

    public RepositoryWrapper(ApplicationIdentityDbContext applicationDBContext)
    {
        _dbContext = applicationDBContext;
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
