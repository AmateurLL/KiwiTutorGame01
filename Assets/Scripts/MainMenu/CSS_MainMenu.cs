using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSS_MainMenu : MonoBehaviour
{
    public GameObject LevelSelectRef;
    public void Play()
    {
        LevelSelectRef.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("bye");
    }
}
