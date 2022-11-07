using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_BouncePad : MonoBehaviour
{
    [SerializeField] public float jumpModAmount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Bouncy bouncy");
            CSS_GameManager.Instance.playerRef.GetComponent<CSS_Player>().SetJumpMod(jumpModAmount);
            CSS_GameManager.Instance.playerRef.GetComponent<CSS_Player>().SetJump(true);

        }
    }
}
