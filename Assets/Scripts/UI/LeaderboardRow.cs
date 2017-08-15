using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardRow : MonoBehaviour 
{
    [SerializeField]
    Text nameText;

    [SerializeField]
    Text timeText;

    private HighScoreInfo highScoreInfo;

    public HighScoreInfo HighScoreInfo
    {
        get
        {
            return highScoreInfo;
        }

        set
        {
            highScoreInfo = value;
            nameText.text = highScoreInfo.Name;       
            TimeSpan timeSpan = TimeSpan.FromSeconds(highScoreInfo.Time);
            timeText.text = timeSpan.ToString(@"mm\:ss\:ff");
        }
    }
}
