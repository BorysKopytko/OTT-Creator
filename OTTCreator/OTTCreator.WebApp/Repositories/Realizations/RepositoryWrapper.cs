using OTTCreator.WebApp.Data;
using OTTCreator.WebApp.Repositories.Interfaces;

namespace OTTCreator.WebApp.Repositories.Realizations;

public class RepositoryWrapper : IRepositoryWrapper
{
    private ApplicationIdentityDbContext _dbContext;

    private IUserRepository _userRepository;

    private IContentRepository _contentRepository;

    public IUserRepository UserRepository
    {
        get
        {
            if (_userRepository == null)
                _userRepository = new UserRepository(_dbContext);
            return _userRepository;
        }
    }

    public IContentRepository ContentRepository
    {
        get
        {
            if (_contentRepository == null)
                _contentRepository = new ContentRepository(_dbContext);
            return _contentRepository;
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
