using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    private float desireX;
    private float desireY;

    public float cameraSpeed = 2f;
    public float scaleX = 0.4f;
    public float scaleY = 0.2f;
    public float cameraSize = 5;
    public float offsetY = 1.2f;
    public float offsetX = 0f;

    void Start()
    {
        float resolution = Screen.width / (Screen.height * 1.0F);
        cameraSize *= (2F/ resolution);

        cameraSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.GetComponent<Transform>().position;
        float currentCameraSize = this.GetComponent<Camera>().orthographicSize;

        if (cameraSpeed < 2f)
        {
            cameraSpeed *= 1.05f;
            Debug.Log("cameraSize: " + cameraSpeed);
        }
        this.GetComponent<Camera>().orthographicSize = Mathf.Lerp(currentCameraSize, cameraSize+playerPosition.y*0.05f, Time.deltaTime*cameraSpeed);


        desireX = (playerPosition.x * scaleX)-offsetX;
        desireY = (playerPosition.y * scaleY)-offsetY;
        Vector3 currentPosition = this.GetComponent<Transform>().position;
        if (Mathf.Abs(currentPosition.x - desireX) > 0.1 || Mathf.Abs(currentPosition.y - desireY) > 0.1)
        {
            this.GetComponent<Transform>().position = new Vector3(Mathf.Lerp(currentPosition.x, desireX, Time.deltaTime*cameraSpeed), Mathf.Lerp(currentPosition.y, desireY, Time.deltaTime*cameraSpeed), -10);
        }
       
    }
}
