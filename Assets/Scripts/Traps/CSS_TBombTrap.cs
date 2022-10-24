using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_TBombTrap : CSS_Trap
{

    //Variables of the Trap object
    [SerializeField] private CircleCollider2D m_circle2D;
    private bool isExplode;
    //public float knockbackPower = 100;
    //public float knockbackDuartion = 1;

    void Init()
    {
        this.InitStats(CSS_DataManager.Instance.trapData[2].GetDamage(),
            CSS_DataManager.Instance.trapData[2].GetLifeTime(),
            CSS_DataManager.Instance.trapData[2].GetTimeLock(),
            CSS_DataManager.Instance.trapData[2].GetName());
    }

    private void Awake()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        this.Deterioration();
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
        if (collision.gameObject.tag == "Player" && isExplode)
        {
            Debug.Log("boom");

            //Vector2 direction = (collision.gameObject.transform.position - this.transform.position).normalized;
            //CSS_GameManager.Instance.playerRef.GetComponent<CSS_Player>().GetRigid().AddForce(direction * knockbackPower, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<CSS_Player>().GetIsKnockedBackInstance().KnockBack(this.gameObject);
            //Debug.Log(direction);
            Object.Destroy(this.gameObject);
            //isExplode = false;
        }
    }

    //public IEnumerator Knockback(float knockbackDuartion, float knockbackPower, Transform obj)
    //{
    //    float timer = 0;

    //    while (knockbackDuartion > timer)
    //    {
    //        timer += Time.deltaTime;
    //        Vector2 direction = (obj.transform.position - this.transform.position).normalized;
    //        CSS_GameManager.Instance.playerRef.GetComponent<CSS_Player>().GetRigid().AddForce(-direction * knockbackPower);
    //    }

    //    yield return 0;
    //}

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    Debug.Log("collision");
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Debug.Log("collision (working)");
    //        Vector2 direction = (CSS_GameManager.Instance.playerRef.GetComponent<CSS_Player>().transform.position - this.transform.position).normalized;
    //        CSS_GameManager.Instance.playerRef.GetComponent<CSS_Player>().GetRigid().AddForce(-direction * knockbackPower);
    //        //StartCoroutine(Knockback(knockbackDuartion, knockbackPower, this.transform));
    //    }
    //}
}
