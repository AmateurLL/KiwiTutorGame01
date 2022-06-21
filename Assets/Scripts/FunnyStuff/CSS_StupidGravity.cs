using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_StupidGravity : MonoBehaviour
{
    //Defines a component and variable
    [SerializeField] private Rigidbody2D m_rig2D;
    bool goUp = false;

    // Update is called once per frame
    void Update()
    {
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
        if (transform.position.y >= 4.0f)
        {
            goUp = false;
        }
        else if (transform.position.y <= -3.5f)
        {
            goUp = true;
        }

        m_rig2D.rotation += 1.0f;
    }
}
