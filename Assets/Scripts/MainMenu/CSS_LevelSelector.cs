using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSS_LevelSelector : MonoBehaviour
{
    public GameObject MainMenuRef;
    private string[] Levels = { "Lvl_1", "Lvl_2", "Lvl_3" };

    // The Level 1 text is hardcoded.

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Entering Main Menu");
    }
    public void Level1()
    {
        SceneManager.LoadScene(Levels[0]);
        Debug.Log("Entering Level 1");
    }

    public void Level2()
    {
        SceneManager.LoadScene(Levels[1]);
        Debug.Log("Entering Level 2");
    }
    public void Level3()
    {
        SceneManager.LoadScene(Levels[2]);
        Debug.Log("Entering Level 3");
    }

    public void BackButton()
    {
        MainMenuRef.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
