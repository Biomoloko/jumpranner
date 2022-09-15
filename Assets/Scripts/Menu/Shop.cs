using TMPro;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Shop: MonoBehaviour
{

    [Serializable]
    public class PersonShop
    {
        public int thisViewPerson = 0;
        public List<GameObject> arrPerson;

        public GameObject buttonSelect;
        public GameObject buttonBuy;
        public GameObject buttonSelected;

    }

    [Serializable]
    public class MapShop
    {
        public int thisViewMap = 0;
        public List<GameObject> arrMaps;

        public GameObject buttonSelect;
        public GameObject buttonBuy;
        public GameObject buttonSelected;

    }

    public Animator anim;
    public int thisStage = 0;
    public TextMeshProUGUI moneyCount;

    public PersonShop personShop;
    public MapShop mapShop;


    void Start()
    {
        PlayerPrefs.SetInt("Person0", 1);
        PlayerPrefs.SetInt("Money", 15000);
        personShop.thisViewPerson = PlayerPrefs.GetInt("thisSelectedPerson");
        

        updateShop();
    }

    public void updateShop()
    {
        foreach (GameObject obj in personShop.arrPerson)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in mapShop.arrMaps)
        {
            obj.SetActive(false);
        }

        personShop.arrPerson[personShop.thisViewPerson].SetActive(true);
        mapShop.arrMaps[mapShop.thisViewMap].SetActive(true);

        if (PlayerPrefs.GetInt($"Person{personShop.thisViewPerson}") == 1)
        {
            personShop.buttonSelect.SetActive(true);
            personShop.buttonBuy.SetActive(false);
            personShop.buttonSelected.SetActive(false);

            if (PlayerPrefs.GetInt($"thisSelectedPerson") == personShop.thisViewPerson)
            {
                personShop.buttonSelect.SetActive(false);
                personShop.buttonBuy.SetActive(false);
                personShop.buttonSelected.SetActive(true);
            }
        }
        else
        {
            personShop.buttonSelect.SetActive(false);
            personShop.buttonBuy.SetActive(true);
            personShop.buttonSelected.SetActive(false);

        }

        if (PlayerPrefs.GetInt($"Map{mapShop.thisViewMap}") == 1)
        {
            mapShop.buttonSelect.SetActive(true);
            mapShop.buttonBuy.SetActive(false);
            mapShop.buttonSelected.SetActive(false);

            if (PlayerPrefs.GetInt($"thisSelectedMap") == mapShop.thisViewMap)
            {
                mapShop.buttonSelect.SetActive(false);
                mapShop.buttonBuy.SetActive(false);
                mapShop.buttonSelected.SetActive(true);
            }
        }
        else
        {
            mapShop.buttonSelect.SetActive(false);
            mapShop.buttonBuy.SetActive(true);
            mapShop.buttonSelected.SetActive(false);

        }

        moneyCount.text = $"{PlayerPrefs.GetInt("Money")}";

    }

    public void back()
    {
        if(thisStage == 0)
            thisStage= -1;
        if (thisStage == 1)
            thisStage = 0;
        if (thisStage == 2)
            thisStage = 0;    
        
        anim.SetInteger("stage", thisStage);


    }

    public void openShopPerson()
    {
        thisStage = 1;
        anim.SetInteger("stage", thisStage);
    }
    public void openMapPerson()
    {
        thisStage = 2;
        anim.SetInteger("stage", thisStage);
    }

    public void backMenu()
    {
        SceneManager.LoadScene("Menu");
        MainMenu.startload = true;
    }

    public void nextPerson()
    {
        if( personShop.thisViewPerson < personShop.arrPerson.Count - 1)
        {
            personShop.thisViewPerson++;
            updateShop();
        }
    }
    public void nextMap()
    {
        if (mapShop.thisViewMap < mapShop.arrMaps.Count - 1)
        {
            mapShop.thisViewMap++;
            updateShop();
        }
    }

    public void backPerson()
    {
        if (personShop.thisViewPerson >= 1 )
        {
            personShop.thisViewPerson--;
            updateShop();
        }
    }
    public void backMap()
    {
        if (mapShop.thisViewMap >= 1)
        {
            mapShop.thisViewMap--;
            updateShop();
        }
    }

    public void selecte()
    {
        if(thisStage == 1)
            PlayerPrefs.SetInt($"thisSelectedPerson", personShop.thisViewPerson);
        else
            PlayerPrefs.SetInt($"thisSelectedMap", mapShop.thisViewMap);
        updateShop();
    }

    public void buy()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 5000);
        if (thisStage == 1)
            PlayerPrefs.SetInt($"Person{personShop.thisViewPerson}", 1);
        else
            PlayerPrefs.SetInt($"Map{mapShop.thisViewMap}", 1);
        updateShop();
    }

}
