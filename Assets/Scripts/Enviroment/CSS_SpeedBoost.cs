using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_SpeedBoost : MonoBehaviour
{
    [SerializeField] private CircleCollider2D m_circle2D;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("hi1");
            collision.gameObject.GetComponent<CSS_Player>().GetIsSpeedBoostInstance().SpeedBoost();
            //Object.Destroy(this.gameObject);
        }
    }
}
