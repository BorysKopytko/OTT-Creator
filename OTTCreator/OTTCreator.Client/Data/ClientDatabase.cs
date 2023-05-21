using OTTCreator.Client.Models;
using SQLite;

namespace OTTCreator.Client.Data
{
    public class ClientDatabase
    {
        SQLiteAsyncConnection clientDatabase;

        public ClientDatabase() { }

        async Task Init()
        {
            if (clientDatabase is not null)
                return;

            clientDatabase = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.flags);
            var result = await clientDatabase.CreateTableAsync<ContentItem>();
        }

        public async Task<List<ContentItem>> GetItemsAsync()
        {
            await Init();
            return await clientDatabase.Table<ContentItem>().ToListAsync();
        }
    }
}
