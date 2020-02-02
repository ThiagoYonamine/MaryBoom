using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private bool shouldPlay;

    // Start is called before the first frame update
    void Start()
    {
        if (BGMusic.Instance != null)
        {
            BGMusic.Instance.StopMusic();
        }

        RefreshPlayerPrefs();
    }

    public void RefreshPlayerPrefs()
    {
        shouldPlay = PlayerPrefs.GetInt("Music", 1) == 1;
        if (shouldPlay)
        {
            PlayMusic();
        }
        else
        {
            StopMusic();
        }
    }

    public void StopMusic()
    {
        this.gameObject.GetComponent<AudioSource>().Pause();
    }

    public void PlayMusic()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
    }
}
