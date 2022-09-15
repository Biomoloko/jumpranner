using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHexAnimator : MonoBehaviour
{
    void Start()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (Main.statusGame)
            GetComponentInParent<Animator>().SetBool("life", false);
    }
}
