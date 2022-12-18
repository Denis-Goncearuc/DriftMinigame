using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

public class DriftScore : MonoBehaviour
{
    [SerializeField] private CarController carController;
    [SerializeField] private UI ui;
    [SerializeField] float driftPointsGain;
    [SerializeField] float roundTime;

    private float currentScore;
    private int multiplier;
    private float driftTime;
    private float totalScore;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        roundTime -= Time.deltaTime;

        if (roundTime < 0)
        {
            
            enabled = false;
            ui.CompleteLevel();
            return;
        }
        ui.UpdateTimer(roundTime);
        if (carController.isDrifting)
        {
            driftTime += Time.deltaTime;
            multiplier = 1 + Mathf.FloorToInt(driftTime / 2);
            currentScore += Mathf.FloorToInt(driftPointsGain * Time.deltaTime * multiplier);
        }
        else
        {
            totalScore += currentScore;
            currentScore = 0;
            driftTime = 0;
        }
        
        
        ui.UpdateScore(carController.isDrifting, currentScore,totalScore,multiplier);
    }
}
