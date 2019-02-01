using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // Publicly accessable property to access the state machine's current state
    public virtual State CurrentState {
        get {return _currentState;}
        set {Transition (value);}
    }
    // Protected values for the current state and a transition controller
    protected State _currentState;
    protected bool _inTransition;

    // Method to return the current state's script
    // Must be an inheriter of the State class
    public virtual T GetState<T> () where T : State {
        T target = GetComponent<T>();
        // Adds the state to the state machine
        if(target == null)
            target = gameObject.AddComponent<T>();
        return target;
    }

    // Switches the public state propterty
    public virtual void ChangeState<T> () where T : State {
        CurrentState = GetState<T>();
    }

    // Switches the protected state property and deactivates the previous state
    protected virtual void Transition (State value) {
        if (_currentState == value || _inTransition) return;

        _inTransition = true;

        if(_currentState != null) 
            _currentState.Exit();

        _currentState = value;

        if(_currentState != null)
            _currentState.Enter();

        _inTransition = false;
    }
}
