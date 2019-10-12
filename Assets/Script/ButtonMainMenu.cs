using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonMainMenu : MonoBehaviour
{
    public GameObject[] star;
    public GameObject lockImg;
    public Text levelTxt;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        for (int i = 0; i < 3; i++)
        {
            star[i].SetActive(false);
        }
        lockImg.SetActive(false);
        levelTxt.text = GetSceneNumber().ToString();

        if (IsLocked())
        {
           // this.GetComponent<Image>().color = Color.gray;
            this.GetComponent<Button>().interactable = false;
            lockImg.SetActive(true);
            levelTxt.text = "";
        }

        int currentStars = PlayerPrefs.GetInt(this.gameObject.name, 0);
        for(int i = 0; i < currentStars; i++)
        {
            star[i].SetActive(true);
        }
    }

    private bool IsLocked()
    {
        int sceneNumber = GetSceneNumber();
        sceneNumber--;
       if (sceneNumber == 0) return false;
       return PlayerPrefs.GetInt(Constant.FASE_PREFIX+sceneNumber.ToString(), 0) <= 0;
    }

    private int GetSceneNumber()
    {
        int sceneNumber = 0;
        try
        {
            sceneNumber = Int32.Parse(this.gameObject.name.Substring(4));
        }
        catch (FormatException)
        {
            Debug.Log("Unable to parse int");
        }
        return sceneNumber;
    }
}
