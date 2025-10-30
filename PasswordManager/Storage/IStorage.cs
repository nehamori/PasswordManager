namespace PasswordManager.Storage
{
    internal interface IStorage
    {
        void GetMe();

        void ListPasswords();

        PasswordData GetPasswordData(int id);

        void SavePasswordData(PasswordData passwordData);

    }
}
