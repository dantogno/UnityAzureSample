# Test the client connection

Now that the AzureMobileServiceClient singleton is created, it's time to test the client connection.

## Create the TestClientConnection script

1. Right click the Scripts folder in the Unity project window and create a new C# script called **TestClientConnection**.

2. Open the script in Visual Studio, delete any template code, and add the following:
  ```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Linq;

public class TestClientConnection : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Task.Run(TestTableConnection);
    }

    private async Task TestTableConnection()
    {
        var table = AzureMobileServiceClient.Client.GetTable<CrashInfo>();
        try
        {
            await table.InsertAsync(new CrashInfo { Id = "testCrash", X = 1, Y = 2, Z = 3 });
        }
        catch (Exception e)
        {
            Debug.Log("Error inserting item: " + e.Message);
        }

        var allCrashes = new List<CrashInfo>();

        try
        {
            var list = await table.ToListAsync();
            foreach (var crash in list)
            {
                allCrashes.Add(crash);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Error fetching crashes" + e.Message);
        }

        var testCrashInfo = allCrashes.Where(crash => crash.Id == "testCrash").FirstOrDefault();

        Debug.Log("Test crash ID: " + testCrashInfo.Id);

        Debug.Assert(testCrashInfo.Id == "testCrash");
    }
}
  ```
