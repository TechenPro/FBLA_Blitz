using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    // Private to prevent interference
    private float _timeRemaining;
    private bool _isRunning;
    private Action _callback;
    
    #region Public Properties
    // Getters and Setters to access the values
    public string DisplayTime {
        // Returns only an int to be displayed
        get{return _timeRemaining.ToString("0.0");}
    }

    public float TimeRemaining {
        get{return _timeRemaining;}
    }
    #endregion

    // Constructor Methods
    public void Init(float length){
        _timeRemaining = length;
        _callback = new Action(StopTimer);
    }
    // Overloaded with the option of passing a callback function
    public void Init(float length, Action callback){
        _timeRemaining = length;
        _callback = callback;
    }

    #region Behavior Controlls
    // These all give controll of the Timer object to the parent
    public void StartTimer(float value){
        _timeRemaining = value;
        _isRunning = true;
    }

    public void StopTimer(){
        _isRunning = false;
    }

    public void ResumeTimer(){
        _isRunning = true;
    }
    #endregion

    // Update is called once per frame
    void Update(){
        if(_isRunning){
            _timeRemaining -= Time.deltaTime;
            if(_timeRemaining <= 0){
                _isRunning = false;
                _callback();
            }
        }
    }
}
