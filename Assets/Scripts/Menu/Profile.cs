using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Profile : MonoBehaviour
{
    [Serializable]
    public class Achive
    {
        public GameObject success;
        public GameObject work;
        public GameObject noSuccess;
    }

    public List<Achive> arrAchives;

    void Start()
    {
        PlayerPrefs.SetInt("Achive3", 2);
        PlayerPrefs.SetInt("Achive4", 1);


        for (int i = 0; i < arrAchives.Count; i++)
        {
            if(PlayerPrefs.GetInt($"Achive{i}") == 0 )
            {
                arrAchives[i].noSuccess.SetActive(true);
                arrAchives[i].success.SetActive(false);
                arrAchives[i].work.SetActive(false);
            }
            else if(PlayerPrefs.GetInt($"Achive{i}") == 1)
            {
                arrAchives[i].noSuccess.SetActive(false);
                arrAchives[i].success.SetActive(false);
                arrAchives[i].work.SetActive(true);
            }
            else
            {
                arrAchives[i].noSuccess.SetActive(false);
                arrAchives[i].success.SetActive(true);
                arrAchives[i].work.SetActive(false);
            }

        }    
    }

    public void backMenu()
    {
        this.gameObject.GetComponent<Animator>().Play("exitLoad");
    }

    public void exitProfile()
    {
        SceneManager.LoadScene("Menu");
        MainMenu.startload = true;
    }
    
    
}
