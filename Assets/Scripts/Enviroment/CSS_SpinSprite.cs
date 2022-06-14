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
    [SerializeField] private Vector3 _spin;
    private void Awake()
    {
        /*
        this._spin.x = 0;
        //this._spin.y = 50;
        this._spin.z = 75;
        */
        this._spin = new Vector3(0, 50, 75);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_spin * Time.deltaTime);
    }
}
