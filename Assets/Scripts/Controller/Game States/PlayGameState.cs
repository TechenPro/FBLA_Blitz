using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameState : GameState
{
    public override void Enter(){
        Debug.Log("Entering Play");
        base.Enter();
        Debug.Log("Starting Timer");
        owner.gameTimer.ResumeTimer();
    }

    //Unused in current build
    // public override void Exit(){
    //     base.Exit();
    //     owner.PauseTimers();
    // }
}
