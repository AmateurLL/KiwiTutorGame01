using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSS_TNukeTrap : CSS_Trap
{
    public float TimeLeft;
    public bool TimerOn = false;

    public Text TimerTxt;

    void Awake()
    {
        TimerOn = true;
        this.SetLifeTime(5.0f);
        this.SetDamage(-1000);
    }

    void Update()
    {
        Deterioration();
        NukeTimer();

    }

    public override void Deterioration()
    {
        this.SetLifeTime(this.GetLifeTime() - (this.GetTimeModifier() * Time.deltaTime));
        if (this.GetLifeTime() <= 0.0f)
        {
            CSS_GameManager.Instance.playerRef.transform.GetComponent<CSS_Player>().ModifyHP(this.GetDamage());
            Object.Destroy(this.gameObject);
        }
    }

    public void NukeTimer()
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
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
