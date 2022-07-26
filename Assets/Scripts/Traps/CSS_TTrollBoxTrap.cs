using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_TTrollBoxTrap : CSS_Trap
{
    [SerializeField] private float trollCD = 0.2f;
    private float trollModifier = 1.0f;
    private bool doDMG;
    // Start is called before the first frame update
    void Awake()
    {
        this.SetDamage(-1);
        this.doDMG = true;
    }

    // Update is called once per frame
    void Update()
    {
        trollCD -= (trollModifier * Time.deltaTime);
        // if the lifetime is less or equal to 0.0, then the object dissapears.
        if (trollCD <= 0.0f)
        {
            doDMG = true;
        }
        Deterioration();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && doDMG == true)
        {
            CSS_GameManager.Instance.playerRef.transform.GetComponent<CSS_Player>().ModifyHP(this.GetDamage());
            doDMG = false;
        }
    }
}