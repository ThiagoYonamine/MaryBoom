using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoButon : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private float timer;

    private void Start()
    {
        timer = 0;
        this.gameObject.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (videoPlayer.isPlaying)
        {
            timer += Time.deltaTime;
            if(timer >= 8)
            {
                this.gameObject.GetComponent<Button>().interactable = true;
            }
         
        }
    }
}
