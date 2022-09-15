using UnityEngine;
using UnityEngine.UI;
using System;

public class Setting : MonoBehaviour
{
    [Serializable]
    public class Sound
    {
        public Image imageOn;
        public Image imageOff;
    }
    [Serializable]
    public class Music
    {
        public Image imageOn;
        public Image imageOff;
    }
    [Serializable]
    public class Graphic
    {
        public Image hight;
        public Image middle;
        public Image low;
    }

    public Sound soundController;
    public Music musicController;
    public Graphic graphicController;

    void Start()
    {
        examination();
        
        
    }

    public void examination()
    {
        Color greenColor = new Color(0f, 241f, 11f, 255f);
        Color standartColor = new Color(255f, 255f, 255f, 255f);

        if (PlayerPrefs.GetInt("sound") == 0) // 0 -on
        {
            soundController.imageOn.color = greenColor;
            soundController.imageOff.color = standartColor;  
        }
        else if(PlayerPrefs.GetInt("sound") == -1) // -1 - off
        {
            soundController.imageOn.color = standartColor;
            soundController.imageOff.color = greenColor; 
        }



        if (PlayerPrefs.GetInt("music") == 0) // 0 -on
        {
            musicController.imageOn.color = greenColor;
            musicController.imageOff.color = standartColor;
        }
        else if (PlayerPrefs.GetInt("music") == -1) // -1 - off
        {
            musicController.imageOn.color = standartColor;
            musicController.imageOff.color = greenColor;
        }


        if (PlayerPrefs.GetInt("graphic") == 0) // 0 - hight
        {
            graphicController.hight.color = greenColor;
            graphicController.middle.color = standartColor;
            graphicController.low.color = standartColor;

        }
        else if (PlayerPrefs.GetInt("graphic") == -1) // -1 - middle
        {
            graphicController.hight.color = standartColor;
            graphicController.middle.color = greenColor;
            graphicController.low.color = standartColor;

        }

        else if (PlayerPrefs.GetInt("graphic") == -2) // -2 - low
        {
            graphicController.hight.color = standartColor;
            graphicController.middle.color = standartColor;
            graphicController.low.color = greenColor;

        }


    }

    public void soundOn()
    {
        PlayerPrefs.SetInt("sound", 0);
        examination();
    }
    public void soundOff()
    {
        PlayerPrefs.SetInt("sound", -1);
        examination();
    }




    public void musicOn()
    {
        PlayerPrefs.SetInt("music", 0);
        examination();
    }
    public void musicOff()
    {
        PlayerPrefs.SetInt("music", -1);
        examination();
    }




    public void graphicHight()
    {
        PlayerPrefs.SetInt("graphic", 0);
        examination();
    }

    public void graphicMiddle()
    {
        PlayerPrefs.SetInt("graphic", -1);
        examination();
    }

    public void graphicLow()
    {
        PlayerPrefs.SetInt("graphic", -2);
        examination();
    }






}
