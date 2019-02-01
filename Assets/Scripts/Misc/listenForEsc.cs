using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listenForEsc : MonoBehaviour
{
    //Listens for the Escape key and quits if it is pressed
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
