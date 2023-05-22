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
        Debug.Log("ID: " + ID);
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

    public bool GetChaosModeStatus()
    {
        return isChaosMode;
    }
}