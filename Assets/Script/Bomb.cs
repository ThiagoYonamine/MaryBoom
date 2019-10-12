using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bomb : MonoBehaviour
{
    public GameObject explosion;
    public GameObject bomb;
    private GameObject bombInstance;
    public Camera cam;
    public Controller controller;
    private float plusY;
    private bool pressed;

    private void Start()
    {
        pressed = false;
        plusY = 2f;
    }

    void Update()
    {
        if (controller.HasBomb() && !controller.IsFinished())
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
                
                Vector3 position = cam.ScreenToWorldPoint(touch.position);
                bombInstance = Instantiate(bomb, new Vector3(position.x, position.y+plusY, 0), Quaternion.identity);
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 position = cam.ScreenToWorldPoint(touch.position);
                bombInstance.GetComponent<Transform>().position = new Vector3(position.x, position.y+plusY, 0);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                controller.DecrementBombNumber();
                Vector3 position = cam.ScreenToWorldPoint(touch.position);
                Vector2 bombSize = bombInstance.GetComponent<Transform>().localScale;
                explosion.GetComponent<Transform>().localScale = bombSize * 2;
                Instantiate(explosion, new Vector3(position.x, position.y+plusY, 0), Quaternion.identity);
                Destroy(bombInstance);
            }
        }
        
#elif UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition);
            bombInstance = Instantiate(bomb, new Vector3(position.x, position.y+plusY, 0), Quaternion.identity);
            pressed = true;
        }

        if (pressed)
        {
            Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition);
            bombInstance.GetComponent<Transform>().position = new Vector3(position.x, position.y+plusY, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            controller.DecrementBombNumber();
            Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 bombSize = bombInstance.GetComponent<Transform>().localScale;
            explosion.GetComponent<Transform>().localScale = bombSize * 2;
            Instantiate(explosion, new Vector3(position.x, position.y+plusY, 0), Quaternion.identity);
            Destroy(bombInstance);
            pressed = false;
        }
#endif
    }
}
