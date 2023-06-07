namespace OTTCreator.WebApp.Repositories.Interfaces;

public interface IRepositoryWrapper
{
    IUserRepository UserRepository { get; }

    void Save();

    Task SaveAsync();
}
