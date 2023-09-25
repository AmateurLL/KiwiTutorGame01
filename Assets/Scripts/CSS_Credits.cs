using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_Credits : MonoBehaviour
{
    bool isMoveRight = false;
    bool ChaosCredits = false;
    public GameObject MainMenuRef;
    [SerializeField] float speed = 2.5f;
    public GameObject ChaosButtonRef;

    public void BackButton()
    {
        MainMenuRef.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void FunnyCredits()
    {
        ChaosCredits = true;
        Destroy(ChaosButtonRef);
    }

    public void Update()
    {
        if (ChaosCredits)
        {
            Vector3 temp = new Vector3(speed * 10.0f, 2.0f * Mathf.Sin(this.transform.position.x / 20), 0.0f);

            if (isMoveRight)
            {
                this.gameObject.transform.position += temp;
            }
            else if (!isMoveRight)
            {
                this.gameObject.transform.position -= temp;
            }

            if (this.gameObject.transform.position.x < 404.5f)
            {
                isMoveRight = true;
            }
            else if (this.gameObject.transform.position.x > 844.5f)
            {
                isMoveRight = false;
            }
        }
        
    }
}
