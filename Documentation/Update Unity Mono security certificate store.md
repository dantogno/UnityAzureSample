# Update Unity Mono security certificate store

In the `AzureMobileServiceClient` script, the following code was used to ignore TLS and SSL errors:

```csharp
if (ignoreTls)
{
    System.Net.ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => { return true; };
}
```

This is necessary because Unity's Mono ships with an empty certificate store and therefore does not trust any site. You can read more about this on the [Mono security FAQ](http://www.mono-project.com/docs/faq/security/).

In order to connect to Azure without ignoring TLS / SSL, the Unity Mono certificate store must be updated.

## Using mozroots to install certificates

The mozroots tool is included in Mono. It downloads and installs Mozilla's list of root certificates.

1. Open the command prompt terminal.

2. Navigate in the terminal to the **C:\Program Files\Unity\Editor\Data\MonoBleedingEdge\bin>** directory. The exact location may differ depending on where you installed Unity on your local machine.

3. Type the following command and hit **Enter** to run it:

  `mono ..\lib\mono\4.5\mozroots.exe --sync --import`

4. You should get the following output (though the number or certificates added may differ):

  ```
  Downloading from 'https://hg.mozilla.org/releases/mozilla-release/raw-file/default/security/nss/lib/ckfw/builtins/certdata.txt'...
  Importing certificates into user store...
  1 new root certificates were added to your trust store.
  Import process completed.
  ```

5. Now you should be able to set `ignoreTls` to false in `AzureMobileServiceClient.cs` and run the example without receiving TLS related errors.

## Next steps

* [Test the client connection](Test%20the%20client%20connection.md)
