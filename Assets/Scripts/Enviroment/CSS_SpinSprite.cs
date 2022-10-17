using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script makes the sprite spin, that the script is placed on.

You spin me right 'round, baby, right 'round
Like a record, baby, right 'round, 'round, 'round
You spin me right 'round, baby, right 'round
Like a record, baby, right 'round, 'round, 'round
*/
public class CSS_SpinSprite : MonoBehaviour
{
    //Variable
    [SerializeField] private Vector3 _spin;

    // Update is called once per frame
    void Update()
    {
        // Rotates the object by the vector 3 (in degrees).
        transform.Rotate(_spin * Time.deltaTime);
    }
}
