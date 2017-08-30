using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    public void RaceButtonClicked()
    {
        SceneManager.LoadScene("RaceScene");
    }

    public void HeatmapButtonClicked()
    {
        SceneManager.LoadScene("HeatmapScene");
    }

    public void LeaderboardButtonClicked()
    {
        SceneManager.LoadScene("LeaderboardScene");
    }

    public void ExitButtonClicked()
    {
        Application.Quit();
    }
}
