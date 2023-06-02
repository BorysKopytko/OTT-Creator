namespace OTTCreator.Client.Services
{
    public class HttpsClientHandlerService
    {
        public HttpMessageHandler GetPlatformMessageHandler()
        {
#if ANDROID
#if NET7_0_OR_GREATER
            var handler = new Xamarin.Android.Net.AndroidMessageHandler();
#endif
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, Errors) =>
            {
                if (cert != null && cert.Issuer.Equals("CN=localhost"))
                    return true;
                return Errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
#elif WINDOWS
            return null;
#else
            throw new PlatformNotSupportedException("Only Android and Windows supported.");
#endif
        }
    }
}
