using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceFinishUIText : MonoBehaviour 
{
  
    private Text uiText;

    private Animator textAnimator;

    private const string finishedText = "FINISHED!";

    private void Start()
    {
        uiText = GetComponent<Text>();
        textAnimator = GetComponent<Animator>();
    }

    private void OnRaceFinished()
    {
        uiText.text = finishedText;
        textAnimator.SetBool("raceFinished", true);
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
