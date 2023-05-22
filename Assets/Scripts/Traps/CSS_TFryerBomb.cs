using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_TFryerBomb : CSS_Trap
{
    [SerializeField] public float explosionTime;
    [SerializeField] public bool isExploded;
    [SerializeField] public bool isFirstPhase;
    [SerializeField] public int emberAmount;
    void Start()
    {
        this.InitStats(CSS_DataManager.Instance.trapData[6].GetDamage(),
            CSS_DataManager.Instance.trapData[6].GetLifeTime(),
            CSS_DataManager.Instance.trapData[6].GetTimeLock(),
            CSS_DataManager.Instance.trapData[6].GetName(),
            CSS_DataManager.Instance.trapData[6].GetTier());
        this.explosionTime = this.GetLifeTime() / 2;
        this.isFirstPhase = true;
        this.emberAmount = 8;
    }

    void Update()
    {
        this.Deterioration();
    }

    public override void Deterioration()
    {
        this.SetLifeTime(this.GetLifeTime() - (this.GetTimeModifier() * Time.deltaTime));
        // when the explosion happens (and creates embers)
        if (this.GetLifeTime() <= explosionTime && !isExploded && isFirstPhase)
        {
            Debug.Log("first explosion");
            isExploded = true;
            isFirstPhase = false;
            SummonEmbers();
        }
        // embers burn out
        if (this.GetLifeTime() <= 0.0f)
        {
            Object.Destroy(this.gameObject);
        }
    }

    public void SummonEmbers()
    {
        for (int i = 0; i < emberAmount; i++)
        {
            Vector3 emberPosition = new Vector3(this.gameObject.transform.position.x,
                                                this.gameObject.transform.position.y, 
                                                this.gameObject.transform.position.z);
            emberPosition.x = emberPosition.x + Random.Range(3.0f, -3.0f);
            Instantiate(CSS_GameManager.Instance.emberRef, emberPosition, Quaternion.identity);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isExploded)
        {
            CSS_GameManager.Instance.playerRef.transform.GetComponent<CSS_Player>().TakeDamage(this.GetDamage());
            isExploded = false;
        }
    }
}
