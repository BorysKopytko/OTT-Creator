using Microsoft.Maui.Devices;
public static class Constants
{
    public static string LocalhostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
    public static string Scheme = "https"; // або http
    public static string Port = "7075"; // або 5217
    public static string WebAPIUrl = $"{Scheme}://{LocalhostUrl}:{Port}";
}
