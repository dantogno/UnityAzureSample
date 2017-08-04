using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.WindowsAzure.MobileServices;

public static class AzureMobileServiceClient
{
    private const string backendUrl = "http://dpa-mobile-app-test1.azurewebsites.net";

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
