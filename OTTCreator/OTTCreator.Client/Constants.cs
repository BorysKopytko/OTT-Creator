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

    public const bool isTestDataNeeded = true;

    public static string LocalhostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
    public static string Scheme = "http"; // or http
    public static string Port = "5217";
    public static string APIUrl = $"{Scheme}://{LocalhostUrl}:{Port}/";
}
