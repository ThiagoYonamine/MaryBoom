using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private static BGMusic instance = null;
    private float volume = 1f;
    private bool shouldPlay;
    public static BGMusic Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        RefreshPlayerPrefs();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
        if (shouldPlay)
        {
            this.gameObject.GetComponent<AudioSource>().UnPause();
            this.gameObject.GetComponent<AudioSource>().volume = Mathf.Lerp(this.gameObject.GetComponent<AudioSource>().volume,
                volume, Time.deltaTime);
        }
        else
        {
            StopMusic();
        }
    }

    public void PauseMusic()
    {
        RefreshPlayerPrefs();
        this.volume = 0.4f;
    }

    public void ResumeMusic()
    {
        RefreshPlayerPrefs();
        this.volume = 1f;
    }

    //stop on main menu
    public void StopMusic()
    {
        this.gameObject.GetComponent<AudioSource>().Pause();
        shouldPlay = false;
    }

    public void RefreshPlayerPrefs()
    {
        shouldPlay = PlayerPrefs.GetInt("Music") == 1;
    }
}