using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_TierSystem : MonoBehaviour
{
    public static CSS_TierSystem Instance { get; private set; }
    [SerializeField] public float[] timeLockList;

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
        SetTrapTimeLock();
    }

    public float[] GetTrapTimeLock()
    {
        return timeLockList;
    }

    public void SetTrapTimeLock()
    {
        timeLockList = new float[CSS_DataManager.Instance.GetTrapData().Count];
        for (int i = 0; i < CSS_DataManager.Instance.GetTrapData().Count; i++)
        {
            timeLockList[i] = CSS_DataManager.Instance.GetTrapData()[i].GetTimeLock();
        }
    }
}
