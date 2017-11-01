using Microsoft.WindowsAzure.MobileServices;

public static class AzureMobileServiceClient
{
    // Use mozroots / cert-syc to update your Unity Mono certificate store!
    private const string backendUrl = "MOBILE_APP_URL";
    private static MobileServiceClient client;

    public static MobileServiceClient Client
    {
        get
        {
            if (client == null)
            {
                client = new MobileServiceClient(backendUrl);
            }

            return client;
        }
    }
}
