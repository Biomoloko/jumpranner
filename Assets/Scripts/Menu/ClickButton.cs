using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    

    public void click()
    {
        this.gameObject.GetComponent<Animator>().Play("click");
    }
}
