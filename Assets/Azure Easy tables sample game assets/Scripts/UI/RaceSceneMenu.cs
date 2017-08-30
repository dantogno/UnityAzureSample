using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceSceneMenu : MonoBehaviour 
{

    public void RestartClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void HeatmapButtonClicked()
    {
        SceneManager.LoadScene("HeatmapScene");
    }

    public void LeaderboardButtonClicked()
    {
        SceneManager.LoadScene("LeaderboardScene");
    }

    public void MenuButtonClicked()
    {
        SceneManager.LoadScene("MenuScene");

    }
}
