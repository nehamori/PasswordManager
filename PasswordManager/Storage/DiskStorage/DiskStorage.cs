using Microsoft.Data.Sqlite;

namespace PasswordManager.Storage.DiskStorage
{
    internal class DiskStorage
    {
        private SqliteConnection _connection;

        public DiskStorage(string path)
        {
            string connectionString = $"Data Source={path}";
            _connection = new SqliteConnection(connectionString);
        }
    }
}
