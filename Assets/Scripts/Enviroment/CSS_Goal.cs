using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_Goal : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private BoxCollider2D m_box2D;
    [SerializeField] private bool isWin = false;
    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isWin == false)
        {
            Debug.Log("win (or did you?)");
            isWin = true;
        }
    }

    public bool GetIsWin()
    {
        return this.isWin;
    }
}
