using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{
    public GameObject explosion;

    public void Detonate()
    {
          Instantiate(explosion, this.transform.position, Quaternion.identity);
          Destroy(this.gameObject);
    }
}
