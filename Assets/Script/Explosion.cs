using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float power;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 bombSize = this.GetComponent<Transform>().localScale;
        Collider[] colliders = Physics.OverlapSphere(this.GetComponent<Transform>().position, bombSize.x*2f);
        foreach(Collider hit in colliders)
        {
            Rigidbody rib = hit.GetComponent<Rigidbody>();
            if (rib != null)
            {
                if (rib.gameObject.tag == "TNT")
                {
                    rib.AddExplosionForce(bombSize.x * power/3, this.GetComponent<Transform>().position, bombSize.x * 2f, 0.1f, ForceMode.Impulse);
                    if (ShouldDetonate(rib.gameObject.transform.position, this.GetComponent<Transform>().position, bombSize.x))
                    {
                        rib.gameObject.GetComponent<TNT>().Detonate();
                    }
                }
                else if (rib.gameObject.tag == "TimerBomb")
                {
                    rib.AddExplosionForce(bombSize.x * power / 3, this.GetComponent<Transform>().position, bombSize.x * 2f, 0.1f, ForceMode.Impulse);
                    if (ShouldDetonate(rib.gameObject.transform.position, this.GetComponent<Transform>().position, bombSize.x))
                    {
                        rib.gameObject.GetComponent<TimerBomb>().Trigger();
                    }
                }
                else if (rib.gameObject.tag == "Hay")
                {
                    if (ShouldDetonate(rib.gameObject.transform.position, this.GetComponent<Transform>().position, bombSize.x))
                    {
                        rib.gameObject.GetComponent<Hay>().Burn();
                    }
                }
                else
                {
                    rib.velocity = new Vector3(rib.velocity.x, 0, 0);
                    rib.AddExplosionForce(bombSize.x * power, this.GetComponent<Transform>().position, bombSize.x * 2f, 0.1f, ForceMode.Impulse);
                }
            }

        }
    }

    private bool ShouldDetonate(Vector3 obj, Vector3 explosion, float bombSize)
    {
        if(Mathf.Abs(obj.x - explosion.x) < bombSize && Mathf.Abs(obj.y - explosion.y) < bombSize)
        {
            return true;
        }
        return false;
    }

}
