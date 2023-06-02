public static class Constants
{
    public static string LocalhostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
    public static string Scheme = "http"; // or https
    public static string Port = "5217";
    public static string APIUrl = $"{Scheme}://{LocalhostUrl}:{Port}";
}
