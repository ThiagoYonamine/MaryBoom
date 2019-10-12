using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBomb : MonoBehaviour
{
    public GameObject explosion;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Trigger()
    {
        animator.Play("TimerBomb");
    }

    public void Detonate()
    {
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
