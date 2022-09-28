using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BotState
{
    Hold,
    Move
}
public class BotLogic : MonoBehaviour
{
    [SerializeField] Animator anim;
    private IBotState botState;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        ChangeBotState(BotState.Hold);
    }

    void Update()
    {
        botState.UpdateAction();
        
    }

    public void ChangeBotState(BotState state)
    {
        switch (state)
        {
            case BotState.Hold:
                botState = GetComponent<BotHoldPosition>();
                break;
            case BotState.Move:
                var curState = GetComponent<BotMovingInGame>();
                botState = curState;
                anim.SetBool("IsMoving", true);
                break;
        }
    }

    
}
