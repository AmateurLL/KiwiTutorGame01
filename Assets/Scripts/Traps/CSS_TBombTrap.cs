using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_TBombTrap : MonoBehaviour
{

    //Variables of the Trap object
    [SerializeField] private CircleCollider2D m_circle2D;
    [SerializeField] private float fuseTime = 3.0f;
    [SerializeField] private float timeModifier = 1.0f;
    private bool isExplode;

    void Init()
    {
        this.isExplode = false;
    }

    private void Awake()
    {
        Init();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Fuse();
    }

    void Fuse()
    {
        // This modifies the lifeTime variable (that starts at 10), at the rate that means it will 10 ten seconds
        // to trigger the if statement.
        fuseTime -= (timeModifier * Time.deltaTime);
        // if the lifetime is less or equal to 0.0, then the object dissapears.
        if (fuseTime <= 0.0f)
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
            isExplode = false;
            Object.Destroy(this.gameObject);

        }
    }

    public IEnumerator Knockback(float knockbackDuartion, float knockpackPower, Transform obj)
    {
        float timer = 0;

        while (knockbackDuartion > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            CSS_GameManager.Instance.playerRef.GetComponent<CSS_Player>().GetRigid().AddForce(-direction * knockpackPower);
        }

        yield return 0;
    }
}
