using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
   public void Update()
   {
       if(this.gameObject.transform.position.y <= -40)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
            this.gameObject.transform.position = new Vector3(1f, 10f, 0f);
        }
   }

}
