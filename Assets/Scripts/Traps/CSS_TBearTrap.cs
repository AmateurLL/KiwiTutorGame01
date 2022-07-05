using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_TBearTrap : MonoBehaviour
{
    [SerializeField] private BoxCollider2D m_box2D;

    float timeModifier;
    bool isTrapped;
    bool isTimeUp;
    int dmg;
    [SerializeField] private float lifeTime = 10.0f;
    [SerializeField] private float deteriorationModifier = 1.0f;
    public void Init()
    {
        this.timeModifier = 1.0f;
        this.dmg = -10;
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
        Deterioration();
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
        _player.transform.GetComponent<CSS_Player>().ModifyHP(dmg);
        _player.transform.GetComponent<CSS_Player>().SetModTime(3.0f);
        _player.transform.GetComponent<CSS_Player>().SetAffect(true);
    }

    public bool GetIsTimeUp()
    {
        return this.isTimeUp;
    }

    void Deterioration()
    {
        // This modifies the lifeTime variable (that starts at 10), at the rate that means it will 10 ten seconds
        // to trigger the if statement.
        lifeTime -= (deteriorationModifier * Time.deltaTime);
        // if the lifetime is less or equal to 0.0, then the object dissapears.
        if (lifeTime <= 0.0f)
        {
            Debug.Log("adios");
            Object.Destroy(this.gameObject);
        }
    }
}
