using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Microsoft.WindowsAzure.MobileServices;

public class SpawnCrashMarkers : MonoBehaviour
{
    [SerializeField]
    private GameObject markerPrefab;

    List<CrashInfo> crashesFromServer;
    IMobileServiceTable<CrashInfo> crashesTable;

    // Use this for initialization
    async void Start()
    {
        crashesTable = AzureMobileServiceClient.Client.GetTable<CrashInfo>();
        await Task.Run(InitializeCrashList);
        SpawnMarkersFromList();
    }

    private async Task InitializeCrashList()
    {
        Debug.Log("Downloading crash data from Azure...");
        crashesFromServer = await crashesTable.ToListAsync();
        Debug.Log("Done downloading.");
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
