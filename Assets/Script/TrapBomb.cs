using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBomb : MonoBehaviour
{
    public GameObject explosion;


    public AudioClip explosionSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player" || col.gameObject.tag == "Obs")
        {
            PlaySounds(explosionSound);
            StartCoroutine(StartDetonation());
        }
    }

    IEnumerator StartDetonation()
    {
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    private void PlaySounds(AudioClip audio)
    {
        if (PlayerPrefs.GetInt("Sound", 0) == 1)
        {
            audioSource.PlayOneShot(audio);
        }
    }
}
