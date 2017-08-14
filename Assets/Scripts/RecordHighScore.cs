using System.Collections;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Linq;
using UnityEngine.UI;

public class RecordHighScore : MonoBehaviour 
{
    [SerializeField]
    private int numberOfAttempts = 3;

    [SerializeField]
    private InputField nameInputField;

    [SerializeField]
    private CanvasGroup enterNamePopup;

    private IMobileServiceTable<HighScoreInfo> highScoreTable;
    private List<HighScoreInfo> highScores;
    private string playerName = string.Empty;

    private const int sizeOfHighScoreList = 10;

    private async void Start()
    {
        ShowEnterNamePopup(false);

        highScoreTable = AzureMobileServiceClient.Client.GetTable<HighScoreInfo>();
        await Task.Run(DownloadHighScores);
    }

    private void ShowEnterNamePopup(bool shouldShow)
    {
        enterNamePopup.alpha = shouldShow ? 1 : 0;
        enterNamePopup.interactable = shouldShow;
    }

    public void SubmitButtonClicked()
    {
        playerName = nameInputField.text;
    }

    private async Task DownloadHighScores()
    {
        Debug.Log("Downloading high score data from Azure...");

        for (int i = 0; i < numberOfAttempts; i++)
        {
            try
            {
                Debug.Log("Connecting... attempt " + (i + 1));

                highScores = await highScoreTable
                    .OrderBy(item => item.Time)
                    .Take(sizeOfHighScoreList)
                    .ToListAsync();

                Debug.Log("Done downloading high score data.");
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

    private async void OnAfterMostRecentScoreSet(float newScore)
    {
        bool isNewHighScore = CheckForNewHighScore(newScore);

        if (isNewHighScore)
        {
            await GetPlayerNameAsync();
            await UpdateHighScoreTableAsync(newScore);
        }
    }

    private async Task GetPlayerNameAsync()
    {
        // Wait a bit before showing the popup.
        // This just helps the player experience feel
        // less jarring.
        await Task.Delay(2000);
        ShowEnterNamePopup(true);

        // Wait until the player enters a name and clicks submit.
        // OnSubmitButtonClicked will set the playerName.
        while (playerName == string.Empty)
        {
            await Task.Delay(100);
        }

        ShowEnterNamePopup(false);
    }

    private bool CheckForNewHighScore(float newScore)
    {
        bool noHighScores = highScores.Count() == 0;
        var lowerScores = highScores.Where(x => x.Time > newScore);

        return lowerScores.Count() > 0 || noHighScores;
    }

    private async Task UpdateHighScoreTableAsync(float newScore)
    {
        var newHighScoreInfo = new HighScoreInfo { Name = playerName, Time = newScore };

        try
        {
            Debug.Log("Uploading high score data to Azure...");

            await highScoreTable.InsertAsync(newHighScoreInfo);

            Debug.Log("Finished uploading high score data.");
        }
        catch (System.Exception e)
        {
            Debug.Log("Error uploading high score data: " + e.Message);
        }
    }

    private void OnEnable()
    {
        LapTimer.AfterMostRecentScoreSet += OnAfterMostRecentScoreSet;
    }

    private void OnDisable()
    {
        LapTimer.AfterMostRecentScoreSet -= OnAfterMostRecentScoreSet;
    }

}
