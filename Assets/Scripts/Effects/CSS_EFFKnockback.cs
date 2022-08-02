using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dynamic Component (Can be used on any other object)
public class CSS_EFFKnockback : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_Rig2D;

    [SerializeField] private float knockbackPower = 25.0f;
    [SerializeField] private float knockbackDuartion = 0.15f;
    [SerializeField] private bool isKnockedBack = false;


    public void KnockBack(GameObject _sender)
    {
        StopAllCoroutines();
        this.isKnockedBack = true;
        Vector2 dir = (this.transform.position - _sender.transform.position).normalized;
        this.m_Rig2D.AddForce(dir * this.knockbackPower, ForceMode2D.Impulse);
        Debug.Log(dir);
        StartCoroutine(Reset());
        
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(this.knockbackDuartion);
        //this.m_Rig2D.velocity = Vector3.zero;
        this.isKnockedBack = false;
    }

    public bool GetIsKnockBack()
    {
        return (this.isKnockedBack);
    }
}
