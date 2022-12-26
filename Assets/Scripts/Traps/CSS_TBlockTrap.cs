using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_TBlockTrap : CSS_Trap
{
    private void Init()
    {
        this.InitStats(CSS_DataManager.Instance.trapData[0].GetDamage(),
            CSS_DataManager.Instance.trapData[0].GetLifeTime(),
            CSS_DataManager.Instance.trapData[0].GetTimeLock(),
            CSS_DataManager.Instance.trapData[0].GetName(),
            CSS_DataManager.Instance.trapData[0].GetTier());
    }
    void Awake()
    {
        this.Init();
    }

    private void Update()
    {
        this.Deterioration();
    }
}
