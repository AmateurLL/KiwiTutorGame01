using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSS_LevelSelector : MonoBehaviour
{
    public GameObject MainMenuRef;
    public void Level1()
    {
        SceneManager.LoadScene("Lvl_1");
    }

    public void BackButton()
    {
        MainMenuRef.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
