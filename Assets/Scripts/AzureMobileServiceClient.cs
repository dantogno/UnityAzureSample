using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.WindowsAzure.MobileServices;

public static class AzureMobileServiceClient
{
    // Either use mozroots / cert-syc to update your Unity mono certificate store,
    // or set ignoreTls to true to ignore security certificate errors.
    private const bool ignoreTls = true;
    private const string backendUrl = "http://unitytestmobileapp.azurewebsites.net";
    private static MobileServiceClient client;

    public static MobileServiceClient Client
    {
        get
        {
            if (client == null)
            {
                if (ignoreTls)
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => { return true; };
                }
                client = new MobileServiceClient(backendUrl);
            }

            return client;
        }
    }
}
