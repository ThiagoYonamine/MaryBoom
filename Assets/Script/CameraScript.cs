using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    private float scaleX;
    private float scaleY;
    private float desireX;
    private float desireY;
    private float cameraSpeed;

    private void Start()
    {
        scaleX = 0.1f;
        scaleY = 0.2f;
        cameraSpeed = 2;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.GetComponent<Transform>().position;
        float currentCameraSize = this.GetComponent<Camera>().orthographicSize;
        this.GetComponent<Camera>().orthographicSize = Mathf.Lerp(currentCameraSize, 5+playerPosition.y*0.05f, Time.deltaTime*cameraSpeed);
        desireX = playerPosition.x * scaleX;
        desireY = (playerPosition.y * scaleY)-1;
        Vector3 currentPosition = this.GetComponent<Transform>().position;
        if (Mathf.Abs(currentPosition.x - desireX) > 0.1 || Mathf.Abs(currentPosition.y - desireY) > 0.1)
        {
            this.GetComponent<Transform>().position = new Vector3(Mathf.Lerp(currentPosition.x, desireX, Time.deltaTime*cameraSpeed), Mathf.Lerp(currentPosition.y, desireY, Time.deltaTime*cameraSpeed), -10);
        }
       
    }
}
