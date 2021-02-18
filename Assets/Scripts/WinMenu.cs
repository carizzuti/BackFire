using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    public static WinMenu instance;

    [SerializeField] private GameObject winMenuUI;
    [SerializeField] private Text goldScore, silverScore, timeBonusScore, totalScore;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenWinMenu()
    {
        Time.timeScale = 0;
        GetScores();
        winMenuUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelSelect()
    {
        // Not implemented yet
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void GetScores()
    {
        // Gold coin = 100 pts, silver coin = 50 pts, timeBonus = 10 pts per second under par
        int completionPoints = 500;
        int goldPoints = 100 * Collectible.instance.GetGoldCount();
        int silverPoints = 50 * Collectible.instance.GetSilverCount();
        int timeBonusPoints = (int)Math.Round(TimerController.instance.GetElapsedTime() * 10);
        int total = goldPoints + silverPoints + timeBonusPoints + completionPoints;

        goldScore.text = "Gold Collected: " + goldPoints;
        silverScore.text = "Silver Collected: " + silverPoints;
        timeBonusScore.text = "Time Bonus: " + timeBonusPoints;
        totalScore.text = "Total Score: " + total;
    }

}
