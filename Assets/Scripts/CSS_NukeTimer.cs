using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSS_NukeTimer : CSS_TNukeTrap
{
    //public float TimeLeft;
    //public bool TimerOn = false;

    //public Text TimerTxt;
    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
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
        currentTime += 1;
        //float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        float milliseconds = Mathf.FloorToInt((currentTime % 60) * 10);

        TimerTxt.text = string.Format("{1:00}:{2:000}", seconds, milliseconds);
    }
}
