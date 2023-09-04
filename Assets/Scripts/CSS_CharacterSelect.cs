using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_CharacterSelect : MonoBehaviour
{
    public GameObject MainMenuRef;

    public void BackButton()
    {
        MainMenuRef.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void SelectBean()
    {
        CSS_MainManager.Instance.CharacterSelect(0);
    }

    public void SelectTV()
    {
        CSS_MainManager.Instance.CharacterSelect(1);
    }
}
