using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CSS_GameTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public bool timerOn;
    public float timeLeft;
    void Init()
    {
        timerOn = true;
        timeLeft = 0.0f;
        timerText = this.GetComponent<TMP_Text>();
    }

    public void Start()
    {
        Init();
    }
    // Update is called once per frame
    void Update()
    {
        if (CSS_GameManager.Instance.GetIsGameOver())
        {
            timerOn = false;
        }

        if (timerOn)
        {
            // 60 x 5 = 300, 300 seconds is 5 mins
            // Calculates when the game should end
            //if (TimeLeft <= 108000.0f)
            //{
            //    TimeLeft += Time.deltaTime;
            //    updateTimer(TimeLeft);
            //}
            //else
            //{
            //    TimeLeft = 0;
            //    TimerOn = false;
            //    Object.Destroy(this.gameObject);
            //}
            timeLeft += Time.deltaTime;
            updateTimer(timeLeft);
        }
    }

    void updateTimer(float currentTime)
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.GetComponent<TMP_Text>().text = string.Format("{0:0}:{1:00}", minutes, seconds);
        CSS_GameManager.Instance.SetGameTimer(timerText.GetComponent<TMP_Text>().text);
        CSS_GameManager.Instance.SetGameTimeMin(minutes);
        CSS_GameManager.Instance.SetGameTimeSec(seconds);
    }
}
