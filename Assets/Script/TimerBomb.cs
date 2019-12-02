using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBomb : MonoBehaviour
{
    public GameObject explosion;
    private Animator animator;


    public AudioClip explosionSound;
    private AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public void Trigger()
    {
        PlaySounds();
        animator.Play("TimerBomb");
    }

    public void Detonate()
    {
        
        StartCoroutine(StartDetonation());
       
    }

    IEnumerator StartDetonation()
    {
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    private void PlaySounds()
    {
        if (PlayerPrefs.GetInt("Sound", 0) == 1)
        {
            audioSource.PlayOneShot(explosionSound);
        }
    }
}
