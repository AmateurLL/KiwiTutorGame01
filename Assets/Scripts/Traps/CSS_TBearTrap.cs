using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_TBearTrap : CSS_Trap
{
    [SerializeField] private BoxCollider2D m_box2D;

    bool isTrapped;
    //bool isTimeUp;
    public void Init()
    {
        this.InitStats(CSS_DataManager.Instance.trapData[1].GetDamage(),
            CSS_DataManager.Instance.trapData[1].GetLifeTime(),
            CSS_DataManager.Instance.trapData[1].GetTimeLock(),
            CSS_DataManager.Instance.trapData[1].GetName(),
            CSS_DataManager.Instance.trapData[1].GetTier());
    }
    private void Start()
    {
        Init();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Trapped(collision.gameObject);

        }
    }

    void Update()
    {
        this.Deterioration();
        // The trap is supposed to destroy itself when it is triggered
        // Not when the player stops getting affected by the speed decrease
        if (isTrapped)
        {
            Object.Destroy(this.gameObject);
        }

    }
    private void Trapped(GameObject _player)
    {
        //Debug.Log("slow down plz");
        isTrapped = true;
        _player.transform.GetComponent<CSS_Player>().SetMaxVeloMod(0.5f);
        _player.transform.GetComponent<CSS_Player>().TakeDamage(this.GetDamage());
        _player.transform.GetComponent<CSS_Player>().SetModTime(3.0f);
        _player.transform.GetComponent<CSS_Player>().SetAffect(true);
    }

    //ublic bool GetIsTimeUp()
    //{
        //return this.isTimeUp;
    //}
}
