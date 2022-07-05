using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_GameManager : MonoBehaviour
{
    //Singleton
    public static CSS_GameManager Instance { get; private set; }
    [Header("References")]
    [SerializeField] public GameObject playerRef;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
