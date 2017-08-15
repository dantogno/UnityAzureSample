using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardMenu : MonoBehaviour 
{
    public void BackButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public async void ResetButtonClicked()
    {
        await Leaderboard.DeleteAllEntriesAsync();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
