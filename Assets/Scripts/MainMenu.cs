using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelectMenu1");
    }

    public void QuitGame()
    {
        //Application.Quit();
        SceneManager.LoadScene("ShopMenu");
    }
}
