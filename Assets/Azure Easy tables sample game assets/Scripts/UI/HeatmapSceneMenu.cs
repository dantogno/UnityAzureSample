using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeatmapSceneMenu : MonoBehaviour 
{
    [SerializeField]
    Heatmap heatmap;

    public void BackButtonClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ClearButtonClicked()
    {
        heatmap.DeleteCrashDataAsync();
    }
}
