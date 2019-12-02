using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{
    public GameObject explosion;

    public AudioClip explosionSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator StartDetonation()
    {
        yield return new WaitForSeconds(0.15f);
        PlaySounds(explosionSound);
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);

    }

    public void Detonate()
    {
        StartCoroutine(StartDetonation());
    }

    private void PlaySounds(AudioClip audio)
    {
        if (PlayerPrefs.GetInt("Sound", 0) == 1)
        {
            audioSource.PlayOneShot(audio);
        }
    }
}
