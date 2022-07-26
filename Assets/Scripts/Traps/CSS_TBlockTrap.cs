using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_TBlockTrap : CSS_Trap
{
    private void Awake()
    {
        this.SetLifeTime(3.0f);
    }
    void Update()
    {
        this.Deterioration();
    }
}
