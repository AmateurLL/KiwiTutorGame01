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
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        this.GetComponent<TMP_Text>().text = TimeLeft.ToString("0.00");
    }
}
