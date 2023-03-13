using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_Ember : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] private int emberDamage = 1;
    [SerializeField] private float emberCooldown = 0.15f;
    private float timeModifier = 1.0f;

    private void Awake()
    {
        this.lifeTime = Random.Range(3.0f, 5.0f);
    }

    private void Update()
    {
        Deterioration();
    }

    public void Deterioration()
    {
        // This modifies the lifeTime variable (that starts at 10), at the rate that means it will 10 ten seconds
        // to trigger the if statement.
        lifeTime -= (timeModifier * Time.deltaTime);
        emberCooldown -= (timeModifier * Time.deltaTime);
        // if the lifetime is less or equal to 0.0, then the object dissapears.
        if (lifeTime <= 0.0f)
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && emberCooldown <= 0.0f)
        {
            CSS_GameManager.Instance.playerRef.transform.GetComponent<CSS_Player>().TakeDamage(1);
            emberCooldown = 0.1f;
        }
    }
}
