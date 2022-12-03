using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UberApp.Models
{
    public class DatabaseSqLite
    {
        private readonly SQLiteAsyncConnection _database;
        public DatabaseSqLite(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Request>();
        }

        public Task<int> AddRequest(Request request)
        {
            return _database.InsertAsync(request);
        }

        public Task<List<Request>> GetRequests()
        {
            return _database.Table<Request>()
                .Where(x => x.Finished == false)
                .ToListAsync();
        }
    }
}
