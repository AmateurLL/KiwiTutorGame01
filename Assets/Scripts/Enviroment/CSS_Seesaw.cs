using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_Seesaw : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 spinAmount;
    [SerializeField] private float timer;
    [SerializeField] private bool rotateRight;


    // Update is called once per frame
    void Update()
    {
        if (rotateRight)
        {
            timer += Time.deltaTime;
            this.transform.Rotate(spinAmount * speed * Time.deltaTime);
        }
        else if (!rotateRight)
        {
            timer -= Time.deltaTime;
            this.transform.Rotate(-spinAmount * speed * Time.deltaTime);
        }

        if (timer >= 1.0f)
        {
            rotateRight = false;
        }
        else if (timer <= -1.0f)
        {
            rotateRight = true;
        }

    }
}
