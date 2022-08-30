using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CSS_GameTimer : MonoBehaviour
{
    public TMP_Text TimerText;
    public bool TimerOn;
    public float TimeLeft;
    void Init()
    {
        TimerOn = true;
        TimeLeft = 0.0f;
    }

    public void Start()
    {
        Init();
    }
    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            // 60 x 5 = 300, 300 seconds is 5 mins
            // Calculates when the game should end
            if (TimeLeft <= 300.0f)
            {
                TimeLeft += Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
                Object.Destroy(this.gameObject);
            }
        }
    }

    void updateTimer(float currentTime)
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        this.GetComponent<TMP_Text>().text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
