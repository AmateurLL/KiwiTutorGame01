using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_PlayerBuffer : MonoBehaviour
{
    [SerializeField] private CircleCollider2D m_bufferCollider;
    [SerializeField] bool isMouseOver = false;
    void Awake()
    {
        m_bufferCollider = this.gameObject.GetComponent<CircleCollider2D>();
    }


    //private void OnCollisionStay2D(Collision2D collision)
    //{

    //}


}
