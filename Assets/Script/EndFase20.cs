using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFase20 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }

    }
}
