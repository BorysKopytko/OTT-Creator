public static class Constants
{
    public const string databaseFileName = "OTTCreatorClientDatabase.db3";

    public const SQLite.SQLiteOpenFlags flags =
        SQLite.SQLiteOpenFlags.ReadWrite |
        SQLite.SQLiteOpenFlags.Create |
        SQLite.SQLiteOpenFlags.SharedCache |
        SQLite.SQLiteOpenFlags.ProtectionComplete;

    public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, databaseFileName);
}
