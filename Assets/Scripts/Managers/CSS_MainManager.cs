using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CSS_MainManager : MonoBehaviour
{
    public static CSS_MainManager Instance { get; private set; }
    static int ID = 0;
    public TextMeshPro ChaosTxt;

    [Header("Gamemode Settings")]
    public static bool isChaosMode = false;
    [SerializeField] public static int CharacterNo = 0;
    [Space]
    [Header("Visual Settings")]
    [SerializeField] public static int frameRate = 60;
    [SerializeField] public bool isFullscreen = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            ID += 1;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        //Debug.Log("ID: " + ID);
    }
    private void Start()
    {
        Application.targetFrameRate = frameRate;
    }

    public void Update()
    {
        if (Input.GetKeyDown("f11"))
        {
            ToggleFullScreen();
        }
    }
    public void ToggleFullScreen()
    {
        
        if (!isFullscreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            Debug.Log("No alt f4 allowed");
            isFullscreen = true;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            Debug.Log("alt f4 allowed");
            isFullscreen = false;
        }
    }
    public void ToggleChaosMode()
    {
        if (isChaosMode == false)
        {
            isChaosMode = true;
        }
        else if (isChaosMode == true)
        {
            isChaosMode = false;
        }
    }

    public void CharacterSelect(int _char)
    {
        CharacterNo = _char;
    }

    public bool GetChaosModeStatus()
    {
        return isChaosMode;
    }
}