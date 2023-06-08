namespace OTTCreator.WebApp.Repositories.Interfaces;

public interface IRepositoryWrapper
{
    IUserRepository UserRepository { get; }

    IContentRepository ContentRepository { get; }

    void Save();

    Task SaveAsync();
}
