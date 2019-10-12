using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool finish;
    private Vector3 finishPosition;
    public Controller controller;
    private float gameOverTimer;
    private bool touchedEnemy;


    private void Start()
    {
        finish = false;
        touchedEnemy = false;
        gameOverTimer = 5;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Finish")
        {
            finish = true;
            this.GetComponent<Rigidbody>().useGravity = false;
            finishPosition = other.gameObject.transform.position;
        }

        else if (other.gameObject.tag == "Mola")
        {
            other.GetComponent<Animator>().Play("MolaPlay");

            float forceX = Mathf.Cos(other.transform.eulerAngles.z%90);
            float forceY = Mathf.Abs(Mathf.Sin(other.transform.eulerAngles.z%90));
            this.GetComponent<Rigidbody>().AddForce(new Vector3(forceX*10, forceY*10, 0), ForceMode.Impulse);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            touchedEnemy = true;
        }
    }

    private void Update()
    {
        if (finish)
        {
            this.transform.position = 
                Vector3.Lerp(this.transform.position, finishPosition, Time.deltaTime*2); 
            this.GetComponent<Rigidbody>().velocity = 
                Vector3.Lerp(this.GetComponent<Rigidbody>().velocity, Vector3.zero, Time.deltaTime*3);
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            this.transform.rotation = 
                Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime*3);

            ShowMenu(true);
        }
        else
        {
            CheckGameOver();
        }


    }

    private void CheckGameOver()
    {
        if (!controller.HasBomb())
        {
            if (gameOverTimer <= 0 || IsStopped())
            {
                controller.ShowMenu(false);
            }
            else
            {
                float variation = Time.deltaTime;
                gameOverTimer -= variation;
                controller.FadeOut(variation * 0.08f);
            }
        }
        else if (IsOutOfScene() || touchedEnemy)
        {
            controller.ShowMenu(false);
        }
     
    }

    private bool IsStopped()
    {
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        if (rigidbody.velocity.sqrMagnitude < .1 && rigidbody.angularVelocity.sqrMagnitude < .1)
        {
            return true;
        }
        return false;
    }

    private bool IsOutOfScene()
    {
        if (this.transform.position.y < -8f)
        {
            this.GetComponent<Rigidbody>().useGravity = false;
            return true;
        }
        return false;
    }

    private void ShowMenu(bool isVictory)
    {
        if (Mathf.Abs(this.transform.position.x - finishPosition.x) < 0.1 &&
              Mathf.Abs(this.transform.position.y - finishPosition.y) < 0.5)
        {
            controller.ShowMenu(isVictory);
        }
    }
}
