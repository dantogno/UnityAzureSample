using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Microsoft.WindowsAzure.MobileServices;

public class SpawnCrashMarkers : MonoBehaviour
{
    [SerializeField]
    private GameObject markerPrefab;

    [SerializeField]
    int numberOfAttempts = 3;

    List<CrashInfo> crashesFromServer;
    IMobileServiceTable<CrashInfo> crashesTable;

    async void Start()
    {
        crashesTable = AzureMobileServiceClient.Client.GetTable<CrashInfo>();
        await Task.Run(InitializeCrashListAsync);
        SpawnMarkersFromList();
    }

    private async Task InitializeCrashListAsync()
    {
        Debug.Log("Downloading crash data from Azure...");

        for (int i = 0; i < numberOfAttempts; i++)
        {
            try
            {
                Debug.Log("Connecting... attempt " + (i +1));
                crashesFromServer = await crashesTable.ToListAsync();
                Debug.Log("Done downloading.");
                return;
            }
            catch (System.Exception e)
            {
                Debug.Log("Error connecting: " + e.Message);
            }

            if (i == numberOfAttempts - 1)
                Debug.Log("Connection failed. Check logs, try again later.");
            else
                await Task.Delay(500);
        }
    }

    private void SpawnMarkersFromList()
    {
        foreach (var item in crashesFromServer)
        {
            GameObject marker = GameObject.Instantiate(markerPrefab);
            marker.transform.position = new Vector3 { x = item.X, y = item.Y, z = item.Z };
        }
    }

}
