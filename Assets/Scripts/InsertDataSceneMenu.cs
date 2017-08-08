using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InsertDataSceneMenu : MonoBehaviour 
{

    public void RestartClicked()
    {
        SceneManager.LoadScene("InsertDataScene");
    }

    public void HeatmapButtonClicked()
    {
        SceneManager.LoadScene("ReadDataScene");
    }

    public void MenuButtonClicked()
    {
        SceneManager.LoadScene("MenuScene");

    }
}
