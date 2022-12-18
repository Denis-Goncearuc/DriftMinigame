using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{

    [SerializeField] private TMP_Text currentScoreText;
    [SerializeField] private TMP_Text multiplierText;
    [SerializeField] private TMP_Text totalScoreText;
    [SerializeField] private TMP_Text rewardText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject levelComplete;
    
    
    private float currentScore;
    private int multiplier;
    private float totalScore;
    private int totalReward;

    public void UpdateTimer(float time)
    {
        TimeSpan timer = TimeSpan.FromSeconds(time);
        timerText.text = timer.ToString("mm':'ss");
    }
    
    public void UpdateScore(bool isDrifting, float _currentScore, float _totalScore, int _multiplier)
    {
        currentScore = _currentScore;
        multiplier = _multiplier;
        totalScore = _totalScore;

        
        multiplierText.gameObject.SetActive(isDrifting);
        currentScoreText.gameObject.SetActive(isDrifting);
        if (isDrifting)
        {
            currentScoreText.text = currentScore + " PTS";
            multiplierText.text = " x"+multiplier;
        }
        else
        {
            totalScoreText.text = totalScore + " PTS";
        }
        
        
    }

    public void CompleteLevel()
    {
        levelComplete.SetActive(true);
        totalReward = Mathf.FloorToInt(totalScore / 10);
        rewardText.text = totalReward + " $";
    }

    public void DoubleReward()
    {
        totalReward *= 2;
        rewardText.text = totalReward + " $";
    }
    
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    
    
}
