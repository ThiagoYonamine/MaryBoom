﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mola : MonoBehaviour
{
    public AudioClip explosionSound;
    private AudioSource audioSource;
    public float forceIntensityX=15;
    public float forceIntensityY=10;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        this.GetComponent<Animator>().Play("MolaPlay");
        PlaySounds();
        float forceX = Mathf.Sin(this.transform.eulerAngles.z % 91);
        float forceY = Mathf.Abs(Mathf.Cos(this.transform.eulerAngles.z % 91));
        other.GetComponent<Rigidbody>().AddForce(new Vector3(forceX * -forceIntensityX, forceY * forceIntensityY, 0), ForceMode.VelocityChange);
    }

    private void PlaySounds()
    {
        if (PlayerPrefs.GetInt("Sound", 0) == 1)
        {
            audioSource.PlayOneShot(explosionSound);
        }
    }
}
