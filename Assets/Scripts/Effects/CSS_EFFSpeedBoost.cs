using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_EFFSpeedBoost : MonoBehaviour
{
    [SerializeField] private float speedPower = 1.5f;
    [SerializeField] private float speedDefault = 1.0f;
    [SerializeField] private float speedDuration = 5.0f;
    [SerializeField] private bool isSpeedUp = false;



    public void SpeedBoost()
    {
        StopAllCoroutines();
        //Debug.Log("hi2");
        this.isSpeedUp = true;
        CSS_GameManager.Instance.playerRef.GetComponent<CSS_Player>().SetSpdMod(speedPower);
        StartCoroutine(Reset());

    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(this.speedDuration);
        CSS_GameManager.Instance.playerRef.GetComponent<CSS_Player>().SetSpdMod(speedDefault);
        this.isSpeedUp = false;
    }

    public bool GetIsSpedUp()
    {
        return this.isSpeedUp;
    }
}
