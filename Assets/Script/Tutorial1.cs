using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial1 : MonoBehaviour
{

    public GameObject touch_tutorial;
    public GameObject down_tutorial;
    public GameObject size_tutorial;
    private bool pressed;
    public Camera cam;
    public GameObject player;

    private void Start()
    {
        touch_tutorial.SetActive(true);
        down_tutorial.SetActive(false);
        size_tutorial.SetActive(false);
    }
    void Update()
    {
        if (player.transform.position.x > -2)
        {
            touch_tutorial.SetActive(false);
            down_tutorial.SetActive(false);
            size_tutorial.SetActive(false);
        }
        else
        {
            CheckTouch();
        }

    }

    private void CheckTouch()
    {

#if UNITY_ANDROID && !UNITY_EDITOR
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                 touch_tutorial.SetActive(false);
                 down_tutorial.SetActive(true);
            
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 position = cam.ScreenToWorldPoint(touch.position);
                if (position.y < -3 && position.x < -5.5f)
                {
                    down_tutorial.SetActive(false);
                    size_tutorial.SetActive(true);
                }
                 else
                 {
                    down_tutorial.SetActive(true);
                    size_tutorial.SetActive(false);
                 }
              
            }

            if (touch.phase == TouchPhase.Ended)
            {
                size_tutorial.SetActive(false);
                down_tutorial.SetActive(false);
                touch_tutorial.SetActive(true);
            }
        }
        
#elif UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            touch_tutorial.SetActive(false);
            down_tutorial.SetActive(true);
            pressed = true;
        }

        if (pressed)
        {
            Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition);
            if (position.y < -3 && position.x < -5.5f)
            {
                down_tutorial.SetActive(false);
                size_tutorial.SetActive(true);
            }
            else
            {
                down_tutorial.SetActive(true);
                size_tutorial.SetActive(false);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            size_tutorial.SetActive(false);
            down_tutorial.SetActive(false);
            touch_tutorial.SetActive(true);
            pressed = false;

        }
#endif
    }
}
