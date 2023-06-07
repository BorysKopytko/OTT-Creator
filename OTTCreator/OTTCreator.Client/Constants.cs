public static class Constants
{
    public static string LocalhostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
    public static string Scheme = "https"; // or http
    public static string Port = "7075"; // or 5217
    public static string APIUrl = $"{Scheme}://{LocalhostUrl}:{Port}";
}
