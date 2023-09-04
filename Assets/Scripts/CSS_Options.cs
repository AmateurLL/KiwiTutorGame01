using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSS_Options : MonoBehaviour
{
    public GameObject MainMenuRef;
    public GameObject optionsRef;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = CSS_AudioManager.Instance.GetVolume();
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    public void BackButton()
    {
        MainMenuRef.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ValueChangeCheck()
    {
        //Debug.Log(slider.value);
        CSS_AudioManager.Instance.SetVolume(slider.value);
    }
}
