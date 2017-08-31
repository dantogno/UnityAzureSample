using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{   
    [Tooltip("The next checkpoint, if there is one.")]
    [SerializeField]
    private Checkpoint nextCheckpoint;

    [Tooltip("Is this the finish line?")]
    [SerializeField]
    private bool isFinishLine;

    [Tooltip("Check this if this is the first checkpoint (and not the finish line).")]
    [SerializeField]
    private bool isFirstCheckpoint;


    public static event Action RaceFinished;

    public bool IsEnabled { get; set; } = false;

    private bool isRaceFinished = false;

    private void Start()
    {
        if (isFirstCheckpoint)
        {
            IsEnabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag == "Player" && IsEnabled)
        {
            Debug.Log($"Checkpoint reached: {gameObject.name}");

            if (nextCheckpoint != null)
                nextCheckpoint.IsEnabled = true;

            if (isFinishLine && !isRaceFinished)
            {
                isRaceFinished = true;
                Debug.Log("Race finished!");
                RaceFinished?.Invoke();
            }
        }
    }

}
