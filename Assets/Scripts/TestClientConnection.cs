using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices;

public class TestClientConnection : MonoBehaviour
{
    void Start()
    {
        Task.Run(TestTableConnection);
    }

    private async Task TestTableConnection()
    {
        var table = AzureMobileServiceClient.Client.GetTable<CrashInfo>();

        Debug.Log("Testing ToListAsync...");
        await TestToListAsync(table);

        Debug.Log("Testing InsertAsync...");
        await TestInsertAsync(table);

        Debug.Log("Testing DeleteAsync...");
        await TestDeleteAsync(table);

        Debug.Log("All testing complete.");
    }

    private async Task TestInsertAsync(IMobileServiceTable<CrashInfo> table)
    {
        try
        {
            var allEntries = await TestToListAsync(table);
            var initialCount = allEntries.Count();

            await table.InsertAsync(new CrashInfo { X = 1, Y = 2, Z = 3 });

            allEntries = await TestToListAsync(table);
            var newCount = allEntries.Count();

            Debug.Assert(newCount == initialCount + 1, "InsertAsync failed!");
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<List<CrashInfo>> TestToListAsync(IMobileServiceTable<CrashInfo> table)
    {
        try
        {
            var allEntries = await table.ToListAsync();
            Debug.Assert(allEntries != null, "ToListAsync failed!");
            return allEntries;
        }
        catch (Exception)
        {

            throw;
        }
    }

    private async Task TestDeleteAsync(IMobileServiceTable<CrashInfo> table)
    {
        var allEntries = await TestToListAsync(table);

        foreach (var item in allEntries)
        {
            try
            {
                await table.DeleteAsync(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        allEntries = await TestToListAsync(table);

        Debug.Assert(allEntries.Count() == 0, "DeleteAsync failed!");
    }
}