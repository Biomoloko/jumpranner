using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bot : MonoBehaviour
{
    public GameObject obj;
    public Rigidbody rigidbody;
    public Animator anim;

    bool freeGravity = true;

    public Vector3 navigateDirection = new Vector3(0, 0, 0);
    public DateTime timer = DateTime.Now;
    public int sec = 0;

    private void Start()
    {
       


    }
    public void resetTime(int navigate = 0)
    {
        timer = DateTime.Now;

        if (freeGravity & navigate == 0)
        {
            anim.SetBool("IsGrounded", false);
            navigateDirection = new Vector3(UnityEngine.Random.Range(-2, 2), rigidbody.velocity.y, UnityEngine.Random.Range(-2, 2));
        }
        else if(navigate == 0)
        {
            anim.SetBool("IsGrounded", true);
            navigateDirection = new Vector3(UnityEngine.Random.Range(-2, 2), 0, UnityEngine.Random.Range(-2, 2));
        }
        else 
        {
            navigateDirection = new Vector3(-rigidbody.velocity.x, 0, -rigidbody.velocity.z);
        }
        sec = UnityEngine.Random.Range(-2, 2);
    }




    public void FixedUpdate()
    {
        if (Main.statusGame)
        {
            rigidbody.velocity = navigateDirection;

            if ((DateTime.Now - timer).Seconds >= sec)
                        resetTime();
            freeGravity = true;
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        freeGravity = false;
    }
    private void OnCollisionExit(Collision collision)
    {
        freeGravity = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "walls")
        {
            resetTime(1);
        }
        if(collision.collider.name == "lastPanel")
        {
            GameObject.Destroy(gameObject);
            Main.countLifeBots--;
        }
    }
}