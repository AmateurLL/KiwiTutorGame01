using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_TTrollBoxTrap : CSS_Trap
{
    [SerializeField] private float trollCD = 0.1f;
    private float trollModifier = 1.0f;
    private bool doDMG;
    [SerializeField] private Vector3 _spinClown = new Vector3(0,0,50);
    // Start is called before the first frame update
    void Awake()
    {
        this.InitStats(CSS_DataManager.Instance.trapData[3].GetDamage(),
            CSS_DataManager.Instance.trapData[3].GetLifeTime(),
            CSS_DataManager.Instance.trapData[3].GetTimeLock(),
            CSS_DataManager.Instance.trapData[3].GetName(),
            CSS_DataManager.Instance.trapData[3].GetTier());
    }

    // Update is called once per frame
    void Update()
    {
        trollCD -= (trollModifier * Time.deltaTime);
        // if the lifetime is less or equal to 0.0, then the object dissapears.
        if (trollCD <= 0.0f)
        {
            doDMG = true;
            trollCD = 0.1f;
        }
        Deterioration();
        SpinSprite();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && doDMG == true)
        {
            CSS_GameManager.Instance.playerRef.transform.GetComponent<CSS_Player>().ModifyHP(this.GetDamage());
            doDMG = false;
        }
    }

    public void SpinSprite()
    {
        this.transform.GetChild(0).transform.Rotate(_spinClown * Time.deltaTime);
    }
}
