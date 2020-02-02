using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIf : MonoBehaviour
{

    public GameObject target;


    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
        }
    }
}
