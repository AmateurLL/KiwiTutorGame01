using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSS_LevelSelector : MonoBehaviour
{
    public GameObject MainMenuRef;
    public GameObject audioManagerRef;
    private string[] Levels = { "Lvl_1", "Lvl_2", "Lvl_3" };
    public int BGMSelector = 0;

    // The Level 1 text is hardcoded.

    private void Start()
    {
        audioManagerRef = CSS_MainManager.Instance.transform.gameObject;
    }
    public void MainMenu()
    {
        audioManagerRef.transform.gameObject.GetComponent<CSS_AudioManager>().BGMSelector(0);
        SceneManager.LoadScene("MainMenu");
        //Debug.Log("Entering Main Menu");
    }
    public void Level1()
    {
        audioManagerRef.transform.gameObject.GetComponent<CSS_AudioManager>().BGMSelector(1);
        SceneManager.LoadScene(Levels[0]);
        //Debug.Log("Entering Level 1");
    }

    public void Level2()
    {
        audioManagerRef.transform.gameObject.GetComponent<CSS_AudioManager>().BGMSelector(2);
        SceneManager.LoadScene(Levels[1]);
        //Debug.Log("Entering Level 2");
    }
    public void Level3()
    {
        audioManagerRef.transform.gameObject.GetComponent<CSS_AudioManager>().BGMSelector(3);
        SceneManager.LoadScene(Levels[2]);
        //Debug.Log("Entering Level 3");
    }

    public void BackButton()
    {
        MainMenuRef.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public int GetBGMNum()
    {
        return BGMSelector;
    }
}
