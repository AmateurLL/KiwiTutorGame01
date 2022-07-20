using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CSS_Trap : MonoBehaviour
{
    //Variables of the Trap object
    [Header("Deterioration")]
    [SerializeField] private float lifeTime = 10.0f;
    private float timeModifier = 1.0f;

    [Header("Trap Stats")]
    [SerializeField] private int damage = 1;

    // This function makes the trap dissapear after 10 seconds.
    public virtual void Deterioration()
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

    //Overloading a function
    //(Basically you can have parameters, but they aren't needed if you have one without)
    //public void Deterioration(int _x, int _y)
    //{
    // 
    //}

    ////////////////////////////////////////////////////////////////////////////hi////////////////////////////////////////////////hix2///////////////////////////

    public void SetLifeTime(float _life)
    {
        lifeTime = _life;
    }

    public void SetTimeModifier(float _mod)
    {
        timeModifier = _mod;
    }

    public void SetDamage(int _dmg)
    {
        damage = _dmg;
    }

    public float GetLifeTime()
    {
        return this.lifeTime;
    }

    public float GetTimeModifier()
    {
        return this.timeModifier;
    }

    public int GetDamage()
    {
        return this.damage;
    }
}
