using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Sets the event Handler for the button events
    public static event EventHandler<InfoEventArgs<int>> buttonEvent;

    string[] _buttons = new string[] {"P1_A1", "P1_A2", "P1_A3", "P1_A4", "P1_Blitz", "P2_A1", "P2_A2", "P2_A3", "P2_A4", "P2_Blitz" };

    void Update(){
        
        // Loops through potential buttons to determine which ones are pressed in order to trigger the event
        for(int i = 0; i < 10; ++i){
            if(Input.GetButtonUp(_buttons[i])){
                if(buttonEvent != null)
                    buttonEvent(this, new InfoEventArgs<int>(i));
            }
        }
    }
}
