using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadDataSceneMenu : MonoBehaviour 
{
    public void BackButtonClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
