using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject[] stars;
    public GameObject[] buttons;
    public Image background;
    public Sprite win;
    public Sprite defeat;
    public Text level_txt;

    public AudioClip[] starSound;
    public AudioClip winSound;
    public AudioClip defeatSound;
    private AudioSource audioSource;

    public void Start()
    {

        this.gameObject.SetActive(false);
        for (int i = 0; i<3; i++) { 
            stars[i].SetActive(false);
            buttons[i].SetActive(false);
        }
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator ActiveStars(int n)
    {
        yield return new WaitForSeconds(0.8f);
        for (int i = 0; i < n; i++)
        {
            yield return new WaitForSeconds(0.5f);
            stars[i].SetActive(true);
            PlaySounds(starSound[i]);

        }

        if (n > 0) n = 3;
        else n = 2;

        for (int b = 0; b < n; b++)
        {
            buttons[b].SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }

    }

    public void Play(int n, int level)
    {
        BGMusic.Instance.PauseMusic();
        this.gameObject.SetActive(true);
        if (n == 0)
        {
           background.sprite = defeat;
           PlaySounds(defeatSound);
        }
        else
        {
            background.sprite = win;
            PlaySounds(winSound);
        }

        StartCoroutine(ActiveStars(n));
        level_txt.text = level.ToString();
    }

    private void PlaySounds(AudioClip audio)
    {
        if (PlayerPrefs.GetInt("Sound", 0) == 1)
        {
            audioSource.PlayOneShot(audio);
        }
    }
}
