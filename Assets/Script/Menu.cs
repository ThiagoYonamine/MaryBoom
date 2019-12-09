using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject[] stars;
    public GameObject[] buttons;
    public Image background;
    public Sprite win;
    public Sprite defeat;
    public Text level_txt;
    public GoogleMobileAdsDemoScript ads;

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
        buttons[3].SetActive(false);
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

        // number of star > 0 = victory case
        if (n > 0)
        {
            buttons[0].SetActive(true); // replay
            yield return new WaitForSeconds(0.2f);
            buttons[1].SetActive(true); // next
            yield return new WaitForSeconds(0.2f);
            buttons[2].SetActive(true); // home
        }
        // defeat case
        else
        {
            buttons[0].SetActive(true); // replay
            yield return new WaitForSeconds(0.2f);
            buttons[2].SetActive(true); // home
            yield return new WaitForSeconds(0.2f);
            buttons[3].SetActive(true); // reward
            buttons[3].GetComponent<Button>().interactable = false;
            StartCoroutine(SetRewardActive());
            
        }
    }

    public void Play(int n, int level)
    {
        if (n <= 0)
        {
            LoadRewarded();
        }
        if (BGMusic.Instance != null)
        {
            BGMusic.Instance.PauseMusic();
        }
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

    public int GetCurrentScene()
    {
        string scene = SceneManager.GetActiveScene().name;
        try
        {
            return Int32.Parse(scene.Substring(4));

        }
        catch (FormatException)
        {
            Debug.Log("Unable to parse int");
            return 0;
        }
    }


    private void LoadRewarded()
    {
        if (ads != null)
        {
            ads.CreateAndLoadRewardedAd();
        }
    }

    private bool IsRewardedAdLoaded()
    {
        if (ads != null)
        {
           return ads.IsRewardedAdLoaded();
        }
        return false;
    }

    public void ShowRewarded()
    {
        if (ads != null)
        {
            ads.ShowRewardedAd(GetCurrentScene());
            buttons[3].GetComponent<Button>().interactable = false;
        }
    }

    IEnumerator SetRewardActive()
    {
        int i = 0;
        for(i=0;i<5;i++)
        {
            if (IsRewardedAdLoaded())
            {
                buttons[3].GetComponent<Button>().interactable = true;
                break;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
