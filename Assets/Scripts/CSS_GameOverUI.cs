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
    public ParticleSystem particles;


    public void PlayerWinText()
    {
        title.GetComponent<TMP_Text>().text = "The bean has";
        title2.GetComponent<TMP_Text>().text = "escaped!";
        title2.GetComponent<TMP_Text>().color = new Color32(172, 250, 15, 255);
        subtitle.GetComponent<TMP_Text>().text = "The keyboard player wins...";
        timer.GetComponent<TMP_Text>().text = "The game lasted for " + CSS_GameManager.Instance.GetGameTimer();
    }
}
