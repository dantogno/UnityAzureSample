using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LapTimer : MonoBehaviour
{
    private Text timeText;
    private float laptTime = 0f;
    private bool raceFinished = false;

    private void Start()
    {
        timeText = GetComponent<Text>();
    }

    private void Update()
    {
        UpdateLapTime();
    }

    private void UpdateLapTime()
    {
        if (!raceFinished)
        {
            laptTime += Time.deltaTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(laptTime);

            timeText.text = timeSpan.ToString(@"mm\:ss\:ff");
        }
    }

    private void OnRaceFinished()
    {
        raceFinished = true;
    }

    private void OnEnable()
    {
        Checkpoint.RaceFinished += OnRaceFinished;   
    }

    private void OnDisable()
    {
        Checkpoint.RaceFinished -= OnRaceFinished;
    }
}
