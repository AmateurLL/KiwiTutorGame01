using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_PlayerGroundCheck : MonoBehaviour
{
    //Lists Componenents of GroundCheck in the editor
    [Header("Components")]
    [SerializeField] private CircleCollider2D m_circle2D;
    [SerializeField] private bool isGrounded = false;

    //This function is one of unity's in built collision functions.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the circle collider is in contact with an object with the tag "Ground" as well as the boolean
        // "isGrounded" being false, "isGrounded" will become true, allowing the player to jump.
        if (collision.gameObject.tag == "Ground" && isGrounded == false)
        {
            isGrounded = true;
        }
    }

    // this is a getter for isGrounded - this can be transfered to other scripts.
    public bool GetisGrounded()
    {
        return this.isGrounded;
    }

    // this is a setter for isGrounded - this can modify the value of isGrounded from other scripts.
    public void SetisGrounded(bool _Grounded)
    {
        isGrounded = _Grounded;
    }
}
