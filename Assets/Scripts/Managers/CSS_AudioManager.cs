using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_AudioManager : MonoBehaviour
{
    public static CSS_AudioManager Instance { get; private set; }
    [SerializeField] AudioSource m_audio;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        this.m_audio = this.gameObject.GetComponent<AudioSource>();
        this.m_audio.volume = 0.5f;
    }

    void Start()
    {
        BGMSelector(0);
    }

    public void MusicSelector()
    {

        //Debug.Log("this is at the very least ran");
        //if (levelSelectorRef.transform.GetComponent<CSS_LevelSelector>().GetBGMNum())
        //{
        //    this.m_audio.clip = this.gameObject.GetComponent<CSS_AudioTrackRef>().BGM_MainMenu;
        //    Debug.Log("menu1");
        //}
        //else if (levelSelectorRef.transform.GetComponent<CSS_LevelSelector>().GetLevelNum()[1] == true)
        //{
        //    this.m_audio.clip = this.gameObject.GetComponent<CSS_AudioTrackRef>().BGM_LevelOne;
        //    Debug.Log("one");
        //}
        //else if (levelSelectorRef.transform.GetComponent<CSS_LevelSelector>().GetLevelNum()[2] == true)
        //{
        //    this.m_audio.clip = this.gameObject.GetComponent<CSS_AudioTrackRef>().BGM_LevelTwo;
        //    Debug.Log("two");
        //}
        //else if (levelSelectorRef.transform.GetComponent<CSS_LevelSelector>().GetLevelNum()[3] == true)
        //{
        //    this.m_audio.clip = this.gameObject.GetComponent<CSS_AudioTrackRef>().BGM_LevelThree;
        //    Debug.Log("three");
        //}
        //else
        //{
        //    this.m_audio.clip = this.gameObject.GetComponent<CSS_AudioTrackRef>().BGM_MainMenu;
        //    Debug.Log("menu2");
        //}
        //Debug.Log("this is at the very least ran2");
    }

    public void BGMSelector(int _x)
    {
        switch (_x)
        {
            case 0:
                this.m_audio.Stop();
                this.m_audio.clip = this.gameObject.GetComponent<CSS_AudioTrackRef>().BGM_MainMenu;
                this.m_audio.Play();
                break;

            case 1:
                this.m_audio.Stop();
                this.m_audio.clip = this.gameObject.GetComponent<CSS_AudioTrackRef>().BGM_LevelOne;
                this.m_audio.Play();
                break;

            case 2:
                this.m_audio.Stop();
                this.m_audio.clip = this.gameObject.GetComponent<CSS_AudioTrackRef>().BGM_LevelTwo;
                this.m_audio.Play();
                break;

            case 3:
                this.m_audio.Stop();
                this.m_audio.clip = this.gameObject.GetComponent<CSS_AudioTrackRef>().BGM_LevelThree;
                this.m_audio.Play();
                break;

            default:
                this.m_audio.Stop();
                this.m_audio.clip = this.gameObject.GetComponent<CSS_AudioTrackRef>().BGM_MainMenu;
                this.m_audio.Play();
                break;
        }
    }

    public float GetVolume()
    {
        return m_audio.volume;
    }

    public void SetVolume(float _vol)
    {
        this.m_audio.volume = _vol;
    }

}
