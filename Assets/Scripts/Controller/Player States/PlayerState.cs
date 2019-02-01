using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Same as GameState, but for a PlayerController
public abstract class PlayerState : State
{
    protected PlayerController owner;
    public Timer playerTimer {get{return owner.questionTimer;}}

    protected virtual void Awake(){
        owner = gameObject.GetComponent<PlayerController>();
    }

    protected override void AddListeners(){
        InputController.buttonEvent += OnFire;
    }

    protected override void RemoveListeners(){
        InputController.buttonEvent -= OnFire;
    }

    protected virtual void OnFire(object sender, InfoEventArgs<int> e){

    }
}
