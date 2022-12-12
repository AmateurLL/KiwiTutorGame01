using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CSS_GameOverUI : MonoBehaviour
{
    public GameObject title;
    public GameObject title2;
    public GameObject subtitle;
    public GameObject timer;
    public GameObject beans;
    public ParticleSystem particles;

    private void Awake()
    {
        title = this.gameObject.transform.GetChild(0).gameObject;
        title2 = this.gameObject.transform.GetChild(1).gameObject;
        subtitle = this.gameObject.transform.GetChild(2).gameObject;
        timer = this.gameObject.transform.GetChild(3).gameObject;
        beans = this.gameObject.transform.GetChild(6).gameObject;
    }

    public void PlayerWinText()
    {
        timer.SetActive(true);
        title.GetComponent<TMP_Text>().text = "The bean has";
        title2.GetComponent<TMP_Text>().text = "escaped!";
        title2.GetComponent<TMP_Text>().color = new Color32(172, 250, 15, 255);
        subtitle.GetComponent<TMP_Text>().text = "The bean wins...";
        timer.GetComponent<TMP_Text>().text = "The game lasted for " + CSS_GameManager.Instance.GetGameTimer();
        beans.SetActive(false);
    }
}
