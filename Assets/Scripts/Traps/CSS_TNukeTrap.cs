using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class CSS_TNukeTrap : CSS_Trap
{
    public float TimeLeft;
    public TextMeshPro TimerTxt;

    void Start()
    {
        this.InitStats(CSS_DataManager.Instance.trapData[4].GetDamage(),
            CSS_DataManager.Instance.trapData[4].GetLifeTime(),
            CSS_DataManager.Instance.trapData[4].GetTimeLock(),
            CSS_DataManager.Instance.trapData[4].GetName(),
            CSS_DataManager.Instance.trapData[4].GetTier());
        TimerTxt = this.gameObject.transform.GetChild(0).GetComponent<TextMeshPro>();
        TimeLeft = this.GetLifeTime();
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
            CSS_GameManager.Instance.playerRef.transform.GetComponent<CSS_Player>().TakeDamage(this.GetDamage());
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

    public void NukeTimer()
    {
        if (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
            updateTimer(TimeLeft);
        }
        else
        {
            TimeLeft = 0;
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt((currentTime % 60) - 1);
        float milliseconds = Mathf.FloorToInt(((currentTime % 60) * 100) - 1);

        //TimerTxt.text = string.Format("{0:00} : {1:00}", seconds, milliseconds);
        TimerTxt.text = TimeSpan.FromSeconds(TimeLeft).ToString("ss\\.ff");
    }
}
