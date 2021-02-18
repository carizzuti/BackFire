using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossMenu : MonoBehaviour
{
    public static LossMenu instance;

    [SerializeField] private GameObject lossMenuUI;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OpenLossMenu()
    {
        Time.timeScale = 0;
        lossMenuUI.SetActive(true);
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
}
