using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{

    public Camera mainCamera;

    private GameObject ceu;
    private GameObject solo3;
    private GameObject solo2;
    private GameObject solo1;


    public void Start()
    {
        solo1 = this.transform.GetChild(1).gameObject;
        solo2 = this.transform.GetChild(2).gameObject;
        solo3 = this.transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float x = mainCamera.transform.position.x;
        float y = mainCamera.transform.position.y;

        solo1.transform.position = new Vector3(x/1.1f, -y-6f,0);
        solo2.transform.position = new Vector3(x/1.2f, -y/1.1f-1, 0);
        solo3.transform.position = new Vector3(x/1.5f, -y/1.5f, 0);
    }
}
