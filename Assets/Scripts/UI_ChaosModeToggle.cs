using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ChaosModeToggle : MonoBehaviour
{
    [SerializeField] private Toggle chaosTog;
    void Start()
    {
        this.chaosTog = this.GetComponent<Toggle>();
        this.chaosTog.isOn = CSS_MainManager.Instance.GetChaosModeStatus();
    }

}
