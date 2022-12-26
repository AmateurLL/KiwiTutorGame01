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
    [SerializeField] private int tier;
    // This function makes the trap dissapear after 10 seconds.
    public virtual void Deterioration()
    {
        // This modifies the lifeTime variable (that starts at 10), at the rate that means it will 10 ten seconds
        // to trigger the if statement.
        lifeTime -= (timeModifier * Time.deltaTime);
        // if the lifetime is less or equal to 0.0, then the object dissapears.
        if (lifeTime <= 0.0f)
        {
            //Debug.Log("adios");
            Object.Destroy(this.gameObject);
        }
    }

    public void InitStats(int _dmg, float _life, float _lock, string _name, int _tier)
    {
        this.SetDamage(_dmg);
        this.SetLifeTime(_life);
        this.SetTimeLock(_lock);
        this.SetName(_name);
        this.SetTier(_tier);
    }

    // Debug message Purpose
    public void Print()
    {
        Debug.Log("Name: " + trapName + " | " +
            "Lifetime: " + lifeTime + " | " +
            "Damage: " + damage + " | " +
            "Timelock: " + timeLock + " | " +
            "Tier: " + tier);
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

    public void SetTier(int _tier)
    {
        tier = _tier;
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

    public int GetTier()
    {
        return this.tier;
    }
}
