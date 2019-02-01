using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract State class
public abstract class State : MonoBehaviour
{
    // Default Method to make sure listeners are always added on entering the state
    public virtual void Enter(){
        AddListeners();
    }

    // Default methods to remove listeners no matter what cause the state to change
    public virtual void Exit(){
        RemoveListeners();
    }
    protected virtual void OnDestroy(){
        RemoveListeners();
    }

    // Abstract methods to be overridden with specific listener assignments
    protected virtual void AddListeners(){
    }

    protected virtual void RemoveListeners(){
    }
}
