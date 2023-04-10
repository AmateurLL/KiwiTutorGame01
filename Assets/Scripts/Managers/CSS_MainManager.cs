using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_MainManager : MonoBehaviour
{
    public static CSS_MainManager Instance { get; private set; }
    static int ID = 0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            ID += 1;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject);
        Debug.Log("ID: " + ID);
    }
}