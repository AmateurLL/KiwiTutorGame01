using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_TBearTrap : MonoBehaviour
{
    [SerializeField] private BoxCollider2D m_box2D;

    float timeModifier;
    float spdReduction;
    float timeCount;
    bool isTrapped;
    bool isTimeUp;

    public void Init()
    {
        this.timeModifier = 3.0f;
        this.spdReduction = 0.25f;
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
        timeCount = timeModifier;
        timeCount -= Time.deltaTime;
        if (timeCount <= 0.0f)
        {
            //Object.Destroy(this.gameObject);
        }

    }
    private void Trapped(GameObject _player)
    {

        isTrapped = true;

        _player.transform.GetComponent<CSS_Player>().spdMod = 0.25f;
    }

    public bool GetIsTimeUp()
    {
        return this.isTimeUp;
    }
}
