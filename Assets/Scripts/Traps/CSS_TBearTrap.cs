using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_TBearTrap : CSS_Trap
{
    [SerializeField] private BoxCollider2D m_box2D;

    bool isTrapped;
    bool isTimeUp;
    public void Init()
    {
        this.SetDamage(-10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Trapped(collision.gameObject);

        }
    }

    private void Awake()
    {
        Init();
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
        Debug.Log("slow down plz");
        isTrapped = true;
        _player.transform.GetComponent<CSS_Player>().SetSpdMod(0.25f);
        _player.transform.GetComponent<CSS_Player>().ModifyHP(this.GetDamage());
        _player.transform.GetComponent<CSS_Player>().SetModTime(3.0f);
        _player.transform.GetComponent<CSS_Player>().SetAffect(true);
    }

    public bool GetIsTimeUp()
    {
        return this.isTimeUp;
    }
}
