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

    private void Awake()
    {
        /*
        this._spin.x = 0;
        //this._spin.y = 50;
        this._spin.z = 75;
        */
        // Defines the rate of the objects rotation, while rotating them in 3d, in a 2d space.
        this._spin = new Vector3(0, 50, 75);
    }
    // Update is called once per frame
    void Update()
    {
        // Rotates the object by the vector 3 (in degrees).
        transform.Rotate(_spin * Time.deltaTime);
    }
}
