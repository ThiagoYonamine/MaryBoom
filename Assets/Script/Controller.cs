using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public Menu menu;
    public Text bomb;
    public Image fade;
    public GoogleMobileAdsDemoScript ads;
    private int bombNumber;
    private int currentScene;
    private int currentStar;
    private bool menuCalled;
    private int plays;

    void Start()
    {
        if (BGMusic.Instance != null)
        {
            BGMusic.Instance.ResumeMusic();
        }

        menu.gameObject.SetActive(true);
        currentScene = GetCurrentScene();
        currentStar = PlayerPrefs.GetInt(Constant.FASE_PREFIX + currentScene.ToString(), 0);
        bombNumber = Constant.initb[currentScene];
        bomb.text = bombNumber.ToString();
        menuCalled = false;

        plays = PlayerPrefs.GetInt("Plays", 0);
        if (plays % 5 == 0)
        {
            LoadInterestial();
        }
      
    }

    public bool IsFinished()
    {
        return menu.isActiveAndEnabled;
    }

    public void DecrementBombNumber()
    {
        bombNumber--;
        bomb.text = bombNumber.ToString();
    }

    public void FadeOut(float value)
    { 
        var tempColor = fade.color;
        tempColor.a += value;
        fade.color = tempColor;
    }

    public void ResetFadeOut()
    {
        var tempColor = fade.color;
        tempColor.a = 0;
        fade.color = tempColor;
    }

    public bool HasBomb()
    {
        return bombNumber > 0;
    }

    public void ShowMenu(bool isVictory)
    {
        if (!menuCalled)
        {
            menuCalled =true;
            int starNumber = 0;
            if (isVictory)
            {
                ResetFadeOut();
                if (bombNumber >= Constant.star3[currentScene]) starNumber = 3;
                else if (bombNumber >= Constant.star2[currentScene]) starNumber = 2;
                else if (bombNumber >= Constant.star1[currentScene]) starNumber = 1;
            }
            SaveStarPrefs(starNumber);
            if (plays % 5 == 0)
            {
                ShowInterestial();
            }
            Debug.Log("ShowBanner");
            ShowBanner();
            PlayerPrefs.SetInt("Plays", ++plays);
            menu.Play(starNumber, currentScene);
        }
    }

    private void SaveStarPrefs(int newStar)
    {
        if (currentStar != newStar)
        {
            currentStar = newStar;
            int maxStar = PlayerPrefs.GetInt(Constant.FASE_PREFIX + currentScene.ToString(), 0);
            PlayerPrefs.SetInt(Constant.FASE_PREFIX + currentScene.ToString(), Math.Max(maxStar, currentStar));
           
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

    public void ShowBanner()
    {
        ads.RequestBanner();
    }

    public void LoadInterestial()
    {
        ads.RequestInterstitial();
    }

    public void ShowInterestial()
    {
        ads.ShowInterstitial();
    }

    void OnDestroy()
    {
        Debug.Log("OnDestroy1");
        ads.DestroyAds();
    }
}
