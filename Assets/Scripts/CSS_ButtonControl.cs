using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSS_ButtonControl : MonoBehaviour
{
    [SerializeField] public Button[] buttonList;

    private void Awake()
    {
        //Sets the unused buttons off by default
        for (int i = 7; i < buttonList.Length; i++)
        {
            buttonList[i].interactable = false;
        }
    }
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

    public void SetSpin()
    {
        CSS_GameManager.Instance.selectedTrapRef = CSS_GameManager.Instance.spinningBoxRef;
    }

    public void SetFryer()
    {
        CSS_GameManager.Instance.selectedTrapRef = CSS_GameManager.Instance.fryerBombRef;
    }
}
