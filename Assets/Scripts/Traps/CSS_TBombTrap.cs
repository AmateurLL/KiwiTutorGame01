using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_TBombTrap : CSS_Trap
{

    //Variables of the Trap object
    [SerializeField] private CircleCollider2D m_circle2D;
    private bool isExplode;
    [SerializeField] private bool isPlayerAffected;
    //public float knockbackPower = 100;
    //public float knockbackDuartion = 1;

    void Init()
    {
        this.InitStats(CSS_DataManager.Instance.trapData[2].GetDamage(),
            CSS_DataManager.Instance.trapData[2].GetLifeTime(),
            CSS_DataManager.Instance.trapData[2].GetTimeLock(),
            CSS_DataManager.Instance.trapData[2].GetName());
        isPlayerAffected = false;
    }

    private void Awake()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        this.Deterioration();
        if (isExplode == true)
        {
            if (this.GetLifeTime() <= -0.2f)
            {
                Object.Destroy(this.gameObject);
            }
        }
        //if (isExplode == true)
        //{
        //    if (isPlayerAffected == true)
        //    {
        //        CSS_GameManager.Instance.playerRef.GetComponent<CSS_Player>().GetIsKnockedBackInstance().KnockBack(this.gameObject);
        //    }
        //    Object.Destroy(this.gameObject);
        //}
    }

    // Fuze deterioration
    public override void Deterioration()
    {
        this.SetLifeTime(this.GetLifeTime() - (this.GetTimeModifier() * Time.deltaTime));
        if (this.GetLifeTime() <= 0.0f)
        {
            Debug.Log("explosion or something");
            isExplode = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isExplode)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("boom");

                //Vector2 direction = (collision.gameObject.transform.position - this.transform.position).normalized;
                //CSS_GameManager.Instance.playerRef.GetComponent<CSS_Player>().GetRigid().AddForce(direction * knockbackPower, ForceMode2D.Impulse);
                collision.gameObject.GetComponent<CSS_Player>().GetIsKnockedBackInstance().KnockBack(this.gameObject);
                //Debug.Log(direction);
                //isExplode = false;
                isPlayerAffected = true;
                CSS_GameManager.Instance.playerRef.transform.GetComponent<CSS_Player>().ModifyHP(this.GetDamage());
                Object.Destroy(this.gameObject);
            }
        }
    }
}
