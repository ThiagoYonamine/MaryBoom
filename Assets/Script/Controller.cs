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
    public Image fade;
    private int bombNumber;
    private int currentScene;
    private int currentStar;

    void Start()
    {
        currentScene = GetCurrentScene();
        currentStar = PlayerPrefs.GetInt(Constant.FASE_PREFIX + currentScene.ToString(), 0);
        bombNumber = Constant.initb[currentScene];
        bomb.text = bombNumber.ToString();
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
        int starNumber = 0;
        if (isVictory) {
            ResetFadeOut();
            if (bombNumber >= Constant.star3[currentScene]) starNumber = 3;
            else if (bombNumber >= Constant.star2[currentScene]) starNumber = 2;
            else if (bombNumber >= Constant.star1[currentScene]) starNumber = 1;
        }
        SaveStarPrefs(starNumber);
        menu.Play(starNumber, currentScene);
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
}