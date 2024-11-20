using SQLite;
using advertising_agency.Models;

namespace advertising_agency.Services.Database;

public static class ConnectionService
{
    private static SQLiteAsyncConnection? _database;

    public static async Task<SQLiteAsyncConnection> GetDatabaseConnectionAsync()
    {
        if (_database != null) 
        {
          return _database;
        }

        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ads.db3");
        _database = new SQLiteAsyncConnection(dbPath);
        await _database.CreateTableAsync<AdCampaign>();

        return _database;
    }
}
