using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_Portal : MonoBehaviour
{
    public Transform portal;
    Vector2 portalPos = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CSS_Player>().GetPlayerObjTrans();
    }

    // Update is called once per frame
    void Update()
    {
        portal.position = new Vector2(1.0f, 1.0f);
        if (transform.position.y >= 1)
        {
            //transform.position.y = 0.01;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CSS_Player>().SetPlayerObjTrans(transform.GetChild(1).transform.position);
        }
    }
}
