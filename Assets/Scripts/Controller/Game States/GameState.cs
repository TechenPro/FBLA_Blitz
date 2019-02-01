using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Abstract Game State for the GameController
public abstract class GameState : State
{
    protected GameController owner;

    protected virtual void Awake(){
        owner = GetComponent<GameController>();
    }

    protected override void AddListeners(){
        InputController.buttonEvent += OnFire;
    }

    protected override void RemoveListeners(){
        InputController.buttonEvent -= OnFire;
    }

    // Method to specify what listeners to use
    protected virtual void OnFire(object sender, InfoEventArgs<int> e){

    }
}
