using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_TBombTrap : CSS_Trap
{

    //Variables of the Trap object
    [SerializeField] private CircleCollider2D m_circle2D;
    private bool isExplode;
    public float knockbackPower = 100;
    public float knockbackDuartion = 1;

    void Init()
    {
        this.m_circle2D = this.GetComponent<CircleCollider2D>();
        this.isExplode = false;
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

    public override void Deterioration()
    {
        this.SetLifeTime(-(this.GetTimeModifier() * Time.deltaTime));
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
            //Trapped(collision.gameObject);
            Debug.Log("boom");

            Vector2 playerObject = new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y);
            Vector2 currentPosition = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
            Vector2 direction = (playerObject - currentPosition).normalized;
            CSS_GameManager.Instance.playerRef.GetComponent<CSS_Player>().GetRigid().AddForce(direction * knockbackPower, ForceMode2D.Impulse);
            
            isExplode = false;
            Object.Destroy(this.gameObject);
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
