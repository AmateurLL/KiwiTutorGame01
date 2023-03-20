using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_BouncePad : MonoBehaviour
{
    [SerializeField] public float jumpModAmount;
    public float thrust = 50.0f;
    [SerializeField] public Vector2 force;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float x = this.gameObject.transform.rotation.x;
            float y = 20.0f;
            force = new Vector2(x, y);
            Debug.Log(this.gameObject.transform.up);
            //CSS_GameManager.Instance.playerRef.GetComponent<CSS_Player>().SetJumpMod(jumpModAmount);
            //CSS_GameManager.Instance.playerRef.GetComponent<CSS_Player>().SetJump(true);
            CSS_GameManager.Instance.playerRef.GetComponent<CSS_Player>().GetRigid().AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
        }
    }
}
