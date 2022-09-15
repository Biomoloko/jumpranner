using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Main : MonoBehaviour
{
    
    static public bool statusGame = false;
    static public int countLifeBots = 9;

    new public GameObject camera;

    [Serializable]    
    public class Player
    {
        public GameObject mainObj;
        public List<Animator> arrAnimPerson;
        public List<GameObject> arrPerson;
    }

    [Serializable]
    public class Statistic
    {
        public int thisPerson = 2;
        
    }

    [Serializable]
    public class BotController
    {
        public List<GameObject> arrBots;
        public List<Bot> arrActiveBots = new List<Bot>(10);
        
    }
   

    public List<Transform> arrTransformRespawn;

    public BotController botController;
    public Player player;
    public PlayerControllerNew playerController;
    public Statistic statistic;

    public int positionPlayer;


    private void Start()
    {

        PlayerPrefs.SetInt("thisSelectedPerson", 3);
        statistic.thisPerson = PlayerPrefs.GetInt("thisSelectedPerson");
        player.arrPerson[statistic.thisPerson].SetActive(true);


        positionPlayer = UnityEngine.Random.Range(0, 3);
        player.mainObj.transform.position = arrTransformRespawn[positionPlayer].position;

        for(int i = 0; i < botController.arrBots.Count - 1 ; i++)
        {
            
            if(i != positionPlayer)
            {
                int variableBot = UnityEngine.Random.Range(0, botController.arrBots.Count - 1);
                Bot bot = new Bot() { obj = Instantiate(botController.arrBots[variableBot].GetComponent<Bot>().obj) };

                botController.arrActiveBots[i] = bot;
                botController.arrActiveBots[i].anim = botController.arrActiveBots[i].obj.GetComponent<Animator>();
                botController.arrActiveBots[i].obj.transform.position = arrTransformRespawn[i].position;
                botController.arrActiveBots[i].rigidbody = botController.arrActiveBots[i].obj.GetComponent<Rigidbody>();


                
                botController.arrActiveBots[i].resetTime();

            }

            Debug.Log(i);

          

        }

        countLifeBots = 9;

    }

    public void FixedUpdate()
    {
        //camera.transform.position = new Vector3(player.mainObj.transform.position.x + 0.65f,
        //                                        player.mainObj.transform.position.y + 2.3f,
        //                                        player.mainObj.transform.position.z - 1.82f);

        //if (playerController.onGround)
        //{
            
        //    if (playerController._joystick.Horizontal != 0 || playerController._joystick.Vertical != 0)
        //    {
        //        player.arrAnimPerson[statistic.thisPerson].SetInteger("stage", 2);
        //    }
        //    else
        //        player.arrAnimPerson[statistic.thisPerson].SetInteger("stage", 1);
        //}
        //else
        //    player.arrAnimPerson[statistic.thisPerson].SetInteger("stage", 3);

        

       

    }

    //public void jumpPlayer()
    //{
    //    if(playerController.onGround)
    //        player.mainObj.GetComponent<Rigidbody>().AddForce(transform.up * 65f, ForceMode.Impulse);
    //}
}
