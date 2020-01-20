﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        int sum = 0;
        for(int i = 1; i <= 30; i++)
        {
            sum += PlayerPrefs.GetInt("Fase"+i, 0);
        }
        
        score.text = sum+"/90";
    }

}
