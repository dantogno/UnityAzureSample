using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Linq;

public class TestClientConnection : MonoBehaviour
{
	void Start ()
    {
        Task.Run(TestTableConnection);
	}
    
    private async Task TestTableConnection()
    {
        var testCrashID = "testCrash";

        var table = AzureMobileServiceClient.Client.GetTable<CrashInfo>();
        try
        {
            await table.InsertAsync(new CrashInfo { Id = testCrashID, X = 1, Y = 2, Z = 3 });
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

        var testCrashInfo = allCrashes.Where(crash => crash.Id == testCrashID).FirstOrDefault();

        Debug.Log("Test crash ID: " + testCrashInfo.Id);

        Debug.Assert(testCrashInfo.Id == testCrashID);
    }
}
