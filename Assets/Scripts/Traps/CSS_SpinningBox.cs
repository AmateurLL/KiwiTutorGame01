using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_SpinningBox : CSS_Trap
{
    void Init()
    {
        this.InitStats(CSS_DataManager.Instance.trapData[5].GetDamage(),
            CSS_DataManager.Instance.trapData[5].GetLifeTime(),
            CSS_DataManager.Instance.trapData[5].GetTimeLock(),
            CSS_DataManager.Instance.trapData[5].GetName(),
            CSS_DataManager.Instance.trapData[5].GetTier());
    }

    private void Awake()
    {
        Init();
    }

    //Defines a component and variable
    [SerializeField] private Rigidbody2D m_rig2D;
    bool goUp = false;

    // Update is called once per frame
    void Update()
    {
        Deterioration();
        // If the velocity is too high or low it gets inverted
        if (m_rig2D.gravityScale >= 3.0f)
        {
            goUp = true;
        }
        else if (m_rig2D.gravityScale < -3.0f)
        {
            goUp = false;
        }

        if (goUp == true)
        {
            m_rig2D.gravityScale -= 0.01f;
        }
        else if (goUp == false)
        {
            m_rig2D.gravityScale += 0.01f;
        }

        if (m_rig2D.gravityScale > 3.1f || m_rig2D.gravityScale < -3.1f)
        {
            m_rig2D.gravityScale = 0.0f;
            goUp = true;
        }

        m_rig2D.rotation += 1.0f;
    }
}
