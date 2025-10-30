using SQLite;

namespace PasswordManager.Storage.DiskStorage
{
    public class CheckPasswordIntegrity {
        [PrimaryKey, AutoIncrement]
        public required string CheckString { get; set; }
    }
}
