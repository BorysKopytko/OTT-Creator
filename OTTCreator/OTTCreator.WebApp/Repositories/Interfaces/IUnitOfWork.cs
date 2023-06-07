namespace OTTCreator.WebApp.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<int> Commit();
}
