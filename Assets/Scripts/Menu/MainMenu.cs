using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Animator animLoad;
    public AnimateScript animateScript;

    static public bool startload = false;

    private void Start()
    {
        if(startload)
            animLoad.SetInteger("stage", 1);
    }
    public void loadScene(string name)
    {
        animLoad.SetInteger("stage", 2);
        animateScript.nameScene = name;
    }

    public void openVk()
    {
        Application.OpenURL("https://vk.com/public208616619");
    }

    public void openStart()
    {
        Application.OpenURL("https://vk.com/public208616619");
    }

    public void loadOtherGame()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.SpaceOfEternity.Cannonwithseals");
    }
}
