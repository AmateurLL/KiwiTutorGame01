using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSS_GameManager : MonoBehaviour
{
    //Singleton
    public static CSS_GameManager Instance { get; private set; }
    [Header("Main References")]
    [SerializeField] public GameObject playerRef;
    [SerializeField] public GameObject mousePlayerRef;
    [SerializeField] public GameObject selectedTrapRef;
    [SerializeField] public GameObject cameraRef;
    [SerializeField] public GameObject cameraPosRef;
    [SerializeField] public GameObject speedBoostRef;
    [SerializeField] public GameObject GameUIRef;
    [SerializeField] public GameObject GameOverUIRef;
    [Space]

    [Header("Trap References")]
    [SerializeField] public GameObject TBlockTrapRef;
    [SerializeField] public GameObject TBearTrapRef;
    [SerializeField] public GameObject TBombTrapRef;
    [SerializeField] public GameObject TNukeTrapRef;
    [SerializeField] public GameObject TTrollBoxTrapRef;
    [SerializeField] public GameObject spinningBoxRef;
    [SerializeField] public GameObject fryerBombRef;
    [SerializeField] public GameObject emberRef;
    [Space]

    [Header("Sprite References")]
    [SerializeField] public RuntimeAnimatorController BeanCharRef;
    [SerializeField] public RuntimeAnimatorController TVCharRef;
    //[SerializeField] public Sprite[] BeanCharSprite;
    //[SerializeField] public Sprite[] TVCharSprite;
    [SerializeField] public Sprite[] SpriteArray;
    [Space]

    [Header("Game Stats")]
    [SerializeField] private bool isWin = false;
    [SerializeField] private bool isDead = false;
    [SerializeField] private bool isGameOver = false;
    [SerializeField] private string gameTimer;
    [SerializeField] private float gameTimeSec;
    [SerializeField] private float gameTimeMin;

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
    }

    private void Start()
    {
        //SelectChar();        
        CheckChaosMode();
        CSS_TierSystem.Instance.SetTrapTimeLock();
        CSS_ButtonControl.Instance.ButtonInitialize();
    }

    void Update()
    {
        if (isWin == true)
        {
            GameUIRef.SetActive(false);
            GameOverUIRef.SetActive(true);
            GameOverUIRef.GetComponent<CSS_GameOverUI>().PlayerWinText();
            isGameOver = true;
            isWin = false;
        }
        else if (isDead == true)
        {
            //SceneManager.LoadScene("MainMenu");
            GameUIRef.SetActive(false);
            GameOverUIRef.SetActive(true);
            isGameOver = true;
        }
    }

    private void CheckChaosMode()
    {
        if (CSS_MainManager.isChaosMode == true)
        {
            playerRef.GetComponent<CSS_Player>().SetSpdMod(1.5f);
            playerRef.GetComponent<CSS_Player>().SetMaxXVelo(20.0f);
            playerRef.GetComponent<CSS_Player>().SetMaxYVelo(60.0f);
            playerRef.GetComponent<CSS_Player>().SetJumpPower(15.625f);
            mousePlayerRef.GetComponent<CSS_DevilPlayer>().SetSpawnCD(3.25f);
        }
    }

    public void SelectChar()
    {
        switch (CSS_MainManager.CharacterNo)
        {
            case 0:
                //playerRef.GetComponent<CSS_Player>().GetPlayerAnim().runtimeAnimatorController = BeanCharRef;
                playerRef.GetComponent<CSS_Player>().SetPlayerSprite(SpriteArray[0]);
                break;

            case 1:
                //playerRef.GetComponent<CSS_Player>().GetPlayerAnim().runtimeAnimatorController = TVCharRef;
                playerRef.GetComponent<CSS_Player>().SetPlayerSprite(SpriteArray[1]);
                break;

            default:
                //playerRef.GetComponent<CSS_Player>().GetPlayerAnim().runtimeAnimatorController = BeanCharRef;
                playerRef.GetComponent<CSS_Player>().SetPlayerSprite(SpriteArray[0]);
                break;
        }
    }

    // this is a getter for IsWin - this can be transfered to other scripts.
    public bool GetIsWin()
    {
        return this.isWin;
    }

    public void SetIsWin(bool _win)
    {
        this.isWin = _win;
    }

    public bool GetIsDead()
    {
        return this.isDead;
    }

    public void SetIsDead(bool _dead)
    {
        this.isDead = _dead;
    }

    public bool GetIsGameOver()
    {
        return this.isGameOver;
    }

    public void SetIsGameOver(bool _game)
    {
        this.isGameOver = _game;
    }

    public string GetGameTimer()
    {
        return this.gameTimer;
    }

    public void SetGameTimer(string _time)
    {
        this.gameTimer = _time;
        //Debug.Log("The time is " + this.gameTimer);
    }

    public float GetGameTimeSec()
    {
        return this.gameTimeSec;
    }

    public void SetGameTimeSec(float _sec)
    {
        this.gameTimeSec = _sec;
        //Debug.Log("The time is " + this.gameTimer);
    }

    public float GetGameTimeMin()
    {
        return this.gameTimeMin;
    }

    public void SetGameTimeMin(float _min)
    {
        this.gameTimeMin = _min;
        //Debug.Log("The time is " + this.gameTimer);
    }
}
