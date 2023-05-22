using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSS_ButtonControl : MonoBehaviour
{
    public static CSS_ButtonControl Instance { get; private set; }
    //There is 12 buttons (as of 03/01/2023)
    [SerializeField] public Button[] buttonList;
    [SerializeField] public bool DebugButtons;
    [SerializeField] private int timer;
    // 0 = Block
    // 1 = Bear
    // 2 = Bomb
    // 3 = Clown
    // 4 = Fryer
    // 5 = Spinning
    // 6 = Nuke
    struct Buttons
    {
        public int ID;
        public Button buttonSlot;
        public float timeLock;

        public Buttons(int _ID, Button _buttonSlot, float _timeLock)
        {
            this.ID = _ID;
            this.buttonSlot = _buttonSlot;
            this.timeLock = _timeLock;
        }
    }
    Buttons[] trapButtons = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        if (!DebugButtons)
        {
            //Sets the unused buttons off by default (0 for all, 7 for unused ones only)
            for (int i = 0; i < buttonList.Length; i++)
            {
                buttonList[i].interactable = false;
            }
        }
    }

    public void ButtonInitialize()
    {
        trapButtons = new Buttons[CSS_TierSystem.Instance.GetTrapTimeLock().Length];
        trapButtons[0].ID = 1;
        trapButtons[0].buttonSlot = buttonList[0];
        trapButtons[0].timeLock = CSS_TierSystem.Instance.GetTrapTimeLock()[0];
        trapButtons[1].ID = 2;
        trapButtons[1].buttonSlot = buttonList[1];
        trapButtons[1].timeLock = CSS_TierSystem.Instance.GetTrapTimeLock()[1];
        trapButtons[2].ID = 3;
        trapButtons[2].buttonSlot = buttonList[2];
        trapButtons[2].timeLock = CSS_TierSystem.Instance.GetTrapTimeLock()[2];
        trapButtons[3].ID = 4;
        trapButtons[3].buttonSlot = buttonList[3];
        trapButtons[3].timeLock = CSS_TierSystem.Instance.GetTrapTimeLock()[3];
        trapButtons[4].ID = 5;
        trapButtons[4].buttonSlot = buttonList[4];
        trapButtons[4].timeLock = CSS_TierSystem.Instance.GetTrapTimeLock()[6];
        trapButtons[5].ID = 6;
        trapButtons[5].buttonSlot = buttonList[5];
        trapButtons[5].timeLock = CSS_TierSystem.Instance.GetTrapTimeLock()[5];
        trapButtons[6].ID = 7;
        trapButtons[6].buttonSlot = buttonList[6];
        trapButtons[6].timeLock = CSS_TierSystem.Instance.GetTrapTimeLock()[4];
    }

    public void Update()
    {
        timer = (Mathf.RoundToInt(CSS_GameManager.Instance.GetGameTimeMin()) * 60) + Mathf.RoundToInt(CSS_GameManager.Instance.GetGameTimeSec());
        //Debug.Log("Timer: " + timer);

        // Detects when the timre is less than or equal to the value of trapButtons.timeLock, aka when they should be activated.
        if (trapButtons != null)
        {
            for (int i = 0; i < trapButtons.Length; i++)
            {
                if (timer >= trapButtons[i].timeLock)
                {
                    trapButtons[i].buttonSlot.interactable = true;
                }
            }
        }
        
        // This is a switch statement to detect when to enable the buttons.
        //switch (CSS_GameManager.Instance.GetGameTimer())
        //{
        //    case "0:00":
        //        Debug.Log("timer working");
        //        trapButtons[0].buttonSlot.interactable = true;
        //        trapButtons[1].buttonSlot.interactable = true;
        //        trapButtons[2].buttonSlot.interactable = true;
        //        break;

        //    case "0:25":
        //        trapButtons[3].buttonSlot.interactable = true;
        //        break;

        //    case "0:30":
        //        trapButtons[4].buttonSlot.interactable = true;
        //        break;

        //    case "0:50":
        //        trapButtons[5].buttonSlot.interactable = true;
        //        break;

        //    case "1:20":
        //        trapButtons[6].buttonSlot.interactable = true;
        //        break;
        //}
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
