using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{

   public Vector3 position = new Vector3(1f, 10f, 0f);
   public void Update()
   {
       if(this.gameObject.transform.position.y <= -40)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
            this.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);
            this.gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            this.gameObject.transform.position = position;
        }
   }

}
