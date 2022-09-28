using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Main : MonoBehaviour
{
    private static BotLogic[] BotList;
    private static bool _statusGame;
    public static bool statusGame 
    {
        get => _statusGame;
        set
        {
            _statusGame = value;
            if (value == true)
            {
                foreach (var bot in BotList)
                {
                    bot.ChangeBotState(BotState.Move);
                }
            }
            else
            {
                foreach (var bot in BotList)
                {
                    bot.ChangeBotState(BotState.Hold);
                }
            }
        }
    }
    private void Awake()
    {
        BotList = FindObjectsOfType<BotLogic>();
        Debug.Log(BotList.Length);
    }

}
