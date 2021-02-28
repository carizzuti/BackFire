
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
    [SerializeField] private Text goldInventory, silverInventory, timeCounter;
    [SerializeField] private int parTime = 60; // in seconds

    private void Awake()
    {
        instance = this;
    }

    public void OpenWinMenu()
    {
        InventoryStats();
        GetScores();
        winMenuUI.SetActive(true);
        SaveData();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelectMenu1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void InventoryStats()
    {
        goldInventory.text = GameController.instance.GetGoldCollected() + " / " + GameController.instance.GetGoldAvailable();
        silverInventory.text = GameController.instance.GetSilverCollected() + " / " + GameController.instance.GetSilverAvailable();

        TimeSpan timePlayed = TimeSpan.FromSeconds(TimerController.instance.GetElapsedTime());
        string timePlayingStr = "Time: " + timePlayed.ToString("mm':'ss'.'ff");
        timeCounter.text = timePlayingStr;
    }

    private void GetScores()
    {
        // Gold coin = 100 pts, silver coin = 50 pts, timeBonus = 10 pts per second under par
        int completionPoints = 500;
        int goldPoints = 100 * GameController.instance.GetGoldCollected();
        int silverPoints = 50 * GameController.instance.GetSilverCollected();
        int timeBonusPoints = (parTime - (int)Math.Round(TimerController.instance.GetElapsedTime())) * 10;

        if (timeBonusPoints < 0)
        {
            timeBonusPoints = 0;
        }

        int total = goldPoints + silverPoints + timeBonusPoints + completionPoints;

        goldScore.text = "Gold Collected: " + goldPoints;
        silverScore.text = "Silver Collected: " + silverPoints;
        timeBonusScore.text = "Time Bonus: " + timeBonusPoints;
        totalScore.text = "Total Score: " + total;
    }

    private void SaveData()
    {
        PlayerStats.Gold += GameController.instance.GetGoldCollected();
        PlayerStats.Silver += GameController.instance.GetSilverCollected();
    }

}


