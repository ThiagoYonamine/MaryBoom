using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hay : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Burn()
    {
        animator.Play("HayExplode");
    }

    public void Detonate()
    {
        Destroy(this.gameObject);
    }
}
