using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSS_GameManager : MonoBehaviour
{
    //Singleton
    public static CSS_GameManager Instance { get; private set; }
    [Header("References")]
    [SerializeField] public GameObject playerRef;
    [SerializeField] public GameObject selectedTrapRef;
    [SerializeField] public GameObject TBlockTrapRef;
    [SerializeField] public GameObject TBearTrapRef;
    [SerializeField] public GameObject TBombTrapRef;
    [SerializeField] public GameObject TNukeTrapRef;
    [SerializeField] public GameObject TTrollBoxTrapRef;
    [SerializeField] public GameObject spinningBoxRef;
    [SerializeField] public GameObject cameraPosRef;
    [SerializeField] public GameObject cameraRef;

    [Space]
    [Header("Game Stats")]
    [SerializeField] private bool isWin = false;
    [SerializeField] private bool isDead = false;

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

    void Update()
    {
        if (isWin == true)
        {
            SceneManager.LoadScene("MainMenu");
            isWin = false;
        }
        else if (isDead == true)
        {
            SceneManager.LoadScene("MainMenu");
            isDead = false;
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
}
