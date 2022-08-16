using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSS_ButtonControl : MonoBehaviour
{
    [SerializeField] public Button[] buttonList;

    public void SetBox()
    {
        CSS_GameManager.Instance.selectedTrapRef = CSS_GameManager.Instance.TBlockTrapRef;
    }

    public void SetBearTrap()
    {
        CSS_GameManager.Instance.selectedTrapRef = CSS_GameManager.Instance.TBearTrapRef;
    }

    public void SetBomb()
    {
        CSS_GameManager.Instance.selectedTrapRef = CSS_GameManager.Instance.TBombTrapRef;
    }

    public void SetTrollBox()
    {
        CSS_GameManager.Instance.selectedTrapRef = CSS_GameManager.Instance.TTrollBoxTrapRef;
    }

    public void SetNuke()
    {
        CSS_GameManager.Instance.selectedTrapRef = CSS_GameManager.Instance.TNukeTrapRef;
    }

    public void SetSpinn()
    {
        CSS_GameManager.Instance.selectedTrapRef = CSS_GameManager.Instance.spinningBoxRef;
    }

}
