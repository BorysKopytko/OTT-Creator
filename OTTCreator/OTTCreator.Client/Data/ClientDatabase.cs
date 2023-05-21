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

        public async Task<ContentItem> GetItemAsync(int id)
        {
            await Init();
            return await clientDatabase.Table<ContentItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(ContentItem item)
        {
            await Init();
            if (item.ID != 0)
                return await clientDatabase.UpdateAsync(item);
            else
                return await clientDatabase.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(ContentItem item)
        {
            await Init();
            return await clientDatabase.DeleteAsync(item);
        }
    }
}
