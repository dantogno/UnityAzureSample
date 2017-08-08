using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    public void InsertButtonClicked()
    {
        SceneManager.LoadScene("InsertDataScene");
    }

    public void ReadButtonClicked()
    {
        SceneManager.LoadScene("ReadDataScene");
    }

    public void ExitButtonClicked()
    {
        Application.Quit();
    }
}
