using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_TNukeTrap : CSS_Trap
{

    void Awake()
    {
        this.SetLifeTime(5.0f);
        this.SetDamage(-1000);
    }

    void Update()
    {
        Deterioration();

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
}
