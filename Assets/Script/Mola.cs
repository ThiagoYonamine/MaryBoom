using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mola : MonoBehaviour
{
    public AudioClip explosionSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayerPrefs.SetInt("Sound", 1);
    }

    void OnTriggerEnter(Collider other)
    {
        this.GetComponent<Animator>().Play("MolaPlay");
        PlaySounds();
        float forceX = Mathf.Sin(this.transform.eulerAngles.z % 91);
        float forceY = Mathf.Abs(Mathf.Cos(this.transform.eulerAngles.z % 91));
        Debug.Log("X " + forceX + " Y " + forceY);
        other.GetComponent<Rigidbody>().AddForce(new Vector3(forceX * -15, forceY * 10, 0), ForceMode.VelocityChange);
    }

    private void PlaySounds()
    {
        if (PlayerPrefs.GetInt("Sound", 0) == 1)
        {
            audioSource.PlayOneShot(explosionSound);
        }
    }
}
