using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_TBlockTrap : CSS_Trap
{
    public void Init()
    {
        this.InitStats(CSS_DataManager.Instance.trapData[0].GetDamage(),
                        CSS_DataManager.Instance.trapData[0].GetLifeTime(),
                        CSS_DataManager.Instance.trapData[0].GetTimeLock(),
                        CSS_DataManager.Instance.trapData[0].GetName());
    }

    private void Awake()
    {
        //this.SetLifeTime(3.0f);
        this.Init();
    }
    void Update()
    {
        this.Deterioration();
    }
}
