using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBomb : MonoBehaviour
{
    public GameObject explosion;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
