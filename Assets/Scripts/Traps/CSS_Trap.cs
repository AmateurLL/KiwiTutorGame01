using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_Trap : MonoBehaviour
{
    //Variables of the Trap object
    [SerializeField] private float lifeTime = 10.0f;
    [SerializeField] private float timeModifier = 1.0f;

    // Update is called once per frame
    void Update()
    {
        Deterioration();
    }

    // This function makes the trap dissapear after 10 seconds.
    void Deterioration()
    {
        // This modifies the lifeTime variable (that starts at 10), at the rate that means it will 10 ten seconds
        // to trigger the if statement.
        lifeTime -= (timeModifier * Time.deltaTime);
        // if the lifetime is less or equal to 0.0, then the object dissapears.
        if (lifeTime <= 0.0f)
        {
            Debug.Log("adios");
            Object.Destroy(this.gameObject);
        }
    }
}
