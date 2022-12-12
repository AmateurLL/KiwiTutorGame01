using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_TFryerBomb : CSS_Trap
{
    [SerializeField] public float explosionTime;
    [SerializeField] public bool isExploded;
    void Awake()
    {
        this.InitStats(CSS_DataManager.Instance.trapData[6].GetDamage(),
            CSS_DataManager.Instance.trapData[6].GetLifeTime(),
            CSS_DataManager.Instance.trapData[6].GetTimeLock(),
            CSS_DataManager.Instance.trapData[6].GetName());
        this.explosionTime = this.GetLifeTime() / 2;
    }

    void Update()
    {
        this.Deterioration();
    }

    public override void Deterioration()
    {
        this.SetLifeTime(this.GetLifeTime() - (this.GetTimeModifier() * Time.deltaTime));
        // when the explosion happens (and creates embers)
        if (this.GetLifeTime() <= explosionTime && !isExploded)
        {
            Debug.Log("first explosion");
            isExploded = true;
        }
        // embers burn out
        if (this.GetLifeTime() <= 0.0f)
        {
            Object.Destroy(this);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CSS_GameManager.Instance.playerRef.transform.GetComponent<CSS_Player>().ModifyHP(this.GetDamage());
        }
    }
}
