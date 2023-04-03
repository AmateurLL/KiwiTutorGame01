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
        this.isSpeedUp = true;
        CSS_GameManager.Instance.playerRef.GetComponent<CSS_Player>().SetMaxVeloMod(speedPower);
        //This is unity's intergrated timer system.
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        //After speedDuration seconds, the increased MAX velocity resets to default.
        yield return new WaitForSeconds(this.speedDuration);
        CSS_GameManager.Instance.playerRef.GetComponent<CSS_Player>().SetMaxVeloMod(speedDefault);
        this.isSpeedUp = false;
    }

    public bool GetIsSpedUp()
    {
        return this.isSpeedUp;
    }
}