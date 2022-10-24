using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 moveStart;
    [SerializeField] private Vector3 moveEnd;
    [SerializeField] private float speed;
    [SerializeField] private bool isMoveRight = true;
    [SerializeField] private bool isMoveUp = true;
    [SerializeField] private bool isVertical;

    // Update is called once per frame
    void Update()
    {
        if (isVertical != true)
        {
            if (this.transform.position.x >= moveEnd.x)
            {
                isMoveRight = false;
            }
            else if (this.transform.position.x <= moveStart.x)
            {
                isMoveRight = true;
            }

            if (isMoveRight == true)
            {
                this.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else if (isMoveRight != true)
            {
                this.transform.Translate(-Vector3.right * speed * Time.deltaTime);
            }
        }
        else if (isVertical == true)
        {
            if (this.transform.position.y >= moveEnd.y)
            {
                isMoveUp = false;
            }
            else if (this.transform.position.y <= moveStart.y)
            {
                isMoveUp = true;
            }

            if (isMoveUp == true)
            {
                this.transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            else if (isMoveUp != true)
            {
                this.transform.Translate(-Vector3.up * speed * Time.deltaTime);
            }
        }
    }
}
