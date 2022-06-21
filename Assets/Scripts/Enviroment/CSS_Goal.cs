using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_Goal : MonoBehaviour
{
    //Lists Componenents of the Goal in the editor
    [Header("Components")]
    [SerializeField] private BoxCollider2D m_box2D;
    [SerializeField] private bool isWin = false;

    //This function is one of unity's in built collision functions.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the goal is in contact with an object with the tag "Player" as well as the bool
        // "isWin" being false, the player will win, setting the isWin variable to true.
        if (collision.gameObject.tag == "Player" && isWin == false)
        {
            Debug.Log("win (or did you?)");
            isWin = true;
        }
    }

    // this is a getter for IsWin - this can be transfered to other scripts.
    public bool GetIsWin()
    {
        return this.isWin;
    }
}
