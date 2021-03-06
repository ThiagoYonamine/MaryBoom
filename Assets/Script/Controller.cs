﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public Menu menu;
    public Text bomb;
    public Text extraBomb;
    public Text PerfectStar;
    public Image fade;
    public GoogleMobileAdsDemoScript ads;
    private int bombNumber;
    private int extraBombNumber;
    private int currentScene;
    private int currentStar;
    private bool menuCalled;
    private int plays;
    private int perfectStarCount;

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
        extraBombNumber = PlayerPrefs.GetInt(Constant.EXTRA_BOMBS + currentScene, 0);
        updateExtraBombs();
        bomb.text = bombNumber.ToString();
        menuCalled = false;
        perfectStarCount = (bombNumber+extraBombNumber - Constant.star3[currentScene]);
        PerfectStar.text = perfectStarCount.ToString();

        //Set player stats
        int totalPlays = PlayerPrefs.GetInt("TotalPlays", 0);
        PlayerPrefs.SetInt("TotalPlays", ++totalPlays);

        if (ShouldShowInterestial())
        {
            LoadInterestial();
        }
      
    }

    private void updateExtraBombs()
    {
        if (extraBombNumber > 0)
        {
            extraBomb.gameObject.SetActive(true);
            extraBomb.text = "+" + extraBombNumber.ToString();
        } else
        {
            extraBomb.gameObject.SetActive(false);
        }
      
    }

    public bool ShouldShowInterestial()
    {
        if (PlayerPrefs.GetInt("Plays", 0) >= 10 && PlayerPrefs.GetInt("Ads" + currentScene, 0) == 0)
        {
            return true;
        }
        return false;
    }

    public bool IsFinished()
    {
        return menu.isActiveAndEnabled;
    }

    public void DecrementBombNumber()
    {
        if(extraBombNumber > 0)
        {
            extraBombNumber--;
            updateExtraBombs();
        }
        else
        {
            bombNumber--;
            bomb.text = bombNumber.ToString();
        }
      

        perfectStarCount--;
        if (perfectStarCount < 0)
        {
            PerfectStar.text = "-";
        }
        else
        {
            PerfectStar.text = perfectStarCount.ToString();
        }
       

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
            if (ShouldShowInterestial())
            {
                ShowInterestial();
                PlayerPrefs.SetInt("Plays", 0);
                PlayerPrefs.SetInt("Ads" + currentScene, 1);
            }
            Debug.Log("ShowBanner");
            ShowBanner();
            plays = PlayerPrefs.GetInt("Plays", 0);
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

    public void ShowRewarded()
    {
        ads.ShowRewardedAd(currentScene);
    }

    void OnDestroy()
    {
        Debug.Log("OnDestroy1");
        ads.DestroyAds();
    }
}
