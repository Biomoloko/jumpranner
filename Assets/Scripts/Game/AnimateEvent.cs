using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateEvent : MonoBehaviour
{
    private static PlayerManager player; 
    public void startGame()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerManager>();
        }
        Main.statusGame = true;
    }

    public void destroyThisBlock()
    {
        player.ExitCollision();
        gameObject.SetActive(false);
    }
}
