using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGameState : GameState
{

    public override void Enter(){
        base.Enter();
        owner.LoadGameData();
        owner.gameTimer.StartTimer(owner.gameLength);
     }
}
