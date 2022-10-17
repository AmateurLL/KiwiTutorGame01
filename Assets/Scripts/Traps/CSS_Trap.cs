using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_Trap : MonoBehaviour
{
    //Variables of the Trap object
    [Header("Deterioration")]
    [SerializeField] private float lifeTime = 10.0f;
    private float timeModifier = 1.0f;

    [Header("Trap Stats")]
    [SerializeField] private int damage = 1;
    [SerializeField] private float timeLock;
    [SerializeField] private string trapName;
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

    public void Print()
    {
        Debug.Log("Name: " + trapName + "\n");
        Debug.Log("Lifetime: " + lifeTime + "\n");
        Debug.Log("Damage: " + damage + "\n");
        Debug.Log("TimeLock: " + timeLock + "\n");
    }

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

    public void SetTimeLock(float _timelock)
    {
        timeLock = _timelock;
    }

    public void SetName(string _trapName)
    {
        trapName = _trapName;
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

    public float GetTimeLock()
    {
        return this.timeLock;
    }

    public string GetName()
    {
        return this.trapName;
    }
}
